using System;
using Model.Flow;
using System.Reflection;
using System.Transactions;
using BLL.Notice;
using System.Data;

namespace BLL.Flow
{
    /// <summary>
    /// 流程引擎
    /// </summary>
    public class Engine
    {
        private readonly static Instance _instance = new Instance();
        private static readonly ActionNotice actionNotice = new ActionNotice();
        private static readonly Script.FinanceScript financeScript = new Script.FinanceScript();

        /// <summary>
        /// 流程流转(提交表单、修改流程)
        /// </summary>
        /// wangpf  16.08.30
        /// yaoy    16.09.08
        /// wangpf  16.09.13
        /// <param name="data"></param>
        public bool Transfer(FlowData data)
        {
            var result = true;
            var actionId = data.ActionId;

            // 获取行为节点
            var actionInfo = new BLL.Flow.Action().Get(actionId);

            // 获取方法的默认构造函数
            BLL.Flow.Script.FinanceScript reflectObj = new BLL.Flow.Script.FinanceScript();

            Type type = typeof(BLL.Flow.Script.FinanceScript);

            using (TransactionScope scope = new TransactionScope())
            {

                // 判断节点是否有保存数据的业务方法
                if (actionInfo.BusinessMethod != null)
                {
                    // 通过反射获取方法实例
                    MethodInfo method = type.GetMethod(actionInfo.BusinessMethod);
                    // 设置方法参数
                    object[] obj = new object[1];

                    // 保存字符串参数
                    // 打印合同方法
                    if (actionInfo.BusinessMethod == "SaveContrantData")
                    {
                        obj[0] = new BLL.Flow.Instance().GetData(data.InstanceId.Value, new { FinanceId = 0 }).FinanceId.ToString();
                    }
                    else
                    {
                        obj[0] = data.BusinessData;
                    }
                    // 动态调用方法
                    var resultObj = method.Invoke(reflectObj, obj);
                    ////调用通知模块
                    //result &= new BLL.Notice.Notice().SendNotice(data.InstanceId.Value, actionId);

                    //判断方法是否成功执行
                    if (!resultObj.Equals(result))
                    {
                        result = false;
                    }
                }

                // 流程流转
                result &= new BLL.Flow.Engine().Process(data);

                // 清空临时数据
                result &= new BLL.Flow.Instance().ModifyTempData(data.InstanceId.Value, string.Empty);

                // 流程流转后,选择是否发送通知
                var actionNotices = actionNotice.GetActionNotice(actionId);

                // 节点通知不为空,则需要发送节点通知
                if (actionNotices != null)
                {
                    string customerName = string.Empty;
                    DataTable dt = new DAL.Finance.ApplicantInfoMapper().FindApplicationByInstanceId(data.InstanceId.Value);
                    if (dt.Rows.Count > 0)
                    {
                        customerName =dt.Rows[0]["Name"].ToString();
                    }
                    // 有系统通知
                    if (actionNotices.SystemNotice) {
                        financeScript.SystemNotice(actionNotices, data.InstanceId.Value,customerName);
                    }

                    // 有邮件通知
                    if (actionNotices.EmailNotice)
                    {
                        financeScript.EamlNotice(actionNotices, data.InstanceId.Value, customerName);
                    }
                }

                if (result)
                {
                    scope.Complete();
                }
            }


            return result;
        }

        /// <summary>
        /// 发起流程
        /// </summary>
        /// yaoy    16.07.26
        /// <returns></returns>
        public int StartProcess()
        {
            var flowId = 1;
            var nodeId = new Node().GetDefault(flowId).NodeId;

            var instance = new InstanceInfo()
            {
                FlowId = flowId,
                StartUser = User.User.CurrentUserId,
                StartTime = DateTime.Now,
                Status = InstanceInfo.StatusEnum.正常,
            };

            if (_instance.Add(instance))
            {
                instance.CurrentNode = nodeId;
                instance.CurrentUser = User.User.CurrentUserId;
                instance.ProcessTime = DateTime.Now;
                instance.ProcessUser = User.User.CurrentUserId;
                instance.InstanceId = instance.InstanceId;

                _instance.Modify(instance);
            }

            return instance.InstanceId;
        }

        /// <summary>
        /// 控制流程实例的流转
        /// </summary>
        /// qiy     16.04.29
        /// yaoy    16.07.27 移除流程引擎中开始流程方法
        /// <param name="data">流程数据</param>
        /// <returns></returns>
        public bool Process(FlowData data)
        {
            var _action = new Action();
            InstanceInfo instance;

            ActionInfo action = _action.Get(data.ActionId);
            instance = _instance.Get(data.InstanceId.Value);
            IFindUser finduser = FindUser.CreateStrategy(action);

            instance.CurrentNode = action.Transfer;
            instance.CurrentUser = finduser.FindUser(data);
            instance.ProcessTime = DateTime.Now;
            instance.ProcessUser = User.User.CurrentUserId;

            if (action.Type == ActionInfo.TypeEnum.完成)
                instance.Status = InstanceInfo.StatusEnum.完成;
            else if (action.Type == ActionInfo.TypeEnum.终止)
                instance.Status = InstanceInfo.StatusEnum.终止;

            if (instance.Status != InstanceInfo.StatusEnum.正常)
                instance.EndTime = DateTime.Now;

            Log _log = new Log();

            _log.Add(new LogInfo
            {
                InstanceId = instance.InstanceId,
                NodeId = action.NodeId,
                ActionId = action.ActionId,
                ProcessUser = instance.ProcessUser,
                ProcessTime = instance.ProcessTime,
                InOpinion = data.InOpinion,
                ExOpinion = data.ExOpinion
            });

            return _instance.Modify(instance);
        }
    }
}

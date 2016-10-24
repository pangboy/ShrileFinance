using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Models.Flow;

namespace BLL.Flow
{
    public class RevokeUtil
    {
        /// <summary>
        /// 回退流程
        /// </summary>
        /// yaoy    16.09.13
        /// <param name="instanceId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool RevokeFlow(int instanceId, ref string message)
        {
            bool result = false;

            var userId = User.User.CurrentUserId;
            // 获取实例信息
            var instanceInfo = new Instance().Get(instanceId);
            // 获取最后一次记录流程日志信息
            var logList = new Log().GetTopByInstanceId(instanceId);
            // 最后一次日志记录信息
            var fistLogInfo = logList[0];

            // 倒数第二次,如果第一次处理流程，则只有一条记录
            var secondLogInfo = logList.Count == 2 ? logList[1] : logList[0];

            if (userId == fistLogInfo.ProcessUser)
            {
                var actionInfo = new Action().Get(fistLogInfo.ActionId);

                switch (actionInfo.Type)
                {
                    case ActionInfo.TypeEnum.发起:
                        result = true;
                        break;
                    case ActionInfo.TypeEnum.流转:
                        result = true;
                        break;
                    case ActionInfo.TypeEnum.完成:
                        message = "已完成的流程无法撤回！";
                        break;
                    case ActionInfo.TypeEnum.终止:
                        message = "已终止的流程无法撤回！";
                        break;
                    default:
                        break;
                }

                if (result)
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        instanceInfo.CurrentNode = fistLogInfo.NodeId;
                        instanceInfo.CurrentUser = userId;
                        instanceInfo.ProcessTime = secondLogInfo.ProcessTime;
                        instanceInfo.ProcessUser = secondLogInfo.ProcessUser;

                        result &= new Log().Remove(instanceId);
                        result &= new Instance().Modify(instanceInfo);

                        if (result)
                        {
                            scope.Complete();
                        }
                    }
                }
            }
            else
            {
                message = "流程已经被其他用户处理，无法撤回！";
            }

            return result;
        }
    }
}

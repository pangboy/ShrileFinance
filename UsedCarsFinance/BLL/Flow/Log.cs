using System.Collections.Generic;
using Model.Flow;
using Model.User;

namespace BLL.Flow
{
    public class Log
    {
        private static readonly DAL.Flow.LogMapper logMapper = new DAL.Flow.LogMapper();

        /// <summary>
        /// 添加记录
        /// </summary>
        /// qiy     16.04.29
        /// <param name="value"></param>
        public void Add(LogInfo value)
        {
            logMapper.Insert(value);
        }

        /// <summary>
        /// 通过记录获取某节点的处理用户
        /// </summary>
        /// qiy     16.05.04
        /// <param name="instanceId">实例标识</param>
        /// <param name="nodeId">节点标识</param>
        /// <returns></returns>
        public int GetUserByNode(int instanceId, int nodeId)
        {
            var logs = logMapper.FindByInstanceId(instanceId);

            var log = logs.FindLast(m => m.NodeId == nodeId);

            return log.ProcessUser;
        }

        /// <summary>
        /// 根据实例ID获取最后一次日志信息
        /// </summary>
        /// yaoy    16.08.30
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public List<LogInfo> GetTopByInstanceId(int instanceId)
        {
            return logMapper.FindTopByInstanceId(instanceId);
        }

        /// <summary>
        /// 根据实例id查找所有操作者
        /// </summary>
        /// yand    16.09.10
        /// <param name="instanceId">实例ID</param>
        /// <returns></returns>
        public List<LogInfo> GetListByInstanceId(int instanceId)
        {
            return logMapper.FindByInstanceId(instanceId);
        }
        /// <summary>
        /// 查找除当前用户处理该流程的所有人
        /// </summary>
        /// yand    16.09.11
        /// <param name="instanceId">实例ID</param>
        /// <param name="userId">当前操作者</param>
        /// <returns></returns>
        public List<LogInfo> GetListByUserId(int instanceId,int userId)
        {
            return logMapper.FindByUserId(instanceId,userId);
        }

        /// <summary>
        /// 获取审核意见列表
        /// </summary>
        /// yaoy    16.04.28
        /// qiy     16.04.28    修改
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public object GetOpinion(int instanceId)
        {
            UserInfo user = new BLL.User.User().CurrentUser();
            RoleInfo role = new BLL.User.Role().Get(user.RoleId);

            return new {
                ExOpinion = logMapper.FindExOpinion(instanceId),
                InOpinion = (role.Power <= 3) ? logMapper.FindInOpinion(instanceId) : null
            };
        }

        /// <summary>
        /// 删除日志记录中最后一次流程实例日志
        /// </summary>
        /// yaoy    16.09.13
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public bool Remove(int instanceId)
        {
            return logMapper.Delete(instanceId) > 0;
        }
    }
}

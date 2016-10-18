using System.Collections.Generic;
using Model.Flow;

namespace BLL.Flow
{
    public class Action
	{
		private readonly static DAL.Flow.ActionMapper actionMapper = new DAL.Flow.ActionMapper();

        /// <summary>
        /// 获取
        /// </summary>
        /// qiy     16.04.29
        /// <param name="actionId">行为标识</param>
        /// <returns></returns>
		public ActionInfo Get(int actionId)
		{
			return actionMapper.Find(actionId);
		}

        /// <summary>
        /// 获取节点下所有的行为
        /// </summary>
        /// qiy     16.04.29
        /// <param name="nodeId">节点标识</param>
        /// <returns></returns>
        public List<ActionInfo> GetByNode(int nodeId)
        {
            return actionMapper.FindByNode(nodeId);
        }
	}
}

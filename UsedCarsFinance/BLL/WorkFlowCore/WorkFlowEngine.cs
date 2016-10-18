using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL.WorkFlowCore
{
    public class WorkFlowEngine
    {
        public WorkFlowEngine(IProcess processClass)
        {
            this.WorkFlowEngineCore = new WorkFlowEngineCore(this.ProcessClass = processClass);
        }
        private IProcess ProcessClass { get; set; }
        private WorkFlowEngineCore WorkFlowEngineCore { get; set; }


        /// <summary>
        /// 发起流程
        /// </summary>
        /// wangpf  15.11.25
        /// <param name="workFlowId">流程ID</param>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public bool StartProcess(int workFlowId, int userId, string instanceData)
        {
            bool result = false;

            FlowAction action = this.WorkFlowEngineCore.GetStartAction(workFlowId);
            ToDoWorkInfo toDoWork = this.WorkFlowEngineCore.GetToDoWork((int)action.ID);
            this.WorkFlowEngineCore.IFindUserMechanism = new FindOnlyUser(toDoWork.nodeInfo.RoleId);
            result = this.WorkFlowEngineCore.Start(action, toDoWork, userId, instanceData);

            return result;
        }
        /// <summary>
        /// 继续流程
        /// </summary>
        /// <param name="actionId">行为ID</param>
        /// <param name="instanceId">流程实例ID</param>
        /// <param name="processUserId">处理者ID</param>
        /// <param name="pointUserId">分配任务时指定的用户ID</param>
        /// <returns></returns>
        public bool ContinueProcess(int actionId, int instanceId, int processUserId, int pointUserId = 0)
        {
            ToDoWorkInfo toDoWork = this.WorkFlowEngineCore.GetToDoWork(actionId);
            switch (toDoWork.action.Type)
            {
                case (int)FlowFindType.角色:
                    this.WorkFlowEngineCore.IFindUserMechanism = new FindOnlyUser((int)toDoWork.nodeInfo.RoleId);
                    break;
                case (int)FlowFindType.分配:
                    this.WorkFlowEngineCore.IFindUserMechanism = new FindUserByPoint(pointUserId);
                    break;
                case (int)FlowFindType.记录:
                    this.WorkFlowEngineCore.IFindUserMechanism = new FindUserByFlowLog(instanceId, (int)toDoWork.action.ToNode);
                    break;
                case (int)FlowFindType.分配并处理过:
                    this.WorkFlowEngineCore.IFindUserMechanism = new FindUserDone(instanceId,actionId);
                    break;
            }
            return this.WorkFlowEngineCore.Submit(instanceId, toDoWork, processUserId);
        }

        public int GetMessageAlerts(int userId)
        {
            return (int)this.WorkFlowEngineCore.GetMessageAlerts(userId);
        }


    }
}

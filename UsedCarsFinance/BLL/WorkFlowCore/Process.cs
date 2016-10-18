using System;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Flow;
using DAL.User;

namespace BLL.WorkFlowCore
{
    public class Process : IProcess
    {
        /// <summary>
        /// 根据流程行为ID获取流程行为
        /// </summary>
        /// wangpf  15.11.24
        /// <param name="actionId">行为ID</param>
        /// <returns></returns>
        public FlowAction GetActionByActionID(int actionId)
        {
            return new ActionMapper().Find(actionId);
        }
        /// <summary>
        /// 根据流程开始节点ID获取流程开始行为
        /// </summary>
        /// wangpf  15.11.24
        /// <param name="nodeId">开始节点ID</param>
        /// <returns></returns>
        public FlowAction GetStartActionByStartNode(int nodeId)
        {
            return new ActionMapper().FindStartAction(nodeId);
        }

        /// <summary>
        /// 根据节点ID获取节点
        /// </summary>
        /// wangpf  15.11.24
        /// <param name="nodeId">节点ID</param>
        /// <returns></returns>
        public NodeInfo GetFlowNodeByNodeID(int nodeId)
        {
            return new NodeMapper().Find(nodeId);
        }
        /// <summary>
        /// 根据流程ID获取流程的开始节点
        /// </summary>
        /// wangpf  15.11.24
        /// <param name="workFlowId">流程ID</param>
        /// <returns></returns>
        public NodeInfo GetStartFlowNode(int workFlowId)
        {
            return new NodeMapper().FindStartNode(workFlowId);
        }

        /// <summary>
        /// 创建流程实例
        /// </summary>
        /// wangpf  15.11.24
        /// <param name="instance">流程实例实体</param>
        /// <returns></returns>
        public object NewFlowInstance(InstanceInfo1 instance)
        {
            return new InstanceMapper().Insert(instance);
        }

        public bool UpdateFlowInstance(InstanceInfo1 instance)
        {
            return new InstanceMapper().Update(instance);
        }

        /// <summary>
        /// 创建流程日志
        /// </summary>
        /// wangpf  15.11.24
        /// <param name="flowLog">流程日志实体</param>
        /// <returns></returns>
        public bool NewFlowLog(FlowLogInfo flowLog)
        {
            return new LogMapper().Insert(flowLog);
        }

        /// <summary>
        /// 创建审批意见
        /// </summary>
        /// wangpf  15.11.24
        /// <param name="auditOpinion">审批意见实体</param>
        /// <returns></returns>
        public object NewFlowAuditOpinion(AuditOpinionInfo auditOpinion)
        {
            return new AuditOpinionMapper().Insert(auditOpinion);
        }

        /// <summary>
        /// 获取流程的下一个任务
        /// </summary>
        /// wangpf  15.11.24
        /// <param name="actionId">行为ID</param>
        /// <returns></returns>
        public ToDoWorkInfo GetToDoWork(int actionId)
        {
            return new ToDoWorkMapper().Find(actionId);
        }


        public UserInfo GetUserByUserID(int userId)
        {
            return new UserMapper().Find(userId);
        }

        /// <summary>
        /// 结束流程实例
        /// </summary>
        /// <param name="instance">流程实例实体</param>
        /// <returns></returns>
        public bool EndFlowInstance(InstanceInfo1 instance)
        {
            return new InstanceMapper().End(instance);
        }

        /// <summary>
        /// 新建节点消息通知
        /// </summary>
        /// wangpf  15.12.03
        /// <param name="nodeMessage">节点消息实体</param>
        /// <returns></returns>
        public bool NewMessageAlerts(NodeMessageInfo nodeMessage)
        {
            return new NodeMessageMapper().Insert(nodeMessage) > 0;
        }
        /// <summary>
        /// 处理节点消息通知,更改状态为已查阅
        /// </summary>
        /// wangpf  15.12.03
        /// <param name="nodeId">要处理的消息节点ID</param>
        /// <param name="userId">要处理的用户ID</param>
        /// <returns></returns>
        public bool DealMessageAlerts(int nodeId, int userId)
        {
            return new NodeMessageMapper().Update(nodeId, userId);
        }


        public object GetMessageAlerts(int userId)
        {
            return new NodeMessageMapper().GetNodeMessage(userId);
        }
    }
}

using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.WorkFlowCore
{
    public interface IProcess
    {
        /// <summary>
        /// 根据流程行为ID获取流程行为
        /// </summary>
        /// <param name="actionId">行为ID</param>
        /// <returns></returns>
        FlowAction GetActionByActionID(int actionId);
        /// <summary>
        /// 根据流程开始节点获取流程发起行为
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        FlowAction GetStartActionByStartNode(int nodeId);

        /// <summary>
        /// 根据节点ID获取节点信息
        /// </summary>
        /// <param name="nodeId">节点ID</param>
        /// <returns></returns>
        NodeInfo GetFlowNodeByNodeID(int nodeId);
        /// <summary>
        /// 根据流程ID获取开始节点
        /// </summary>
        /// <param name="workFlowId">流程ID</param>
        /// <returns></returns>
        NodeInfo GetStartFlowNode(int workFlowId);

        /// <summary>
        /// 创建流程实例
        /// </summary>
        /// <param name="instance">流程实例实体</param>
        /// <returns></returns>
        object NewFlowInstance(InstanceInfo1 instance);
        /// <summary>
        /// 更新流程实例
        /// </summary>
        /// <param name="instance">流程实例实体</param>
        /// <returns></returns>
        bool UpdateFlowInstance(InstanceInfo1 instance);

        /// <summary>
        /// 结束流程实例
        /// </summary>
        /// <param name="instance">流程实例实体</param>
        /// <returns></returns>
        bool EndFlowInstance(InstanceInfo1 instance);
        /// <summary>
        /// 新建流程日志
        /// </summary>
        /// <param name="flowLog">流程日志实体</param>
        /// <returns></returns>
        bool NewFlowLog(FlowLogInfo flowLog);

        /// <summary>
        /// 新建流程审批意见
        /// </summary>
        /// <param name="auditOpinion">审批意见实体</param>
        /// <returns></returns>
        object NewFlowAuditOpinion(AuditOpinionInfo auditOpinion);

        /// <summary>
        /// 获取流程下一个任务
        /// </summary>
        /// <param name="actionId">行为id</param>
        /// <returns></returns>
        ToDoWorkInfo GetToDoWork(int actionId);

        /// <summary>
        /// 根据用户ID获取用户信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        UserInfo GetUserByUserID(int userId);

        /// <summary>
        /// 新建节点消息通知
        /// </summary>
        /// <param name="nodeMessage">节点消息实体</param>
        /// <returns></returns>
        bool NewMessageAlerts(NodeMessageInfo nodeMessage);

        /// <summary>
        /// 处理节点消息通知
        /// </summary>
        /// <param name="nodeId">要处理的节点ID</param>
        /// <param name="userId">处理者ID</param>
        /// <returns></returns>
        bool DealMessageAlerts(int nodeId,int userId);

        /// <summary>
        /// 获取节点消息通知信息
        /// </summary>
        /// <param name="userId">要获取的用户ID</param>
        /// <returns></returns>
        object GetMessageAlerts(int userId);
    }
}

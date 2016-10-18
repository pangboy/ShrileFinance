using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.WorkFlowCore
{
    public class WorkFlowEngineCore
    {
        public WorkFlowEngineCore(IProcess processClass)
        {
            this.ProcessClass = processClass;
        }
        private IProcess ProcessClass { get; set; }
        public IFindUserMechanism IFindUserMechanism { get; set; }

        /// <summary>
        /// 发起流程
        /// </summary>
        /// wangpf  15.11.24
        /// <param name="action">当前流程行为实体</param>
        /// <param name="toDoWork">下一个任务实体</param>
        /// <param name="processUserId">当前用户ID</param>
        /// <param name="instanceData">关联的数据</param>
        /// <returns></returns>
        public bool Start(FlowAction action, ToDoWorkInfo toDoWork, int processUserId, string instanceData)
        {
            bool result = true;
            //1.新建流程实例
            InstanceInfo1 instance = new InstanceInfo1()
            {
                WorkFlowId = toDoWork.nodeInfo.FlowId,
                ProcessUser = processUserId,
                ProcessTime = DateTime.Now,
                StartUser = processUserId,
                StartTime = DateTime.Now,
                Status = (byte)FlowStatus.流转
            };
            int instanceId = (int)this.ProcessClass.NewFlowInstance(instance);
            //2.1 下一个处理者ID
            var nextUserId = this.IFindUserMechanism.FindUser();
            //3.更新流程实例
            result &= this.ContinueProcess(toDoWork, instanceId, nextUserId, processUserId);
            //4.节点通知处理
            result &= NewNodeMessage((int)toDoWork.action.ToNode,nextUserId,"",1);
            //5.记录流程日志
            string content = string.Format("用户" + this.ProcessClass.GetUserByUserID(processUserId).Username + "发起了流程");
            result &= NewFlowLog(instanceId, (int)toDoWork.action.Node, (int)toDoWork.action.ID, processUserId, content);

            return result;
        }

        /// <summary>
        /// 审批流程
        /// </summary>
        /// wangpf  15.11.25
        /// <param name="instanceId">流程实例ID</param>
        /// <param name="toDoWork">下一个任务</param>
        /// <param name="processUserId">处理者ID</param>
        /// <returns></returns>
        public bool Submit(int instanceId, ToDoWorkInfo toDoWork, int processUserId)
        {
            bool result = true;
            string content = string.Empty;
            int nextUserId;
            //1.判断任务节点类型(流转节点,结束节点等)
            switch (toDoWork.nodeInfo.Type)
            {
                case (int)NodeType.发起节点:
                    //查找下一个操作者
                    nextUserId = this.IFindUserMechanism.FindUser();
                    //流转流程
                    result &= this.ContinueProcess(toDoWork, instanceId, nextUserId, processUserId);
                    //处理通知消息
                    result &= DealNodeMessage((int)toDoWork.action.Node, processUserId, (int)toDoWork.action.ToNode, nextUserId, "", 1);
                    //日志内容
                    content = string.Format("用户" + this.ProcessClass.GetUserByUserID(processUserId).Username + "执行了流程");
                    break;
                case (int)NodeType.流转节点:
                    //查找下一个操作者
                    nextUserId = this.IFindUserMechanism.FindUser();
                    //流转流程
                    result &= this.ContinueProcess(toDoWork, instanceId, nextUserId, processUserId);
                    //处理通知消息
                    result &= DealNodeMessage((int)toDoWork.action.Node,processUserId,(int)toDoWork.action.ToNode,nextUserId,"",1);
                    //日志内容
                    content = string.Format("用户" + this.ProcessClass.GetUserByUserID(processUserId).Username + "执行了流程");
                    break;
                case (int)NodeType.结束节点:
                    //结束流程
                    result &= this.EndProcess(toDoWork, instanceId, processUserId);
                    //处理消息通知
                    result &= this.ProcessClass.DealMessageAlerts((int)toDoWork.action.Node,processUserId);
                    //日志内容
                    content = string.Format("用户" + this.ProcessClass.GetUserByUserID(processUserId).Username + "结束了流程");
                    break;
                case (int)NodeType.中止节点:
                    //中止流程
                    result &= this.StopProcess(toDoWork, instanceId, processUserId);
                    //处理消息通知
                    result &= this.ProcessClass.DealMessageAlerts((int)toDoWork.action.Node, processUserId);
                    //日志内容
                    content = string.Format("用户" + this.ProcessClass.GetUserByUserID(processUserId).Username + "中止了流程");
                    break;
            };
            //2.记录流程日志
            result &= NewFlowLog(instanceId, (int)toDoWork.action.Node, (int)toDoWork.action.ID, processUserId, content);

            return result;
        }

        /// <summary>
        /// 新建流程日志
        /// </summary>
        /// <param name="instanceId">流程实例ID</param>
        /// <param name="nodeId">当前操作节点ID</param>
        /// <param name="actionId">当前行为ID</param>
        /// <param name="processUserId">当前处理者ID</param>
        /// <param name="content">日志内容</param>
        /// <returns></returns>
        private bool NewFlowLog(int instanceId, int nodeId, int actionId, int processUserId, string content)
        {
            FlowLogInfo flowLog = new FlowLogInfo()
            {
                InstanceId = instanceId,
                NodeId = nodeId,
                ActionId = actionId,
                ProcessUser = processUserId,
                ProcessTime = DateTime.Now,
                Content = content
            };
            return this.ProcessClass.NewFlowLog(flowLog);
        }


        public object GetMessageAlerts(int userId) 
        {
            return this.ProcessClass.GetMessageAlerts(userId);
        }

        /// <summary>
        /// 获取开始行为(用于发起流程前没有行为)
        /// </summary>
        /// wangpf  15.11.26
        /// <param name="workFlowId"></param>
        /// <returns></returns>
        public FlowAction GetStartAction(int workFlowId)
        {
            var startNode = this.ProcessClass.GetStartFlowNode(workFlowId);
            var startAction = this.ProcessClass.GetStartActionByStartNode((int)startNode.NodeId);
            return startAction;
        }
        /// <summary>
        /// 根据行为ID获取下一步任务
        /// </summary>
        /// wangpf  15.11.26
        /// <param name="actionId">行为ID</param>
        /// <returns></returns>
        public ToDoWorkInfo GetToDoWork(int actionId)
        {
            ToDoWorkInfo toDoWork = this.ProcessClass.GetToDoWork(actionId);
            return toDoWork;
        }

        /// <summary>
        /// 结束流程流转
        /// </summary>
        /// wangpf  15.11.25
        /// <param name="toDoWork">下一个任务实体</param>
        /// <param name="instanceId">流程实例ID</param>
        /// <param name="currentUserId">当前用户ID</param>
        /// <returns></returns>
        private bool EndProcess(ToDoWorkInfo toDoWork, int instanceId, int currentUserId)
        {
            //更新流程为结束
            InstanceInfo1 instance = new InstanceInfo1()
            {
                InstanceId = instanceId,
                CurrentNode = (int)toDoWork.nodeInfo.NodeId,
                CurrentUser = null,
                ProcessUser = currentUserId,
                ProcessTime = DateTime.Now,
                EndTime = DateTime.Now,
                Status = (byte)FlowStatus.结束
            };

            return this.ProcessClass.EndFlowInstance(instance);
        }
        /// <summary>
        /// 中止流程流转
        /// </summary>
        /// wangpf  15.11.25
        /// <param name="toDoWork">下一个任务实体</param>
        /// <param name="instanceId">流程实例ID</param>
        /// <param name="currentUserId">当前用户ID</param>
        /// <returns></returns>
        private bool StopProcess(ToDoWorkInfo toDoWork, int instanceId, int currentUserId)
        {
            //更新流程为中止
            InstanceInfo1 instance = new InstanceInfo1()
            {
                InstanceId = instanceId,
                CurrentNode = (int)toDoWork.nodeInfo.NodeId,
                CurrentUser = null,
                ProcessUser = currentUserId,
                ProcessTime = DateTime.Now,
                EndTime = DateTime.Now,
                Status = (byte)FlowStatus.中止
            };

            return this.ProcessClass.EndFlowInstance(instance);
        }
        /// <summary>
        /// 继续流程流转
        /// </summary> 
        /// wangpf  15.11.25
        /// <param name="toDoWork">下一个任务实体</param>
        /// <param name="instanceId">流程实例ID</param>
        /// <param name="nextUserId">下一个处理用户ID</param>
        /// <param name="currentUserId">当前用户ID</param>
        /// <returns></returns>
        private bool ContinueProcess(ToDoWorkInfo toDoWork, int instanceId, int nextUserId, int currentUserId)
        {
            //更新流程
            InstanceInfo1 instance = new InstanceInfo1()
            {
                InstanceId = instanceId,
                CurrentNode = (int)toDoWork.nodeInfo.NodeId,
                CurrentUser = nextUserId,
                ProcessUser = currentUserId,
                ProcessTime = DateTime.Now
            };

            return this.ProcessClass.UpdateFlowInstance(instance);
        }

        /// <summary>
        /// 新建节点消息通知
        /// </summary>
        /// wangpf  15.12.03
        /// <param name="nodeId">节点ID</param>
        /// <param name="nextUserId">通知者ID</param>
        /// <param name="content">通知内容</param>
        /// <param name="type">通知类型</param>
        /// <returns></returns>
        private bool NewNodeMessage(int nodeId, int nextUserId, string content, Byte type)
        {
            NodeMessageInfo nodeMessage = new NodeMessageInfo()
            {
                nodeId = nodeId,
                userId = nextUserId,
                Content = content,
                Type = type,
                IsRead = false
            };
            return this.ProcessClass.NewMessageAlerts(nodeMessage);
        }
        /// <summary>
        /// 处理节点消息通知
        /// </summary>
        /// wangpf  15.12.03
        /// <param name="currentNodeId">要处理的当前节点ID</param>
        /// <param name="currentUserId">要处理的当前用户ID</param>
        /// <param name="nextNodeId">要新建的下一个节点ID</param>
        /// <param name="nextUserId">要新建的下一个用户ID</param>
        /// <param name="content">要新建的节点内容</param>
        /// <param name="type">要新建的节点类型</param>
        /// <returns></returns>
        private bool DealNodeMessage(int currentNodeId,int currentUserId,int nextNodeId, int nextUserId, string content, Byte type) 
        {
            bool result = true;
           //1.处理自己的消息通知为已读
            result &= this.ProcessClass.DealMessageAlerts(currentNodeId,currentUserId);
            //2.新建下一个用户的消息通知
            result &= NewNodeMessage(nextNodeId,nextUserId,content,type);

            return result;
        }
    }
}

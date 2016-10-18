using DAL.Flow;
using DAL.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.WorkFlowCore
{
    /// <summary>
    /// 寻找角色下的唯一用户,多用于员工提交给主管部门
    /// </summary>
    /// wangpf  15.11.25
    public class FindOnlyUser:IFindUserMechanism
    {
        public FindOnlyUser(int RoleId)
        {
            this.roleId = RoleId;
        }
        public int roleId { get; set; }
        public int FindUser()
        {
            return new UserMapper().FindOnlyByRoleID(this.roleId);
        }
    }
    /// <summary>
    /// 根据流程日志,找到上一步操作的用户
    /// </summary>
    /// wangpf  15.11.25
    public class FindUserByFlowLog : IFindUserMechanism
    {
        public FindUserByFlowLog() { }
        public FindUserByFlowLog(int InstanceId,int NodeId)
        {
            this.instanceId = InstanceId;
            this.nodeId = NodeId;
        }
        public int instanceId { get; set; }
        public int nodeId { get; set; }
        public int FindUser()
        {
            return new LogMapper().FindUserByFlowLog(instanceId,nodeId);
        }
    }

    /// <summary>
    /// 通过分配的用户ID寻找指定的用户
    /// </summary>
    /// wangpf  15.11.26
    public class FindUserByPoint : IFindUserMechanism
    {
        public FindUserByPoint(int UserId)
        {
            this.userId = UserId;
        }
        public int userId { get; set; }
        public int FindUser()
        {
            return this.userId;
        }
    }
    /// <summary>
    /// 寻找处理过该任务的上一个操作者
    /// </summary>
    public class FindUserDone : IFindUserMechanism
    {
        public FindUserDone(int InstanceId,int ActionId)
        {
            this.instanceId = InstanceId;
            this.actionId = ActionId;
            this.nodeId = this.FindNodeByToNode();
        } 
        public int nodeId { get; set; }
        public int instanceId { get; set; }
        public int actionId { get; set; }

        //1.根据当前所在节点信息找寻从哪个节点流转过来的
        public int FindNodeByToNode() 
        {
            return new NodeMapper().FindNodeByActionId(this.actionId);
        }

        public int FindUser() 
        {
            FindUserByFlowLog f = new FindUserByFlowLog(this.instanceId,this.nodeId);
            return f.FindUser(); 
        }
    }
    /// <summary>
    /// 寻找处理过改任务的唯一用户
    /// </summary>
    public class FindUser4 : IFindUserMechanism
    {
        public int FindUser()
        {
           
            throw new NotImplementedException();
        }
    }
}

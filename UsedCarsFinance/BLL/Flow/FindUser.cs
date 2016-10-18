using Model.Flow;
using System;

namespace BLL.Flow
{
    /// <summary>
    /// 寻找用户接口 - 策略模式
    /// </summary>
    /// qiy     16.04.29
    public interface IFindUser
    {
        int? FindUser(object value);
    }

    /// <summary>
    /// 创建策略
    /// </summary>
    /// qiy     16.04.29
    public class FindUser
    {
        public static IFindUser CreateStrategy(ActionInfo action)
        {
            IFindUser strategy;

            switch (action.AllocationType)
            {
                case ActionInfo.AllocationEnum.角色:
                    strategy = new FindByRole();
                    break;
                case ActionInfo.AllocationEnum.指定:
                    strategy = new FindUserBySpecify();
                    break;
                case ActionInfo.AllocationEnum.记录:
                    strategy = new FindUserByLog();
                    break;
                case ActionInfo.AllocationEnum.不指定:
                    strategy = new NoAllocation();
                    break;
                case ActionInfo.AllocationEnum.渠道经理:
                    strategy = new FIndPartner();
                    break;
                case ActionInfo.AllocationEnum.发起者:
                    strategy = new FindStarter();
                    break;
                case ActionInfo.AllocationEnum.自己:
                    strategy = new FindSelf();
                    break;
                default:
                    throw new ApplicationException("创建寻找用户策略失败!");
            }

            return strategy;
        }
    }


    /// <summary>
    /// 寻找指定的用户
    /// </summary>
    /// qiy     16.04.29
    public class FindUserBySpecify : IFindUser
    {
        public int? FindUser(object value)
        {
            return ((FlowData)value).FindUserValue;
        }
    }
    /// <summary>
    /// 按流程记录寻找用户
    /// </summary>
    /// qiy     16.05.04
    public class FindUserByLog : IFindUser
    {
        public int? FindUser(object value)
        {
            var _log = new Log();
            var _action = new Action();

            var data = (FlowData)value;

            var action = _action.Get(data.ActionId);

            return _log.GetUserByNode(data.InstanceId.Value, action.Transfer.Value);
        }
    }
    /// <summary>
    /// 不分配
    /// </summary>
    /// qiy     16.04.29
    public class NoAllocation : IFindUser
    {
        public int? FindUser(object value)
        {
            return null;
        }
    }
    /// <summary>
    /// 寻找合作商下的首个渠道经理
    /// </summary>
    /// qiy     16.04.29
    public class FIndPartner : IFindUser
    {
        public int? FindUser(object value)
        {
            var _partner = new Credit.Account();

            var creditId = _partner.Get(User.User.CurrentUserId).CreditId;
            var accounts = _partner.GetAll(creditId);
            var manager = accounts.Find(m => m.RoleId == 9 && m.Status == Model.User.UserInfo.StatusEnum.正常);

            if (manager == null)
                throw new ApplicationException("该合作商没有渠道经理，任务无法分配。");

            return manager.UserId;
        }
    }
    /// <summary>
    /// 寻找发起者
    /// </summary>
    /// qiy     16.05.04
    public class FindStarter : IFindUser
    {
        public int? FindUser(object value)
        {
            var _instance = new Instance();
            var data = (FlowData)value;

            var instance = _instance.Get(data.InstanceId.Value);

            return instance.StartUser;
        }
    }

    /// <summary>
    /// 获取当前用户
    /// </summary>
    /// qiy     16.05.03
    public class FindSelf : IFindUser
    {
        public int? FindUser(object value)
        {
            return User.User.CurrentUserId;
        }
    }

    /// <summary>
    /// 根据授信主体的分配策略寻找
    /// </summary>
    /// qiy     16.05.31
    public class FindByRole : IFindUser
    {
        public int? FindUser(object value)
        {
            var data = (FlowData)value;

            var transfer = new Action().Get(data.ActionId).Transfer;
            var roldId = new Node().Get(transfer.Value).RoleId;

            var financeId = new Instance().GetData(data.InstanceId.Value, new { FinanceId = 0 }).FinanceId;
            var creditId = new Finance.Finance().Get(financeId).CreateOf;
            var processUser = new Credit.Credit().Get(creditId).ProcessUser;

            int? userId;
            switch (roldId)
            {
                case 3:
                    userId = processUser.User1;
                    break;
                case 4:
                    userId = processUser.User2;
                    break;
                case 5:
                    userId = processUser.User3;
                    break;
                case 10:
                    userId = processUser.User4;
                    break;
                case 6:
                    userId = processUser.User5;
                    break;
                default:
                    userId = null;
                    break;
            }

            return userId;
        }
    }
}

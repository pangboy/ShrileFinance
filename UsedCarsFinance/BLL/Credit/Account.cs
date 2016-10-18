using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Credit;
using System.Transactions;
using System.Data;
using System.Collections.Specialized;
using Model;

namespace BLL.Credit
{
    public class Account
    {
        private readonly static BLL.User.User _user = new User.User();
        private readonly static DAL.Credit.AccountMapper accountMapper = new DAL.Credit.AccountMapper();

        /// <summary>
        /// 获取
        /// </summary>
        /// qiy		16.03.30
        /// <param name="userId">用户标识</param>
        /// <returns></returns>
        public AccountInfo Get(int userId)
        {
            AccountInfo account = accountMapper.Find(userId);

            if (account != null)
                Model.ConvertHelper.Copy(_user.GetUser(userId), account);

            return account;
        }
        /// <summary>
        /// 获取所有渠道帐号
        /// </summary>
        /// qiy     16.04.28
        /// <param name="creditId">授信标识</param>
        /// <returns></returns>
        public List<AccountInfo> GetAll(int creditId)
        {
            List<AccountInfo> results = new List<AccountInfo>();
            List<AccountInfo> accounts = accountMapper.FindByCredit(creditId);

            foreach (var item in accounts)
            {
                var account = Get(item.UserId);

                results.Add(account);
            }

            return results;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// qiy		16.03.30
        /// <param name="value">值</param>
        /// <returns></returns>
        public bool Add(AccountInfo value)
        {
            bool result = true;

            using (TransactionScope scope = new TransactionScope())
            {
                result &= _user.Add(value);

                if (result)
                    accountMapper.Insert(value);

                if (result)
                    scope.Complete();
            }

            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// qiy		16.03.30
        /// <param name="value">值</param>
        /// <returns></returns>
        public bool Modify(AccountInfo value)
        {
            bool result = true;

            using (TransactionScope scope = new TransactionScope())
            {
                result &= _user.Modify(value);
                result &= accountMapper.Delete(value.UserId) > 0;

                if (result)
                    accountMapper.Insert(value);

                if (result)
                    scope.Complete();
            }

            return result;
        }

        /// <summary>
        /// 获取授信主体账号信息列表
        /// </summary>
        /// yaoy    16.03.30
        /// <param name="data"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public DataTable List(Pagination page, NameValueCollection data)
        {
            return accountMapper.List(page, data);
        }
    }
}

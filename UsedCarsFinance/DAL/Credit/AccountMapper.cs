using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using Model;
using Model.Credit;

namespace DAL.Credit
{
    public class AccountMapper : AbstractMapper<AccountInfo>
    {
        /// <summary>
        /// 查找
        /// </summary>
        /// qiy		16.03.30
        /// <param name="userId">用户标识</param>
        /// <returns></returns>
        public AccountInfo Find(int userId)
        {
            string findStatement =
                "SELECT UserId, CreditId FROM CRET_Account WHERE UserId = @ID";

            return AbstractFind(findStatement, userId);
        }

        /// <summary>
        /// 根据授信主体查找帐号
        /// </summary>
        /// qiy     16.04.28
        /// <param name="creditId">授信标识</param>
        /// <returns></returns>
        public List<AccountInfo> FindByCredit(int creditId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT UserId AS UI_ID, CreditId FROM CRET_Account WHERE CreditId = @CreditId
            ");
            DHelper.AddParameter(comm, "@CreditId", SqlDbType.Int, creditId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return LoadAll(dt.Rows);
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// qiy		16.03.30
        /// <param name="value">值</param>
        public void Insert(AccountInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
				INSERT INTO CRET_Account (UserId, CreditId) 
				VALUES (@UserId, @CreditId)
			");
            DHelper.AddParameter(comm, "@UserId", SqlDbType.Int, value.UserId);
            DHelper.AddParameter(comm, "@CreditId", SqlDbType.Int, value.CreditId);

            DHelper.ExecuteNonQuery(comm);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// yaoy    16.08.04
        /// <param name="userId"></param>
        /// <returns></returns>
        public int Delete(int userId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
				DELETE FROM CRET_Account WHERE UserId = @UserId
			");
            DHelper.AddParameter(comm, "@UserId", SqlDbType.Int, userId);

            return DHelper.ExecuteNonQuery(comm);
        }
        /// <summary>
        /// 获取授信信息列表
        /// </summary>
        /// yaoy    16.03.30
        /// <param name="data"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public DataTable List(Pagination page, NameValueCollection data)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT temp.rownum,ui.*,cci.Name,cci.CreditId,dbo.Dic(2, ui.Status) AS StatusDesc,rol.Name AS RoleName FROM USER_UserInfo AS ui
                    RIGHT JOIN (
                        SELECT TOP(@End) ROW_NUMBER() OVER(ORDER BY UserId DESC) AS rownum, UserId, CreditId FROM CRET_Account AS ca
                        WHERE (@CreditId IS NULL OR ca.CreditId = @CreditId)
                    ) AS temp ON temp.UserId = ui.UI_ID
                    LEFT JOIN CRET_CreditInfo AS cci ON cci.CreditId = temp.CreditId
                    LEFT JOIN USER_Relation AS ur ON ur.UserId = ui.UI_ID
                    LEFT JOIN USER_Role AS rol ON rol.UR_ID = ur.RoleId
                WHERE temp.rownum> @Begin ORDER BY cci.CreditId DESC
            ");

            DHelper.AddInParameter(comm, "@CreditId", SqlDbType.Int, data["CreditId"]);
            DHelper.AddInParameter(comm, "@Begin", SqlDbType.Int, page.Begin);
            DHelper.AddInParameter(comm, "@End", SqlDbType.Int, page.End);

            SqlCommand commPage = DHelper.GetSqlCommand(@"
                SELECT COUNT(UserId) FROM CRET_Account
                WHERE (@CreditId IS NULL OR CreditId = @CreditId)
            ");
            DHelper.AddInParameter(commPage, "@CreditId", SqlDbType.Int, data["CreditId"]);

            page.Total = Convert.ToInt32(DHelper.ExecuteScalar(commPage));

            return DHelper.ExecuteDataTable(comm);
        }
    }
}

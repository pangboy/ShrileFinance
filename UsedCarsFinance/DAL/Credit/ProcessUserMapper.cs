using System.Data;
using System.Data.SqlClient;
using Models.Credit;

namespace DAL.Credit
{
    public class ProcessUserMapper : AbstractMapper<ProcessUserInfo>
    {
        /// <summary>
        /// 查找
        /// </summary>
        /// qiy		16.05.31
        /// <param name="id">标识</param>
        /// <returns></returns>
        public ProcessUserInfo Find(int id)
        {
            string findStatement =
                "SELECT CreditId, User1, User2, User3, User4, User5, User6 FROM CRET_ProcessUser WHERE CreditId = @ID";

            return AbstractFind(findStatement, id);
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// qiy		16.05.31
        /// <param name="value">值</param>
        public void Insert(ProcessUserInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
				INSERT INTO CRET_ProcessUser (CreditId, User1, User2, User3, User4, User5, User6) 
				VALUES (@CreditId, @User1, @User2, @User3, @User4, @User5, @User6)
			");
            DHelper.AddParameter(comm, "@CreditId", SqlDbType.Int, value.CreditId);
            DHelper.AddParameter(comm, "@User1", SqlDbType.Int, value.User1);
            DHelper.AddParameter(comm, "@User2", SqlDbType.Int, value.User2);
            DHelper.AddParameter(comm, "@User3", SqlDbType.Int, value.User3);
            DHelper.AddParameter(comm, "@User4", SqlDbType.Int, value.User4);
            DHelper.AddParameter(comm, "@User5", SqlDbType.Int, value.User5);
            DHelper.AddParameter(comm, "@User6", SqlDbType.Int, value.User6);

            DHelper.ExecuteNonQuery(comm);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// qiy		16.05.31
        /// <param name="value">值</param>
        /// <returns></returns>
        public int Update(ProcessUserInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
				UPDATE CRET_ProcessUser SET 
					User1 = @User1,
					User2 = @User2,
					User3 = @User3,
					User4 = @User4,
					User5 = @User5
				WHERE CreditId = @CreditId
			");
            DHelper.AddParameter(comm, "@CreditId", SqlDbType.Int, value.CreditId);

            DHelper.AddParameter(comm, "@User1", SqlDbType.Int, value.User1);
            DHelper.AddParameter(comm, "@User2", SqlDbType.Int, value.User2);
            DHelper.AddParameter(comm, "@User3", SqlDbType.Int, value.User3);
            DHelper.AddParameter(comm, "@User4", SqlDbType.Int, value.User4);
            DHelper.AddParameter(comm, "@User5", SqlDbType.Int, value.User5);
            //DHelper.AddParameter(comm, "@User6", SqlDbType.Int, value.User6);

            return DHelper.ExecuteNonQuery(comm);
        }
    }
}

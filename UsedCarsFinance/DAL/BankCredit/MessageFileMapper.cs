using Models.BankCredit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.BankCredit
{
    public class MessageFileMapper: BankAbstractMapper<MessageFileInfo>
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// yaoy    16.05.26
        /// <param name="messageFileTypeId"></param>
        /// <returns></returns>
        public List<MessageFileInfo> List(int messageFileTypeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_MessageFile WHERE MFT_ID = @MessageFileTypeId
            ");
            DHelper.AddInParameter(comm, "@MessageFileTypeId", SqlDbType.Int, messageFileTypeId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return dt.Rows.Count > 0 ? LoadAll(dt.Rows) : null;
        }


        /// <summary>
        /// 实体
        /// </summary>
        /// yaoy    16.05.26
        /// <param name="messageFileId"></param>
        /// <returns></returns>
        public MessageFileInfo Find(int messageFileId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_MessageFile WHERE BMF_ID = @MessageFileId
            ");
            DHelper.AddInParameter(comm, "@MessageFileId", SqlDbType.Int, messageFileId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return dt.Rows.Count > 0 ? Load(dt.Rows[0]) : null;

        }
    }
}

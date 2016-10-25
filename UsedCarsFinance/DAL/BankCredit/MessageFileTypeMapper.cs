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
    public class MessageFileTypeMapper: BankAbstractMapper<MessageFileTypeInfo>
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// yaoy    16.05.26
        /// <returns></returns>
        public List<MessageFileTypeInfo> List()
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_MessageFileType
            ");

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return dt.Rows.Count > 0 ? LoadAll(dt.Rows) : null;
        }

        /// <summary>
        /// 实体
        /// </summary>
        /// yaoy    16.05.26
        /// <param name="messageFileTypeId"></param>
        /// <returns></returns>
        public MessageFileTypeInfo Find(int messageFileTypeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_MessageFileType WHERE MFT_ID = @MessageFileTypeId
            ");

            DHelper.AddInParameter(comm, "@MessageFileTypeId", SqlDbType.Int, messageFileTypeId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return dt.Rows.Count > 0 ? Load(dt.Rows[0]) : null;
        }

        /// <summary>
        /// 根据报文类型获取文件类型
        /// </summary>
        /// yaoy    16.09.28
        /// <param name="messageTypeId"></param>
        /// <returns></returns>
        public MessageFileTypeInfo FindByMessageTypeId(int messageTypeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT mft.* FROM BANK_MessageFileType mft
                LEFT JOIN BANK_MessageFile AS bmf ON mft.MFT_ID = bmf.MFT_ID
                LEFT JOIN BANK_MessageType AS bmt ON bmf.BMF_ID = bmt.BMF_ID
                WHERE bmt.BMT_ID = @MessageTypeId
            ");
            DHelper.AddInParameter(comm, "@MessageTypeId", SqlDbType.Int, messageTypeId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return dt.Rows.Count > 0 ? Load(dt.Rows[0]) : null;
        }
    }
}

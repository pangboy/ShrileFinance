using Models.BankCredit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace DAL.BankCredit
{
    public class MessageTypeMapper: BankAbstractMapper<MessageTypeInfo>
    {
        /// <summary>
        /// 通过文件种类ID获取列表
        /// </summary>
        /// yaoy    16.05.25
        /// <param name="messsageFileId"></param>
        /// <returns></returns>
        public List<MessageTypeInfo> List(int messageFileId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_MessageType WHERE BMF_ID = @MessageFileId
            ");
            DHelper.AddInParameter(comm, "@MessageFileId", SqlDbType.Int, messageFileId);

            return LoadAll(DHelper.ExecuteDataTable(comm).Rows);
        }

        /// <summary>
        /// 通过文件类型获取下拉框列表
        /// </summary>
        /// yaoy    16.07.06
        /// <param name="fileType"></param>
        /// <returns></returns>
        public List<ComboInfo> FindComListByFileType(int fileType)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT bmf.BMF_ID, bmf.FileName FROM BANK_MessageFileType AS mft
                    LEFT JOIN BANK_MessageFile AS bmf ON bmf.MFT_ID = mft.MFT_ID
                WHERE mft.FileType = @FileType AND bmf.BMF_ID IS NOT NULL
            ");
            DHelper.AddInParameter(comm, "@FileType", SqlDbType.Int, fileType);

            DataTable dt = DHelper.ExecuteDataTable(comm);
            List<ComboInfo> list = new List<ComboInfo>();
            foreach (DataRow dr in dt.Rows)
            {
                ComboInfo cbi = new ComboInfo(dr["BMF_ID"].ToString(), dr["FileName"].ToString());
                list.Add(cbi);
            }

            return list;
        }

        /// <summary>
        /// 通过文件种类ID获取下拉框列表
        /// </summary>
        /// yaoy    16.05.26
        /// <param name="fileId"></param>
        /// <returns></returns>
        public List<ComboInfo> FindComList(int fileId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT bmt.BMT_ID,bmt.Describe FROM BANK_MessageType AS bmt
                    LEFT JOIN BANK_ReportFiles AS brf ON brf.MessageFileID = bmt.BMF_ID
                WHERE brf.FileID = @FileId
            ");
            DHelper.AddInParameter(comm, "@FileId", SqlDbType.Int, fileId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            List<ComboInfo> list = new List<ComboInfo>();

            foreach (DataRow dr in dt.Rows)
            {
                ComboInfo cbi = new ComboInfo(dr["BMT_ID"].ToString(), dr["Describe"].ToString());

                list.Add(cbi);
            }

            return list;
        }

        /// <summary>
        /// 信息记录类型下拉框
        /// </summary>
        /// yand    16.07.11
        /// <param name="MessageTypeID">信息记录类型ID</param>
        /// <returns></returns>
        public List<ComboInfo> FindList(int MessageTypeID)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
            SELECT * FROM BANK_MessageType WHERE BMT_ID = @MessageTypeID
            ");
            DHelper.AddInParameter(comm, "@MessageTypeID", SqlDbType.Int, MessageTypeID);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            List<ComboInfo> list = new List<ComboInfo>();

            foreach (DataRow dr in dt.Rows)
            {
                ComboInfo cbi = new ComboInfo(dr["BMP_Code"].ToString(), dr["Describe"].ToString());

                list.Add(cbi);
            }

            return list;
        }

        /// <summary>
        /// 实体
        /// </summary>
        /// yaoy    16.05.26
        /// <param name="messageTypeId"></param>
        /// <returns></returns>
        public MessageTypeInfo Find(int messageTypeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_MessageType WHERE BMT_ID = @MessageTypeId
            ");

            DHelper.AddInParameter(comm, "@MessageTypeId", SqlDbType.Int, messageTypeId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return dt.Rows.Count > 0 ? Load(dt.Rows[0]) : null;
        }
    }
}

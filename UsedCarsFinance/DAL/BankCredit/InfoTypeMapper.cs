using Model;
using Model.BankCredit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL.BankCredit
{
    public class InfoTypeMapper: BankAbstractMapper<InfoTypeInfo>
    {
        /// <summary>
        /// 下拉框列表
        /// </summary>
        /// yaoy    16.05.26
        /// <param name="messageTypeId"></param>
        /// <returns></returns>
        public List<ComboInfo> GetComList(int messageTypeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_InfoType WHERE BMT_ID = @MessageTypeId
            ");
            DHelper.AddInParameter(comm, "@MessageTypeId", SqlDbType.Int, messageTypeId);

            DataTable dt = DHelper.ExecuteDataTable(comm);
            List<ComboInfo> list = new List<ComboInfo>();

            foreach (DataRow dr in dt.Rows)
            {
                ComboInfo cbi = new ComboInfo(dr["BIT_ID"].ToString(), dr["InfoName"].ToString());

                list.Add(cbi);
            }

            return list;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// yaoy    16.05.26
        /// <param name="messageTypeId"></param>
        /// <returns></returns>
        public List<InfoTypeInfo> List(int messageTypeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_InfoType WHERE BMT_ID = @MessageTypeId
            ");
            DHelper.AddInParameter(comm, "@MessageTypeId", SqlDbType.Int, messageTypeId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return dt.Rows.Count > 0 ? LoadAll(dt.Rows) : null;

        }

        /// <summary>
        /// 实体
        /// </summary>
        /// yaoy    16.05.26
        /// <param name="infoTypeId"></param>
        /// <returns></returns>
        public InfoTypeInfo Find(int infoTypeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_InfoType WHERE BIT_ID = @InfoTypeId
            ");
            DHelper.AddInParameter(comm, "@InfoTypeId", SqlDbType.Int, infoTypeId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return dt.Rows.Count > 0 ? Load(dt.Rows[0]) : null;
        }

        /// <summary>
        /// 获取信息记录列表
        /// </summary>
        /// yand    16.08.02
        /// <param name="infoTypeID"></param>
        /// <returns></returns>
        public List<ComboInfo> GetList(int infoTypeID)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_InfoType WHERE BIT_ID = @infoTypeID
            ");
            DHelper.AddInParameter(comm, "@infoTypeID", SqlDbType.Int, infoTypeID);

            DataTable dt = DHelper.ExecuteDataTable(comm);
            List<ComboInfo> list = new List<ComboInfo>();

            foreach (DataRow dr in dt.Rows)
            {
                ComboInfo cbi = new ComboInfo(dr["InfoCode"].ToString(), dr["InfoName"].ToString());

                list.Add(cbi);
            }

            return list;
        }
    }
}

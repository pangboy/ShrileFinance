using DataHelper;
using Model.BankCredit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL.BankCredit
{
    public class DataSegmentMapper : BankAbstractMapper<DataSegmentInfo>
    {
        /// <summary>
        /// 根据信息记录ID获取段列表
        /// </summary>
        /// yand    16.05.25
        /// <param name="InfoTypeId">信息记录ID</param>
        /// <returns></returns>
        public List<DataSegmentInfo> FindByInfoTypeId(int InfoTypeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_DataSegment WHERE BIT_ID = @InfoTypeId
            ");
            DHelper.AddInParameter(comm, "@InfoTypeId", SqlDbType.Int, InfoTypeId);

            return LoadAll(DHelper.ExecuteDataTable(comm).Rows);
        }

        /// <summary>
        /// 下拉框列表
        /// </summary>
        /// yaoy    16.05.26
        /// <param name="messageTypeId"></param>
        /// <returns></returns>
        public List<ComboInfo> FindComList(int messageTypeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_DataSegment WHERE BIT_ID = @MessageTypeId
            ");
            DHelper.AddInParameter(comm, "@MessageTypeId", SqlDbType.Int, messageTypeId);

            DataTable dt = DHelper.ExecuteDataTable(comm);
            List<ComboInfo> list = new List<ComboInfo>();

            foreach (DataRow dr in dt.Rows)
            {
                ComboInfo cbi = new ComboInfo(dr["BDS_ID"].ToString(), dr["ParagraphName"].ToString());

                list.Add(cbi);
            }

            return list;
        }

        /// <summary>
        /// 实体
        /// </summary>
        /// yaoy    16.05.26
        /// <param name="dataSegmentId"></param>
        /// <returns></returns>
        public DataSegmentInfo Find(int dataSegmentId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_DataSegment WHERE BDS_ID = @DataSegmentId
            ");
            DHelper.AddInParameter(comm, "@DataSegmentId", SqlDbType.Int, dataSegmentId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return dt.Rows.Count > 0 ? Load(dt.Rows[0]) : null;
        }

        /// <summary>
        /// 根据信息类型ID和段编码获取实体
        /// </summary>
        /// yaoy    16.09.20
        /// <param name="infoTypeId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataSegmentInfo FindByInfoTypeAndCode(int infoTypeId, string code)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_DataSegment WHERE BIT_ID = @InfoTypeId AND ParagraphCode = @Code
            ");
            DHelper.AddInParameter(comm, "@InfoTypeId", SqlDbType.Int, infoTypeId);
            DHelper.AddInParameter(comm, "@Code", SqlDbType.NChar, code);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return dt.Rows.Count > 0 ? Load(dt.Rows[0]) : null;
        }

        /// <summary>
        /// 根据信息类型ID和数据段规则ID获取数据段实体
        /// </summary>
        /// yaoy    16.09.28
        /// <param name="infoTypeId"></param>
        /// <param name="segmentRulesId"></param>
        /// <returns></returns>
        public DataSegmentInfo FindByInfoTypeIdAndSegmentRulesId(int infoTypeId, int segmentRulesId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_DataSegment AS bds
                    LEFT JOIN BANK_SegmentRules AS bsr ON bsr.BDS_ID = bds.BDS_ID 
                    LEFT JOIN BANK_Meta AS bm ON bm.MetaCode = bsr.MetaCode
                WHERE bds.BIT_ID = @InfoTypeId AND bsr.BSR_ID = @SegmentRulesId
            ");
            DHelper.AddInParameter(comm, "@InfoTypeId", SqlDbType.Int, infoTypeId);
            DHelper.AddInParameter(comm, "@SegmentRulesId", SqlDbType.Int, segmentRulesId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return dt.Rows.Count > 0 ? Load(dt.Rows[0]) : null;
        }

        /// <summary>
        /// 集合
        /// </summary>
        /// yaoy    16.09.20
        /// <param name="infoTypeId"></param>
        /// <returns></returns>
        public List<DataSegmentInfo> List(int infoTypeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_DataSegment WHERE BIT_ID = @InfoTypeId
            ");
            DHelper.AddInParameter(comm, "@InfoTypeId", SqlDbType.Int, infoTypeId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return LoadAll(dt.Rows);
        }

        /// <summary>
        /// 必填项集合
        /// </summary>
        /// yaoy    16.09.20
        /// <param name="infoTypeId"></param>
        /// <returns></returns>
        public List<DataSegmentInfo> FindMustList(int infoTypeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_DataSegment WHERE BIT_ID = @InfoTypeId AND BRC_Status = 'M'
            ");
            DHelper.AddInParameter(comm, "@InfoTypeId", SqlDbType.Int, infoTypeId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return LoadAll(dt.Rows);
        }
    }
}

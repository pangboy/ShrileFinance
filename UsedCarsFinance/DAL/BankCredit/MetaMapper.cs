using Models;
using Models.BankCredit;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.BankCredit
{
    public class MetaMapper : BankAbstractMapper<MetaInfo>
    {
        /// <summary>
        /// 根据数据元标识符获取该条记录
        /// </summary>
        /// yand     16.07.04
        /// <param name="MetaCode">数据元标识</param>
        /// <returns></returns>
        public MetaInfo Find(int MetaCode)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_Meta WHERE MetaCode = @MetaCode
            ");
            DHelper.AddInParameter(comm, "@MetaCode", SqlDbType.Int, MetaCode);

            var dt = DHelper.ExecuteDataTable(comm);
            var result = Load(dt);

            result.RuleType = new RuleTypeInfo();

            if (dt.Rows[0]["RuleTypeId"] is DBNull)
            {
                result.RuleType.RuleTypeId = Convert.ToInt32(null);
            }
            else
            {
                result.RuleType.RuleTypeId = Convert.ToInt32(dt.Rows[0]["RuleTypeId"]);
            }

            return result;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// yangj    16.07.05
        /// <param name="page"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public DataTable List(Models.Pagination page, NameValueCollection filter)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT tmp.rownum, bm.MetaCode, bm.Name, bm.DataType, bm.DatasLength,CASE bm.Type WHEN 1 THEN '企业' WHEN 2 THEN '个人' END AS TypeName
                FROM BANK_Meta AS bm
					RIGHT JOIN (SELECT TOP (@End) ROW_NUMBER() OVER (ORDER BY MetaCode DESC) AS rownum,MetaCode,Type FROM BANK_Meta
					)AS tmp ON bm.MetaCode = tmp.MetaCode AND tmp.Type = bm.Type
                WHERE tmp.rownum > @Begin
			");

            DHelper.AddParameter(comm, "@Begin", SqlDbType.Int, page.Begin);
            DHelper.AddParameter(comm, "@End", SqlDbType.Int, page.End);

            SqlCommand commPage = DHelper.GetSqlCommand(
                @"SELECT COUNT(*) FROM BANK_Meta
			");

            page.Total = Convert.ToInt32(DHelper.ExecuteScalar(commPage));

            DataTable dt = DHelper.ExecuteDataTable(comm);
            return dt;
        }

        /// <summary>
        /// 根据信息记录类型ID和数据段规则ID获取数据元实体
        /// </summary>
        /// yaoy    16.09.28
        /// <param name="infoTypeId"></param>
        /// <param name="segmentRulesId"></param>
        /// <returns></returns>
        public MetaInfo FindByInfoTypeIdAndSegmentRulesId(int infoTypeId, int segmentRulesId)
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
        /// 增加一条记录
        /// </summary>
        /// yangj    16.07.05
        /// <param name="value">数据元实体</param>
        /// <returns></returns>
        public void Insert(MetaInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                INSERT INTO BANK_Meta (MetaCode,Name,DataType,DatasLength,Type)
                    VALUES (@MetaCode,@Name,@DataType,@DatasLength,@Type)
                SELECT SCOPE_IDENTITY()"
            );

            DHelper.AddParameter(comm, "@MetaCode", SqlDbType.Int, value.MetaCode);
            DHelper.AddParameter(comm, "@Name", SqlDbType.NVarChar, value.Name);
            DHelper.AddParameter(comm, "@DataType", SqlDbType.NVarChar, value.DataType);
            DHelper.AddParameter(comm, "@DatasLength", SqlDbType.Int, value.DatasLength);
            DHelper.AddParameter(comm, "@Type", SqlDbType.Int, value.Type);

            DHelper.ExecuteScalar(comm);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// yangj    16.07.05
        /// <param name="value">数据元实体</param>
        /// <returns></returns>
        public int Update(MetaInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                  UPDATE BANK_Meta SET 
                        MetaCode=@MetaCode,
                        Name=@Name,
                        DataType=@DataType,
                        DatasLength=@DatasLength,
                        Type=@Type
                  WHERE MetaCode=@OldMetaCode AND Type =@OldType
            ");

            DHelper.AddParameter(comm, "@MetaCode", SqlDbType.Int, value.MetaCode);
            DHelper.AddParameter(comm, "@Name", SqlDbType.NVarChar, value.Name);
            DHelper.AddParameter(comm, "@DataType", SqlDbType.NVarChar, value.DataType);
            DHelper.AddParameter(comm, "@DatasLength", SqlDbType.Int, value.DatasLength);
            DHelper.AddParameter(comm, "@Type", SqlDbType.Int, value.Type);
            DHelper.AddParameter(comm, "@OldMetaCode", SqlDbType.Int, value.OldMetaCode);
            DHelper.AddInParameter(comm, "@OldType", SqlDbType.Int, value.OldType);

            return Convert.ToInt32(DHelper.ExecuteNonQuery(comm));
        }

        /// <summary>
        /// 根据数据项ID获取元数据列表
        /// </summary>
        /// yaoy    16.07.06
        /// <param name="dataSegmentId"></param>
        /// <returns></returns>
        public List<MetaInfo> List(int dataSegmentId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT bm.* FROM BANK_SegmentRules AS bsr
                    LEFT JOIN BANK_Meta AS bm ON bm.MetaCode = bsr,MetaCode
                WHERE bsr.BDS_ID = @DataSegmentId
            ");
            DHelper.AddInParameter(comm, "@DataSegmentId", SqlDbType.Int, dataSegmentId);

            DataTable dt = DHelper.ExecuteDataTable(comm);
            return dt.Rows.Count > 0 ? LoadAll(dt.Rows) : null;
        }
        /// <summary>
        /// 根据数据元标识和服务对象作为复合主键，验证重复性
        /// </summary>
        /// yangj     16.07.06
        /// <param name="metaCode">数据元标识</param>
        /// <param name="type">服务对象</param>
        /// <returns></returns>
        public MetaInfo FindByPK(int metaCode, int type)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_Meta WHERE MetaCode = @MetaCode AND Type = @Type
            ");
            DHelper.AddInParameter(comm, "@MetaCode", SqlDbType.Int, metaCode);
            DHelper.AddParameter(comm, "@Type", SqlDbType.Int, type);

            return Load(DHelper.ExecuteDataTable(comm));
        }
    }
}

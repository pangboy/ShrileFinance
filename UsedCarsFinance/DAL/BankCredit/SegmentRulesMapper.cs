using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using Models;
using Models.BankCredit;

namespace DAL.BankCredit
{
    public class SegmentRulesMapper : BankAbstractMapper<SegmentRulesInfo>
    {
        /// <summary>
        /// 实体
        /// </summary>
        /// yaoy    16.07.04
        /// <param name="segmentRulesId">段规则ID</param>
        /// <returns></returns>
        public SegmentRulesInfo Find(int segmentRulesId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_SegmentRules WHERE BSR_ID = @SegmentRulesId
            ");
            DHelper.AddInParameter(comm, "@SegmentRulesId", SqlDbType.Int, segmentRulesId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return dt.Rows.Count > 0 ? Load(dt.Rows[0]) : null;
        }

        /// <summary>
        /// 集合
        /// </summary>
        /// yaoy    16.07.04
        /// <param name="dataSegmentId">段规则ID</param>
        /// <returns></returns>
        public List<SegmentRulesInfo> List(int dataSegmentId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_SegmentRules WHERE BDS_ID = @DataSegmentId ORDER BY BDS_ID ,Position
            ");
            DHelper.AddInParameter(comm, "@DataSegmentId", SqlDbType.Int, dataSegmentId);

            return LoadAll(DHelper.ExecuteDataTable(comm).Rows);
        }

        /// <summary>
        /// 根据信息记录类型ID和数据元ID获取数据段规则集合
        /// </summary>
        /// yaoy    16.09.20
        /// <param name="infoTypeId"></param>
        /// <param name="metaCode"></param>
        /// <returns></returns>
        public List<SegmentRulesInfo> FindByInfoTypeIdAndMetaCode(int infoTypeId, int metaCode)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT bsr.* FROM BANK_SegmentRules AS bsr
                    LEFT JOIN BANK_DataSegment AS bds ON bsr.BDS_ID = bds.BDS_ID
                WHERE bds.BIT_ID = @InfoTypeId AND MetaCode = @MetaCode 
            ");
            DHelper.AddInParameter(comm, "@InfoTypeId", SqlDbType.Int, infoTypeId);
            DHelper.AddInParameter(comm, "@MetaCode", SqlDbType.Int, metaCode);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return LoadAll(dt.Rows);
        }

        /// <summary>
        /// 根据信息类型ID、数据元ID和数据段名称获取数据段规则
        /// </summary>
        /// yaoy    16.09.23
        /// <param name="infoTypeId"></param>
        /// <param name="metaCode"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public SegmentRulesInfo FindSegmentRulesByInfoTypeIdAndMetaCodeAndCode(int infoTypeId, int metaCode, string code)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT bsr.* FROM BANK_SegmentRules AS bsr
                    LEFT JOIN BANK_DataSegment AS bds ON bsr.BDS_ID = bds.BDS_ID
                WHERE bds.BIT_ID = @InfoTypeId AND MetaCode = @MetaCode AND bds.ParagraphCode = @Code
            ");
            DHelper.AddInParameter(comm, "@InfoTypeId", SqlDbType.Int, infoTypeId);
            DHelper.AddInParameter(comm, "@MetaCode", SqlDbType.Int, metaCode);
            DHelper.AddInParameter(comm, "@Code", SqlDbType.NChar, code);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return dt.Rows.Count > 0 ? Load(dt.Rows[0]) : null;
        }

        /// <summary>
        /// 根据信息记录类型ID和数据段编码获取数据段规则集合
        /// </summary>
        /// yaoy    16.09.23
        /// <param name="infoTypeId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<SegmentRulesInfo> FindSegmentRulesByInfoTypeIdAndCode(int infoTypeId, string code)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT bsr.* FROM BANK_SegmentRules AS bsr
                LEFT JOIN BANK_DataSegment AS bds ON bsr.BDS_ID = bds.BDS_ID
                WHERE bds.BIT_ID = @InfoTypeId AND bds.ParagraphCode = @Code
            ");
            DHelper.AddInParameter(comm, "@InfoTypeId", SqlDbType.Int, infoTypeId);
            DHelper.AddInParameter(comm, "@Code", SqlDbType.NChar, code);

            return LoadAll(DHelper.ExecuteDataTable(comm).Rows);
        }

        /// <summary>
        /// 根据元数据ID获取数据段集合
        /// </summary>
        /// yaoy    16.09.20
        /// <param name="metaCode"></param>
        /// <returns></returns>
        public List<SegmentRulesInfo> FindSegmentRulesByMetaCode(int metaCode)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_SegmentRules WHERE MetaCode = @MetaCode
            ");
            DHelper.AddInParameter(comm, "@MetaCode", SqlDbType.Int, metaCode);

            return LoadAll(DHelper.ExecuteDataTable(comm).Rows);
        }

        /// <summary>
        /// 根据信息记录ID和固定位置获取数据段规则ID
        /// </summary>
        /// yaoy    16.09.23
        /// <param name="infoTypeId"></param>
        /// <returns></returns>
        public SegmentRulesInfo FindSegmentRulesIdByInfoTypeIdAndPosition(int infoTypeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT bsr.* FROM BANK_SegmentRules AS bsr
                LEFT JOIN BANK_DataSegment AS bds ON bsr.BDS_ID = bds.BDS_ID
                WHERE bds.BIT_ID  = @InfoTypeId AND bsr.Position = 5
            ");
            DHelper.AddInParameter(comm, "@InfoTypeId", SqlDbType.Int, infoTypeId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return dt.Rows.Count > 0 ? Load(dt.Rows[0]) : null;
        }

        /// <summary>
        /// 获取段规则列表
        /// </summary>
        /// zouql 16.07.06
        /// <param name="pagination">Pagination</param>
        /// <param name="filter">NameValueCollection</param>
        /// <returns>DataTable</returns>
        public DataTable PageList(Pagination pagination, NameValueCollection filter)
        {
            var sql =
                @"
                  SELECT TOP(@End) T.* FROM
				  (
				  SELECT rownum=ROW_NUMBER() OVER (ORDER BY temp.BSR_ID DESC),temp.*,CASE temp.[Type] WHEN 1 THEN '企业' ELSE '个人' end AS EP
				  FROM
				  (
				  SELECT DISTINCT sr.BSR_ID,sr.Position,sr.IsRequired,sr.[Description],
				         m.MetaCode,m.Name,m.DataType,m.DatasLength,m.[Type],
						 ds.BDS_ID,ds.ParagraphName,ds.ParagraphCode,ds.Describe,ds.times,ds.BRC_Status,ds.BIT_ID,ds.TimesType
                  FROM BANK_SegmentRules sr
                  LEFT JOIN BANK_Meta m ON sr.MetaCode=m.MetaCode
                  LEFT JOIN BANK_DataSegment ds ON sr.BDS_ID=ds.BDS_ID
				  )temp
				  )T
				  WHERE T.rownum>@Begin
                ";
            var sqlT = @"
                  SELECT COUNT(*) FROM
				  (
				  SELECT DISTINCT sr.BSR_ID,m.MetaCode,ds.BDS_ID
                  FROM BANK_SegmentRules sr
                  LEFT JOIN BANK_Meta m ON sr.MetaCode=m.MetaCode
                  LEFT JOIN BANK_DataSegment ds ON sr.BDS_ID=ds.BDS_ID
				  )T
                  ";
            SqlCommand cmd = DHelper.GetSqlCommand(sql);
            SqlCommand cmdT = DHelper.GetSqlCommand(sqlT);
            DHelper.AddParameter(cmd, "@Begin", SqlDbType.Int, pagination.Begin);
            DHelper.AddParameter(cmd, "@End", SqlDbType.Int, pagination.End);
            var table = DHelper.ExecuteDataTable(cmd);

            pagination.Total = Convert.ToInt32(DHelper.ExecuteScalar(cmdT));
            return table;
        }

        /// <summary>
        /// 添加段规则
        /// </summary>
        /// zouql 16.07.06
        /// <param name="sr">段规则实体</param>
        /// <returns>结果</returns>
        public int Create(SegmentRulesInfo sr)
        {
            var sql =
                @"
                  INSERT INTO BANK_SegmentRules(Position,IsRequired,[Description],MetaCode)
                  VALUES(@Position,@IsRequired,@Description,@MetaCode)
                  SELECT SCOPE_IDENTITY()
                ";
            SqlCommand cmd = DHelper.GetSqlCommand(sql);
            DHelper.AddInParameter(cmd, "@Position", SqlDbType.Int, sr.Position);
            DHelper.AddInParameter(cmd, "@IsRequired", SqlDbType.VarChar, sr.IsRequired);
            DHelper.AddInParameter(cmd, "@Description", SqlDbType.NVarChar, sr.Description);
            DHelper.AddInParameter(cmd, "@MetaCode", SqlDbType.Int, sr.MetaCode);
            var result = DHelper.ExecuteNonQuery(cmd);
            return result;
        }

        /// <summary>
        /// 获取元代码名称集合
        /// </summary>
        /// zouql 16.07.07
        /// <returns>集合</returns>
        public List<ComboInfo> GetComListMateName()
        {
            var sql =
                @"
                 SELECT MetaCode,Name FROM BANK_Meta
                ";
            SqlCommand cmd = DHelper.GetSqlCommand(sql);
            var table = DHelper.ExecuteDataTable(cmd);
            var list = new List<ComboInfo>();
            for (var i = 0; i < table.Rows.Count; i++)
            {
                var p1 = table.Rows[i]["MetaCode"];
                var p2 = table.Rows[i]["Name"];
                if (p1 == null)
                {
                    p1 = string.Empty;
                }

                if (p2 == null)
                {
                    p2 = string.Empty;
                }

                list.Add(new ComboInfo(p1.ToString(), p2.ToString()));
            }

            return list;
        }

        /// <summary>
        /// 获取元代码名称集合
        /// </summary>
        /// zouql 16.07.07
        /// <param name="type">类型</param>
        /// <returns>集合</returns>
        public List<ComboInfo> GetComListMateName(string type)
        {
            var sql =
                @"
                 SELECT MetaCode,Name FROM BANK_Meta WHERE [Type]=@t
                ";
            SqlCommand cmd = DHelper.GetSqlCommand(sql);
            DHelper.AddInParameter(cmd, "@t", SqlDbType.TinyInt, byte.Parse(type));
            var table = DHelper.ExecuteDataTable(cmd);
            var list = new List<ComboInfo>();
            for (var i = 0; i < table.Rows.Count; i++)
            {
                var p1 = table.Rows[i]["MetaCode"];
                var p2 = table.Rows[i]["Name"];
                if (p1 == null)
                {
                    p1 = string.Empty;
                }

                if (p2 == null)
                {
                    p2 = string.Empty;
                }

                list.Add(new ComboInfo(p1.ToString(), p2.ToString()));
            }

            return list;
        }

        /// <summary>
        /// 模糊查询元代码名称集合()
        /// </summary>
        /// <param name="value">查询值</param>
        /// <param name="type">类型</param>
        /// <returns>集合</returns>
        public List<ComboInfo> GetComListMateName(string value, string type)
        {
            var sql =
                @"
                 SELECT MetaCode,Name FROM BANK_Meta WHERE [Type]=@t AND Name LIKE @value
                ";
            SqlCommand cmd = DHelper.GetSqlCommand(sql);
            DHelper.AddInParameter(cmd, "@value", SqlDbType.NVarChar, "%" + value + "%");
            DHelper.AddInParameter(cmd, "@t", SqlDbType.TinyInt, byte.Parse(type));
            var table = DHelper.ExecuteDataTable(cmd);
            var list = new List<ComboInfo>();
            for (var i = 0; i < table.Rows.Count; i++)
            {
                var p1 = table.Rows[i]["MetaCode"];
                var p2 = table.Rows[i]["Name"];
                if (p1 == null)
                {
                    p1 = string.Empty;
                }

                if (p2 == null)
                {
                    p2 = string.Empty;
                }

                list.Add(new ComboInfo(p1.ToString(), p2.ToString()));
            }

            return list;
        }

        /// <summary>
        /// 检查种子是否已被使用
        /// </summary>
        /// zouql 16.07.06
        /// <param name="sr">实体</param>
        /// <returns>结果</returns>
        public object CheckSeed(SegmentRulesInfo sr)
        {
            var sql =
                @"
                  SELECT * FROM BANK_SegmentRules 
                  WHERE Position=@Position 
                  AND [Description]=@Description 
                  AND MetaCode=@MetaCode
                ";

            SqlCommand cmd = DHelper.GetSqlCommand(sql);
            DHelper.AddInParameter(cmd, "@Position", SqlDbType.Int, sr.Position);
            DHelper.AddInParameter(cmd, "@IsRequired", SqlDbType.VarChar, sr.IsRequired);
            DHelper.AddInParameter(cmd, "@Description", SqlDbType.NVarChar, sr.Description);
            DHelper.AddInParameter(cmd, "@MetaCode", SqlDbType.Int, sr.MetaCode);
            var result = DHelper.ExecuteScalar(cmd);

            return result;
        }

        /// <summary>
        /// 修改段规则
        /// </summary>
        /// zouql 16.07.06
        /// <param name="sr">段规则实体</param>
        /// <returns>结果</returns>
        public int Modify(SegmentRulesInfo sr)
        {
            var sql =
                @"
                  UPDATE BANK_SegmentRules 
                  SET Position=@Position,IsRequired=@IsRequired,
                  [Description]=@Description,MetaCode=@MetaCode
                  WHERE BSR_ID=@BSR_ID
                ";
            SqlCommand cmd = DHelper.GetSqlCommand(sql);
            DHelper.AddInParameter(cmd, "@BSR_ID", SqlDbType.Int, sr.SegmentRulesId);
            DHelper.AddInParameter(cmd, "@Position", SqlDbType.Int, sr.Position);
            DHelper.AddInParameter(cmd, "@IsRequired", SqlDbType.VarChar, sr.IsRequired);
            DHelper.AddInParameter(cmd, "@Description", SqlDbType.NVarChar, sr.Description);
            DHelper.AddInParameter(cmd, "@MetaCode", SqlDbType.Int, sr.MetaCode);
            var result = DHelper.ExecuteNonQuery(cmd);
            return result;
        }

        /// <summary>
        /// 通过主键ID获取段规则实体
        /// </summary>
        /// zouql 16.07.06
        /// <param name="bsrId">主键ID</param>
        /// <param name="metaCode">数据元ID</param>
        /// <returns>实体</returns>
        public SegmentRulesInfo Get(string bsrId, string metaCode)
        {
            string sqlcmd =
                @"
                  SELECT * 
                  FROM BANK_SegmentRules
                  WHERE BSR_ID=@BSR_ID
                ";
            SqlCommand cmd = DHelper.GetSqlCommand(sqlcmd);
            DHelper.AddInParameter(cmd, "@BSR_ID", SqlDbType.Int, int.Parse(bsrId));
            var table = DHelper.ExecuteDataTable(cmd);
            return table.Rows.Count > 0 ? Load(table.Rows[0]) : null;
        }

        /// <summary>
        /// 代码校验，获取信息记录下的下拉框（下拉框中的值校验）
        /// </summary>
        /// yangj 2016.9.20
        /// <param name="infoTypeId">信息记录标识</param>
        /// <param name="htmlId">标签类型标识</param>
        /// <returns></returns>
        public DataTable CodeProofMethod(int infoTypeId, int htmlId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT BSR_ID FROM BANK_SegmentRules AS bs
                    LEFT JOIN BANK_DataSegment AS bd ON bd.BDS_ID = bs.BDS_ID
                    LEFT JOIN BANK_MetaComponents AS bm ON bm.MetaCode = bs.MetaCode
                    LEFT JOIN BANK_HtmlElement AS bh ON bh.BHE_ID = bm.BHE_ID
                WHERE bd.BIT_ID = @BIT_ID AND bh.BHE_ID IN (@BHE_ID) AND bs.MetaCode NOT IN(7653)
            ");

            DHelper.AddInParameter(comm, "@BIT_ID", SqlDbType.Int, infoTypeId);
            DHelper.AddInParameter(comm, "@BHE_ID", SqlDbType.Int, htmlId);

            var table = DHelper.ExecuteDataTable(comm);
            return table;
        }

        /// <summary>
        /// 获取段规则标识
        /// </summary>
        /// zouql   16.09.27
        /// <param name="infoTypeId">信息记录Id</param>
        /// <param name="metaCode">数据元Id</param>
        /// <param name="paragraphCode">段Id</param>
        /// <returns>段规则标识</returns>
        public string FindIdByMetaAndInfoType(int infoTypeId, int metaCode, string paragraphCode)
        {
            var comm = DHelper.GetSqlCommand(@"
                SELECT
	                bsr.BSR_ID
                FROM BANK_InfoType AS bit
                LEFT JOIN BANK_DataSegment AS bds
	                ON bds.BIT_ID = bit.BIT_ID
                LEFT JOIN BANK_SegmentRules AS bsr
	                ON bsr.BDS_ID = bds.BDS_ID
                LEFT JOIN BANK_Meta AS bm
	                ON bm.MetaCode = bsr.MetaCode
                WHERE bit.BIT_ID = @infoTypeId AND ParagraphCode=@ParagraphCode AND bm.MetaCode=@metaCode
            ");

            DHelper.AddInParameter(comm, "@infoTypeId", SqlDbType.Int, infoTypeId);
            DHelper.AddInParameter(comm, "@metaCode", SqlDbType.Int, metaCode);
            DHelper.AddInParameter(comm, "@ParagraphCode", SqlDbType.NVarChar, paragraphCode);

            var segId = DHelper.ExecuteScalar(comm);

            return segId is DBNull || segId == null ? string.Empty : segId.ToString();
        }

        /// <summary>
        /// 获取数据（段Code，段Id，数据元Code，必填）
        /// </summary>
        /// zouql   16.09.27
        /// <param name="infoTypeId">信息记录Id</param>
        /// <returns>字典</returns>
        public Dictionary<string, string> FindDataByMetaId(int infoTypeId)
        {
            var comm = DHelper.GetSqlCommand(@"
                    SELECT
	                    bds.ParagraphCode AS pCode
	                    ,bsr.BSR_ID AS seg
                        ,bsr.IsRequired AS req
	                    ,bsr.MetaCode AS mCode
                    FROM BANK_InfoType AS bit
                    LEFT JOIN BANK_DataSegment AS bds
	                    ON bds.BIT_ID = bit.BIT_ID
                    LEFT JOIN BANK_SegmentRules AS bsr
	                    ON bsr.BDS_ID = bds.BDS_ID
                    LEFT JOIN BANK_Meta AS bm
	                    ON bm.MetaCode = bsr.MetaCode
                    WHERE bit.BIT_ID = @infoTypeId
                    ORDER BY mCode
            ");
            DHelper.AddInParameter(comm, "@infoTypeId", SqlDbType.Int, infoTypeId);

            var dt = DHelper.ExecuteDataTable(comm);

            // 实例化Dictionary容器
            var dataDic = new Dictionary<string, string>();

            // 声明key和value
            var key = string.Empty;
            var value = string.Empty;

            // 将dataTable中的数据填入Dictionary<string, string>
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                // 拼装key
                key = dt.Rows[i]["pCode"] + dt.Rows[i]["seg"].ToString();

                // 拼装value
                value = dt.Rows[i]["req"] + dt.Rows[i]["mCode"].ToString();

                // 存储值
                dataDic.Add(key, value);
            }

            // 返回数据
            return dataDic;
        }
    }
}

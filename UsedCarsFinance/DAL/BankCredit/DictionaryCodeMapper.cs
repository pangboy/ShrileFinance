using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using Models;
using Models.BankCredit;

namespace DAL.BankCredit
{
    /// <summary>
    /// DictionaryCode映射
    /// zouql 2016-07-05
    /// </summary>
    public class DictionaryCodeMapper : BankAbstractMapper<DictionaryCodeInfo>
    {
        /// <summary>
        /// 获取字典代码表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="filter"></param>
        /// zouql 2016-07-05
        /// <returns>字典代码表</returns>
        public DataTable PageList(Pagination pagination, NameValueCollection filter)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT TOP(@End) tt.* 
                FROM (
                    SELECT ROW_NUMBER() OVER (ORDER BY temp.BDT_ID DESC) AS rownum,
                        temp.Code, temp.CodeName, temp.TypeName, temp.ParentCode, ParentCodeName = dic.Name, temp.BDT_ID 
                    FROM (
                        SELECT DISTINCT c.Code,CodeName=c.Name,c.ParentCode,TypeName=t.Name,t.ParentType,c.BDT_ID
                        FROM BANK_DictionaryCode c 
                        LEFT JOIN BANK_DictionaryType t ON c.BDT_ID=t.BDT_ID
                    ) temp
                    LEFT JOIN BANK_DictionaryCode dic ON CONVERT(NVARCHAR,temp.ParentCode)=CONVERT(NVARCHAR,dic.Code)  
				) AS tt
                WHERE tt.rownum > @Begin"
            ); 

            DHelper.AddParameter(comm, "@Begin", SqlDbType.Int, pagination.Begin);
            DHelper.AddParameter(comm, "@End", SqlDbType.Int, pagination.End);

            SqlCommand commPage = DHelper.GetSqlCommand(
                @"SELECT COUNT(tt.rownum) FROM
                 (
                  SELECT  rownum=ROW_NUMBER() OVER (ORDER BY temp.BDT_ID DESC),temp.Code,temp.CodeName,temp.TypeName,temp.ParentCode,ParentCodeName=dic.Name
                  FROM
                  (
                  SELECT DISTINCT c.Code,CodeName=c.Name,c.ParentCode,TypeName=t.Name,t.ParentType,c.BDT_ID
                  FROM BANK_DictionaryCode c 
                  LEFT JOIN BANK_DictionaryType t 
                  ON c.BDT_ID=t.BDT_ID
                  ) temp
                  LEFT JOIN BANK_DictionaryCode dic
                  ON CONVERT(NVARCHAR,temp.ParentCode)=CONVERT(NVARCHAR,dic.Code)
				  )tt
			");

            pagination.Total = Convert.ToInt32(DHelper.ExecuteScalar(commPage));

            DataTable dt = DHelper.ExecuteDataTable(comm);
            return dt;
        }

        /// <summary>
        /// 获取字典代码实体
        /// </summary>
        /// zouql 2016-07-05
        /// <param name="code"></param>
        /// <param name="dictionaryTypeId"></param>
        /// <returns></returns>
        public DictionaryCodeInfo Get(string code, int dictionaryTypeId)
        {
            string sqlcmd =
                @"SELECT CodeId,Code,Name,ParentCode,DictionaryTypeId=BDT_ID 
                  FROM BANK_DictionaryCode 
                  WHERE Code=@Code AND BDT_ID=@DictionaryTypeId";
            SqlCommand comm = DHelper.GetSqlCommand(sqlcmd);
            DHelper.AddInParameter(comm, "@Code", SqlDbType.NVarChar, code);
            DHelper.AddInParameter(comm, "@DictionaryTypeId", SqlDbType.Int, dictionaryTypeId);
            var table = DHelper.ExecuteDataTable(comm);
            return table.Rows.Count > 0 ? Load(table.Rows[0]) : null;
        }

        /// <summary>
        /// 根据数据元获取字典集合
        /// </summary>
        /// yaoy    16.09.26
        /// <param name="metaCode"></param>
        /// <returns></returns>
        public List<DictionaryCodeInfo> List(int metaCode)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT dbc.* FROM BANK_DictionaryCode AS dbc 
                    LEFT JOIN  BANK_MetaDicRelation AS bmr ON bmr.BDT_ID = dbc.BDT_ID
                WHERE bmr.MetaCode = @MetaCode
            ");
            DHelper.AddInParameter(comm, "@MetaCode", SqlDbType.Int, metaCode);

            return LoadAll(DHelper.ExecuteDataTable(comm).Rows);
        }

        /// <summary>
        /// 创建新字典代码行
        /// </summary>
        /// zouql 2016-07-05
        /// <param name="dictionaryCode"></param>
        /// <returns>创建结果</returns>
        public int Create(DictionaryCodeInfo dictionaryCode)
        {
            string sqlcmd =
                @"INSERT INTO BANK_DictionaryCode(Code,Name,ParentCode,BDT_ID) 
                  VALUES(@Code,@Name,@ParentCode,@BDT_ID)
                  SELECT SCOPE_IDENTITY()";
            SqlCommand comm = DHelper.GetSqlCommand(sqlcmd);
            DHelper.AddInParameter(comm, "@Code", SqlDbType.NChar, dictionaryCode.Code);
            DHelper.AddInParameter(comm, "@Name", SqlDbType.NChar, dictionaryCode.Name);
            DHelper.AddInParameter(comm, "@ParentCode", SqlDbType.Int, dictionaryCode.ParentCode);
            DHelper.AddInParameter(comm, "@BDT_ID", SqlDbType.Int, dictionaryCode.DictionaryTypeId);
            var b = DHelper.ExecuteNonQuery(comm);
            return Convert.ToInt32(b);
        }

        /// <summary>
        /// 提取父节点（无重复）
        /// </summary>
        /// zouql 16.07.06
        /// <returns></returns>
        public List<ComboInfo> GetComList()
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT DISTINCT Code,Name
                FROM BANK_DictionaryCode
            ");

            DataTable dt = DHelper.ExecuteDataTable(comm);
            List<ComboInfo> list = new List<ComboInfo>();
            foreach (DataRow dr in dt.Rows)
            {
                var cbi = new ComboInfo(string.Empty, string.Empty);
                object p1 = dr["Code"];
                object p2 = dr["Name"];

                if (p1 != null)
                {
                    cbi.value = p1.ToString();
                }

                if (p2 != null)
                {
                    cbi.text = p2.ToString();
                }

                list.Add(cbi);
            }
            
            return list;
        }

        /// <summary>
        /// 通过字典代码修改字典代码表
        /// </summary>
        /// zouql 2016-07-05
        /// <param name="dictionaryCode"></param>
        /// <returns>修改结果</returns>
        public int Modify(DictionaryCodeInfo dictionaryCode)
        {
            string sqlcmd =
               @"UPDATE BANK_DictionaryCode
                 SET Name=@Name,
                 ParentCode=@ParentCode
                 WHERE Code=@Code AND BDT_ID=@BDT_ID";
            SqlCommand comm = DHelper.GetSqlCommand(sqlcmd);
            DHelper.AddInParameter(comm, "@Code", SqlDbType.NChar, dictionaryCode.Code);
            DHelper.AddInParameter(comm, "@Name", SqlDbType.NChar, dictionaryCode.Name);
            DHelper.AddInParameter(comm, "@ParentCode", SqlDbType.Int, dictionaryCode.ParentCode);
            DHelper.AddInParameter(comm, "@BDT_ID", SqlDbType.Int, dictionaryCode.DictionaryTypeId);

            return Convert.ToInt32(DHelper.ExecuteNonQuery(comm));
        }

        /// <summary>
        /// 根据父节点查找字典
        /// </summary>
        /// <param name="parentCode"></param>
        /// <param name="dictionaryTypeID"></param>
        /// yand    16.07.18
        /// <returns></returns>
        public List<ComboInfo> GetComListByPanrentCode(int parentCode, int dictionaryTypeID)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT  Code,Name FROM BANK_DictionaryCode  
                    WHERE ParentCode = @ParentCode AND BDT_ID = @dictionaryTypeID
            ");
            DHelper.AddInParameter(comm, "@dictionaryTypeID", SqlDbType.Int, dictionaryTypeID);
            DHelper.AddInParameter(comm, "@ParentCode", SqlDbType.NChar, parentCode);
            DataTable dt = DHelper.ExecuteDataTable(comm);
            List<ComboInfo> list = new List<ComboInfo>();
            foreach (DataRow dr in dt.Rows)
            {
                var cbi = new ComboInfo(string.Empty, string.Empty);
                object p1 = dr["Code"];
                object p2 = dr["Name"];

                if (p1 != null)
                {
                    cbi.value = p1.ToString();
                }

                if (p2 != null)
                {
                    cbi.text = p2.ToString();
                }

                list.Add(cbi);
            }

            return list;
        }

        /// <summary>
        /// 获取标识变更段中变更类型的值
        /// </summary>
        /// yand    16.09.30
        /// <param name="metaCode">数据元ID</param>
        /// <param name="parentCode">父元素ID</param>
        /// <returns></returns>
        public List<ComboInfo> GetChangeType(string metaCode,string parentCode)
        {

            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT distinct( bd.CodeId),Code ,Name ,ParentCode ,bd.BDT_ID FROM BANK_DictionaryCode AS bd
                    LEFT JOIN BANK_MetaDicRelation AS bm ON bm.BDT_ID = bd.BDT_ID
                    LEFT JOIN BANK_SegmentRules AS bs ON bs.MetaCode = bm.MetaCode
                WHERE bd.ParentCode = @ParentCode AND bm.MetaCode = @Code
            ");

            DHelper.AddInParameter(comm, "@ParentCode", SqlDbType.NVarChar, parentCode);
            DHelper.AddInParameter(comm, "@Code", SqlDbType.NVarChar, metaCode);

            DataTable dt = DHelper.ExecuteDataTable(comm);
            List<ComboInfo> list = new List<ComboInfo>();

            foreach (DataRow dr in dt.Rows)
            {
                ComboInfo cbi = new ComboInfo(dr["Code"].ToString(), dr["Name"].ToString());

                list.Add(cbi);
            }

            return list;
        }

        /// <summary>
        /// 代码校验（下拉框中的值校验）
        /// </summary>
        /// yangj 2016.9.20
        /// <param name="segmentRulesId">段规则标识</param>
        /// <param name="code">字典代码</param>
        /// <returns></returns>
        public int CodeProofMethod(int segmentRulesId, string code)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT bd.* FROM BANK_DictionaryCode AS bd
                    LEFT JOIN BANK_MetaDicRelation AS bm ON bm.BDT_ID = bd.BDT_ID
                    LEFT JOIN BANK_SegmentRules AS bs ON bs.MetaCode = bm.MetaCode
                WHERE bs.BSR_ID = @SegmentRulesId AND bd.Code = @Code
            ");

            DHelper.AddInParameter(comm, "@SegmentRulesId", SqlDbType.Int, segmentRulesId);
            DHelper.AddInParameter(comm, "@Code", SqlDbType.NVarChar, code);

            var table = DHelper.ExecuteDataTable(comm);
            return table.Rows.Count;
        }
    }
}

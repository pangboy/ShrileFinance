using DataHelper;
using Model;
using Model.BankCredit;
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
    public class DictionaryTypeMapper : BankAbstractMapper<DictionaryTypeInfo>
    {
        /// <summary>
        /// 根据字典类型ID获取该条记录
        /// </summary>
        /// yangj    16.07.01
        /// <param name="dictionaryTypeId">字典类型ID</param>
        /// <returns></returns>
        public DictionaryTypeInfo Find(int dictionaryTypeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM Bank_DictionaryType WHERE BDT_ID = @DictionaryTypeId
            ");
            DHelper.AddInParameter(comm, "@DictionaryTypeId", SqlDbType.Int, dictionaryTypeId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return dt.Rows.Count > 0 ? Load(dt.Rows[0]) : null;
        }

        /// <summary>
        /// 下拉框列表
        /// </summary>
        /// yangj    16.07.01
        /// <param name="dictionaryTypeId">字典类型ID</param>
        /// <returns></returns>
        public List<ComboInfo> GetComList()
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT BDT_ID,Name,ParentType FROM BANK_DictionaryType
            ");

            DataTable dt = DHelper.ExecuteDataTable(comm);
            List<ComboInfo> list = new List<ComboInfo>();

            foreach (DataRow dr in dt.Rows)
            {
                ComboInfo cbi = new ComboInfo(dr["BDT_ID"].ToString(), dr["Name"].ToString());

                list.Add(cbi);
            }

            return list;
        }
        /// <summary>
        /// 根据Code关联关系表查询字典类型实体
        /// </summary>
        /// yand    16.01.18    (由于字典和数据元关系表只有一个查询方法故没建立实体直接在此连表查询)
        /// <param name="MetaCode"></param>
        /// <returns></returns>
        public DictionaryTypeInfo GetComByMetaCode(int MetaCode)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT bdt.BDT_ID,Name,ParentType FROM BANK_DictionaryType AS bdt
                    LEFT JOIN BANK_MetaDicRelation AS bmr ON bdt.BDT_ID = bmr.BDT_ID
                WHERE bmr.MetaCode = @MetaCode
            ");

            DHelper.AddInParameter(comm, "@MetaCode", SqlDbType.Int, MetaCode);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return dt.Rows.Count > 0 ? Load(dt.Rows[0]) : null;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// yangj    16.07.01
        /// <param name="dictionaryTypeId">字典类型ID</param>
        /// <returns></returns>
        public DataTable List(Model.Pagination page, NameValueCollection filter)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT tmp.rownum, bdt.BDT_ID,bdt.Name, temp.Name AS ParentName
                FROM BANK_DictionaryType AS bdt
					RIGHT JOIN (SELECT TOP (@End) ROW_NUMBER() OVER (ORDER BY BDT_ID DESC) AS rownum,BDT_ID FROM BANK_DictionaryType
					)AS tmp ON bdt.BDT_ID = tmp.BDT_ID
                LEFT JOIN BANK_DictionaryType
                    AS temp ON bdt.ParentType = temp.BDT_ID
                WHERE tmp.rownum > @Begin
			");

            DHelper.AddParameter(comm, "@Begin", SqlDbType.Int, page.Begin);
            DHelper.AddParameter(comm, "@End", SqlDbType.Int, page.End);

            SqlCommand commPage = DHelper.GetSqlCommand(
                @"SELECT COUNT(*) FROM BANK_DictionaryType
			");

            page.Total = Convert.ToInt32(DHelper.ExecuteScalar(commPage));

            DataTable dt = DHelper.ExecuteDataTable(comm);
            return dt;
        }

        /// <summary>
        /// 增加一条信息记录
        /// </summary>
        /// yangj    16.07.01
        /// <param name="value">字典类型实体</param>
        /// <returns></returns>
        public void Insert(DictionaryTypeInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                INSERT INTO BANK_DictionaryType (Name,ParentType)
                    VALUES (@Name,@ParentType)
                SELECT SCOPE_IDENTITY()"
            );

            DHelper.AddParameter(comm, "@DictionaryTypeId", SqlDbType.Int, value.DictionaryTypeId);
            DHelper.AddParameter(comm, "@Name", SqlDbType.NVarChar, value.Name);
            DHelper.AddParameter(comm, "@ParentType", SqlDbType.Int, value.ParentType);

            value.DictionaryTypeId = Convert.ToInt32(DHelper.ExecuteScalar(comm));
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// yangj    16.07.01
        /// <param name="value">字典类型实体</param>
        /// <returns></returns>
        public int Update(DictionaryTypeInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                  UPDATE BANK_DictionaryType SET  
                        Name=@Name,
                        ParentType=@ParentType 
                  WHERE BDT_ID=@DictionaryTypeId
            ");
            DHelper.AddParameter(comm, "@DictionaryTypeId", SqlDbType.Int, value.DictionaryTypeId);
            DHelper.AddParameter(comm, "@Name", SqlDbType.NVarChar, value.Name);
            DHelper.AddParameter(comm, "@ParentType", SqlDbType.Int, value.ParentType);

            return Convert.ToInt32(DHelper.ExecuteNonQuery(comm));
        }
    }
}

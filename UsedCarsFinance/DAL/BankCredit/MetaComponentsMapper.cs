using Model.BankCredit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.BankCredit
{
    public class MetaComponentsMapper:BankAbstractMapper<MetaComponentsInfo>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// yaoy    16.07.11
        /// <param name="metaCode"></param>
        /// <returns></returns>
        public MetaComponentsInfo Find(int metaCode)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_MetaComponents WHERE MetaCode = @MetaCode
            ");
            DHelper.AddInParameter(comm, "@MetaCode", SqlDbType.Int, metaCode);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return dt.Rows.Count > 0 ? Load(dt.Rows[0]) : null;
        }
    }
}

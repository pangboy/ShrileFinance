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
   public class HtmlElementMapper:BankAbstractMapper<HtmlElementInfo>
   {
       /// <summary>
       /// 根据元素ID查找html元素实体
       /// </summary>
       /// yand     16.07.04
       /// <param name="metaCode">数据元ID</param>
       /// <returns></returns>
       public List<HtmlElementInfo> Find(int metaCode)
       {
           SqlCommand comm = DHelper.GetSqlCommand(@"
               SELECT he.* FROM BANK_HtmlElement AS he LEFT JOIN BANK_MetaComponents AS mc ON he.BHE_ID = mc.BHE_ID WHERE MetaCode =  @metaCode AND BHE_Type =1
            ");
           DHelper.AddInParameter(comm, "@metaCode", SqlDbType.Int, metaCode);

           return LoadAll(DHelper.ExecuteDataTable(comm).Rows);
       }
    }
}

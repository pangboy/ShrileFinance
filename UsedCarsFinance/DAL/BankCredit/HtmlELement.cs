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
   public class HtmlElement:BankAbstractMapper<HtmlElementInfo>
   {
       /// <summary>
       /// 根据htmlid查找html元素实体
       /// </summary>
       /// yand     16.07.04
       /// <param name="metaCode">数据元ID</param>
       /// <returns></returns>
       public List<HtmlElementInfo> Find(int metaCode)
       {
           SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM BANK_HtmlElement WHERE BHE_ID IN (SELECT BHT_ID FROM BANK_MetaComponents WHERE MetaCode = @metaCode)
            ");
           DHelper.AddInParameter(comm, "@metaCode", SqlDbType.Int, metaCode);

           return LoadAll(DHelper.ExecuteDataTable(comm).Rows);
       }
    }
}

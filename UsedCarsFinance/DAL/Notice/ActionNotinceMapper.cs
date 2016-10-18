using Model.Notice;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Notice
{
   public class ActionNotinceMapper:AbstractMapper<ActionNoticeInfo>
    {
        /// <summary>
        /// 根据行为ID查找对应的内容
        /// </summary>
        /// yand    16.09.10
        /// <param name="actionId"></param>
        /// <returns></returns>
        public ActionNoticeInfo FindByActionId(int actionId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                 SELECT * FROM Notice_ActionNotice WHERE ActionId=@ActionId
            ");
            DHelper.AddInParameter(comm, "@ActionId", SqlDbType.Int, actionId);

            return Load(DHelper.ExecuteDataTable(comm));
        }
    }
}

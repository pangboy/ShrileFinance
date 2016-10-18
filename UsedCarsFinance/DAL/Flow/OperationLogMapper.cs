using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using System.Data;
using DataHelper;

namespace DAL.Flow
{
    public class OperationLogMapper : AbstractMapper<OperationLog>
    {
        //定义列
        private const string COLUMNS = "Type,RE_ID,RE_SID,RE_Module,Content,UI_ID,AddTime";
        //通用的查找语句
        protected override string findStatement
        {
            get { return "SELECT " + COLUMNS + "FROM SYST_OperationLog WHERE OL_ID = @OL_ID"; }
        }

        /// <summary>
        /// 查找日志
        /// </summary>
        /// yand    15.11.13
        /// <param name="id">标识</param>
        /// <returns></returns>
        public OperationLog Find(int id)
        {
            //通用方法查找实体
            return AbstractFind(id);
        }


        public List<OperationLog> List()
        {
            SQLHelper DHelper = new SQLHelper();
            List<OperationLog> list = new List<OperationLog>();

            SqlCommand comm = DHelper.GetSqlCommand(@"SELECT * FROM SYST_OperationLog");

            DataTable dt = DHelper.ExecuteDataTable(comm);

            list = Model.ConvertHelper.Data2List<OperationLog>(dt);

            return list;
        }


        /// <summary>
        /// 插入日志
        /// </summary>
        /// yand    15.11.13
        /// <param name="value"></param>
        /// <returns></returns>
        public int Insert(OperationLog value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(
                "INSERT INTO SYST_OperationLog (Type,RE_ID, RE_SID, RE_Module,Content,UI_ID,AddTime) " +
                "VALUES (@Type,@RE_ID, @RE_SID, @RE_Module,@Content,@UI_ID,default) SELECT SCOPE_IDENTITY() "
                );
            AddParameter(comm, "@Type", SqlDbType.TinyInt, value.Type);
            AddParameter(comm, "@RE_ID", SqlDbType.Int, value.RE_ID);
            AddParameter(comm, "@RE_SID", SqlDbType.Int, value.RE_SID);
            AddParameter(comm, "@RE_Module", SqlDbType.TinyInt, value.RE_Module);
            AddParameter(comm, "@Content", SqlDbType.NVarChar, value.Content);
            AddParameter(comm, "@UI_ID", SqlDbType.Int, value.UI_ID);
         
            return (int)DHelper.ExecuteScalar(comm);
        }

     
        protected override string NameOfID
        {
            get { return "OL_ID"; }
        }

        protected override void Save(OperationLog value, SqlCommand comm)
        {
            throw new NotImplementedException();
        }
    }
}

//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using Model.System;

//namespace DAL.System
//{
//	public class OperationLogMapper : AbstractMapper<OperationLogInfo>
//    {
//        /// <summary>
//        /// 查找日志
//        /// </summary>
//        /// yand    15.11.13
//        /// <param name="id">标识</param>
//        /// <returns></returns>
//        public OperationLogInfo Find(int id)
//        {
//            string findStatement = "SELECT Type,RE_ID,RE_SID,RE_Module,Content,UI_ID,AddTime FROM SYS_OperationLog WHERE OL_ID = @OL_ID";
//            //通用方法查找实体
//            return AbstractFind(findStatement,id);
//        }


//        public List<OperationLogInfo> List()
//        {
//            List<OperationLogInfo> list = new List<OperationLogInfo>();

//            SqlCommand comm = DHelper.GetSqlCommand(@"SELECT * FROM SYS_OperationLog");

//            DataTable dt = DHelper.ExecuteDataTable(comm);

//            list = Model.ConvertHelper.Data2List<OperationLogInfo>(dt);

//            return list;
//        }


//        /// <summary>
//        /// 插入日志
//        /// </summary>
//        /// yand    15.11.13
//        /// <param name="value"></param>
//        /// <returns></returns>
//        public int Insert(OperationLogInfo value)
//        {
//            SqlCommand comm = DHelper.GetSqlCommand(
//                "INSERT INTO SYS_OperationLog (Type,RE_ID, RE_SID, RE_Module,Content,UI_ID,AddTime) " +
//                "VALUES (@Type,@RE_ID, @RE_SID,@RE_Module,@Content,@UI_ID,default) SELECT SCOPE_IDENTITY() "
//                );
//            Save(value, comm);

//            return (int)DHelper.ExecuteScalar(comm);
//        }

//        protected override void Save(OperationLogInfo value, SqlCommand comm)
//        {
//            DHelper.AddParameter(comm, "@Type", SqlDbType.TinyInt, value.Type);
//            DHelper.AddParameter(comm, "@RE_ID", SqlDbType.Int, value.ReferenceId);
//            DHelper.AddParameter(comm, "@RE_SID", SqlDbType.Int, value.RE_SID);
//            DHelper.AddParameter(comm, "@RE_Module", SqlDbType.TinyInt, value.RE_Module);
//            DHelper.AddParameter(comm, "@Content", SqlDbType.NVarChar, value.Content);
//            DHelper.AddParameter(comm, "@UI_ID", SqlDbType.Int, value.UserId);
//        }
//    }
//}

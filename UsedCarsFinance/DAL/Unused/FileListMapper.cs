//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Model;
//using System.Data.SqlClient;
//using System.Data;
//using DataHelper;

//namespace DAL.System
//{
//    public class FileListMapper : AbstractMapper<FileListInfo>
//    {
       
//        /// <summary>
//        /// 查找附件
//        /// </summary>
//        /// yand    15.11.13
//        /// <param name="id">标识</param>
//        /// <returns></returns>
//        public FileListInfo Find(int id)
//        {
//            string findStatement="SELECT RE_ID,RE_SID,RE_Module,OldName,NewName,ExtName,Path,AddTime FROM SYST_FileList WHERE FL_ID = @FL_ID";
//            //通用方法查找实体
//            return AbstractFind(findStatement,id);
//        }

//        /// <summary>
//        /// 通过RE_ID,RE_Module查询文件列表
//        /// </summary>
//        /// yand    15.12.01
//        /// <param name="RE_ID"></param>
//        /// <param name="RE_Module"></param>
//        /// <returns></returns>
//        public List<FileListInfo> FindByReference(int RE_ID, int RE_Module)
//        {
//            List<FileListInfo> result = new List<FileListInfo>();

//            SqlCommand comm = DHelper.GetSqlCommand(
//                @"SELECT FL_ID,RE_ID,RE_SID,RE_Module,OldName,NewName,ExtName,Path,AddTime FROM SYST_FileList WHERE RE_ID=@RE_ID AND RE_Module=@RE_Module"
//                );
//            DHelper.AddInParameter(comm, "@RE_ID", SqlDbType.Int, RE_ID);
//            DHelper.AddInParameter(comm, "@RE_Module", SqlDbType.Int, RE_Module);

//            return LoadAll(DHelper.ExecuteDataTable(comm).Rows);
//        }

//        /// <summary>
//        /// 附件插入
//        /// </summary>
//        /// yand    15.11.13
//        /// <param name="value"></param>
//        /// <returns></returns>
//        public int Insert(FileListInfo value)
//        {
//            SqlCommand comm = DHelper.GetSqlCommand(
//                "INSERT INTO SYST_FileList (RE_ID, RE_SID, RE_Module,OldName,NewName,ExtName,Path,AddTime) " +
//                "VALUES (@RE_ID, @RE_SID,@RE_Module,@OldName,@NewName,@ExtName,@Path,default) SELECT SCOPE_IDENTITY() "
//                );
//            Save(value, comm);

//            return (int)DHelper.ExecuteScalar(comm);
//        }

//        /// <summary>
//        /// 删除附件
//        /// </summary>
//        /// yand    15.11.13
//        /// <param name="Id">标识</param>
//        /// <returns></returns>
//        public bool Delete(int Id)
//        {
//            SqlCommand comm = DHelper.GetSqlCommand(
//                @"DELETE SYST_FileList WHERE FL_ID = @FL_ID
//				");
//            DHelper.AddParameter(comm, "@FL_ID", SqlDbType.Int, Id);

//            return DHelper.ExecuteNonQuery(comm) > 0;
//        }

//        protected override void Save(FileListInfo value, SqlCommand comm)
//        {
//            DHelper.AddParameter(comm, "@RE_ID", SqlDbType.Int, value.RE_ID);
//            DHelper.AddParameter(comm, "@RE_SID", SqlDbType.Int, value.RE_SID);
//            DHelper.AddParameter(comm, "@RE_Module", SqlDbType.TinyInt, value.RE_Module);
//            DHelper.AddParameter(comm, "@OldName", SqlDbType.NVarChar, value.OldName);
//            DHelper.AddParameter(comm, "@NewName", SqlDbType.NVarChar, value.NewName);
//            DHelper.AddParameter(comm, "@ExtName", SqlDbType.NVarChar, value.ExtName);
//            DHelper.AddParameter(comm, "@Path", SqlDbType.NVarChar, value.Path);
//        }
//    }
//}

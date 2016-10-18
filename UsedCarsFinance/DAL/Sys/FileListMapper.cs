using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Model.Sys;
using Model;

namespace DAL.Sys
{
	public class FileListMapper : AbstractMapper<FileInfo>
	{
		/// <summary>
		/// 查找
		/// </summary>
		/// qiy		16.04.05
		/// <param name="id">文件标识</param>
		/// <returns></returns>
		public FileInfo Find(int id)
		{
			string findStatement =
				"SELECT FL_ID, ReferenceId, OldName, NewName, ExtName, FilePath, AddDate FROM SYS_FileList WHERE FL_ID = @ID";

			return AbstractFind(findStatement, id);
		}
		/// <summary>
		/// 根据被引用信息查找
		/// </summary>
		/// qiy		16.04.05
		/// <param name="referenceId">引用标识</param>
		/// <returns></returns>
		public List<FileInfo> FindByReference(int referenceId)
		{
			SqlCommand comm = DHelper.GetSqlCommand(@"
				SELECT FL_ID, ReferenceId, OldName, NewName, ExtName, FilePath, AddDate FROM SYS_FileList WHERE ReferenceId = @ReferenceId 
			");
			DHelper.AddParameter(comm, "@ReferenceId", SqlDbType.Int, referenceId);

			DataTable dt = DHelper.ExecuteDataTable(comm);

			return LoadAll(dt.Rows);
		}

        /// <summary>
        /// 查询合同名称
        /// </summary>
        /// yand    16.05.17
        /// <param name="referenced"></param>
        /// <returns></returns>
        public List<ComboInfo> FindContrantByReferenced(int referenced)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                    SELECT * FROM SYS_FileList WHERE ReferenceId IN(
                            SELECT ReferenceId FROM SYS_Reference WHERE ReferencedId = @ReferencedId AND ReferencedModule =4)
			");
            DHelper.AddParameter(comm, "@ReferencedId", SqlDbType.Int, referenced);

            DataTable dt = DHelper.ExecuteDataTable(comm);


            List<ComboInfo> list = new List<ComboInfo>();

            foreach (DataRow dr in dt.Rows)
            {
                ComboInfo cbi = new ComboInfo(dr["FL_ID"].ToString(), dr["NewName"].ToString());

                list.Add(cbi);
            }

            return list;
        }

    
		/// <summary>
		/// 插入
		/// </summary>
		/// qiy		16.04.05
		/// <param name="value">值</param>
		public void Insert(FileInfo value)
		{
			SqlCommand comm = DHelper.GetSqlCommand(@"
				INSERT INTO SYS_FileList (ReferenceId, OldName, NewName, ExtName, FilePath, AddDate) 
				VALUES (@ReferenceId, @OldName, @NewName, @ExtName, @FilePath, @AddDate) SELECT SCOPE_IDENTITY()
			");
			DHelper.AddParameter(comm, "@ReferenceId", SqlDbType.Int, value.ReferenceId);
			DHelper.AddParameter(comm, "@OldName", SqlDbType.NVarChar, value.OldName);
			DHelper.AddParameter(comm, "@NewName", SqlDbType.NVarChar, value.NewName);
			DHelper.AddParameter(comm, "@ExtName", SqlDbType.NVarChar, value.ExtName);
			DHelper.AddParameter(comm, "@FilePath", SqlDbType.NVarChar, value.FilePath);
			DHelper.AddParameter(comm, "@AddDate", SqlDbType.DateTime, value.AddDate);

			value.FileId = Convert.ToInt32(DHelper.ExecuteScalar(comm));
		}

		/// <summary>
		/// 删除文件
		/// </summary>
		/// qiy		16.04.05
		/// <param name="fileId">文件标识</param>
		/// <returns></returns>
		public int Delete(int fileId)
		{
			SqlCommand comm = DHelper.GetSqlCommand(
				"DELETE SYS_FileList WHERE FL_ID = @FileId"
			);
			DHelper.AddParameter(comm, "@FileId", SqlDbType.Int, fileId);

			return DHelper.ExecuteNonQuery(comm);
		}
		/// <summary>
		/// 根据外键删除
		/// </summary>
		/// qiy		16.04.05
		/// <param name="referenceId">引用标识</param>
		/// <returns></returns>
		public int DeleteByReference(int referenceId)
		{
			SqlCommand comm = DHelper.GetSqlCommand(
				"DELETE SYS_FileList WHERE ReferenceId = @ReferenceId"
			);
			DHelper.AddParameter(comm, "@ReferenceId", SqlDbType.Int, referenceId);

			return DHelper.ExecuteNonQuery(comm);
		}
	}
}

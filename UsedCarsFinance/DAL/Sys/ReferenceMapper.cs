using System;
using System.Data;
using System.Data.SqlClient;
using Models.Sys;
using System.Collections.Generic;

namespace DAL.Sys
{
	public class ReferenceMapper : AbstractMapper<ReferenceInfo>
	{
		/// <summary>
		/// 查找
		/// </summary>
		/// qiy		16.03.30
		/// <param name="id">引用标识</param>
		/// <returns></returns>
		public ReferenceInfo Find(int id)
		{
			string findStatement =
				"SELECT ReferenceId, ReferencedId, ReferencedModule, ReferencedSid FROM SYS_ReferenceNew WHERE ReferenceId = @ID";

            var sqlCommand= DHelper.GetSqlCommand(findStatement);

            DHelper.AddParameter(sqlCommand, "@ID", SqlDbType.Int, id);

            return Load(DHelper.ExecuteDataTable(sqlCommand));
		}

		/// <summary>
		/// 根据被引用信息查找
		/// </summary>
		/// qiy		16.03.30
		/// <param name="referenced">被引用实例</param>
		/// <returns></returns>
		public ReferenceInfo FindByReferenced(ReferenceInfo referenced)
		{
			SqlCommand comm = DHelper.GetSqlCommand(@"
				SELECT ReferenceId, ReferencedId, ReferencedModule, ReferencedSid FROM SYS_ReferenceNew 
				WHERE ReferencedId = @ReferencedId 
					AND ReferencedModule = @ReferencedModule
					AND (@ReferencedSid IS NULL OR ReferencedSid = @ReferencedSid)
			");
			DHelper.AddParameter(comm, "@ReferencedId", SqlDbType.UniqueIdentifier, referenced.ReferencedId.Value);
			DHelper.AddParameter(comm, "@ReferencedModule", SqlDbType.Int, referenced.ReferencedModule);
			DHelper.AddParameter(comm, "@ReferencedSid", SqlDbType.Int, referenced.ReferencedSid);

			DataTable dt = DHelper.ExecuteDataTable(comm);

			return Load(dt);
		}

		/// <summary>
		/// 插入
		/// </summary>
		/// qiy		16.03.30
		/// <param name="value">值</param>
		public void Insert(ReferenceInfo value)
		{
			SqlCommand comm = DHelper.GetSqlCommand(@"
				INSERT INTO SYS_ReferenceNew (ReferencedId, ReferencedModule, ReferencedSid) 
				VALUES (@ReferencedId, @ReferencedModule, @ReferencedSid) SELECT SCOPE_IDENTITY()
			");
			DHelper.AddParameter(comm, "@ReferencedId", SqlDbType.UniqueIdentifier, value.ReferencedId.Value);
			DHelper.AddParameter(comm, "@ReferencedModule", SqlDbType.Int, value.ReferencedModule);
			DHelper.AddParameter(comm, "@ReferencedSid", SqlDbType.Int, value.ReferencedSid);

			value.ReferenceId = Convert.ToInt32(DHelper.ExecuteScalar(comm).ToString());
		}

		/// <summary>
		/// 更新
		/// </summary>
		/// qiy		16.03.30
		/// <param name="value">值</param>
		/// <returns></returns>
		public int Update(ReferenceInfo value)
		{
			SqlCommand comm = DHelper.GetSqlCommand(@"
				UPDATE SYS_ReferenceNew SET 
					ReferencedId = @ReferencedId,
					ReferencedModule = @ReferencedModule, 
					ReferencedSid = @ReferencedSid 
				WHERE ReferenceId = @ReferenceId
			");
			DHelper.AddParameter(comm, "@ReferenceId", SqlDbType.Int, value.ReferenceId);

			DHelper.AddParameter(comm, "@ReferencedId", SqlDbType.UniqueIdentifier, value.ReferencedId.Value);
			DHelper.AddParameter(comm, "@ReferencedModule", SqlDbType.Int, value.ReferencedModule);
			DHelper.AddParameter(comm, "@ReferencedSid", SqlDbType.Int, value.ReferencedSid);

			return DHelper.ExecuteNonQuery(comm);
		}

        public int Delete(int referenceId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
				DELETE SYS_ReferenceNew WHERE ReferenceId=@ReferenceId
			");
            DHelper.AddParameter(comm, "@ReferenceId", SqlDbType.Int, referenceId);

            return DHelper.ExecuteNonQuery(comm);
        }
	}
}

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
				"SELECT ReferenceId, ReferencedId, ReferencedModule, ReferencedSid FROM SYS_Reference WHERE ReferenceId = @ID";

			return AbstractFind(findStatement, id);
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
				SELECT ReferenceId, ReferencedId, ReferencedModule, ReferencedSid FROM SYS_Reference 
				WHERE ReferencedId = @ReferencedId 
					AND ReferencedModule = @ReferencedModule
					AND (@ReferencedSid IS NULL OR ReferencedSid = @ReferencedSid)
			");
			DHelper.AddParameter(comm, "@ReferencedId", SqlDbType.Int, referenced.ReferencedId);
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
				INSERT INTO SYS_Reference (ReferencedId, ReferencedModule, ReferencedSid) 
				VALUES (@ReferencedId, @ReferencedModule, @ReferencedSid) SELECT SCOPE_IDENTITY()
			");
			DHelper.AddParameter(comm, "@ReferencedId", SqlDbType.Int, value.ReferencedId);
			DHelper.AddParameter(comm, "@ReferencedModule", SqlDbType.Int, value.ReferencedModule);
			DHelper.AddParameter(comm, "@ReferencedSid", SqlDbType.Int, value.ReferencedSid);

			value.ReferenceId = Convert.ToInt32(DHelper.ExecuteScalar(comm));
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
				UPDATE SYS_Reference SET 
					ReferencedId = @ReferencedId,
					ReferencedModule = @ReferencedModule, 
					ReferencedSid = @ReferencedSid 
				WHERE ReferenceId = @ReferenceId
			");
			DHelper.AddParameter(comm, "@ReferenceId", SqlDbType.Int, value.ReferenceId);

			DHelper.AddParameter(comm, "@ReferencedId", SqlDbType.Int, value.ReferencedId);
			DHelper.AddParameter(comm, "@ReferencedModule", SqlDbType.Int, value.ReferencedModule);
			DHelper.AddParameter(comm, "@ReferencedSid", SqlDbType.Int, value.ReferencedSid);

			return DHelper.ExecuteNonQuery(comm);
		}
	}
}

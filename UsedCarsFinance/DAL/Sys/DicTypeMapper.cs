using Model;
using Model.Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Sys
{
	public class DicTypeMapper : AbstractMapper<DictionaryTypeInfo>
	{
		/// <summary>
		/// 查询字典类型
		/// </summary>
		/// yaoy    15.11.30
		/// qiy		15.12.04
        /// qiy     16.04.29    增加Seed字段
		/// <param name="id"></param>
		/// <returns></returns>
		public DictionaryTypeInfo Find(int id)
		{
			SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT DT_ID, Field, Name, IsCommon, Seed FROM SYS_DicType WHERE DT_ID = @DT_ID
            ");
			DHelper.AddParameter(comm, "@DT_ID", SqlDbType.Int, id);

			DataTable dt = DHelper.ExecuteDataTable(comm);

			return Load(dt);
		}

		/// <summary>
		/// 查询列表
		/// </summary>
		/// yaoy    15.11.30
		/// qiy		15.12.04
		/// <returns></returns>
		public DataTable List()
		{
			SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT DT_ID, Field, Name, IsCommon, Seed FROM SYS_DicType
            ");

			return DHelper.ExecuteDataTable(comm);
		}

		/// <summary>
		/// 查询选项
		/// </summary>
		/// qiy		15.12.04
		/// <returns></returns>
		public List<ComboInfo> Option()
		{
			SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT DT_ID, Name FROM SYS_DicType
            ");

			DataTable dt = DHelper.ExecuteDataTable(comm);

			List<ComboInfo> list = new List<ComboInfo>();

			foreach (DataRow dr in dt.Rows)
			{
				ComboInfo cbi = new ComboInfo(dr["DT_ID"].ToString(), dr["Name"].ToString());

				list.Add(cbi);
			}

			return list;
		}

		/// <summary>
		/// 插入
		/// </summary>
		/// qiy		15.12.04
		/// <param name="value"></param>
		/// <returns></returns>
		public void Insert(DictionaryTypeInfo value)
		{
			SqlCommand comm = DHelper.GetSqlCommand(
				"INSERT INTO SYS_DicType (Field, Name, IsCommon, Seed)" +
				"VALUES (@Field, @Name, @IsCommon, @Seed) SELECT SCOPE_IDENTITY()"
 			);

			DHelper.AddInParameter(comm, "@Field", SqlDbType.NVarChar, value.Field);
			DHelper.AddInParameter(comm, "@Name", SqlDbType.NVarChar, value.Name);
			DHelper.AddInParameter(comm, "@IsCommon", SqlDbType.Bit, value.IsCommon);
			DHelper.AddInParameter(comm, "@Seed", SqlDbType.Int, value.Seed);

			value.TypeId =  Convert.ToInt32(DHelper.ExecuteScalar(comm));
		}

		/// <summary>
		/// 更新
		/// </summary>
		/// yaoy    15.11.30
		/// qiy		15.12.04
		/// <param name="value"></param>
		/// <returns></returns>
		public bool Update(DictionaryTypeInfo value)
		{
			SqlCommand comm = DHelper.GetSqlCommand(
				@"UPDATE SYS_DicType SET
 					Field = @Field,
					Name = @Name,
					IsCommon = @IsCommon,
					Seed = @Seed
 				WHERE DT_ID = @TypeId
			");
			DHelper.AddParameter(comm, "@TypeId", SqlDbType.Int, value.TypeId);

			DHelper.AddInParameter(comm, "@Field", SqlDbType.NVarChar, value.Field);
			DHelper.AddInParameter(comm, "@Name", SqlDbType.NVarChar, value.Name);
			DHelper.AddInParameter(comm, "@IsCommon", SqlDbType.Bit, value.IsCommon);
			DHelper.AddInParameter(comm, "@Seed", SqlDbType.Int, value.Seed);

			return DHelper.ExecuteNonQuery(comm) > 0;
		}
	}
}

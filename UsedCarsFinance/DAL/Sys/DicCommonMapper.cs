using Model.Sys;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Sys
{
	public class DicCommonMapper : AbstractMapper<DictionaryInfo>
	{
		/// <summary>
		///	查询字典
		/// </summary>
		/// qiy		15.12.04
		/// <param name="type">字典类型</param>
		/// <param name="code">字典编号</param>
		/// <returns></returns>
		public DictionaryInfo Find(int type, int code)
		{
			SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT Type, Code, Name, Remarks FROM SYS_DicCommon
                WHERE Type = @Type AND Code = @Code
            ");
			DHelper.AddParameter(comm, "@Type", SqlDbType.Int, type);
			DHelper.AddParameter(comm, "@Code", SqlDbType.Int, code);

			DataTable dt = DHelper.ExecuteDataTable(comm);

			return Load(dt);
		}

		/// <summary>
		/// 插入
		/// </summary>
		/// yaoy    15.12.01
		/// qiy		15.12.03
		/// <param name="value"></param>
		/// <returns></returns>
		public void Insert(DictionaryInfo value)
        {
			SqlCommand comm = DHelper.GetSqlCommand(
				"INSERT INTO SYS_DicCommon (Type, Code, Name, Remarks)" +
				"VALUES (@Type, @Code, @Name, @Remarks)"
				);
			DHelper.AddParameter(comm, "@Type", SqlDbType.Int, value.Type);
			DHelper.AddParameter(comm, "@Code", SqlDbType.Int, value.Code);
			DHelper.AddParameter(comm, "@Name", SqlDbType.NVarChar, value.Name);
			DHelper.AddParameter(comm, "@Remarks", SqlDbType.NVarChar, value.Remarks);

			DHelper.ExecuteNonQuery(comm);
        }

		/// <summary>
		/// 更新
		/// </summary>
		/// yaoy    15.11.30
		/// qiy		15.12.03
		/// <param name="value"></param>
		/// <returns></returns>
		public bool Update(DictionaryInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(
				@"UPDATE SYS_DicCommon SET
					Name = @Name,
					Remarks = @Remarks
 				WHERE Type = @Type AND Code = @Code
			");
			DHelper.AddParameter(comm, "@Type", SqlDbType.Int, value.Type);
			DHelper.AddParameter(comm, "@Code", SqlDbType.Int, value.Code);

			DHelper.AddParameter(comm, "@Name", SqlDbType.NVarChar, value.Name);
			DHelper.AddParameter(comm, "@Remarks", SqlDbType.NVarChar, value.Remarks);

            return DHelper.ExecuteNonQuery(comm) > 0;
        }

		/// <summary>
		/// 集合
		/// </summary>
		/// yaoy    15.11.30
		/// qiy		15.12.03
		/// <returns></returns>
		public DataTable List()
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT Field, Type, sdt.Name AS TypeName, Code, sdc.Name, Remarks FROM SYS_DicCommon AS sdc
                   LEFT JOIN SYS_DicType AS sdt ON sdt.DT_ID = sdc.Type
            ");

            return DHelper.ExecuteDataTable(comm);
        }
    }
}

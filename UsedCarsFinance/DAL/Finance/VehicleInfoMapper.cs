using System;
using System.Data;
using System.Data.SqlClient;
using Models.Finance;

namespace DAL.Finance
{
	public class VehicleInfoMapper : AbstractMapper<VehicleInfo>
	{
		/// <summary>
		/// 查找
		/// </summary>
		/// qiy		16.03.31
		/// <param name="financeId">融资标识</param>
		/// <returns></returns>
		public VehicleInfo Find(int financeId)
		{
			string findStatement =
				"SELECT VehicleKey, BuyCarPrice, RegisterCity, SallerName, PlateNo, FrameNo, EngineNo, RegisterDate, RunningMiles, FactoryDate, BuyCarYears, Color FROM FANC_VehicleInfo WHERE FinanceId = @ID";

			return AbstractFind(findStatement, financeId);
		}

		/// <summary>
		/// 插入
		/// </summary>
		/// qiy		16.03.31
		/// <param name="financeId">融资标识</param>
		/// <param name="value">值</param>
		public void Insert(int financeId, VehicleInfo value)
		{
			SqlCommand comm = DHelper.GetSqlCommand(@"
				INSERT INTO FANC_VehicleInfo (FinanceId, VehicleKey, BuyCarPrice, RegisterCity, SallerName, PlateNo, FrameNo, EngineNo, RegisterDate, RunningMiles, FactoryDate, BuyCarYears, Color) 
				VALUES (@FinanceId, @VehicleKey, @BuyCarPrice, @RegisterCity, @SallerName, @PlateNo, @FrameNo, @EngineNo, @RegisterDate, @RunningMiles, @FactoryDate, @BuyCarYears, @Color)
			");
			DHelper.AddParameter(comm, "@FinanceId", SqlDbType.Int, financeId);
			DHelper.AddParameter(comm, "@VehicleKey", SqlDbType.NVarChar, value.VehicleKey);
			DHelper.AddParameter(comm, "@BuyCarPrice", SqlDbType.NVarChar, value.BuyCarPrice);
			DHelper.AddParameter(comm, "@RegisterCity", SqlDbType.NVarChar, value.RegisterCity);
			DHelper.AddParameter(comm, "@SallerName", SqlDbType.NVarChar, value.SallerName);
			DHelper.AddParameter(comm, "@PlateNo", SqlDbType.NVarChar, value.PlateNo);
			DHelper.AddParameter(comm, "@FrameNo", SqlDbType.NVarChar, value.FrameNo);
			DHelper.AddParameter(comm, "@EngineNo", SqlDbType.NVarChar, value.EngineNo);
			DHelper.AddParameter(comm, "@RegisterDate", SqlDbType.NVarChar, value.RegisterDate);
			DHelper.AddParameter(comm, "@RunningMiles", SqlDbType.NVarChar, value.RunningMiles);
			DHelper.AddParameter(comm, "@FactoryDate", SqlDbType.NVarChar, value.FactoryDate);
			DHelper.AddParameter(comm, "@BuyCarYears", SqlDbType.NVarChar, value.BuyCarYears);
			DHelper.AddParameter(comm, "@Color", SqlDbType.NVarChar, value.Color);

			DHelper.ExecuteNonQuery(comm);
		}

		/// <summary>
		/// 更新
		/// </summary>
		/// qiy		16.03.31
		/// <param name="financeId">融资标识</param>
		/// <param name="value">值</param>
		/// <returns></returns>
		public int Update(int financeId, VehicleInfo value)
		{
			SqlCommand comm = DHelper.GetSqlCommand(@"
				UPDATE FANC_VehicleInfo SET 
					VehicleKey = @VehicleKey,
					BuyCarPrice = @BuyCarPrice,
					RegisterCity = @RegisterCity,
					SallerName = @SallerName,
					PlateNo = @PlateNo,
					FrameNo = @FrameNo,
					EngineNo = @EngineNo,
					RegisterDate = @RegisterDate,
					RunningMiles = @RunningMiles,
					FactoryDate = @FactoryDate,
					BuyCarYears = @BuyCarYears, 
					Color = @Color 
				WHERE FinanceId = @FinanceId
			");
			DHelper.AddParameter(comm, "@FinanceId", SqlDbType.Int, financeId);

			DHelper.AddParameter(comm, "@VehicleKey", SqlDbType.NVarChar, value.VehicleKey);
			DHelper.AddParameter(comm, "@BuyCarPrice", SqlDbType.NVarChar, value.BuyCarPrice);
			DHelper.AddParameter(comm, "@RegisterCity", SqlDbType.NVarChar, value.RegisterCity);
			DHelper.AddParameter(comm, "@SallerName", SqlDbType.NVarChar, value.SallerName);
			DHelper.AddParameter(comm, "@PlateNo", SqlDbType.NVarChar, value.PlateNo);
			DHelper.AddParameter(comm, "@FrameNo", SqlDbType.NVarChar, value.FrameNo);
			DHelper.AddParameter(comm, "@EngineNo", SqlDbType.NVarChar, value.EngineNo);
			DHelper.AddParameter(comm, "@RegisterDate", SqlDbType.NVarChar, value.RegisterDate);
			DHelper.AddParameter(comm, "@RunningMiles", SqlDbType.NVarChar, value.RunningMiles);
			DHelper.AddParameter(comm, "@FactoryDate", SqlDbType.NVarChar, value.FactoryDate);
			DHelper.AddParameter(comm, "@BuyCarYears", SqlDbType.NVarChar, value.BuyCarYears);
			DHelper.AddParameter(comm, "@Color", SqlDbType.NVarChar, value.Color);

			return DHelper.ExecuteNonQuery(comm);
		}

        /// <summary>
        /// 删除
        /// </summary>
        /// qiy     16.04.11
        /// <param name="financeId">融资标识</param>
        /// <returns></returns>
        public int Delete(int financeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
				DELETE FANC_VehicleInfo WHERE FinanceId = @FinanceId
			");
            DHelper.AddParameter(comm, "@FinanceId", SqlDbType.Int, financeId);

            return DHelper.ExecuteNonQuery(comm);
        }
    }
}

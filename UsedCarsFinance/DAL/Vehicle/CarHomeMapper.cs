using DataHelper;
using Models;
using Models.Finance;
using Models.Vehicle;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Vehicle
{
    public class CarHomeMapper
    {
        SQLHelper carHomeHelper = new SQLHelper(new WebConfigure("connHomeCar"));

        /// <summary>
        /// 查询车辆品牌
        /// </summary>
        /// yand    16.07.25
        /// <returns></returns>
        public List<ComboInfo> GetBrand()
        {
            List<ComboInfo> list = new List<ComboInfo>();

            SqlCommand comm = carHomeHelper.GetSqlCommand(@"
                SELECT BrandCode,CarBrand FROM Sys_Brand ORDER BY CarBrand ASC
            ");

            DataTable dt = carHomeHelper.ExecuteDataTable(comm);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ComboInfo cbi = new ComboInfo(dr["BrandCode"].ToString(), dr["CarBrand"].ToString());
                    list.Add(cbi);
                }
            }

            return list;
        }

        /// <summary>
        /// 根据车辆品牌查询车辆系列
        /// </summary>
        /// yand    16.07.25
        /// <param name="brandCode">品牌ID</param>
        /// <returns></returns>
        public List<ComboInfo> GetSeries(string brandCode)
        {
            List<ComboInfo> list = new List<ComboInfo>();

            SqlCommand comm = carHomeHelper.GetSqlCommand(@"
                SELECT SeriesCode,Series FROM Sys_Series WHERE BrandCode = @SeriesCode ORDER BY Series ASC
            ");
            carHomeHelper.AddInParameter(comm, "@SeriesCode", SqlDbType.NVarChar, brandCode);
            DataTable dt = carHomeHelper.ExecuteDataTable(comm);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ComboInfo cbi = new ComboInfo(dr["SeriesCode"].ToString(), dr["Series"].ToString());
                    list.Add(cbi);
                }
            }

            return list;
        }

        /// <summary>
        /// 根据车辆系列ID和车辆品牌查询车辆车型
        /// </summary>
        /// <param name="BrandCode">品牌ID</param>
        /// <param name="ModelID">系列ID</param>
        /// <returns></returns>
        public List<ComboInfo> GetVehicle(string brandCode, string seriesCode)
        {
            List<ComboInfo> list = new List<ComboInfo>();

            SqlCommand comm = carHomeHelper.GetSqlCommand(@"
                SELECT VehicleCode,Vehicle FROM Sys_Vehicle WHERE BrandCode=@BrandCode AND SeriesCode=@SeriesCode ORDER BY Vehicle ASC
            ");
            carHomeHelper.AddInParameter(comm, "@BrandCode", SqlDbType.NVarChar, brandCode);
            carHomeHelper.AddInParameter(comm, "@SeriesCode", SqlDbType.NVarChar, seriesCode);

            DataTable dt = carHomeHelper.ExecuteDataTable(comm);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ComboInfo cbi = new ComboInfo(dr["VehicleCode"].ToString(), dr["Vehicle"].ToString());
                    list.Add(cbi);
                }
            }

            return list;
        }

        /// <summary>
        /// 根据车辆ID获取品牌，系列
        /// </summary>
        /// yand    16.07.25
        /// <param name="vehicleKey"></param>
        /// <returns></returns>
        public CarHomeInfo FindCarInfo(string vehicleKey)
        {
            CarHomeInfo carHome = new CarHomeInfo();

            SqlCommand comm = carHomeHelper.GetSqlCommand(@"
                SELECT sv.Vehicle,ss.Series,sb.CarBrand FROM Sys_Vehicle AS sv
                    LEFT JOIN Sys_Series AS ss ON sv.SeriesCode = ss.SeriesCode
                    LEFT JOIN Sys_Brand AS sb ON sb.BrandCode = ss.BrandCode
                WHERE sv.VehicleCode =@VehicleKey
            ");
            carHomeHelper.AddInParameter(comm, "@VehicleKey", SqlDbType.NVarChar, vehicleKey);

            DataTable dt = carHomeHelper.ExecuteDataTable(comm);

            if (dt.Rows.Count > 0)
            {
                carHome = ConvertHelper.Data2Model<CarHomeInfo>(dt.Rows[0]);
            }

            return carHome;
        }

        /// <summary>
        /// 根据车型选择厂商指导价格
        /// </summary>
        /// yand    16.07.25
        /// <param name="vehicleKey"></param>
        /// <returns></returns>
        public ConfigInfo GetPriceByVehicleID(string vehicleKey)
        {
            ConfigInfo configInfo = new ConfigInfo();
            SqlCommand comm = carHomeHelper.GetSqlCommand(@"
                SELECT * FROM Sys_CarConfig WHERE VehicleCode = @VehicleKey
            ");
            carHomeHelper.AddInParameter(comm, "@VehicleKey", SqlDbType.NVarChar, vehicleKey);

            DataTable dt = carHomeHelper.ExecuteDataTable(comm);

            if (dt.Rows.Count > 0)
            {
                configInfo = ConvertHelper.Data2Model<ConfigInfo>(dt.Rows[0]);
            }

            return configInfo;
        }

        /// <summary>
        /// 通过VehicleKey获取品牌ID,系列ID
        /// </summary>
        /// yand    16.07.25
        /// <param name="vehicleKey"></param>
        /// <returns></returns>
        public VehicleInfo Find(string vehicleKey)
        {
            VehicleInfo vehicle = new VehicleInfo();

            SqlCommand comm = carHomeHelper.GetSqlCommand(@"
                SELECT BrandCode AS MakeCode,SeriesCode AS  FamilyCode FROM Sys_Vehicle WHERE Sys_Vehicle.VehicleCode = @VehicleKey
            ");
            carHomeHelper.AddInParameter(comm, "@VehicleKey", SqlDbType.NVarChar, vehicleKey);

            DataTable dt = carHomeHelper.ExecuteDataTable(comm);

            if (dt.Rows.Count > 0)
            {
                vehicle = ConvertHelper.Data2Model<VehicleInfo>(dt.Rows[0]);
            }

            return vehicle;
        }
    }
}

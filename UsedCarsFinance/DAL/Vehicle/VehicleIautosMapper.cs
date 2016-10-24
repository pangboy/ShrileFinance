using System.Collections.Generic;
using Models;
using Models.Vehicle;
using System.Data;
using System.Data.SqlClient;
using DataHelper;
using System;
using Models.Finance;

namespace DAL.Vehicle
{
    public class VehicleIautosMapper
    {
        /// <summary>
        /// 品牌
        /// </summary>
        /// <returns></returns>
        public List<ComboInfo> MakeOption()
        {
            List<ComboInfo> list = new List<ComboInfo>();
            SQLHelper iautosHelper = new SQLHelper(new WebConfigure("connIautos"));

            SqlCommand comm = iautosHelper.GetSqlCommand(@"
                SELECT BrandID,BrandName FROM IautosBrandInfo ORDER BY BrandName ASC
            ");

            DataTable dt = iautosHelper.ExecuteDataTable(comm);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ComboInfo cbi = new ComboInfo(dr["BrandID"].ToString(), dr["BrandName"].ToString());

                    list.Add(cbi);
                }
            }
               
            return list;
        }

        /// <summary>
        /// 系列
        /// </summary>
        /// <param name="makeCode"></param>
        /// <returns></returns>
        public List<ComboInfo> FamilyOption(string makeCode)
        {
            List<ComboInfo> list = new List<ComboInfo>();
            SQLHelper iautosHelper = new SQLHelper(new WebConfigure("connIautos"));

            SqlCommand comm = iautosHelper.GetSqlCommand(@"
                 SELECT SeriesID,SeriesName FROM IautosSeriesInfo WHERE BrandID = @BrandID ORDER BY SeriesName ASC
            ");
            iautosHelper.AddInParameter(comm, "@BrandID", SqlDbType.Int, makeCode);

            DataTable dt = iautosHelper.ExecuteDataTable(comm);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ComboInfo cbi = new ComboInfo(dr["SeriesID"].ToString(), dr["SeriesName"].ToString());

                    list.Add(cbi);
                }
            }

            return list;

        }

        /// <summary>
        /// 年款
        /// </summary>
        /// <param name="makeCode"></param>
        /// <param name="familyCode"></param>
        /// <returns></returns>
        public List<ComboInfo> YearOption(string makeCode, string familyCode)
        {
            List<ComboInfo> list = new List<ComboInfo>();
            SQLHelper iautosHelper = new SQLHelper(new WebConfigure("connIautos"));
                
            SqlCommand comm = iautosHelper.GetSqlCommand(@"
                SELECT yi.ID,yi.Year FROM IautosYearInfo AS yi
                     LEFT JOIN IautosSeriesInfo AS si ON si.SeriesID = yi.SeriesID
                WHERE si.SeriesID = @SeriesID AND si.BrandID = @BrandID
                ORDER BY Year DESC
            ");
            iautosHelper.AddInParameter(comm, "@BrandID", SqlDbType.Int, makeCode);
            iautosHelper.AddInParameter(comm, "@SeriesID", SqlDbType.Int, familyCode);

            DataTable dt = iautosHelper.ExecuteDataTable(comm);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ComboInfo cbi = new ComboInfo(dr["ID"].ToString(), dr["Year"].ToString());

                    list.Add(cbi);
                }
            }

            return list;
        }

        /// <summary>
        /// 车型
        /// </summary>
        /// <param name="makeCode"></param>
        /// <param name="familyCode"></param>
        /// <param name="yearCode"></param>
        /// <returns></returns>
        public List<ComboInfo> VehicleOption(string makeCode, string familyCode, string yearCode)
        {
            List<ComboInfo> list = new List<ComboInfo>();
            SQLHelper iautosHelper = new SQLHelper(new WebConfigure("connIautos"));

            SqlCommand comm = iautosHelper.GetSqlCommand(@"
                SELECT si.ID,si.SpecialName FROM IautosSpecialInfo AS si
                    LEFT JOIN IautosSeriesInfo AS isi ON isi.SeriesID = si.SeriesID
                    LEFT JOIN IautosYearInfo AS yin ON yin.ID = si.yearsID
                WHERE isi.BrandID = @BrandID
                  AND si.SeriesID = @SeriesID 
                  AND yin.ID = @YearID
                ORDER BY si.Year DESC
            ");
            iautosHelper.AddInParameter(comm, "@BrandID", SqlDbType.Int, makeCode);
            iautosHelper.AddInParameter(comm, "@SeriesID", SqlDbType.Int, familyCode);
            iautosHelper.AddInParameter(comm, "@YearID", SqlDbType.Int, yearCode);

            DataTable dt = iautosHelper.ExecuteDataTable(comm);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ComboInfo cbi = new ComboInfo(dr["ID"].ToString(), dr["SpecialName"].ToString());

                    list.Add(cbi);
                }
            }

            return list;
        }

        /// <summary>
        /// 通过VehicleKey获取品牌ID,系列ID,年款ID
        /// </summary>
        /// yaoy    16.04.07
        /// <param name="vehicleKey"></param>
        /// <returns></returns>
        public VehicleInfo Find(string vehicleKey)
        { 
            VehicleInfo vehicle =new VehicleInfo();
            SQLHelper iautosHelper = new SQLHelper(new WebConfigure("connIautos"));

            SqlCommand comm = iautosHelper.GetSqlCommand(@"
                SELECT CAST(isi.BrandID AS VARCHAR) AS MakeCode, si.SeriesID AS FamilyCode,CAST(si.yearsID AS VARCHAR) AS YearCode  FROM IautosSpecialInfo AS si
                    LEFT JOIN IautosSeriesInfo AS isi ON isi.SeriesID = si.SeriesID
                WHERE si.ID = @VehicleKey
            ");
            iautosHelper.AddInParameter(comm, "@VehicleKey", SqlDbType.Int, vehicleKey);

            DataTable dt = iautosHelper.ExecuteDataTable(comm);

            if (dt.Rows.Count > 0)
            {
                vehicle = ConvertHelper.Data2Model<VehicleInfo>(dt.Rows[0]);

            }

            return vehicle;
        }

        /// <summary>
        /// 根据车辆ID获取品牌，系列
        /// </summary>
        /// yand    16.05.13
        /// <param name="vehicleKey"></param>
        /// <returns></returns>
        public VehicleDescInfo FindDesc(string vehicleKey)
        {
            VehicleDescInfo vehicle = new VehicleDescInfo();
            SQLHelper iautosHelper = new SQLHelper(new WebConfigure("connIautos"));

            SqlCommand comm = iautosHelper.GetSqlCommand(@"
                SELECT isi.brand, si.SpecialName,si.Year  FROM IautosSpecialInfo AS si
                    LEFT JOIN IautosSeriesInfo AS isi ON isi.SeriesID = si.SeriesID
                    LEFT JOIN IautosBrandInfo AS ib ON ib.BrandID = isi.BrandID
                WHERE si.ID = @VehicleKey
            ");
            iautosHelper.AddInParameter(comm, "@VehicleKey", SqlDbType.Int, vehicleKey);

            DataTable dt = iautosHelper.ExecuteDataTable(comm);

            if (dt.Rows.Count > 0)
            {
                vehicle = ConvertHelper.Data2Model<VehicleDescInfo>(dt.Rows[0]);

            }

            return vehicle;
        }

        /// <summary>
        /// 获取新车价格
        /// </summary>
        /// yaoy    16.04.08
        /// <param name="vehicleKey"></param>
        /// <returns></returns>
        public decimal FindNewVehicleIautosPrice(int vehicleKey)
        {
            SQLHelper iautosHelper = new SQLHelper(new WebConfigure("connIautos"));

            SqlCommand comm = iautosHelper.GetSqlCommand(@"
                SELECT TOP(1) NewCarPrice FROM CarSeriesRegionPrice WHERE  SpecialID = @VehicleKey
            ");
            iautosHelper.AddInParameter(comm, "@VehicleKey", SqlDbType.Int, vehicleKey);

            string temp = Convert.ToString(iautosHelper.ExecuteScalar(comm));

            return Convert.ToDecimal(0 + temp);
        }

        /// <summary>
        /// 获取二手车价格
        /// </summary>
        /// yaoy    16.04.08
        /// <param name="vehicleKey"></param>
        /// <param name="cityName"></param>
        /// <returns></returns>
        public decimal FindUsedVehicleIautosPrice(int vehicleKey, string cityName)
        {
            SQLHelper iautosHelper = new SQLHelper(new WebConfigure("connIautos"));

            SqlCommand comm = iautosHelper.GetSqlCommand(@"
                SELECT TOP(1) BuyPrice FROM CarSeriesRegionPrice 
                WHERE  SpecialID = @VehicleKey AND CityName = @CityName
            ");
            iautosHelper.AddInParameter(comm, "@VehicleKey", SqlDbType.Int, vehicleKey);
            iautosHelper.AddInParameter(comm, "@CityName", SqlDbType.VarChar, "北京");

            string temp = Convert.ToString(iautosHelper.ExecuteScalar(comm));

            return Convert.ToDecimal(0 + temp);
        }
    }
}

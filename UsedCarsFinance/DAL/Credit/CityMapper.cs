using Model;
using Model.Credit;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Credit
{
    /// <summary>
    /// 城市类
    /// </summary>
    /// cais    16.05.09
    public class CityMapper : AbstractMapper<CityInfo>
    {
        /// <summary>
        /// 查找城市代码，用于生成合同
        /// </summary>
        /// cais    16.05.09
        /// <returns></returns>
        public DataTable Find(string citycode)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
               SELECT  CityCode , CityName  FROM CRET_Cities WHERE CityCode=@CityCode
            ");
            DHelper.AddParameter(comm, "@CityCode", SqlDbType.NVarChar, citycode);

            return DHelper.ExecuteDataTable(comm);
        }

        /// <summary>
        /// 查询所有的省，用于页面
        /// </summary>
        /// cais    16.05.09
        /// <returns></returns>
        public List<ComboInfo> FindProvince()
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
              SELECT ProvinceCode,ProvinceName FROM  CRET_Cities GROUP BY ProvinceCode,ProvinceName
            ");

            DataTable dt = DHelper.ExecuteDataTable(comm);

            List<ComboInfo> list = new List<ComboInfo>();

            foreach (DataRow dr in dt.Rows)
            {
                ComboInfo cbi = new ComboInfo(dr["ProvinceCode"].ToString(), dr["ProvinceName"].ToString());

                list.Add(cbi);
            }

            return list;
        }

        /// <summary>
        /// 通过省查询市，用于页面  列表(Combo)
        /// </summary>
        /// cais    16.05.09
        /// <returns></returns>
        public List<ComboInfo> FindCitys(int ProvinceCode)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
             SELECT CityCode,CityName FROM CRET_Cities WHERE ProvinceCode =@ProvinceCode
            ");
            DHelper.AddParameter(comm, "@ProvinceCode", SqlDbType.Int, ProvinceCode);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            List<ComboInfo> list = new List<ComboInfo>();

            foreach (DataRow dr in dt.Rows)
            {
                ComboInfo cbi = new ComboInfo(dr["CityCode"].ToString(), dr["CityName"].ToString());

                list.Add(cbi);
            }

            return list;
        }

        /// <summary>
        /// 通过市区代码查询市，用于页面列表(Combo)
        /// </summary>
        /// cais    16.05.09
        /// <returns></returns>
        public List<ComboInfo> FindCity(int CityCode)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
             SELECT CityCode,CityName FROM CRET_Cities WHERE CityCode =@CityCode
            ");
            DHelper.AddParameter(comm, "@CityCode", SqlDbType.Int, CityCode);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            List<ComboInfo> list = new List<ComboInfo>();

            foreach (DataRow dr in dt.Rows)
            {
                ComboInfo cbi = new ComboInfo(dr["CityCode"].ToString(), dr["CityName"].ToString());

                list.Add(cbi);
            }

            return list;
        }
    }
}
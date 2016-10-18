using Model;
using Model.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Vehicle
{
  public  class CarHome
    {
        private static readonly DAL.Vehicle.CarHomeMapper carHomeMapper = new DAL.Vehicle.CarHomeMapper();

        /// <summary>
        /// 查询车辆品牌
        /// </summary>
        /// yand    16.07.25
        /// <returns></returns>
        public List<ComboInfo> GetBrand()
        {
            return carHomeMapper.GetBrand();
        }

        /// <summary>
        /// 获取车辆系列
        /// </summary>
        /// yand    16.07.25
        /// <param name="BrandID"></param>
        /// <returns></returns>
        public  List<ComboInfo> GetSeries(string BrandID)
        {
            return carHomeMapper.GetSeries(BrandID);
        }

        /// <summary>
        /// 获取车辆车型
        /// </summary>
        /// yand    16.07.25
        /// <param name="BrandID"></param>
        /// <param name="ModelID"></param>
        /// <returns></returns>
        public List<ComboInfo> GetVehicle(string BrandID, string ModelID)
        {
            return carHomeMapper.GetVehicle(BrandID, ModelID);
        }

        /// <summary>
        /// 根据VehicleID查询车辆车型，品牌，系列信息
        /// </summary>
        /// yand    16.07.26
        /// <param name="VehicleKey"></param>
        /// <returns></returns>
        public CarHomeInfo FindCarInfo(string VehicleKey)
        {
            return carHomeMapper.FindCarInfo(VehicleKey);
        }

        /// <summary>
        /// 根据车辆车型查询厂商指导价
        /// </summary>
        /// yand    16.07.28
        /// <param name="VehicleKey"></param>
        /// <returns></returns>
        public ConfigInfo GetPriceByVehicleID (string VehicleKey)
        {
            return carHomeMapper.GetPriceByVehicleID(VehicleKey);
        }
     } 
}

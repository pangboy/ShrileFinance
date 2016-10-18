using Model;
using Model.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers.Vehicle
{
    public class CarHomeController : ApiController
    {
        private readonly static BLL.Vehicle.CarHome _carHome = new BLL.Vehicle.CarHome();

        /// <summary>
        /// 品牌
        /// </summary>
        /// yand    16.07.25
        /// <returns></returns>
        [HttpGet]
        public List<ComboInfo> GetBrand()
        {
            return _carHome.GetBrand();
        }

        /// <summary>
        /// 系列
        /// </summary>
        /// yand    16.07.25
        /// <param name="BrandID">品牌ID</param>
        /// <returns></returns>
		[HttpGet]
        public List<ComboInfo> GetSeries(string brandCode)
        {
            return _carHome.GetSeries(brandCode);
        }

        /// <summary>
        /// 车型
        /// </summary>
        /// yand    16.07.25
        /// <param name="BrandID">品牌ID</param>
        /// <param name="ModelID">系列ID</param>
        /// <returns></returns>
		[HttpGet]
        public List<ComboInfo> GetVehicle(string brandCode, string seriesCode)
        {
            return _carHome.GetVehicle(brandCode, seriesCode);
        }

        /// <summary>
        /// 根据车辆车型获取车辆品牌系列车型信息
        /// </summary>
        /// yand    16.07.25
        /// <param name="VehicleKey">车型ID</param>
        /// <returns></returns>
        [HttpGet]
        public CarHomeInfo GetCarConfigure(string VehicleCode)
        {
            return _carHome.FindCarInfo(VehicleCode);
        }

        /// <summary>
        /// 加载车辆评估信息
        /// </summary>
        /// yaoy    16.08.02
        /// <param name="vehicleKey"></param>
        /// <returns></returns>
        [HttpGet]
        public ConfigInfo GetPriceByVehicleID(string vehicleKey)
        {
            return _carHome.GetPriceByVehicleID(vehicleKey);
        }
    }
}

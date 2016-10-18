using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model;

namespace Web.Controllers.Vehicle
{
    public class VehicleIautosController : ApiController
    {
        private readonly static BLL.Vehicle.VehicleIautos _vehicle = new BLL.Vehicle.VehicleIautos();

        /// <summary>
        /// 品牌
        /// </summary>
        /// yaoy    16.04.07
        /// <returns></returns>
        [HttpGet]
		public List<ComboInfo> GetMake()
		{
            return _vehicle.MakeOption();
        }

        /// <summary>
        /// 系列
        /// </summary>
        /// yaoy    16.04.07
        /// <param name="makeCode"></param>
        /// <returns></returns>
		[HttpGet]
		public List<ComboInfo> GetFamily(string makeCode)
		{
            return _vehicle.FamilyOption(makeCode);
		}

        /// <summary>
        /// 年款
        /// </summary>
        /// yaoy    16.04.07
        /// <param name="makeCode"></param>
        /// <param name="familyCode"></param>
        /// <returns></returns>
		[HttpGet]
		public List<ComboInfo> GetYear(string makeCode, string familyCode)
		{
            return _vehicle.YearOption(makeCode, familyCode);
		}

        /// <summary>
        /// 车型
        /// </summary>
        /// yaoy    16.04.07
        /// <param name="makeCode"></param>
        /// <param name="familyCode"></param>
        /// <param name="yearCode"></param>
        /// <returns></returns>
		[HttpGet]
		public List<ComboInfo> GetVehicle(string makeCode, string familyCode, string yearCode)
		{
            return _vehicle.VehicleOption(makeCode, familyCode, yearCode);
		}

        /// <summary>
        /// 获取第一车网新车价格
        /// </summary>
        /// yaoy    16.04.08
        /// <param name="vehicleKey"></param>
        /// <returns></returns>
        [HttpGet]
        public decimal GetNewVehiclePrice(int vehicleKey)
        {
            return _vehicle.GetNewVehicleIautosPrice(vehicleKey);
        }

        /// <summary>
        /// 获取第一车网二手车价格
        /// </summary>
        /// yaoy    16.04.08
        /// <param name="vehicleKey"></param>
        /// <param name="cityName"></param>
        /// <returns></returns>
        [HttpGet]
        public decimal GetUsedVehiclePrice(int vehicleKey,string cityName)
        {
            return _vehicle.GetUsedVehicleIautosPrice(vehicleKey, cityName);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Finance;
using Models.Vehicle;
using System.Data;

namespace BLL.Vehicle
{
    public class VehicleIautos : IVehicleOption
    {
        public static readonly DAL.Vehicle.VehicleIautosMapper vehicleIautosMapper = new DAL.Vehicle.VehicleIautosMapper();
        /// <summary>
        /// 品牌
        /// </summary>
        /// yaoy  16.04.07
        /// <returns></returns>
        public List<ComboInfo> MakeOption()
        {
            return vehicleIautosMapper.MakeOption();
        }

        /// <summary>
        /// 系列
        /// </summary>
        /// yaoy    16.04.07
        /// <param name="MakeCode"></param>
        /// <returns></returns>
        public List<ComboInfo> FamilyOption(string MakeCode)
        {
            return vehicleIautosMapper.FamilyOption(MakeCode);
        }

        /// <summary>
        /// 年款
        /// </summary>
        /// yaoy 16.04.07
        /// <param name="MakeCode"></param>
        /// <param name="FamilyCode"></param>
        /// <returns></returns>
        public List<ComboInfo> YearOption(string MakeCode, string FamilyCode)
        {
            return vehicleIautosMapper.YearOption(MakeCode, FamilyCode);
        }

        /// <summary>
        /// 车型
        /// </summary>
        /// yaoy    16.04.07
        /// <param name="MakeCode"></param>
        /// <param name="FamilyCode"></param>
        /// <param name="YearCode"></param>
        /// <returns></returns>
        public List<ComboInfo> VehicleOption(string MakeCode, string FamilyCode, string YearCode)
        {
            return vehicleIautosMapper.VehicleOption(MakeCode, FamilyCode, YearCode);
        }

        /// <summary>
        /// 获取车辆品牌ID,系列ID,年款ID
        /// </summary>
        /// yaoy    16.04.07
        /// yand    16.07.25 改数据库链接以及查询方法
        /// <param name="vehicle"></param>
        public void Get(IVehicleInfo vehicle)
        {
            //VehicleInfo vehicleInfo= vehicleIautosMapper.Find(vehicle.VehicleKey);
            VehicleInfo vehicleInfo =new  DAL.Vehicle.CarHomeMapper().Find(vehicle.VehicleKey);

            vehicle.MakeCode = vehicleInfo.MakeCode;
            vehicle.FamilyCode = vehicleInfo.FamilyCode;
            vehicle.YearCode = vehicleInfo.YearCode;
        }


        /// <summary>
        /// 获取新车价格
        /// </summary>
        /// yaoy    16.04.08
        /// <param name="vehicleKey"></param>
        /// <returns></returns>
        public decimal GetNewVehicleIautosPrice(int vehicleKey)
        {
            return vehicleIautosMapper.FindNewVehicleIautosPrice(vehicleKey) * 10000;
        }

        /// <summary>
        /// 获取二手车价格
        /// </summary>
        /// yaoy    16.04.08
        /// <param name="vehicleKey"></param>
        /// <param name="cityName"></param>
        /// <returns></returns>
        public decimal GetUsedVehicleIautosPrice(int vehicleKey,string cityName)
        {
            return vehicleIautosMapper.FindUsedVehicleIautosPrice(vehicleKey, cityName) * 10000;
        }
    }
}

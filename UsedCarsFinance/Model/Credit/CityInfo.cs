using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Credit
{

    /// <summary>
    /// 省市区信息
    /// </summary>
    /// cais    16.05.09
    public class CityInfo
    {
        /// <summary>
        /// 城市代码
        /// </summary>
        public int CityCode { get; set; }
        /// <summary>
        /// 城市名称
        /// </summary>
        public int CityName { get; set; }
        /// <summary>
        /// 省代码
        /// </summary>
        public int ProvinceCode { get; set; }
        /// <summary>
        /// 省名称
        /// </summary>
        public int ProvinceName { get; set; }
    }
}
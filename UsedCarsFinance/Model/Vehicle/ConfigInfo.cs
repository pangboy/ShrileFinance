using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Vehicle
{
    /// <summary>
    /// 汽车之家车型配置数据实体（目前需要这两个暂时就写了这两个，后期需要在加）
    /// </summary>
    /// yand    16.07.28
   public class ConfigInfo
    {
        public string VehicleCode { get; set; }

        public decimal ManufacturerGuidePrice { get; set; }
    }
}

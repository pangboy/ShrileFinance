using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Finance
{
    /// <summary>
    /// 运营
    /// </summary>
    /// zouql   16.07.28
    /// zouql   16.08.30 增加融资扩展信息
    public class OperatingInfo
    {
        // 放还款账号
        public List<BankInfo> BankInfos { get; set; }

        // 融资信息
        public FinanceInfo Finance { get; set; }

        // 车辆信息
        public VehicleInfo VehicleInfo { get; set; }

        // 融资扩展信息
        public FinanceExtraInfo FinanceExtra { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Finance
{
    /// <summary>
    /// 融资申请实体组合类
    /// </summary>
    public class FinanceNodeGroupInfo
    {
        /// <summary>
        /// 融资实体
        /// </summary>
        public FinanceInfo FinanceInfo;

        /// <summary>
        /// 融资扩展实体
        /// </summary>
        public FinanceExtraInfo FinanceExtraInfo;

        /// <summary>
        /// 申请人集合
        /// </summary>
        public List<ApplicantInfo> Applicants;

        /// <summary>
        /// 车辆实体
        /// </summary>
        public VehicleInfo VehicleInfo;
    }
}

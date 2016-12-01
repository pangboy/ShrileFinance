namespace Core.Entities.Loan
{
    /// <summary>
    /// 质押保证合同
    /// </summary>
    public class PledgeGuarantyContract : GuarantyContract
    {
        public enum PledgeTypeEnum : byte
        {
            存单 = 1,
            票据 = 2,
            保单 = 3,
            国债 = 4,
            股权 = 5,
            股票 = 6,
            其他权利 = 7
        }

        /// <summary>
        /// 质押序号
        /// </summary>
        public string PledgeNumber { get; set; }

        /// <summary>
        /// 质押物价值
        /// </summary>
        public decimal? CollateralValue { get; set; }

        /// <summary>
        /// 质押物种类
        /// </summary>
        public PledgeTypeEnum? PledgeType { get; set; }
    }
}

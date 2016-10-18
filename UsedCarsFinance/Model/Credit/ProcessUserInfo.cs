namespace Model.Credit
{
    /// <summary>
    /// 流程处理用户
    /// </summary>
    /// qiy     16.05.31
    public class ProcessUserInfo
    {
        public int CreditId { get; set; }

        /// <summary>
        /// 初审
        /// </summary>
        public int? User1 { get; set; }
        /// <summary>
        /// 复审
        /// </summary>
        public int? User2 { get; set; }
        /// <summary>
        /// 运营
        /// </summary>
        public int? User3 { get; set; }
        /// <summary>
        /// 运营复审
        /// </summary>
        public int? User4 { get; set; }
        /// <summary>
        /// 财务
        /// </summary>
        public int? User5 { get; set; }
        /// <summary>
        /// 总经理
        /// </summary>
        public int? User6 { get; set; }
    }
}

namespace Model.Credit
{
    /// <summary>
    /// 授信主体-渠道信息
    /// </summary>
    /// qiy		16.03.29
    public class PartnerInfo : CreditInfo
    {
        public decimal Bail { get; set; }
        public string Address { get; set; }
        public string ProxyArea { get; set; }
        public string VehicleManage { get; set; }
        public string ControllerName { get; set; }
        public string ControllerIdentity { get; set; }
        public string ControllerTelephone { get; set; }
        public string Province { get; set; }
        public string City { get; set; } 
    }
}

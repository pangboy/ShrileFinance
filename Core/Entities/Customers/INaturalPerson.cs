namespace Core.Entities.Customers
{
    public interface INaturalPerson
    {
        /// <summary>
        /// 证件类型
        /// </summary>
        string CertificateType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        string CertificateCode { get; set; }
    }
}

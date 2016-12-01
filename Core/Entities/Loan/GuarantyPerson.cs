﻿namespace Core.Entities.Loan
{
    /// <summary>
    /// 自然人（继承于担保人）
    /// </summary>
    public class GuarantyPerson : Entity, IGuarantor
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        public string CertificateType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string CertificateNumber { get; set; }
    }
}

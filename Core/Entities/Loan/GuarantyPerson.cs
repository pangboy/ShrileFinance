using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Loan
{
    /// <summary>
    /// 自然人（担保人）
    /// </summary>
    public class GuarantyPerson : Entity, IGuarantor
    {
        public string Name{ get;set;}

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

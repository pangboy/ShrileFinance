using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Loan
{
    /// <summary>
    /// 机构（担保人）
    /// </summary>
    public class GuarantyOrganization : Entity, IGuarantor
    {
        public string Name { get; set; }
    }
}

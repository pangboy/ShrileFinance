using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Loan
{
    public class GuarantyContract : Entity
    {
        /// <summary>
        /// 担保人
        /// </summary>
        public IGuarantor IGuarantor { get; set; }
    }
}

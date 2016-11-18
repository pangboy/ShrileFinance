using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Finance
{
    public class LeaseeContract
    {
        public string  @融资租赁合同 { get; set; }
        public string @乙方姓名 { get; set; }
        public string @乙方证件号码 { get; set; }
        public string @共借人姓名 { get; set; }

        public string @共借人证件号码 { get; set; }
        public string @品牌 { get; set; }
        public string @型号 { get; set; }
        public string @车牌号 { get; set; }
        public string @读表里程数 { get; set; }
        public string @融资额大写 { get; set; }
        public string @融资额 { get; set; }
        public string @融资期限 { get; set; }
        public string @手续费大写 { get; set; }
        public string @手续费 { get; set; }
        public string @保证金大写 { get; set; }
        public string @保证金 { get; set; }
        public string @还款日 { get; set; }
        public string @首次支付年 { get; set; }
        public string @首次支付月 { get; set; }
        public string @首次支付日 { get; set; }
        public string @户名 { get; set; }
        public string @开户行 { get; set; }
        public string @账号 { get; set; }
    }
}

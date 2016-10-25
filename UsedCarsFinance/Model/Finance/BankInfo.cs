using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Credit;

namespace Models.Finance
{
    /// <summary>
    /// 银行卡信息
    /// </summary>
    /// zouql   16.07.16
    public class BankInfo
    {
        // 主键ID
        public int BankId { get; set; }
        // 融资
        public int FinanceId { get; set; }
        // 银行卡号
        public string BankCard { get; set; }
        //放款人ID
        public int? CreditId { get; set; }
        // 还款人
        public int? ApplicantId { get; set; }
        // 开户行
        public string BankName { get; set; }
    }
}

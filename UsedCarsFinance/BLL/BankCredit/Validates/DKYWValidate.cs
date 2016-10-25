using Models.BankCredit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BankCredit.Validates
{
    public class DKYWValidate : BaseValidate
    {
        private int typeId;
        //信贷业务采集报文校验
        public DKYWValidate(int InfoTypeId, MessageInfo data) : base(data)
        {
            typeId = InfoTypeId;
            Valid(InfoTypeId, data);
        }
        public override void Valid(int InfoTypeId, MessageInfo data)
        {
            base.Valid(InfoTypeId, data);

            if (!string.IsNullOrEmpty(PData.SegmentRules["E507"]))
            {
                if (PData.SegmentRules["E506"] == "") PData.SegmentRules["E506"] = "0.0";
                if (Convert.ToDouble(PData.SegmentRules["E507"]) > Convert.ToDouble(PData.SegmentRules["E506"]))
                {
                    throw new ApplicationException("“可用余额”的值必须小于等于“贷款合同金额”值");
                }
            }

            if (!string.IsNullOrEmpty(PData.SegmentRules["D500"]) && !string.IsNullOrEmpty(PData.SegmentRules["D499"]))
            {
                if (Convert.ToInt32(PData.SegmentRules["D500"]) < Convert.ToInt32(PData.SegmentRules["D499"]))
                {
                    throw new ApplicationException("“贷款合同生效日期”的时间必须小于等于“贷款合同终止日期”");
                }
            }
            if (!string.IsNullOrEmpty(PData.SegmentRules["H570"]) && !string.IsNullOrEmpty(PData.SegmentRules["H571"]))
            {
                if (Convert.ToInt32(PData.SegmentRules["H570"]) > Convert.ToInt32(PData.SegmentRules["H571"]))
                {
                    throw new ApplicationException("“展期起始日期”的时间必须小于等于“展期到期日期”");
                }
            }
            if (!string.IsNullOrEmpty(PData.SegmentRules["H709"]) && !string.IsNullOrEmpty(PData.SegmentRules["H710"]))
            {
                if (Convert.ToInt32(PData.SegmentRules["H709"]) > Convert.ToInt32(PData.SegmentRules["H710"]))
                {
                    throw new ApplicationException("“展期起始日期”的时间必须小于等于“展期到期日期”");
                }
            }
            if (!string.IsNullOrEmpty(PData.SegmentRules["F525"]) && !string.IsNullOrEmpty(PData.SegmentRules["F526"]))
            {
                //TODO 还需要根据当前信息记录获取报文文件下的贷款合同生效日期
                if (Convert.ToInt32(PData.SegmentRules["F525"]) > Convert.ToInt32(PData.SegmentRules["F526"]))
                {
                    throw new ApplicationException("“借据放款日期”的时间必须小于等于“借据到期日期”");
                }
            }
            if (!string.IsNullOrEmpty(PData.SegmentRules["F524"]) && !string.IsNullOrEmpty(PData.SegmentRules["F523"]))
            {
                if (Convert.ToDouble(PData.SegmentRules["F524"]) > Convert.ToDouble(PData.SegmentRules["F523"]))
                {
                    throw new ApplicationException("“贷款借据余额”必须小于等于“贷款借据金额”");
                }
            }
            if((!string.IsNullOrEmpty(PData.SegmentRules["D1022"])&& string.IsNullOrEmpty(PData.SegmentRules["D1023"]))|| (string.IsNullOrEmpty(PData.SegmentRules["D1022"]) && !string.IsNullOrEmpty(PData.SegmentRules["D1023"])))
            {
                throw new ApplicationException("币种、金额必须成对出现");
            }
        }

        protected override void GetData(out string[] segments, out string[] segmentRules, out string[] mates)
        {
            string[] segment = new string[] { };
            if (typeId == 10 || typeId == 16)
            {
                segment = new string[] { "B", "D", "E" };
            }
            else if (typeId == 14 || typeId == 15 || typeId == 20 || typeId == 21 || typeId == 22 || typeId == 23 || typeId == 24 || typeId == 30 || typeId == 31)
            {
                segment = new string[] { "B", "D" };
            }
            else if (typeId == 11 || typeId == 17 || typeId == 26)
            {
                segment = new string[] { "B", "F" };
            }
            else if (typeId == 12 || typeId == 18 || typeId == 27)
            {
                segment = new string[] { "B", "G" };
            }
            else if (typeId == 13 || typeId == 19 || typeId == 28)
            {
                segment = new string[] { "B", "H" };
            }
            else if (typeId == 25)
            {
                segment = new string[] { "B", "E" };
            }
            else if (typeId == 29)
            {
                segment = new string[] { "B", "I" };
            }
            segments = segment;
            //分别对报表类型段规则 D499贷款合同生效日期;D500贷款合同终止日期;E506贷款合同金额;E507可用余额;H570,H709展期起始日期;H571,H710展期到期日期,F525借据放款日期,F526借据放款到期日,F524贷款借据余额
            //F523贷款借据金额;H569,H708展期金额;D590叙做金额,D618贴现金额,D622票面金额,E649融资协议金额,F667融资金额,D730开证金额,D760保函金额,D786汇票金额,D810授信额度;D839\G921保证金额;E862\H947抵押物评估值
            //E869\H954抵押金额;F900\I983质押金额,D1003垫款金额,F896\I979质押物价值,币种,金额
            segmentRules = new string[] { "D499", "D500","E506","E507","H570","H709","H571","H710","F525","F526","F524","F523", "H569", "H708", "D590","D618","D622","E649","F667","D730","D760","D786","D810" ,
            "D839","G921","E869","H954","F900","I983","D1003","F896","I979","D1022","D1023"};
            //分别对报表类型数据元ID,2511贷款合同生效日期,2513贷款合同终止日期,1573贷款合同金额,1575可用余额,2521展期起始日期,2523展期到期日期,2515借据放款日期,2517借据放款到期日,1513贷款借据余额,
            //1511贷款借据金额,1517展期金额，1519续做金额,1523贴现金额,1525票面金额,1527融资协议金额,1531融资金额,1535开证金额,1539保函金额,1543汇票金额,1545授信额度,1547保证金额,1549抵押物评估值
            //1551抵押金额，1557质押金额，1559垫款金额,1571质押物价值
            mates = new string[] { "2511", "2513", "1573", "1575", "2521", "2523", "2515", "2517", "1513", "1511", "1517", "1519", "1523", "1525", "1527", "1531", "1535", "1529", "1543", "1545", "1547", "1549", "1551", "1557", "1559", "1571" };
        }
    }
}

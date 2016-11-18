using Models.Credit;
using Models.Finance;
using System;
using System.Data;

namespace BLL.Contract
{
    public class ContractsCalc
    {
        private readonly static DAL.Finance.FinanceInfoMapper financeMapper = new DAL.Finance.FinanceInfoMapper();
        private readonly static DAL.Credit.PartnerInfoMapper partnerMapper = new DAL.Credit.PartnerInfoMapper();
        private readonly static DAL.Credit.CityMapper cityMapper = new DAL.Credit.CityMapper();
        private readonly static DAL.Contract.ContractMapper contract = new DAL.Contract.ContractMapper();

        /// <summary>
        /// 生成并保存合同号
        /// </summary>
        /// <param name="type">HZ,HB,BZ,BB,DY</param>
        /// <param name="financeid">融资id</param>
        /// <param name="applicantid">申请人id</param>
        /// <returns>合同号</returns>
        public string GetContractNum(string type, int financeid, int applicantid)
        {
            string error = "";

            string AAAA = "";
            string CCCC = "";
            string DDD = "";
            string BB = FindByCreateOf(financeid, ref  error);
            if (BB != "" && error == "")
            {
                int intbb = Convert.ToInt32(BB);

                AAAA = GetCityCode(intbb);

                CCCC = GetYYMM();

                string Time = DateTime.Now.ToString("yyyy-MM-01 00:00:000");

                string ddCountBymonth = contract.FindCount(Time, BB).ToString();//当月当渠道的流水号

                int DDlength = ddCountBymonth.Length;
                if (DDlength == 1)
                {
                    DDD = "00" + ddCountBymonth;
                }
                if (DDlength == 2)
                {
                    DDD = "0" + ddCountBymonth;
                }
                if (DDlength == 3)
                {
                    DDD = "00" + ddCountBymonth;
                }
            }

            string all = AAAA + BB + CCCC + DDD;//组成AAAABBCCCCDDD

            //同一个主合同号只能有一个，没有就增加一个

            DataTable ContractMainCodeDT = contract.Find(financeid);

            if (ContractMainCodeDT.Rows.Count == 1) {
                all = ContractMainCodeDT.Rows[0][0].ToString();
            }

            if (ContractMainCodeDT.Rows.Count < 1)
            {
                Contractinfo Contract = new Contractinfo()
                {
                    ContractMainCode = all,
                    FinanceId = financeid
                };

                contract.Insert(Contract);
            }

            if (type == "HZ" || type == "HB" || type == "BZ" || type == "HZ" || type == "BB" || type == "DY" || type == "DB" || type == "JK" || type == "ZY" || type == "JT" || type == "JS")
            {
                if (type == "HZ")
                {
                    return type + all;//融资租赁合同
                }
                if (type == "BZ")
                {
                    DataTable dt = contract.FindApplicantIdIndex(financeid, 3);
                    int BZindex = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (applicantid == Convert.ToInt32(dt.Rows[i]["ApplicantId"]))
                        {
                            BZindex = i + 1;
                        }
                    }
                    return type + all + BZindex;//保证合同
                }
                if (type == "DY")
                {
                    return type + all;//车辆抵押合同,暂未实现
                }
            }

            return "";
        }

        /// <summary>
        /// 查找系统渠道编码
        /// </summary>
        /// <param name="financeid">融资id</param>
        /// <returns>01</returns>
        public string FindByCreateOf(int financeid, ref string error)
        {
            string varCreateOf = "";

            FinanceInfo finance = financeMapper.Find(financeid);
            if (finance.CreateOf.ToString() == "")
            {
                error = "未找到系统[渠道编码]";
            }
            if (finance.CreateOf.ToString().Length == 1)
            {
                varCreateOf = "0" + finance.CreateOf.ToString();
            }
            if (finance.CreateOf.ToString().Length > 2)
            {
                error = "系统[渠道编码]过大，不符合生成规则";
            }
            return varCreateOf;
        }

        /// <summary>
        /// 获得当前年月
        /// </summary>
        /// <returns>yyMM</returns>
        public string GetYYMM()
        {
            return DateTime.Now.ToString("yyMM");
        }

        /// <summary>
        /// 获得城市代码1200天津市
        /// </summary>
        /// <param name="CreateOf"></param>
        /// <returns></returns>
        public string GetCityCode(int CreateOf)
        {
            DataTable dt = null;
            PartnerInfo partner = partnerMapper.Find(CreateOf);
            if (partner.City != null)
            {
                dt = cityMapper.Find(partner.City);
            }
            if (dt != null && dt.Rows.Count==1)
            {
                return dt.Rows[0]["CityCode"].ToString();
            }
            return "";
        }
    }
}
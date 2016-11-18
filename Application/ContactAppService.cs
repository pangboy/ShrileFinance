using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Finance;
using Core.Interfaces.Repositories;

namespace Application
{
    public class ContactAppService
    {
        private readonly IContractRepository repository;
        private readonly IFinanceRepository financerepository;
        private readonly IPartnerRepository partnerrepository;
        private readonly static DAL.Credit.CityMapper cityMapper = new DAL.Credit.CityMapper();


        public ContactAppService(IContractRepository repository,IFinanceRepository financerepository,IPartnerRepository partnerrepository)
        {
            this.repository = repository;
            this.financerepository = financerepository;
            this.partnerrepository = partnerrepository
        }

        public string GetContractNum(string type, Guid financeid, int applicantid)
        {
            string error = "";

            string AAAA = "";
            string CCCC = "";
            string DDD = "";
            string BB = FindByCreateOf(financeid, ref error);
            if (BB != "" && error == "")
            {
                int intbb = Convert.ToInt32(BB);

                AAAA = GetCityCode(intbb);

                CCCC = GetYYMM();

                DateTime Time =Convert.ToDateTime( DateTime.Now.ToString("yyyy-MM-01 00:00:000"));

                string ddCountBymonth = repository.GetAll(m => m.Date >= Time && m.Date <= DateTime.Now && m.Number.Contains(BB)).ToList().Count.ToString();// contract.FindCount(Time, BB).ToString();//当月当渠道的流水号

                int DDlength = ddCountBymonth.Length;
                DDD = DDlength.ToString().PadLeft(3, '0');
            
            }

            string all = AAAA + BB + CCCC + DDD;//组成AAAABBCCCCDDD

            //同一个主合同号只能有一个，没有就增加一个
            var finance = financerepository.Get(financeid);

            if (finance.Contact!=null)
            {
                all = finance.Contact.FirstOrDefault().Number;
            }
            else
            {
                finance.Contact.Add(new Contract()
                {
                    Number = type + all,
                    Name = "融资租赁合同",
                    Date = DateTime.Now
                });
                financerepository.Modify(finance);
                financerepository.Commit();
            }
            return "";
        }

        /// <summary>
        /// 查找系统渠道编码
        /// </summary>
        /// <param name="financeid">融资id</param>
        /// <returns>01</returns>
        public string FindByCreateOf(Guid financeid, ref string error)
        {
            string varCreateOf = "";

            var  finance = financerepository.Get(financeid);
            if (finance.CreateOf.ToString() == "")
            {
                error = "未找到系统[渠道编码]";
            }
            if (finance.CreateOf.ToString().Length == 1|| finance.CreateOf.ToString().Length == 2)
            {
                varCreateOf = finance.CreateOf.ToString().PadLeft(2, '0'); ;
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
        public string GetCityCode(Guid CreateOf)
        {
            DataTable dt = null;
            var  partner = partnerrepository.GetAll(m=>m.Id == CreateOf);
            if (partner.City != null)
            {
                dt = cityMapper.Find(partner.City);
            }
            if (dt != null && dt.Rows.Count == 1)
            {
                return dt.Rows[0]["CityCode"].ToString();
            }
            return "";
        }
    }
}

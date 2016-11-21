namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Reflection;
    using System.Transactions;
    using AutoMapper;
    using Core.Entities;
    using Core.Entities.Finance;
    using Core.Entities.Identity;
    using Core.Entities.Partner;
    using Core.Interfaces.Repositories;
    using Data.PDF;
    using ViewModels.FinanceViewModels;

    /// <summary>
    /// 融资
    /// </summary>
    public class FinanceAppService
    {
        private readonly IFinanceRepository repository;
        private readonly AppUserManager userManager;
        private readonly AppRoleManager roleManager;
        private readonly IContractRepository contractRepository;
        private readonly IPartnerRepository partnerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FinanceAppService" /> class.
        /// </summary>
        /// <param name="repository">融资仓储</param>
        /// <param name="userManager">用户管理</param>
        /// <param name="roleManager">角色管理</param>
        /// <param name="contractRepository">合同</param>
        public FinanceAppService(IFinanceRepository repository, AppUserManager userManager, AppRoleManager roleManager, IContractRepository contractRepository, IPartnerRepository partnerRepository)
        {
            this.repository = repository;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.contractRepository = contractRepository;
            this.partnerRepository = partnerRepository;
        }

        public void Create(FinanceApplyViewModel value)
        {
            try
            {
                var finance = Mapper.Map<Finance>(value);
                finance.FinanceProduce = Mapper.Map<ICollection<FinanceProduce>>(value.FinanceProduce);
                finance.Applicant = Mapper.Map<ICollection<Applicant>>(value.Applicant);
                finance.CreateBy = userManager.CurrentUser();
                finance.CreateOf = partnerRepository.GetByUser(userManager.CurrentUser());
                finance.Produce = null;
                repository.Create(finance);
                repository.Commit();
                value.Id = finance.Id;
            }
            catch 
            {
                throw new Core.Exceptions.InvalidOperationAppException("保存失败.");
            }
        }

        public PartnerAndUser GetPartnerAndUser()
        {
           AppUser user = userManager.CurrentUser();
            Partner partner = partnerRepository.GetByUser(userManager.CurrentUser());
            return new PartnerAndUser()
            {
                PartnerName = partner.ProxyArea,
                UserName = user.Name,
                Phone = user.PhoneNumber,
            };
                 
        }
        public void Modify(FinanceApplyViewModel model)
        {
            try
            {
                var finance = repository.Get(model.Id.Value);
                Mapper.Map(model, finance);

                new UpdateBind().Bind(finance.FinanceProduce, model.FinanceProduce);
                new UpdateBind().Bind(finance.Applicant, model.Applicant);

                repository.Modify(finance);
                repository.Commit();
            }
            catch
            {
                throw new Core.Exceptions.InvalidOperationAppException("修改失败.");
            }

         
        }

        public FinanceApplyViewModel Get(Guid id)
        {
            var finance = repository.Get(id);

            FinanceApplyViewModel financeViewModel = Mapper.Map<FinanceApplyViewModel>(finance);
            return financeViewModel;
        }

        public string CreateLeaseInfoPdf(Guid financeId)
        {
            var finance = repository.Get(financeId);
            // 合同pdf地址
            string pdfPath = string.Empty;
            using (TransactionScope scope = new TransactionScope())
            {
                var mainApplicant = finance.Applicant.Where(m => m.Type == Applicant.TypeEnum.主要申请人).FirstOrDefault();
                if (mainApplicant != null)
                {
                    string hz = GetContractNum("HZ", financeId);//融资租赁合同编号代码

                    // 获取融资信息
                    SqlParameter[] sqlparams = new SqlParameter[1];
                    sqlparams[0] = new SqlParameter("FinanceId", financeId);
                    DataTable dt = repository.LeaseeContract(sqlparams);

                    // 合同参数
                    string contractParams = string.Empty;

                    // 保存的PDF名称(以合同编号命名)
                    string pdfName = string.Empty;

                    // 合同模板名称
                    string contractName = "FinancingLease.docx";

                    CreatePdf pdf = new CreatePdf();

                    if (dt.Rows.Count > 0)
                    {
                        contractParams = pdf.DataRowToParams(dt.Rows[0]);
                        dt.Rows[0]["[融资租赁合同]"] = hz;
                        pdfName = hz;
                    }

                    pdfPath = pdf.TransformPdf(contractName, contractParams, pdfName);

                    if (pdfPath != null)
                    {
                        finance.Contact.Add(new Contract()
                        {
                            Date = DateTime.Now,
                            Name = "融资租赁合同",
                            Number = pdfName,
                            Path = pdfPath

                        });
                        repository.Modify(finance);
                        repository.Commit();
                    }
                }
            }
            return pdfPath;
        }

        public string GetContractNum(string type, Guid financeid)
        {
            string error = "";
            string AAAA = "";
            string CCCC = "";
            string DDD = "";

            //合作商编码
            var partnerCode = "01";

            //查询合作商ID
            Guid BB = FindByCreateOf(financeid, ref error);
            if (BB != null && error == "")
            {
                AAAA = GetCityCode(BB);

                CCCC = GetYYMM();

                // 获取月初
                DateTime Time = DateTime.Now.AddDays(1 - DateTime.Now.Day);

                int ddCountBymonth = contractRepository.GetAll(m => m.Date >= Time && m.Date <= DateTime.Now && m.Number.Contains(partnerCode)).ToList().Count;// contract.FindCount(Time, BB).ToString();//当月当渠道的流水号

                int DDlength = ddCountBymonth + 1;
                DDD = DDlength.ToString().PadLeft(3, '0');

            }

            //组成AAAABBCCCCDDD
            return AAAA + partnerCode + CCCC + DDD;
        }

        /// <summary>
        /// 查找系统渠道ID
        /// </summary>
        /// <param name="financeid">融资id</param>
        /// <returns>01</returns>
        public Guid FindByCreateOf(Guid financeid, ref string error)
        {
            Guid varCreateOf = new Guid();

            var finance = repository.Get(financeid);
            if (finance.CreateOf == null)
            {
                error = "未找到系统[渠道编码]";
            }
            else
            {
                varCreateOf = finance.CreateOf.Id;
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
        /// <param name="partnerId"></param>
        /// <returns></returns>
        public string GetCityCode(Guid partnerId)
        {
            var partner = partnerRepository.Get(partnerId);

            //由于没有城市代码先手动赋值
            //return partner.City;
            return "1010";
        }

        /// <summary>
        /// 通过融资标识获取信审ViewModel
        /// </summary>
        /// <param name="financeId">融资标识</param>
        /// <returns>信审ViewModel</returns>
        public CreditExamineViewModel GetCreditExamineByFinanceId(Guid financeId)
        {
            if (financeId == null)
            {
                return null;
            }

            // 获取融资实体
            var finance = repository.Get(financeId);

            if (finance == null)
            {
                return null;
            }

            // 当前用户
            var curentUser = userManager.CurrentUser();

            if (curentUser == null)
            {
                return null;
            }

            finance.CreditExamine = finance.CreditExamine ?? new CreditExamine();

            // 实体转ViewModel
            var creditExamineReportViewModel = Mapper.Map<CreditExamineViewModel>(finance.CreditExamine);

            // 融资标识
            creditExamineReportViewModel.FinanceId = finance.Id;

            // 保证金
            if (!string.IsNullOrEmpty(finance.CreditExamine.Margin))
            {
                var array = finance.CreditExamine.Margin.Split('-');
                creditExamineReportViewModel.Margin1 = array[0];
                creditExamineReportViewModel.Margin2 = array[1];
            }

            // 产品编号
            creditExamineReportViewModel.ProductNumber = finance.Produce.Code;

            // 产品详解
            creditExamineReportViewModel.ProductExplain = finance.Produce.Remarks;

            // 产品种类
            creditExamineReportViewModel.ProductCategorie = finance.Vehicle.BusinessType.ToString();

            // 承租人
            var lessee = finance.Applicant.ToList().Find(m => m.Type == Applicant.TypeEnum.主要申请人);
            creditExamineReportViewModel.LesseeName = lessee.Name;
            creditExamineReportViewModel.LesseeIdCard = lessee.IdentityType.Equals("身份证") ? lessee.Identity : null;
            creditExamineReportViewModel.LesseeMobile = lessee.Mobile;

            // 共借人(最多一个)
            creditExamineReportViewModel.CommonBorrwerName1 = finance.Applicant.ToList().Find(m => m.Type == Applicant.TypeEnum.共同申请人).Name;

            // 保证人
            creditExamineReportViewModel.Guarantor = from applicant
                                                     in finance.Applicant.ToList().FindAll(m => m.Type == Applicant.TypeEnum.担保人)
                                                     select applicant.Name;

            // 当前角色
            var curentRole = roleManager.FindByIdAsync(curentUser.RoleId).Result;

            if (curentRole != null)
            {
                var trialUser = finance.CreditExamine.TrialUser ?? new AppUser();
                var reviewUser = finance.CreditExamine.ReviewUser ?? new AppUser();
                var approveUser = finance.CreditExamine.ApproveUser ?? new AppUser();
                var finalUser = finance.CreditExamine.FinalUser ?? new AppUser();

                creditExamineReportViewModel.TrialPerson = new KeyValuePair<string, string>(trialUser.Id, trialUser.UserName);
                creditExamineReportViewModel.ReviewPerson = new KeyValuePair<string, string>(reviewUser.Id, reviewUser.Name);
                creditExamineReportViewModel.ApprovePerson = new KeyValuePair<string, string>(approveUser.Id, approveUser.Name);
                creditExamineReportViewModel.FinalPerson = new KeyValuePair<string, string>(finalUser.Id, finalUser.Name);

                if (curentRole.Name.Equals("初审员"))
                {
                    creditExamineReportViewModel.TrialPerson = new KeyValuePair<string, string>(trialUser.Id, trialUser.UserName);
                }
                else if (curentRole.Name.Equals("复审员"))
                {
                    creditExamineReportViewModel.ReviewPerson = new KeyValuePair<string, string>(reviewUser.Id, reviewUser.Name);
                }
                else if (curentRole.Name.Equals("审批员"))
                {
                    creditExamineReportViewModel.ApprovePerson = new KeyValuePair<string, string>(approveUser.Id, approveUser.Name);
                }
                else if (curentRole.Name.Equals("终审员"))
                {
                    creditExamineReportViewModel.FinalPerson = new KeyValuePair<string, string>(finalUser.Id, finalUser.Name);
                }
            }

            return creditExamineReportViewModel;
        }

        /// <summary>
        /// 编辑信审报告
        /// </summary>
        /// <param name="value">信审ViewModel</param>
        public void EditCreditExamine(CreditExamineViewModel value)
        {
            if (value == null || value.FinanceId == null)
            {
                return;
            }

            // 获取该信审对应的融资实体
            var finance = repository.Get(value.FinanceId);

            if (finance == null)
            {
                return;
            }

            // 当前用户
            var curentUser = userManager.CurrentUser();

            if (curentUser == null)
            {
                return;
            }

            finance.CreditExamine = finance.CreditExamine ?? new CreditExamine();

            // 信审ViewModel转信审实体，更新信审
            Mapper.Map(value, finance.CreditExamine);

            // 保证金
            finance.CreditExamine.Margin = value.Margin1 + "-" + value.Margin2;

            // 当前角色
            var curentRole = roleManager.FindByIdAsync(curentUser.RoleId).Result;

            if (curentRole.Name.Equals("初审员"))
            {
                finance.CreditExamine.TrialUser = curentUser;
            }
            else if (curentRole.Name.Equals("复审员"))
            {
                finance.CreditExamine.ReviewUser = curentUser;
            }
            else if (curentRole.Name.Equals("审批员"))
            {
                finance.CreditExamine.ReviewUser = curentUser;
            }
            else if (curentRole.Name.Equals("终审员"))
            {
                finance.CreditExamine.ReviewUser = curentUser;
            }

            repository.Modify(finance);

            // 执行修改
            repository.Commit();
        }

        /// <summary>
        /// 通过融资标识获取融资审核ViewModel
        /// </summary>
        /// <param name="financeId">信审标识</param>
        /// <returns>融资审核ViewModel</returns>
        public FinanceAuidtViewModel GetFinanceAuidtByFinanceId(Guid financeId)
        {
            if (financeId == null)
            {
                return null;
            }

            // 获取融资实体
            var finance = repository.Get(financeId);

            if (finance == null)
            {
                return null;
            }

            // 实体转ViewModel
            var financeAuditViewModel = new FinanceAuidtViewModel()
            {
                // 融资标识
                FinanceId = finance.Id,

                // 厂商指导价
                ManufacturerGuidePrice = finance.Vehicle.ManufacturerGuidePrice,

                // 融资项（Id、<Name_Maney>）
                FinancingItems = GetFinancingItems(finance)
            };

            // 部分映射
            var array = new string[] { "AdviceMoney", "AdviceRatio", "ApprovalMoney", "ApprovalRatio", "Payment", "Cost" };
            financeAuditViewModel = PartialMapper(finance, financeAuditViewModel, array);

            return financeAuditViewModel;
        }

        /// <summary>
        /// 编辑融资审核
        /// </summary>
        /// <param name="value">融资审核ViewModel</param>
        public void EditFinanceAuidt(FinanceAuidtViewModel value)
        {
            if (value == null || value.FinanceId == null)
            {
                return;
            }

            // 获取该融资审核对应的融资实体
            var finance = repository.Get(value.FinanceId);

            if (finance == null)
            {
                return;
            }

            // 建议融资金额、建议融资比例、审批融资金额、审批融资比例、月供额度、手续费
            var array = new string[] { "AdviceMoney", "AdviceRatio", "ApprovalMoney", "ApprovalRatio", "Payment", "Cost" };
            finance = PartialMapper(value, finance, array);

            // 初审 修改融资项各金额
            if (!value.IsReview)
            {
                // 修改融资项各金额
                finance.FinanceProduce = EditFinanceAuidts(financingItems: finance.FinanceProduce, financingItemCollection: value.FinancingItems);
            }

            repository.Modify(finance);

            // 执行修改
            repository.Commit();
        }

        /// <summary>
        /// 通过融资标识获取运营ViewModel
        /// </summary>
        /// <param name="financeId">融资标识</param>
        /// <returns>运营ViewModel</returns>
        public OperationViewModel GetOperationByFinanceId(Guid financeId)
        {
            if (financeId == null)
            {
                return null;
            }

            // 获取信审报告实体
            var finance = repository.Get(financeId);

            if (finance == null)
            {
                return null;
            }

            // 实体转ViewModel
            var operationReportViewModel = Mapper.Map<OperationViewModel>(finance.FinanceExtension) ?? new OperationViewModel();

            operationReportViewModel.FinanceId = finance.Id;

            // 先付月供
            operationReportViewModel.PayMonthly = finance.Payment;

            // 实际用款额
            operationReportViewModel.ActualAmount = finance.Principal;

            // 选择还款日、首次租金支付日期、保证金、一次性付息、、
            var array = new string[] { "RepaymentDate", "Bail", "RepayRentDate", "OnePayInterest" };
            operationReportViewModel = PartialMapper(finance, operationReportViewModel, array);

            // 融资项
            operationReportViewModel.FinancingItems = GetFinancingItems(finance);

            // 车辆补充信息
            var array1 = new string[] { "RegisterDate", "RunningMiles", "FactoryDate", "BusinessType", "PlateNo", "FrameNo", "EngineNo", "RegisterCity", "Condition" };
            operationReportViewModel = PartialMapper(finance.Vehicle, operationReportViewModel, array1);

            return operationReportViewModel;
        }

        /// <summary>
        /// 编辑运营
        /// </summary>
        /// <param name="value">运营ViewModel</param>
        public void EditOperation(OperationViewModel value)
        {
            if (value == null || value.FinanceId == null)
            {
                return;
            }

            // 获取该信审对应的融资实体
            var finance = repository.Get(value.FinanceId);

            if (finance == null)
            {
                return;
            }

            finance.FinanceExtension = finance.FinanceExtension ?? new FinanceExtension();

            if (value.NodeType.Equals("Customer"))
            {
                // 还款信息
                var customerArray = new string[] { "CustomerAccountName", "CustomerBankName", "CustomerBankCard" };
                finance.FinanceExtension = PartialMapper(value, finance.FinanceExtension, customerArray);

                if (!finance.FinanceExtension.LoanPrincipal.Equals("Channel"))
                {
                    // 放款信息
                    var creditArray = new string[] { "CreditAccountName", "CreditBankName", "CreditBankCard" };
                    finance.FinanceExtension = PartialMapper(value, finance.FinanceExtension, creditArray);
                }

                // 车辆补充信息
                var array1 = new string[] { "RegisterDate", "RunningMiles", "FactoryDate", "BusinessType", "PlateNo", "FrameNo", "EngineNo", "RegisterCity", "Condition" };
                finance.Vehicle = PartialMapper(value, finance.Vehicle, array1);
            }
            else
            {
                // 选择还款日、首次租金支付日期、保证金、先付月供、一次性付息、实际用款额、放款主体、放款账户、放款账户开户行、放款账户卡号、合同Json
                var operationArray = new string[] { "RepaymentDate", "RepayRentDate", "Bail", "PayMonthly", "OnePayInterest", "ActualAmount", "LoanPrincipal", "CreditAccountName", "CreditBankName", "CreditBankCard", "ContactJson" };
                if (!value.LoanPrincipal.Equals("Channel"))
                {
                    operationArray = new string[] { "RepaymentDate", "RepayRentDate", "Bail", "PayMonthly", "OnePayInterest", "ActualAmount", "LoanPrincipal", "ContactJson" };
                }

                finance.FinanceExtension = PartialMapper(value, finance.FinanceExtension, operationArray);
            }

            repository.Modify(finance);

            // 执行修改
            repository.Commit();
        }

        /// <summary>
        ///  获取融资项
        /// </summary>
        /// <param name="finance">融资实体</param>
        /// <returns>融资项</returns>
        private ICollection<KeyValuePair<Guid, KeyValuePair<string, decimal?>>> GetFinancingItems(Finance finance)
        {
            var financingItems = new List<KeyValuePair<Guid, KeyValuePair<string, decimal?>>>();

            // 提取融资项
            finance.FinanceProduce.ToList().ForEach(delegate(FinanceProduce item)
            {
                financingItems.Add(new KeyValuePair<Guid, KeyValuePair<string, decimal?>>(item.Id, new KeyValuePair<string, decimal?>(item.Name, item.Money)));
            });

            return financingItems;
        }

        /// <summary>
        /// 修改融资项各金额
        /// </summary>
        /// <param name="financingItems">融资对应的融资项</param>
        /// <param name="financingItemCollection">前端传回的融资项</param>
        /// <returns></returns>
        private ICollection<FinanceProduce> EditFinanceAuidts(ICollection<FinanceProduce> financingItems, ICollection<KeyValuePair<Guid, KeyValuePair<string, decimal?>>> financingItemCollection)
        {
            var financingItemList = financingItems.ToList();

            // 更新融资项各金额
            financingItemList.ForEach(delegate(FinanceProduce financingItem)
            {
                // 获取融资项标识
                var key = financingItem.Id;

                // 更新指定融资项对应的金额
                financingItem.Money = financingItemCollection.Single(m => m.Key.Equals(key)).Value.Value.Value;
            });

            return financingItemList;
        }

        /// <summary>
        /// 部分映射
        /// </summary>
        /// <typeparam name="refT">输入类型</typeparam>
        /// <typeparam name="outT">输出类型</typeparam>
        /// <param name="refObj">输入对象</param>
        /// <param name="outObj">输出对象</param>
        /// <param name="array">属性名数组</param>
        /// <returns>输出对象（地址不变）</returns>
        private outT PartialMapper<refT, outT>(refT refObj, outT outObj, string[] array = null)
        {
            if (refObj == null)
            {
                return outObj;
            }

            if (outObj == null)
            {
                outObj = Activator.CreateInstance<outT>();
            }

            // 字典记录属性的值
            var container = new Dictionary<object, object>();
            foreach (var item in refObj.GetType().GetProperties())
            {
                if (array == null || array.Contains(item.Name))
                {
                    container.Add(item.Name, item.GetValue(refObj));
                }
            }

            // 字典为空，则返回
            if (container.Keys.Count == 0)
            {
                return outObj;
            }

            // 从字典取值，并对输出对象对应的属性赋值
            foreach (PropertyInfo item in outObj.GetType().GetProperties())
            {
                if (array == null || array.Contains(item.Name))
                {
                    if (container.Keys.Contains(item.Name))
                    {
                        item.SetValue(outObj, container[item.Name], null);

                        container.Remove(item.Name);
                    }
                }
            }

            return outObj;
        }
    }
}

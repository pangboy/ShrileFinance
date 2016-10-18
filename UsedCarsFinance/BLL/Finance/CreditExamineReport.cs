using Model.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL.Finance
{
    public class CreditExamineReport
    {
        private static readonly DAL.Finance.CreditExamineReportMapper CreditExamineReportMapper = new DAL.Finance.CreditExamineReportMapper();

        /// <summary>
        /// 根据融资ID查询信审报告信息
        /// </summary>
        /// yand     16.04.26
        /// <param name="financeId"></param>
        /// <returns></returns>
        public CreditExamineReportInfo Get(int financeId)
        {
            return CreditExamineReportMapper.Find(financeId);
        }

        /// <summary>
        /// 插入信审报告信息
        /// </summary>
        /// yand     16.04.26
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Add(CreditExamineReportInfo value)
        {
            bool result = true;

            using (TransactionScope scope = new TransactionScope())
            {
                CreditExamineReportMapper.Insert(value);
                result &= value.CreditExamineReportID > 0;

                if (result)
                    scope.Complete();
            }

            return result;
        }

        /// <summary>
        /// 根据ID更新信审信息
        /// </summary>
        /// yand     16.04.27
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Modify(CreditExamineReportInfo value)
        {
            bool result = false;
            CreditExamineReportInfo creditExamineReportInfo = CreditExamineReportMapper.Find(value.FinanceId);

            if (value == null) return false;

            //creditExamineReportInfo.CreditExamineReportID = value.CreditExamineReportID;
            creditExamineReportInfo.MainNameType = value.MainNameType;
            creditExamineReportInfo.MainNameReason = value.MainNameReason;
            creditExamineReportInfo.MainAgeType = value.MainAgeType;
            creditExamineReportInfo.MainAgeReason = value.MainAgeReason;
            creditExamineReportInfo.MainMobileType = value.MainMobileType;
            creditExamineReportInfo.MainMobileReason = value.MainMobileReason;
            creditExamineReportInfo.MainLiveHouseAddressType = value.MainLiveHouseAddressType;
            creditExamineReportInfo.MainLiveHouseAddressReason = value.MainLiveHouseAddressReason;
            creditExamineReportInfo.MainAnswerHouseAddressType = value.MainAnswerHouseAddressType;
            creditExamineReportInfo.MainBuyHousePrice = value.MainBuyHousePrice;
            creditExamineReportInfo.MainPresentWorth = value.MainPresentWorth;
            creditExamineReportInfo.FamiliarCarType = value.FamiliarCarType;
            creditExamineReportInfo.CarUsed = value.CarUsed;
            creditExamineReportInfo.Isreasonable = value.Isreasonable;
            creditExamineReportInfo.MainOfficeAddressType = value.MainOfficeAddressType;
            creditExamineReportInfo.MainOfficeAddressReason = value.MainOfficeAddressReason;
            creditExamineReportInfo.MainTakeOffice = value.MainTakeOffice;
            creditExamineReportInfo.MainWorkingLife = value.MainWorkingLife;
            creditExamineReportInfo.MainMonthlyIncome = value.MainMonthlyIncome;
            creditExamineReportInfo.IncomeStream = value.IncomeStream;
            creditExamineReportInfo.JointlyNameType = value.JointlyNameType;
            creditExamineReportInfo.JointlyNameReason = value.JointlyNameReason;
            creditExamineReportInfo.JointlyAgeType = value.JointlyAgeType;
            creditExamineReportInfo.JointlyAgeReason = value.JointlyAgeReason;
            creditExamineReportInfo.JointlyMobileType = value.JointlyMobileType;
            creditExamineReportInfo.JointlyMobileReason = value.JointlyMobileReason;
            creditExamineReportInfo.JointlyLiveHouseAddressType = value.JointlyLiveHouseAddressType;
            creditExamineReportInfo.JointlyLiveHouseAddressReason = value.JointlyLiveHouseAddressReason;
            creditExamineReportInfo.JointlyAnswerHouseAddressType = value.JointlyAnswerHouseAddressType;
            creditExamineReportInfo.JointlyBuyHousePrice = value.JointlyBuyHousePrice;
            creditExamineReportInfo.JointlyPresentWorth = value.JointlyPresentWorth;
            creditExamineReportInfo.JointlyOfficeAddressType = value.JointlyOfficeAddressType;
            creditExamineReportInfo.JointlyOfficeAddressReason = value.JointlyOfficeAddressReason;
            creditExamineReportInfo.JointlyTakeOffice = value.JointlyTakeOffice;
            creditExamineReportInfo.JointlyWorkingLife = value.JointlyWorkingLife;
            creditExamineReportInfo.JointlyMonthlyIncome = value.JointlyMonthlyIncome;
            creditExamineReportInfo.OtherMessage = value.OtherMessage;
            creditExamineReportInfo.ContactInformation = value.ContactInformation;
            creditExamineReportInfo.BankBillType = value.BankBillType;
            creditExamineReportInfo.AnswerBankBill = value.AnswerBankBill;
            creditExamineReportInfo.CreditType = value.CreditType;
            creditExamineReportInfo.AnswerCredit = value.AnswerCredit;
            creditExamineReportInfo.IsHomeVisitsType = value.IsHomeVisitsType;
            creditExamineReportInfo.HomeVisitsRequire = value.HomeVisitsRequire;
            creditExamineReportInfo.HomeVisitsResult = value.HomeVisitsResult;
            creditExamineReportInfo.ComprehensiveEvaluation = value.ComprehensiveEvaluation;
            creditExamineReportInfo.Car = value.Car;
            creditExamineReportInfo.FinanceId = value.FinanceId;

            if (CreditExamineReportMapper.Update(creditExamineReportInfo) > 0)
            {
                result = true;
            }

            return result;

        }

    }
}

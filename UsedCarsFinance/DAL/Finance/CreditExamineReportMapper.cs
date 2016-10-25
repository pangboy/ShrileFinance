using Models.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Finance
{
    public class CreditExamineReportMapper:AbstractMapper<CreditExamineReportInfo>
    {
        /// <summary>
        /// 根据融资ID查询信审报告
        /// </summary>
        /// yand    16.04.27
        /// <param name="financeId"></param>
        /// <returns></returns>
        public CreditExamineReportInfo Find(int financeId)
        {
            string findStatement =
                "SELECT * FROM FANC_CreditExamineReport WHERE financeId = @ID";

            return AbstractFind(findStatement, financeId);
        }

        /// <summary>
        /// 插入信审信息
        /// </summary>
        /// yand    16.04.26
        /// <param name="value"></param>
        public void Insert(CreditExamineReportInfo value)
		{
			SqlCommand comm = DHelper.GetSqlCommand(@"
				INSERT INTO FANC_CreditExamineReport (MainNameType,
                        MainNameReason,
                        MainAgeType,
                        MainAgeReason,
                        MainMobileType,
                        MainMobileReason,
                        MainLiveHouseAddressType,
                        MainLiveHouseAddressReason,
                        MainAnswerHouseAddressType,
                        MainBuyHousePrice,
                        MainPresentWorth,
                        FamiliarCarType,  
                        CarUsed, 
                        Isreasonable, 
                        MainOfficeAddressType,
                        MainOfficeAddressReason,
                        MainTakeOffice,
                        MainWorkingLife,  
                        MainMonthlyIncome, 
                        IncomeStream,
                        JointlyNameType,
                        JointlyNameReason,
                        JointlyAgeType,
                        JointlyAgeReason, 
                        JointlyMobileType, 
                        JointlyMobileReason,
                        JointlyLiveHouseAddressType,
                        JointlyLiveHouseAddressReason, 
                        JointlyAnswerHouseAddressType,
                        JointlyBuyHousePrice,
                        JointlyPresentWorth,
                        JointlyOfficeAddressType,
                        JointlyOfficeAddressReason,
                        JointlyTakeOffice, 
                        JointlyWorkingLife,
                        JointlyMonthlyIncome,
                        OtherMessage,
                        ContactInformation,
                        BankBillType,
                        AnswerBankBill,
                        CreditType,
                        AnswerCredit,
                        IsHomeVisitsType, 
                        HomeVisitsRequire,
                        HomeVisitsResult,
                        ComprehensiveEvaluation, 
                        Car,
                        FinanceID
                        ) 
				VALUES (@MainNameType,
                        @MainNameReason,
                        @MainAgeType,
                        @MainAgeReason,
                        @MainMobileType,
                        @MainMobileReason, 
                        @MainLiveHouseAddressType,
                        @MainLiveHouseAddressReason, 
                        @MainAnswerHouseAddressType,
                        @MainBuyHousePrice, 
                        @MainPresentWorth, 
                        @FamiliarCarType,  
                        @CarUsed, 
                        @Isreasonable, 
                        @MainOfficeAddressType,
                        @MainOfficeAddressReason,
                        @MainTakeOffice,
                        @MainWorkingLife,  
                        @MainMonthlyIncome, 
                        @IncomeStream,
                        @JointlyNameType,
                        @JointlyNameReason,
                        @JointlyAgeType,
                        @JointlyAgeReason, 
                        @JointlyMobileType, 
                        @JointlyMobileReason,
                        @JointlyLiveHouseAddressType,
                        @JointlyLiveHouseAddressReason, 
                        @JointlyAnswerHouseAddressType,
                        @JointlyBuyHousePrice,
                        @JointlyPresentWorth,
                        @JointlyOfficeAddressType,
                        @JointlyOfficeAddressReason,
                        @JointlyTakeOffice, 
                        @JointlyWorkingLife,
                        @JointlyMonthlyIncome,
                        @OtherMessage,
                        @ContactInformation,
                        @BankBillType,
                        @AnswerBankBill,
                        @CreditType,
                        @AnswerCredit,
                        @IsHomeVisitsType, 
                        @HomeVisitsRequire,
                        @HomeVisitsResult,
                        @ComprehensiveEvaluation, 
                        @Car,
                        @FinanceID
                        ) SELECT SCOPE_IDENTITY()
			");
            DHelper.AddParameter(comm, "@MainNameType", SqlDbType.Int, value.MainNameType);
            DHelper.AddParameter(comm, "@MainNameReason", SqlDbType.NVarChar, value.MainNameReason);
            DHelper.AddParameter(comm, "@MainAgeType", SqlDbType.Int, value.MainAgeType);
            DHelper.AddParameter(comm, "@MainAgeReason", SqlDbType.NVarChar, value.MainAgeReason);
            DHelper.AddParameter(comm, "@MainMobileType", SqlDbType.Int, value.MainMobileType);
            DHelper.AddParameter(comm, "@MainMobileReason", SqlDbType.NVarChar, value.MainMobileReason);
            DHelper.AddParameter(comm, "@MainLiveHouseAddressType", SqlDbType.Int, value.MainLiveHouseAddressType);
            DHelper.AddParameter(comm, "@MainLiveHouseAddressReason", SqlDbType.NVarChar, value.MainLiveHouseAddressReason);
            DHelper.AddParameter(comm, "@MainAnswerHouseAddressType", SqlDbType.Int, value.MainAnswerHouseAddressType);
            DHelper.AddParameter(comm, "@MainBuyHousePrice", SqlDbType.Decimal, value.MainBuyHousePrice);
            DHelper.AddParameter(comm, "@MainPresentWorth", SqlDbType.Decimal, value.MainPresentWorth);
            DHelper.AddParameter(comm, "@FamiliarCarType", SqlDbType.Int, value.FamiliarCarType);
            DHelper.AddParameter(comm, "@CarUsed", SqlDbType.NVarChar, value.CarUsed);
            DHelper.AddParameter(comm, "@Isreasonable", SqlDbType.Int, value.Isreasonable);
            DHelper.AddParameter(comm, "@MainOfficeAddressType", SqlDbType.Int, value.MainOfficeAddressType);
            DHelper.AddParameter(comm, "@MainOfficeAddressReason", SqlDbType.NVarChar, value.MainOfficeAddressReason);
            DHelper.AddParameter(comm, "@MainTakeOffice", SqlDbType.NVarChar, value.MainTakeOffice);
            DHelper.AddParameter(comm, "@MainWorkingLife", SqlDbType.Int, value.MainWorkingLife);
            DHelper.AddParameter(comm, "@MainMonthlyIncome", SqlDbType.Decimal, value.MainMonthlyIncome);
            DHelper.AddParameter(comm, "@IncomeStream", SqlDbType.NVarChar, value.IncomeStream);
            DHelper.AddParameter(comm, "@JointlyNameType", SqlDbType.Int, value.JointlyNameType);
            DHelper.AddParameter(comm, "@JointlyNameReason", SqlDbType.NVarChar, value.JointlyNameReason);
            DHelper.AddParameter(comm, "@JointlyAgeType", SqlDbType.Int, value.JointlyAgeType);
            DHelper.AddParameter(comm, "@JointlyAgeReason", SqlDbType.NVarChar, value.JointlyAgeReason);
            DHelper.AddParameter(comm, "@JointlyMobileType", SqlDbType.Int, value.JointlyMobileType);
            DHelper.AddParameter(comm, "@JointlyMobileReason", SqlDbType.NVarChar, value.JointlyMobileReason); 
            DHelper.AddParameter(comm, "@JointlyLiveHouseAddressType", SqlDbType.Int, value.JointlyLiveHouseAddressType);
            DHelper.AddParameter(comm, "@JointlyLiveHouseAddressReason", SqlDbType.NVarChar, value.JointlyLiveHouseAddressReason);
            DHelper.AddParameter(comm, "@JointlyAnswerHouseAddressType", SqlDbType.Int, value.JointlyAnswerHouseAddressType);
            DHelper.AddParameter(comm, "@JointlyBuyHousePrice", SqlDbType.Decimal, value.JointlyBuyHousePrice);
            DHelper.AddParameter(comm, "@JointlyPresentWorth", SqlDbType.Decimal, value.JointlyPresentWorth);
            DHelper.AddParameter(comm, "@JointlyOfficeAddressType", SqlDbType.Int, value.JointlyOfficeAddressType);
            DHelper.AddParameter(comm, "@JointlyOfficeAddressReason", SqlDbType.NVarChar, value.JointlyOfficeAddressReason);
            DHelper.AddParameter(comm, "@JointlyTakeOffice", SqlDbType.NVarChar, value.JointlyTakeOffice);
            DHelper.AddParameter(comm, "@JointlyWorkingLife", SqlDbType.Int, value.JointlyWorkingLife);
            DHelper.AddParameter(comm, "@JointlyMonthlyIncome", SqlDbType.Decimal, value.JointlyMonthlyIncome);
            DHelper.AddParameter(comm, "@OtherMessage", SqlDbType.NVarChar, value.OtherMessage); 
            DHelper.AddParameter(comm, "@ContactInformation", SqlDbType.NVarChar, value.ContactInformation);
            DHelper.AddParameter(comm, "@BankBillType", SqlDbType.Int, value.BankBillType);
            DHelper.AddParameter(comm, "@AnswerBankBill", SqlDbType.NVarChar, value.AnswerBankBill);
            DHelper.AddParameter(comm, "@CreditType", SqlDbType.Int, value.CreditType);
            DHelper.AddParameter(comm, "@AnswerCredit", SqlDbType.NVarChar, value.AnswerCredit); 
            DHelper.AddParameter(comm, "@IsHomeVisitsType", SqlDbType.Int, value.IsHomeVisitsType);
            DHelper.AddParameter(comm, "@HomeVisitsRequire", SqlDbType.NVarChar, value.HomeVisitsRequire);
            DHelper.AddParameter(comm, "@HomeVisitsResult", SqlDbType.NVarChar, value.HomeVisitsResult);
            DHelper.AddParameter(comm, "@ComprehensiveEvaluation", SqlDbType.NVarChar, value.ComprehensiveEvaluation);
            DHelper.AddParameter(comm, "@Car", SqlDbType.NVarChar, value.Car);
            DHelper.AddParameter(comm, "@FinanceID", SqlDbType.Int, value.FinanceId);

            value.CreditExamineReportID = Convert.ToInt32(DHelper.ExecuteScalar(comm));
		}

        /// <summary>
        /// 根据ID更新信审信息
        /// </summary>
        /// yand    16.04.27
        /// <param name="value"></param>
        /// <returns></returns>
        public int Update(CreditExamineReportInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                UPDATE FANC_CreditExamineReport SET
                        MainNameType = @MainNameType,
                        MainNameReason = @MainNameReason,
                        MainAgeType = @MainAgeType,
                        MainAgeReason = @MainAgeReason,
                        MainMobileType = @MainMobileType,
                        MainMobileReason = @MainMobileReason, 
                        MainLiveHouseAddressType = @MainLiveHouseAddressType,
                        MainLiveHouseAddressReason = @MainLiveHouseAddressReason, 
                        MainAnswerHouseAddressType = @MainAnswerHouseAddressType,
                        MainBuyHousePrice = @MainBuyHousePrice, 
                        MainPresentWorth = @MainPresentWorth, 
                        FamiliarCarType = @FamiliarCarType,  
                        CarUsed = @CarUsed, 
                        Isreasonable = @Isreasonable, 
                        MainOfficeAddressType = @MainOfficeAddressType,
                        MainOfficeAddressReason = @MainOfficeAddressReason,
                        MainTakeOffice = @MainTakeOffice,
                        MainWorkingLife = @MainWorkingLife,  
                        MainMonthlyIncome = @MainMonthlyIncome, 
                        IncomeStream = @IncomeStream,
                        JointlyNameType = @JointlyNameType,
                        JointlyNameReason = @JointlyNameReason,
                        JointlyAgeType = @JointlyAgeType,
                        JointlyAgeReason = @JointlyAgeReason, 
                        JointlyMobileType = @JointlyMobileType, 
                        JointlyMobileReason = @JointlyMobileReason,
                        JointlyLiveHouseAddressType = @JointlyLiveHouseAddressType,
                        JointlyLiveHouseAddressReason =  @JointlyLiveHouseAddressReason, 
                        JointlyAnswerHouseAddressType = @JointlyAnswerHouseAddressType,
                        JointlyBuyHousePrice = @JointlyBuyHousePrice,
                        JointlyPresentWorth = @JointlyPresentWorth,
                        JointlyOfficeAddressType = @JointlyOfficeAddressType,
                        JointlyOfficeAddressReason = @JointlyOfficeAddressReason,
                        JointlyTakeOffice = @JointlyTakeOffice, 
                        JointlyWorkingLife = @JointlyWorkingLife,
                        JointlyMonthlyIncome = @JointlyMonthlyIncome,
                        OtherMessage = @OtherMessage,
                        ContactInformation = @ContactInformation,
                        BankBillType = @BankBillType,
                        AnswerBankBill = @AnswerBankBill,
                        CreditType = @CreditType,
                        AnswerCredit = @AnswerCredit,
                        IsHomeVisitsType = @IsHomeVisitsType, 
                        HomeVisitsRequire = @HomeVisitsRequire,
                        HomeVisitsResult = @HomeVisitsResult,
                        ComprehensiveEvaluation = @ComprehensiveEvaluation, 
                        Car = @Car,
                        FinanceID = @FinanceID
                WHERE CreditExamineReportID=@CreditExamineReportID");

            DHelper.AddParameter(comm, "@MainNameType", SqlDbType.Int, value.MainNameType);
            DHelper.AddParameter(comm, "@MainNameReason", SqlDbType.NVarChar, value.MainNameReason);
            DHelper.AddParameter(comm, "@MainAgeType", SqlDbType.Int, value.MainAgeType);
            DHelper.AddParameter(comm, "@MainAgeReason", SqlDbType.NVarChar, value.MainAgeReason);
            DHelper.AddParameter(comm, "@MainMobileType", SqlDbType.Int, value.MainMobileType);
            DHelper.AddParameter(comm, "@MainMobileReason", SqlDbType.NVarChar, value.MainMobileReason);
            DHelper.AddParameter(comm, "@MainLiveHouseAddressType", SqlDbType.Int, value.MainLiveHouseAddressType);
            DHelper.AddParameter(comm, "@MainLiveHouseAddressReason", SqlDbType.NVarChar, value.MainLiveHouseAddressReason);
            DHelper.AddParameter(comm, "@MainAnswerHouseAddressType", SqlDbType.Int, value.MainAnswerHouseAddressType);
            DHelper.AddParameter(comm, "@MainBuyHousePrice", SqlDbType.Decimal, value.MainBuyHousePrice);
            DHelper.AddParameter(comm, "@MainPresentWorth", SqlDbType.Decimal, value.MainPresentWorth);
            DHelper.AddParameter(comm, "@FamiliarCarType", SqlDbType.Int, value.FamiliarCarType);
            DHelper.AddParameter(comm, "@CarUsed", SqlDbType.NVarChar, value.CarUsed);
            DHelper.AddParameter(comm, "@Isreasonable", SqlDbType.Int, value.Isreasonable);
            DHelper.AddParameter(comm, "@MainOfficeAddressType", SqlDbType.Int, value.MainOfficeAddressType);
            DHelper.AddParameter(comm, "@MainOfficeAddressReason", SqlDbType.NVarChar, value.MainOfficeAddressReason);
            DHelper.AddParameter(comm, "@MainTakeOffice", SqlDbType.NVarChar, value.MainTakeOffice);
            DHelper.AddParameter(comm, "@MainWorkingLife", SqlDbType.Int, value.MainWorkingLife);
            DHelper.AddParameter(comm, "@MainMonthlyIncome", SqlDbType.Decimal, value.MainMonthlyIncome);
            DHelper.AddParameter(comm, "@IncomeStream", SqlDbType.NVarChar, value.IncomeStream);
            DHelper.AddParameter(comm, "@JointlyNameType", SqlDbType.Int, value.JointlyNameType);
            DHelper.AddParameter(comm, "@JointlyNameReason", SqlDbType.NVarChar, value.JointlyNameReason);
            DHelper.AddParameter(comm, "@JointlyAgeType", SqlDbType.Int, value.JointlyAgeType);
            DHelper.AddParameter(comm, "@JointlyAgeReason", SqlDbType.NVarChar, value.JointlyAgeReason);
            DHelper.AddParameter(comm, "@JointlyMobileType", SqlDbType.Int, value.JointlyMobileType);
            DHelper.AddParameter(comm, "@JointlyMobileReason", SqlDbType.NVarChar, value.JointlyMobileReason);
            DHelper.AddParameter(comm, "@JointlyLiveHouseAddressType", SqlDbType.Int, value.JointlyLiveHouseAddressType);
            DHelper.AddParameter(comm, "@JointlyLiveHouseAddressReason", SqlDbType.NVarChar, value.JointlyLiveHouseAddressReason);
            DHelper.AddParameter(comm, "@JointlyAnswerHouseAddressType", SqlDbType.Int, value.JointlyAnswerHouseAddressType);
            DHelper.AddParameter(comm, "@JointlyBuyHousePrice", SqlDbType.Decimal, value.JointlyBuyHousePrice);
            DHelper.AddParameter(comm, "@JointlyPresentWorth", SqlDbType.Decimal, value.JointlyPresentWorth);
            DHelper.AddParameter(comm, "@JointlyOfficeAddressType", SqlDbType.Int, value.JointlyOfficeAddressType);
            DHelper.AddParameter(comm, "@JointlyOfficeAddressReason", SqlDbType.NVarChar, value.JointlyOfficeAddressReason);
            DHelper.AddParameter(comm, "@JointlyTakeOffice", SqlDbType.NVarChar, value.JointlyTakeOffice);
            DHelper.AddParameter(comm, "@JointlyWorkingLife", SqlDbType.Int, value.JointlyWorkingLife);
            DHelper.AddParameter(comm, "@JointlyMonthlyIncome", SqlDbType.Decimal, value.JointlyMonthlyIncome);
            DHelper.AddParameter(comm, "@OtherMessage", SqlDbType.NVarChar, value.OtherMessage);
            DHelper.AddParameter(comm, "@ContactInformation", SqlDbType.NVarChar, value.ContactInformation);
            DHelper.AddParameter(comm, "@BankBillType", SqlDbType.Int, value.BankBillType);
            DHelper.AddParameter(comm, "@AnswerBankBill", SqlDbType.NVarChar, value.AnswerBankBill);
            DHelper.AddParameter(comm, "@CreditType", SqlDbType.Int, value.CreditType);
            DHelper.AddParameter(comm, "@AnswerCredit", SqlDbType.NVarChar, value.AnswerCredit);
            DHelper.AddParameter(comm, "@IsHomeVisitsType", SqlDbType.Int, value.IsHomeVisitsType);
            DHelper.AddParameter(comm, "@HomeVisitsRequire", SqlDbType.NVarChar, value.HomeVisitsRequire);
            DHelper.AddParameter(comm, "@HomeVisitsResult", SqlDbType.NVarChar, value.HomeVisitsResult);
            DHelper.AddParameter(comm, "@ComprehensiveEvaluation", SqlDbType.NVarChar, value.ComprehensiveEvaluation);
            DHelper.AddParameter(comm, "@FinanceID", SqlDbType.Int, value.FinanceId);
            DHelper.AddParameter(comm, "@CreditExamineReportID", SqlDbType.Int, value.CreditExamineReportID);
            DHelper.AddParameter(comm, "@Car", SqlDbType.NVarChar, value.Car);

            return DHelper.ExecuteNonQuery(comm);
        }
    }
}

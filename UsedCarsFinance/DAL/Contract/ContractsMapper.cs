using Models.Finance;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Contract
{
    /// <summary>
    /// 合同类
    /// </summary>
    /// cais    16.05.09
    public class ContractMapper : AbstractMapper<Contractinfo>
    {
        /// <summary>
        /// 当地当渠道当月流水号（两位阿拉伯数字）
        /// </summary>
        /// cais    16.05.09
        /// <param name="time"></param>
        /// <param name="bb"></param>
        /// <returns>流水号</returns>
        public int FindCount(string time, string bb)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
             SELECT COUNT(*)+1 FROM FANC_Contracts
                WHERE ContractCreateDateTime  BETWEEN @month AND getdate() AND  ContractMainCode LIKE '%____'+@BB+'%'
            ");

            DHelper.AddParameter(comm, "@month", SqlDbType.NVarChar, time);//当月
            DHelper.AddParameter(comm, "@BB", SqlDbType.NVarChar, bb);//当前渠道

            return Convert.ToInt32(DHelper.ExecuteDataTable(comm).Rows[0][0]);
        }

        /// <summary>
        /// 查找主要合同号个数
        /// </summary>
        /// cais    16.05.09
        /// <param name="all">ContractMainCode[主合同号]</param>
        /// <returns></returns>
        public DataTable Find(int financeid)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
             SELECT ContractMainCode FROM FANC_Contracts WHERE FinanceId=@FinanceId
            ");

            DHelper.AddParameter(comm, "@FinanceId", SqlDbType.NVarChar, financeid);

            return DHelper.ExecuteDataTable(comm);
        }

        /// <summary>
        /// 增加一个
        /// </summary>
        /// cais    16.05.09
        /// <param name="Contract"></param>
        public void Insert(Contractinfo Contract)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
               INSERT INTO FANC_Contracts (
                    FinanceId ,
                    ContractMainCode ,
                    ContractCreateDateTime
                    ) Values(
                    @FinanceId,
                    @ContractMainCode,
                    getdate()
                    )"
            );

            DHelper.AddParameter(comm, "@FinanceId", SqlDbType.Int, Contract.FinanceId);
            DHelper.AddParameter(comm, "@ContractMainCode", SqlDbType.NVarChar, Contract.ContractMainCode);

            DHelper.ExecuteDataTable(comm);
        }

        /// <summary>
        /// 查找
        /// </summary>
        /// cais    16.05.09
        /// <param name="financeid"></param>
        /// <param name="applicantid"></param>
        /// <returns></returns>
        public DataTable FindApplicantIdIndex(int financeid, int type)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
             SELECT FinanceId ,ApplicantId ,[Type] FROM FANC_ApplicantInfo WHERE FinanceId=@FinanceId AND [Type]=@Type ORDER BY ApplicantId
            ");

            DHelper.AddParameter(comm, "@FinanceId", SqlDbType.Int, financeid);
            DHelper.AddParameter(comm, "@Type", SqlDbType.Int, type);

            return DHelper.ExecuteDataTable(comm);
        }



        /// <summary>
        /// 查询车辆抵押合同信息
        /// </summary>
        /// wangpf  16.08.02
        /// <param name="financeId">融资Id</param>
        /// <returns></returns>
        public DataTable FindMortgageInfo(int financeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT '' AS '[抵押物担保数额大写]', '' AS '[融资款项大写]', fi.IntentionPrincipal AS '[抵押物担保数额]', fri.ApprovalPrincipal AS '[融资款项]',
	               ai.Name AS '[抵押人姓名]', ai.[IDENTITY] AS '[证件号码]' , ai.LiveHouseAddress AS '[住所地]', ai.Name AS '[联系人]',
	               ai.Name AS '[债务人姓名]', ai.[IDENTITY] AS '[债务人身份证号]',
	               ai.Phone AS '[联系电话]', ai.Fax AS '[传真]', ai.EMail AS '[电子邮箱]', ai.Postcode	AS '[邮编]',
	               rz.OldName AS '[融资租赁合同编号]',
	               dy.OldName AS '[车辆抵押合同编号]',
	               vi.PlateNo AS '[车牌号]', vi.FrameNo AS '[车架号]', vi.EngineNo AS '[发动机号]',
	               ch.CarBrand AS '[品牌]', ch.Series AS '[型号]'
                FROM FANC_FinanceInfo fi
                JOIN FANC_ReviewInfo fri ON fri.FinanceId = fi.FinanceId
                JOIN FANC_ApplicantInfo ai ON fi.FinanceId = ai.FinanceId 
                JOIN FANC_VehicleInfo vi ON fi.FinanceId = vi.FinanceId
                JOIN V_CarHome AS ch ON vi.VehicleKey = ch.VehicleCode
                JOIN (
	                SELECT fl.OldName  
                    FROM SYS_Reference ref
                    LEFT JOIN  SYS_FileList fl ON ref.ReferenceId = fl.ReferenceId
	                WHERE ReferencedId = @ReferencedId 
			                AND ReferencedModule = @ReferencedModule
			                AND ReferencedSid = 1
                )  AS rz ON 1=1
                JOIN(
  	                SELECT fl.OldName 
                    FROM SYS_Reference ref
                    LEFT JOIN  SYS_FileList fl ON ref.ReferenceId = fl.ReferenceId
	                WHERE ReferencedId = @ReferencedId 
			                AND ReferencedModule = @ReferencedModule
			                AND ReferencedSid = 2
                ) AS dy ON 1=1
                WHERE fi.FinanceId = @FinanceId AND ai.Type = 1
            ");
            DHelper.AddInParameter(comm, "@FinanceId", SqlDbType.Int, financeId);
            DHelper.AddInParameter(comm, "@ReferencedId", SqlDbType.Int, financeId);
            DHelper.AddInParameter(comm, "@ReferencedModule", SqlDbType.Int, 4);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            Sys.MoneyToUpper moneyToUpper = new Sys.MoneyToUpper();
            // 金额转大写
            foreach (DataRow dr in dt.Rows)
            {
                decimal intentionPrincipal = String.IsNullOrEmpty(dr["[抵押物担保数额]"].ToString()) ? 0.0M : Convert.ToDecimal(dr["[抵押物担保数额]"].ToString());
                dr["[抵押物担保数额大写]"] = moneyToUpper.RMBToUpper(intentionPrincipal);

                decimal approvalPrincipal = String.IsNullOrEmpty(dr["[融资款项]"].ToString()) ? 0.0M : Convert.ToDecimal(dr["[融资款项]"].ToString());
                dr["[融资款项大写]"] = moneyToUpper.RMBToUpper(approvalPrincipal);
            }

            return dt;
        }

        /// <summary>
        /// 查询保证合同信息
        /// </summary>
        /// wangpf  16.08.03
        /// <param name="financeId">融资Id</param>
        /// <returns></returns>
        public DataTable FindEnsureInfo(int financeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT ma.Name AS '[承租人]', ma.[Identity] AS '[承租人身份证号]',
	               db.Name AS '[保证人]',db.[Identity] AS '[身份证号]',db.LiveHouseAddress AS '[住址]',db.Mobile  AS '[联系电话]',
	               rz.OldName AS '[融资租赁合同]',
	               bz.OldName  AS '[保证合同编号]'   
                FROM  FANC_ApplicantInfo AS ma 
                RIGHT JOIN (
	                SELECT gt.FinanceId, gt.Name , gt.[Identity], gt.LiveHouseAddress ,gt.Mobile
	                FROM  FANC_ApplicantInfo AS gt
	                WHERE gt.FinanceId = @FinanceId AND gt.Type = @Guarantee
                ) AS db ON ma.FinanceId = db.FinanceId
                LEFT JOIN (
	                SELECT fl.OldName 
                    FROM SYS_Reference ref
                    LEFT JOIN  SYS_FileList fl ON ref.ReferenceId = fl.ReferenceId
	                WHERE ReferencedId = @ReferencedId 
		                AND ReferencedModule = @ReferencedModule
		                AND ReferencedSid = @MainReferenceInfo
                ) AS rz on 1=1
                LEFT JOIN (
	                SELECT fl.OldName
                    FROM SYS_Reference ref
                    LEFT JOIN  SYS_FileList fl ON ref.ReferenceId = fl.ReferenceId
	                WHERE ReferencedId = @ReferencedId 
			                AND ReferencedModule = @ReferencedModule
			                AND ReferencedSid = @GuaranteeReferenceInfo	
                ) AS bz ON 1=1  
                WHERE ma.FinanceId = @FinanceId AND ma.Type = @MainApplicant
            ");
            DHelper.AddInParameter(comm, "@FinanceId", SqlDbType.Int, financeId);
            DHelper.AddInParameter(comm, "@ReferencedId", SqlDbType.Int, financeId);
            DHelper.AddInParameter(comm, "@ReferencedModule", SqlDbType.Int, 4);
            DHelper.AddInParameter(comm, "@MainApplicant", SqlDbType.TinyInt, ApplicantInfo.TypeEnum.主要申请人);
            DHelper.AddInParameter(comm, "@Guarantee", SqlDbType.TinyInt, ApplicantInfo.TypeEnum.担保人);
            DHelper.AddInParameter(comm, "@MainReferenceInfo", SqlDbType.Int, 1);
            DHelper.AddInParameter(comm, "@GuaranteeReferenceInfo", SqlDbType.Int, 3);

            return DHelper.ExecuteDataTable(comm);
        }

        /// <summary>
        /// 查询融资租赁合同信息
        /// </summary>
        /// wangpf  16.08.03
        /// <param name="financeId">融资Id</param>
        /// <returns></returns>
        public DataTable FindLeaseInfo(int financeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT rz.OldName  AS '[融资租赁合同]', db.OldName AS '[担保合同]',  
	             ma.Name AS '[乙方姓名]', ma.[Identity] AS '[乙方证件号码]',
	             ja.Name  AS '[共借人姓名]', ja.[Identity] AS '[共借人证件号码]',
	             vi.PlateNo AS '[车牌号]', vi.FrameNo AS '[车架号]', vi.EngineNo AS '[发动机号]',vi.RunningMiles AS '[读表里程数]'
	             ch.CarBrand AS '[品牌]', ch.Series AS '[型号]',	
	             '' AS '[融资额大写]',fri.Principal AS '[融资额]',fi.ProduceId,
	             pi.Periods AS '[融资期限]','' AS '[手续费大写]',pi.Cost AS '[手续费]',
	             '' AS '[保证金大写]',(pi.CustomerBailRatio * fri.Principal)AS '[保证金]',
	             fri.RepaymentDate AS '[还款日]',
	             YEAR( DATEADD(MM, 1,pi.AddDate)) AS '[首次支付年]',MONTH(DATEADD(MM, 1,pi.AddDate)) AS '[首次支付月]', fri.RepaymentDate AS '[首次支付日]',
	             bi.Name AS '[户名]', bi.BankName AS '[开户行]',bi.BankCard AS '[账号]'
                FROM FANC_FinanceInfo AS fi 
                LEFT JOIN FANC_ReviewInfo AS fri ON fi.FinanceId = fri.FinanceId
                LEFT JOIN PROD_ProduceInfo AS pi ON fi.ProduceId = pi.ProduceId
                LEFT JOIN (
	                SELECT bi.*,fa.Name
	                FROM FANC_BankInfo AS bi
	                LEFT JOIN FANC_ApplicantInfo fa ON fa.FinanceId = bi.FinanceId AND bi.ApplicantId = fa.ApplicantId
	                WHERE fa.FinanceId = @FinanceId
                ) AS bi on 1=1
                LEFT JOIN (
	                SELECT ai.FinanceId, ai.Name , ai.[Identity]
	                FROM FANC_ApplicantInfo AS ai 
	                WHERE ai.FinanceId = @FinanceId AND Type = @MainApplicant
                ) AS ma ON ma.FinanceId = fi.FinanceId
                LEFT JOIN (
                   SELECT ai.FinanceId, ai.Name, ai.[Identity]
	                FROM FANC_ApplicantInfo AS ai 
	                WHERE ai.FinanceId = FinanceId AND Type = @JointlyApplicant
                ) AS ja ON ja.FinanceId = fi.FinanceId 
                LEFT JOIN (
	                SELECT fl.OldName
                    FROM SYS_Reference ref
                    LEFT JOIN  SYS_FileList fl ON ref.ReferenceId = fl.ReferenceId
	                WHERE ReferencedId = @ReferencedId 
			                AND ReferencedModule = @ReferencedModule
			                AND ReferencedSid = @MainReferenceInfo
                )AS rz ON 1=1
                LEFT JOIN(
  	                SELECT fl.OldName 
                    FROM SYS_Reference ref
                    LEFT JOIN  SYS_FileList fl ON ref.ReferenceId = fl.ReferenceId
	                WHERE ReferencedId = @ReferencedId
			                AND ReferencedModule = @ReferencedModule
			                AND (ReferencedSid = @GuaranteeReferenceInfo)
                ) AS db ON 1=1
                LEFT JOIN FANC_VehicleInfo AS vi ON fi.FinanceId = vi.FinanceId
                LEFT JOIN V_CarHome AS ch ON vi.VehicleKey = ch.VehicleCode
                WHERE fi.FinanceId = @FinanceId
            ");
            DHelper.AddInParameter(comm, "@FinanceId", SqlDbType.Int, financeId);
            DHelper.AddInParameter(comm, "@MainApplicant", SqlDbType.Int, ApplicantInfo.TypeEnum.主要申请人);
            DHelper.AddInParameter(comm, "@JointlyApplicant", SqlDbType.Int, ApplicantInfo.TypeEnum.共同申请人);
            DHelper.AddInParameter(comm, "@ReferencedId", SqlDbType.Int, financeId);
            DHelper.AddInParameter(comm, "@ReferencedModule", SqlDbType.Int, 4);
            DHelper.AddInParameter(comm, "@MainReferenceInfo", SqlDbType.Int, 1);
            DHelper.AddInParameter(comm, "@GuaranteeReferenceInfo", SqlDbType.Int, 3);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            Sys.MoneyToUpper moneyToUpper = new Sys.MoneyToUpper();
            // 金额转大写
            foreach (DataRow dr in dt.Rows)
            {
                string approvalPrincipal = String.IsNullOrEmpty(dr["[融资额]"].ToString()) ? "0" : dr["[融资额]"].ToString();
                dr["[融资额大写]"] = moneyToUpper.RMBToUpper(Convert.ToDecimal(approvalPrincipal) * 10000, 2);
                dr["[融资额]"] = Math.Round(Convert.ToDecimal(approvalPrincipal) * 10000, 2);

                string customerPoundage = String.IsNullOrEmpty(dr["[手续费]"].ToString()) ? "0" : dr["[手续费]"].ToString();
                dr["[手续费大写]"] = moneyToUpper.RMBToUpper(customerPoundage, 2);
                dr["[手续费]"] = Math.Round(Convert.ToDecimal(customerPoundage), 2);

                string ensurePrice = String.IsNullOrEmpty(dr["[保证金]"].ToString()) ? "0" : dr["[保证金]"].ToString();
                dr["[保证金大写]"] = moneyToUpper.RMBToUpper(Convert.ToDecimal(ensurePrice) * 100, 2);
                dr["[保证金]"] = Math.Round(Convert.ToDecimal(ensurePrice) * 100, 2);

                string payment = String.IsNullOrEmpty(dr["[月还款金额]"].ToString()) ? "0" : dr["[月还款金额]"].ToString();
                dr["[月还款金额大写]"] = moneyToUpper.RMBToUpper(payment, 2);
                dr["[月还款金额]"] = Math.Round(Convert.ToDecimal(payment), 2);
            }

            return dt;
        }

        /// <summary>
        /// 新的融资租赁合同
        /// </summary>
        /// yand    16.11.17
        /// <param name="financeId"></param>
        /// <returns></returns>
        public DataTable FindLease(Guid financeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
            SELECT rz.Number AS '[融资租赁合同]', rz.Number AS '[担保合同]',  
	             ma.Name AS '[乙方姓名]', ma.[Identity] AS '[乙方证件号码]',
	             ja.Name AS '[共借人姓名]', ja.[Identity] AS '[共借人证件号码]',
	             fv.PlateNo AS '[车牌号]', fv.FrameNo AS '[车架号]', fv.EngineNo AS '[发动机号]',fv.RunningMiles AS '[读表里程数]',
	             vvi.CarBrand AS '[品牌]', vvi.Series AS '[型号]',	
	             '' AS '[融资额大写]',fi.Principal AS '[融资额]',fi.ProduceId,
	             pi.FinancingPeriods AS '[融资期限]','' AS '[手续费大写]',fi.Cost AS '[手续费]',
	             '' AS '[保证金大写]',(pi.CustomerBailRatio * fi.Principal)AS '[保证金]',
	             fi.RepaymentDate AS '[还款日]',
	             YEAR(DATEADD(MM, 1, fi.RepayRentDate)) AS '[首次支付年]',MONTH(DATEADD(MM, 1, fi.RepayRentDate)) AS '[首次支付月]', fi.RepayRentDate AS '[首次支付日]',
	             fe.CreditAccountId AS '[户名]', fe.CreditBankName AS '[开户行]',fe.CreditBankCard AS '[账号]'
                FROM FANC_Finance AS fi
                LEFT JOIN PROD_Produce AS pi ON fi.ProduceId = pi.Id
                LEFT JOIN FANC_Vehicle AS fv ON fv.FinanceId = fi.Id
                LEFT JOIN FANC_FinanceExtension AS fe ON fe.FinanceId = fi.Id
                LEFT JOIN (
                    SELECT ai.FinanceId, ai.Name, ai.[Identity]
                    FROM FANC_Applicant AS ai
                    WHERE ai.FinanceId = @financeId AND Type = 1
                ) AS ma ON ma.FinanceId = fi.Id
                LEFT JOIN (
                   SELECT ai.FinanceId, ai.Name, ai.[Identity]
                    FROM FANC_Applicant AS ai
                    WHERE ai.FinanceId = @financeId AND Type = 2
                ) AS ja ON ja.FinanceId = fi.Id
               LEFT JOIN (
                 SELECT sv.Vehicle, ss.Series, sb.CarBrand, sv.VehicleCode FROM ywcommondb.dbo.Sys_Vehicle AS sv
                    LEFT JOIN ywcommondb.dbo.Sys_Series AS ss ON sv.SeriesCode = ss.SeriesCode
                    LEFT JOIN ywcommondb.dbo.Sys_Brand AS sb ON sb.BrandCode = ss.BrandCode
			   ) AS vvi ON fv.VehicleKey = vvi.VehicleCode
               LEFT JOIN (
                SELECT Number, FinanceId FROM FANC_Contact AS fc WHERE fc.FinanceId = @financeId AND Name = '融资租赁合同（回租）'
			   ) AS rz ON rz.FinanceId = fi.Id
               LEFT JOIN(
                SELECT Number, FinanceId FROM FANC_Contact AS fc WHERE fc.FinanceId = @financeId AND Name = '保证合同'
			   )AS bz ON bz.FinanceId = fi.Id
               WHERE fi.Id = @financeId");
            DHelper.AddInParameter(comm, "@FinanceId", SqlDbType.NVarChar, financeId);
            DataTable dt = DHelper.ExecuteDataTable(comm);

            Sys.MoneyToUpper moneyToUpper = new Sys.MoneyToUpper();
            // 金额转大写
            foreach (DataRow dr in dt.Rows)
            {
                string approvalPrincipal = String.IsNullOrEmpty(dr["[融资额]"].ToString()) ? "0" : dr["[融资额]"].ToString();
                dr["[融资额大写]"] = moneyToUpper.RMBToUpper(Convert.ToDecimal(approvalPrincipal) * 10000, 2);
                dr["[融资额]"] = Math.Round(Convert.ToDecimal(approvalPrincipal) * 10000, 2);

                string customerPoundage = String.IsNullOrEmpty(dr["[手续费]"].ToString()) ? "0" : dr["[手续费]"].ToString();
                dr["[手续费大写]"] = moneyToUpper.RMBToUpper(customerPoundage, 2);
                dr["[手续费]"] = Math.Round(Convert.ToDecimal(customerPoundage), 2);

                string ensurePrice = String.IsNullOrEmpty(dr["[保证金]"].ToString()) ? "0" : dr["[保证金]"].ToString();
                dr["[保证金大写]"] = moneyToUpper.RMBToUpper(Convert.ToDecimal(ensurePrice) * 100, 2);
                dr["[保证金]"] = Math.Round(Convert.ToDecimal(ensurePrice) * 100, 2);

                string payment = String.IsNullOrEmpty(dr["[月还款金额]"].ToString()) ? "0" : dr["[月还款金额]"].ToString();
                dr["[月还款金额大写]"] = moneyToUpper.RMBToUpper(payment, 2);
                dr["[月还款金额]"] = Math.Round(Convert.ToDecimal(payment), 2);
            }

            return dt;
        }


        /// <summary>
        /// 新的保证合同信息
        /// </summary>
        /// yand    16.11.17
        /// 暂时无用，后期可能有用（车辆抵押合同后期用到在做）
        /// <param name="financeId">融资Id</param>
        /// <returns></returns>
        public DataTable FindEnsure(int financeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                  SELECT gt.Name AS '[承租人]', gt.[Identity] AS '[承租人身份证号]',
	               db.Name AS '[保证人]',db.[Identity] AS '[身份证号]',gt.LiveHouseAddress AS '[住址]',gt.Mobile  AS '[联系电话]',
	               rz.Number AS '[融资租赁合同]',
	               bz.Number  AS '[保证合同编号]'   
				   FROM FANC_Applicant AS fa
				   LEFT JOIN FANC_Finance AS ff ON ff.Id = fa.FinanceId
				   LEFT JOIN(
				     SELECT gt.FinanceId, gt.Name , gt.[Identity], gt.LiveHouseAddress ,gt.Mobile
	                FROM  FANC_Applicant AS gt
	                WHERE gt.FinanceId = @FinanceId AND gt.Type = 1
				   ) AS gt ON gt.FinanceId = ff.Id
				      LEFT JOIN(
				     SELECT db.FinanceId, db.Name , db.[Identity]
	                FROM  FANC_Applicant AS db
	                WHERE db.FinanceId = @FinanceId AND db.Type = 3
				   ) AS db ON db.FinanceId = ff.Id
				      LEFT JOIN (
                SELECT Number, FinanceId FROM FANC_Contact AS fc WHERE fc.FinanceId = @financeId AND Name = '融资租赁合同（回租）'
			   ) AS rz ON rz.FinanceId = ff.Id
               LEFT JOIN(
                SELECT Number, FinanceId FROM FANC_Contact AS fc WHERE fc.FinanceId = @financeId AND Name = '保证合同'
			   )AS bz ON bz.FinanceId = ff.Id
                WHERE ff.Id = @FinanceId
            ");
            DHelper.AddInParameter(comm, "@FinanceId", SqlDbType.NVarChar, financeId);

            return DHelper.ExecuteDataTable(comm);
        }
        
    }
}
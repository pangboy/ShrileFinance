using DataHelper;
using Model;
using Model.Produce;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Produce
{
    public class ProduceMapper : AbstractMapper<ProduceInfo>
    {
        /// <summary>
        /// 根据一个产品ID ，修改对应的产品
        /// </summary>
        /// cais    16.03.29
        /// yangj   16.07.25(新增融资返范围)
        /// <param name="produce"></param>
        /// <returns></returns>
        public int Update(ProduceInfo produce)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                UPDATE PROD_ProduceInfo SET Code=@Code ,
                    Name=@Name,
                    InterestRate=@InterestRate,
                    Rate=@Rate,
                    RepaymentMethod=@RepaymentMethod,
                    MinFinancingRatio=@MinFinancingRatio,
                    MaxFinancingRatio=@MaxFinancingRatio,
                    FinalRatio=@FinalRatio,
                    FinancingPeriods=@FinancingPeriods,
                    RepaymentInterval=@RepaymentInterval,
                    CustomerBailRatio=@CustomerBailRatio,
                    CustomerPoundage=@CustomerPoundage,
                    AddDate=@AddDate,
                    Remarks=@Remarks,
                    AdditionalGPSCost=@AdditionalGPSCost,
                    AdditionalOtherCost=@AdditionalOtherCost,
                    IsVehiclePrice=@IsVehiclePrice,
                    IsPurchaseTax=@IsPurchaseTax,
                    IsBusinessInsurance=@IsBusinessInsurance,
                    IsTafficCompulsoryInsurance=@IsTafficCompulsoryInsurance,
                    IsVehicleVesselTax=@IsVehicleVesselTax,
                    IsExtendedWarrantyInsurance=@IsExtendedWarrantyInsurance,
                    IsOther=@IsOther
                WHERE ProduceId=@ProduceId");

            DHelper.AddParameter(comm, "@Code", SqlDbType.NVarChar, produce.Code);
            DHelper.AddParameter(comm, "@Name", SqlDbType.NVarChar, produce.Name);
            DHelper.AddParameter(comm, "@InterestRate", SqlDbType.Float, (produce.InterestRate) / 12);
            DHelper.AddParameter(comm, "@Rate", SqlDbType.Float, (produce.Rate) / 12);

            DHelper.AddParameter(comm, "@RepaymentMethod", SqlDbType.Int, produce.RepaymentMethod);
            DHelper.AddParameter(comm, "@MinFinancingRatio", SqlDbType.Int, produce.MinFinancingRatio);
            DHelper.AddParameter(comm, "@MaxFinancingRatio", SqlDbType.Int, produce.MaxFinancingRatio);
            DHelper.AddParameter(comm, "@FinalRatio", SqlDbType.Int, produce.FinalRatio);
            DHelper.AddParameter(comm, "@FinancingPeriods", SqlDbType.Int, produce.FinancingPeriods);
            DHelper.AddParameter(comm, "@RepaymentInterval", SqlDbType.Int, produce.RepaymentInterval);
            DHelper.AddParameter(comm, "@CustomerBailRatio", SqlDbType.Float, produce.CustomerBailRatio);
            DHelper.AddParameter(comm, "@CustomerPoundage", SqlDbType.Decimal, produce.CustomerPoundage);
            DHelper.AddParameter(comm, "@AddDate", SqlDbType.DateTime, DateTime.Now);
            DHelper.AddParameter(comm, "@Remarks", SqlDbType.NVarChar, produce.Remarks);
            DHelper.AddParameter(comm, "@AdditionalGPSCost", SqlDbType.Decimal, produce.AdditionalGPSCost);
            DHelper.AddParameter(comm, "@AdditionalOtherCost", SqlDbType.Decimal, produce.AdditionalOtherCost);
            // 新增融资范围
            DHelper.AddParameter(comm, "@IsVehiclePrice", SqlDbType.Bit, produce.IsVehiclePrice);
            DHelper.AddParameter(comm, "@IsPurchaseTax", SqlDbType.Bit, produce.IsPurchaseTax);
            DHelper.AddParameter(comm, "@IsBusinessInsurance", SqlDbType.Bit, produce.IsBusinessInsurance);
            DHelper.AddParameter(comm, "@IsTafficCompulsoryInsurance", SqlDbType.Bit, produce.IsTafficCompulsoryInsurance);
            DHelper.AddParameter(comm, "@IsVehicleVesselTax", SqlDbType.Bit, produce.IsVehicleVesselTax);
            DHelper.AddParameter(comm, "@IsExtendedWarrantyInsurance", SqlDbType.Bit, produce.IsExtendedWarrantyInsurance);
            DHelper.AddParameter(comm, "@IsOther", SqlDbType.Bit, produce.IsOther);

            DHelper.AddParameter(comm, "@ProduceId", SqlDbType.Int, produce.ProduceId);

            return DHelper.ExecuteNonQuery(comm);
        }

        /// <summary>
        /// 通过实体，增加一个产品
        /// </summary>
        /// cais    16.03.28
        /// yangj   16.07.25(新增融资返范围)
        /// <param name="produce"></param>
        /// <returns></returns>
        public void Insert(ProduceInfo produce)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                INSERT INTO  PROD_ProduceInfo  (
                    Code,
                    Name,
                    InterestRate,
                    Rate,
                    RepaymentMethod,
                    MinFinancingRatio,
                    MaxFinancingRatio,
                    FinalRatio,
                    FinancingPeriods,
                    RepaymentInterval,
                    CustomerBailRatio,
                    CustomerPoundage,
                    AddDate,
                    Remarks,
                    AdditionalGPSCost,
                    AdditionalOtherCost,
                    IsVehiclePrice,
                    IsPurchaseTax,
                    IsBusinessInsurance,
                    IsTafficCompulsoryInsurance,
                    IsVehicleVesselTax,
                    IsExtendedWarrantyInsurance,
                    IsOther )
                    VALUES(
                    @Code,
                    @Name,
                    @InterestRate,
                    @Rate,
                    @RepaymentMethod,
                    @MinFinancingRatio,
                    @MaxFinancingRatio,
                    @FinalRatio,
                    @FinancingPeriods,
                    @RepaymentInterval,
                    @CustomerBailRatio,
                    @CustomerPoundage,
                    @AddDate,
                    @Remarks,
                    @AdditionalGPSCost,
                    @AdditionalOtherCost,
                    @IsVehiclePrice,
                    @IsPurchaseTax,
                    @IsBusinessInsurance,
                    @IsTafficCompulsoryInsurance,
                    @IsVehicleVesselTax,
                    @IsExtendedWarrantyInsurance,
                    @IsOther )

                SELECT SCOPE_IDENTITY()"
                );

            DHelper.AddParameter(comm, "@Code", SqlDbType.NVarChar, produce.Code);
            DHelper.AddParameter(comm, "@Name", SqlDbType.NVarChar, produce.Name);
            DHelper.AddParameter(comm, "@InterestRate", SqlDbType.Float, (produce.InterestRate) / 12);//月利率
            DHelper.AddParameter(comm, "@Rate", SqlDbType.Float, (produce.Rate) / 12);//费率
            DHelper.AddParameter(comm, "@RepaymentMethod", SqlDbType.Int, produce.RepaymentMethod);
            DHelper.AddParameter(comm, "@MinFinancingRatio", SqlDbType.Int, produce.MinFinancingRatio);
            DHelper.AddParameter(comm, "@MaxFinancingRatio", SqlDbType.Int, produce.MaxFinancingRatio);
            DHelper.AddParameter(comm, "@FinalRatio", SqlDbType.Int, produce.FinalRatio);
            DHelper.AddParameter(comm, "@FinancingPeriods", SqlDbType.Int, produce.FinancingPeriods);
            DHelper.AddParameter(comm, "@RepaymentInterval", SqlDbType.Int, produce.RepaymentInterval);
            DHelper.AddParameter(comm, "@CustomerBailRatio", SqlDbType.Float, produce.CustomerBailRatio);
            DHelper.AddParameter(comm, "@CustomerPoundage", SqlDbType.Decimal, produce.CustomerPoundage);
            DHelper.AddParameter(comm, "@AddDate", SqlDbType.DateTime, DateTime.Now);
            DHelper.AddParameter(comm, "@Remarks", SqlDbType.NVarChar, produce.Remarks);
            DHelper.AddParameter(comm, "@AdditionalGPSCost", SqlDbType.Decimal, produce.AdditionalGPSCost);
            DHelper.AddParameter(comm, "@AdditionalOtherCost", SqlDbType.Decimal, produce.AdditionalOtherCost);
            // 新增融资范围
            DHelper.AddParameter(comm, "@IsVehiclePrice", SqlDbType.Bit, produce.IsVehiclePrice);
            DHelper.AddParameter(comm, "@IsPurchaseTax", SqlDbType.Bit, produce.IsPurchaseTax);
            DHelper.AddParameter(comm, "@IsBusinessInsurance", SqlDbType.Bit, produce.IsBusinessInsurance);
            DHelper.AddParameter(comm, "@IsTafficCompulsoryInsurance", SqlDbType.Bit, produce.IsTafficCompulsoryInsurance);
            DHelper.AddParameter(comm, "@IsVehicleVesselTax", SqlDbType.Bit, produce.IsVehicleVesselTax);
            DHelper.AddParameter(comm, "@IsExtendedWarrantyInsurance", SqlDbType.Bit, produce.IsExtendedWarrantyInsurance);
            DHelper.AddParameter(comm, "@IsOther", SqlDbType.Bit, produce.IsOther);

            produce.ProduceId = Convert.ToInt32(DHelper.ExecuteScalar(comm));
        }

        /// <summary>
        /// 产品列表查询方法
        /// </summary>
        /// cais    16.03.28
        /// <param name="pagination">分页</param>
        /// <param name="filter">参数</param>
        /// <returns></returns>
        public DataTable Find(Model.Pagination pagination, NameValueCollection filter)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT
                    Produce.ProduceId,Code,Name,(InterestRate * 12) as InterestRate,(Rate * 12) as Rate,MinFinancingRatio,MaxFinancingRatio,FinalRatio,FinancingPeriods,RepaymentInterval,CustomerBailRatio,CustomerPoundage,AddDate,Remarks,AdditionalGPSCost,AdditionalOtherCost, dbo.Dic(3,RepaymentMethod) AS paymothed FROM PROD_ProduceInfo
                    AS Produce LEFT JOIN (SELECT TOP (@End) ROW_NUMBER() OVER (ORDER BY ProduceId DESC) AS rownum,ProduceId FROM PROD_ProduceInfo
                    WHERE @Code_Name IS NULL OR (Code like  '%'+@Code_Name+'%' OR Name like '%'+@Code_Name+'%')) AS TMP
                ON Produce.ProduceId=TMP.ProduceId WHERE TMP.rownum>@Begin
            ");

            DHelper.AddParameter(comm, "@Begin", SqlDbType.Int, pagination.Begin);
            DHelper.AddParameter(comm, "@End", SqlDbType.Int, pagination.End);

            DHelper.AddParameter(comm, "@Code_Name", SqlDbType.VarChar, filter["ProductCodeOrName"]);

            SqlCommand commPage = DHelper.GetSqlCommand(@"SELECT Count(*) FROM PROD_ProduceInfo WHERE @Code_Name IS NULL OR (Code like  '%'+@Code_Name+'%' OR Name like '%'+@Code_Name+'%')");

            DHelper.AddParameter(commPage, "@Code_Name", SqlDbType.NVarChar, filter["ProductCodeOrName"]);

            pagination.Total = Convert.ToInt32(DHelper.ExecuteScalar(commPage));

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return dt;
        }

        /// <summary>
        /// 通过一个产品ID，返回一个产品
        /// </summary>
        /// cais    16.03.28
        /// yangj   16.07.26(新增融资返范围)
        /// <param name="produceId"></param>
        /// <returns></returns>
        public ProduceInfo FindByProduce_Id(int produceId)
        {
            if (default(int).Equals(produceId)) return null;

            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT ProduceId,
                        Code,
                        Name,
                        (InterestRate * 12) as InterestRate,
                        (Rate * 12) as Rate,
                        RepaymentMethod,
                        MinFinancingRatio,
                        MaxFinancingRatio,
                        FinalRatio,
                        FinancingPeriods,
                        RepaymentInterval,
                        CustomerBailRatio,
                        CustomerPoundage,
                        AddDate,
                        Remarks,
                        AdditionalGPSCost,
                        AdditionalOtherCost,
                        IsVehiclePrice,
                        IsPurchaseTax,
                        IsBusinessInsurance,
                        IsTafficCompulsoryInsurance,
                        IsVehicleVesselTax,
                        IsExtendedWarrantyInsurance,
                        IsOther 
                FROM PROD_ProduceInfo
                WHERE ProduceId=@ProduceId");

            DHelper.AddParameter(comm, "@ProduceId", SqlDbType.Int, produceId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return Load(dt);
        }

        /// <summary>
        /// 获取产品列表(Combo)
        /// </summary>
        /// cais    16.03.28
        /// <returns></returns>
        public List<ComboInfo> Option()
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"SELECT ProduceId,Code,Name FROM PROD_ProduceInfo");

            DataTable dt = DHelper.ExecuteDataTable(comm);

            List<ComboInfo> list = new List<ComboInfo>();

            foreach (DataRow dr in dt.Rows)
            {
                ComboInfo cbi = new ComboInfo(dr["ProduceId"].ToString(), dr["Code"].ToString());

                list.Add(cbi);
            }

            return list;
        }


        /// <summary>
        /// 产品筛选(还款方式)
        /// </summary>
        /// yangj    16.08.02
        /// <returns></returns>
        public List<ComboInfo> FindByRepaymentMethod(int creditId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT DISTINCT RepaymentMethod
                FROM PROD_ProduceInfo AS A
                LEFT JOIN CRET_BindProduce AS B
                    ON A.ProduceId = B.ProduceId
                    WHERE B.CreditId = @CreditId;");

            DHelper.AddParameter(comm, "@CreditId", SqlDbType.Int, creditId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            List<ComboInfo> list = new List<ComboInfo>();

            foreach (DataRow dr in dt.Rows)
            {
                ComboInfo cbi = new ComboInfo(dr["RepaymentMethod"].ToString(), ((ProduceInfo.RepaymentMethodEnum)(dr["RepaymentMethod"])).ToString());

                list.Add(cbi);
            }

            return list;
        }

        /// <summary>
        /// 产品筛选(产品名)
        /// </summary>
        /// yangj    16.08.02
        /// <returns></returns>
        public List<ComboInfo> FindByProduceName(int creditId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT DISTINCT Name
                FROM PROD_ProduceInfo AS A
                LEFT JOIN CRET_BindProduce AS B
                    ON A.ProduceId = B.ProduceId
                    WHERE B.CreditId = @CreditId;");

            DHelper.AddParameter(comm, "@CreditId", SqlDbType.Int, creditId);


            DataTable dt = DHelper.ExecuteDataTable(comm);

            List<ComboInfo> list = new List<ComboInfo>();

            foreach (DataRow dr in dt.Rows)
            {
                ComboInfo cbi = new ComboInfo(dr["Name"].ToString(), dr["Name"].ToString());

                list.Add(cbi);
            }

            return list;
        }

        /// <summary>
        /// 产品筛选(融资期限)
        /// </summary>
        /// yangj    16.08.02
        /// <returns></returns>
        public List<ComboInfo> FindByFinancingPeriods(int creditId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT DISTINCT FinancingPeriods
                FROM PROD_ProduceInfo AS A
                LEFT JOIN CRET_BindProduce AS B
                    ON A.ProduceId = B.ProduceId
                    WHERE B.CreditId = @CreditId;");

            DHelper.AddParameter(comm, "@CreditId", SqlDbType.Int, creditId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            List<ComboInfo> list = new List<ComboInfo>();

            foreach (DataRow dr in dt.Rows)
            {
                ComboInfo cbi = new ComboInfo(dr["FinancingPeriods"].ToString(), dr["FinancingPeriods"].ToString());

                list.Add(cbi);
            }

            return list;
        }

        /// <summary>
        /// 产品筛选
        /// </summary>
        /// yangj    16.08.02
        /// <param name="produceName">产品名</param>
        /// <param name="repaymentMethod">还款方式</param>
        /// <param name="financingPeriods">融资期限</param>
        /// <returns></returns>
        public List<ComboInfo> FindProduct(string produceName, string repaymentMethod, string financingPeriods, int creditId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT A.ProduceId,
                        Code
                FROM PROD_ProduceInfo AS A
                LEFT JOIN CRET_BindProduce AS B
                    ON A.ProduceId = B.ProduceId
                WHERE B.CreditId = @CreditId
                AND (@Name IS NULL OR Name=@Name)
                AND (@RepaymentMethod IS NULL OR RepaymentMethod=@RepaymentMethod)
                AND (@FinancingPeriods IS NULL OR FinancingPeriods=@FinancingPeriods)");

            DHelper.AddParameter(comm, "@CreditId", SqlDbType.Int, creditId);
            DHelper.AddParameter(comm, "@Name", SqlDbType.NVarChar, produceName);
            DHelper.AddParameter(comm, "@RepaymentMethod", SqlDbType.Int, repaymentMethod);
            DHelper.AddParameter(comm, "@FinancingPeriods", SqlDbType.Int, financingPeriods);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            List<ComboInfo> list = new List<ComboInfo>();

            foreach (DataRow dr in dt.Rows)
            {
                ComboInfo cbi = new ComboInfo(dr["ProduceId"].ToString(), dr["Code"].ToString());

                list.Add(cbi);
            }

            return list;
        }
    }
}
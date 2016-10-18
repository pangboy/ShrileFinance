using System;
using System.Data;
using System.Data.SqlClient;
using Model.Finance;

namespace DAL.Finance
{
    public class FinanceExtraMapper : AbstractMapper<FinanceExtraInfo>
    {
        /// <summary>
        /// 查找
        /// </summary>
        /// yangj   16.08.29
        /// <param name="id">标识</param>
        /// <returns></returns>
        public FinanceExtraInfo Find(int id)
        {
            string findStatement =
              @"SELECT 
                    FinanceId,VehiclePrice,PurchaseTaxPrice,
                    BusinessInsurancePrice,TafficCompulsoryInsurancePrice,
                    VehicleVesselTaxPrice,ExtendedWarrantyInsurancePrice,OtherPrice,
                    ActualVehiclePrice,ActualPurchaseTaxPrice,ActualBusinessInsurancePrice,
                    ActualTafficCompulsoryInsurancePrice,ActualVehicleVesselTaxPrice,
                    ActualExtendedWarrantyInsurancePrice,ActualOtherPrice,
                    OperationType
                FROM FANC_FinanceExtra 
                WHERE FinanceId = @ID";

            return AbstractFind(findStatement, id);
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// yangj   16.08.29
        /// <param name="value">值</param>
        /// <returns></returns>
        public int Insert(FinanceExtraInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
				INSERT INTO FANC_FinanceExtra (
                    FinanceId,
                    VehiclePrice,
                    PurchaseTaxPrice,
                    BusinessInsurancePrice,
                    TafficCompulsoryInsurancePrice,
                    VehicleVesselTaxPrice,
                    ExtendedWarrantyInsurancePrice,
                    OtherPrice,
                    ActualVehiclePrice,
                    ActualPurchaseTaxPrice,
                    ActualBusinessInsurancePrice,
                    ActualTafficCompulsoryInsurancePrice,
                    ActualVehicleVesselTaxPrice,
                    ActualExtendedWarrantyInsurancePrice,
                    ActualOtherPrice,
                    OperationType
                    )
				VALUES (
                    @FinanceId,                 
                    @VehiclePrice,
                    @PurchaseTaxPrice,
                    @BusinessInsurancePrice,
                    @TafficCompulsoryInsurancePrice,
                    @VehicleVesselTaxPrice,
                    @ExtendedWarrantyInsurancePrice,
                    @OtherPrice,
                    @ActualVehiclePrice,
                    @ActualPurchaseTaxPrice,
                    @ActualBusinessInsurancePrice,
                    @ActualTafficCompulsoryInsurancePrice,
                    @ActualVehicleVesselTaxPrice,
                    @ActualExtendedWarrantyInsurancePrice,
                    @ActualOtherPrice,
                    @OperationType
                    ) 
			");

            DHelper.AddParameter(comm, "@FinanceId", SqlDbType.Int, value.FinanceId);

            // 融资预估金额
            DHelper.AddParameter(comm, "@VehiclePrice", SqlDbType.Decimal, value.VehiclePrice);
            DHelper.AddParameter(comm, "@PurchaseTaxPrice", SqlDbType.Decimal, value.PurchaseTaxPrice);
            DHelper.AddParameter(comm, "@BusinessInsurancePrice", SqlDbType.Decimal, value.BusinessInsurancePrice);
            DHelper.AddParameter(comm, "@TafficCompulsoryInsurancePrice", SqlDbType.Decimal, value.TafficCompulsoryInsurancePrice);
            DHelper.AddParameter(comm, "@VehicleVesselTaxPrice", SqlDbType.Decimal, value.VehicleVesselTaxPrice);
            DHelper.AddParameter(comm, "@ExtendedWarrantyInsurancePrice", SqlDbType.Decimal, value.ExtendedWarrantyInsurancePrice);
            DHelper.AddParameter(comm, "@OtherPrice", SqlDbType.Decimal, value.OtherPrice);

            // 融资实际金额
            DHelper.AddParameter(comm, "@ActualVehiclePrice", SqlDbType.Decimal, value.ActualVehiclePrice);
            DHelper.AddParameter(comm, "@ActualPurchaseTaxPrice", SqlDbType.Decimal, value.ActualPurchaseTaxPrice);
            DHelper.AddParameter(comm, "@ActualBusinessInsurancePrice", SqlDbType.Decimal, value.ActualBusinessInsurancePrice);
            DHelper.AddParameter(comm, "@ActualTafficCompulsoryInsurancePrice", SqlDbType.Decimal, value.ActualTafficCompulsoryInsurancePrice);
            DHelper.AddParameter(comm, "@ActualVehicleVesselTaxPrice", SqlDbType.Decimal, value.ActualVehicleVesselTaxPrice);
            DHelper.AddParameter(comm, "@ActualExtendedWarrantyInsurancePrice", SqlDbType.Decimal, value.ActualExtendedWarrantyInsurancePrice);
            DHelper.AddParameter(comm, "@ActualOtherPrice", SqlDbType.Decimal, value.ActualOtherPrice);
            DHelper.AddParameter(comm, "@OperationType", SqlDbType.TinyInt, value.OperationType);

            return DHelper.ExecuteNonQuery(comm);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// yangj   16.09.28
        /// <param name="value">值</param>
        /// <returns></returns>
        public int Update(FinanceExtraInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
				UPDATE FANC_FinanceExtra SET 
                    VehiclePrice=@VehiclePrice,
                    PurchaseTaxPrice=@PurchaseTaxPrice,
                    BusinessInsurancePrice=@BusinessInsurancePrice,
                    TafficCompulsoryInsurancePrice=@TafficCompulsoryInsurancePrice,
                    VehicleVesselTaxPrice=@VehicleVesselTaxPrice,
                    ExtendedWarrantyInsurancePrice=@ExtendedWarrantyInsurancePrice,
                    OtherPrice=@OtherPrice,
                    ActualVehiclePrice=@ActualVehiclePrice,
                    ActualPurchaseTaxPrice=@ActualPurchaseTaxPrice,
                    ActualBusinessInsurancePrice=@ActualBusinessInsurancePrice,
                    ActualTafficCompulsoryInsurancePrice=@ActualTafficCompulsoryInsurancePrice,
                    ActualVehicleVesselTaxPrice=@ActualVehicleVesselTaxPrice,
                    ActualExtendedWarrantyInsurancePrice=@ActualExtendedWarrantyInsurancePrice,
                    ActualOtherPrice=@ActualOtherPrice,
                    OperationType=@OperationType
				WHERE FinanceId = @FinanceId
			");

            DHelper.AddParameter(comm, "@FinanceId", SqlDbType.Int, value.FinanceId);

            // 融资预估金额
            DHelper.AddParameter(comm, "@VehiclePrice", SqlDbType.Decimal, value.VehiclePrice);
            DHelper.AddParameter(comm, "@PurchaseTaxPrice", SqlDbType.Decimal, value.PurchaseTaxPrice);
            DHelper.AddParameter(comm, "@BusinessInsurancePrice", SqlDbType.Decimal, value.BusinessInsurancePrice);
            DHelper.AddParameter(comm, "@TafficCompulsoryInsurancePrice", SqlDbType.Decimal, value.TafficCompulsoryInsurancePrice);
            DHelper.AddParameter(comm, "@VehicleVesselTaxPrice", SqlDbType.Decimal, value.VehicleVesselTaxPrice);
            DHelper.AddParameter(comm, "@ExtendedWarrantyInsurancePrice", SqlDbType.Decimal, value.ExtendedWarrantyInsurancePrice);
            DHelper.AddParameter(comm, "@OtherPrice", SqlDbType.Decimal, value.OtherPrice);

            // 融资实际金额
            DHelper.AddParameter(comm, "@ActualVehiclePrice", SqlDbType.Decimal, value.ActualVehiclePrice);
            DHelper.AddParameter(comm, "@ActualPurchaseTaxPrice", SqlDbType.Decimal, value.ActualPurchaseTaxPrice);
            DHelper.AddParameter(comm, "@ActualBusinessInsurancePrice", SqlDbType.Decimal, value.ActualBusinessInsurancePrice);
            DHelper.AddParameter(comm, "@ActualTafficCompulsoryInsurancePrice", SqlDbType.Decimal, value.ActualTafficCompulsoryInsurancePrice);
            DHelper.AddParameter(comm, "@ActualVehicleVesselTaxPrice", SqlDbType.Decimal, value.ActualVehicleVesselTaxPrice);
            DHelper.AddParameter(comm, "@ActualExtendedWarrantyInsurancePrice", SqlDbType.Decimal, value.ActualExtendedWarrantyInsurancePrice);
            DHelper.AddParameter(comm, "@ActualOtherPrice", SqlDbType.Decimal, value.ActualOtherPrice);
            DHelper.AddParameter(comm, "@OperationType", SqlDbType.TinyInt, value.OperationType);

            return DHelper.ExecuteNonQuery(comm);
        }
    }
}

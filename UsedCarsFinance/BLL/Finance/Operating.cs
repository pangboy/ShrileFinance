using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Finance;

namespace BLL.Finance
{
    public class Operating
    {
        private static readonly DAL.Finance.BankInfoMapper BankInfoMapper = new DAL.Finance.BankInfoMapper();
        private static readonly DAL.Finance.FinanceInfoMapper BinanceInfoMapper = new DAL.Finance.FinanceInfoMapper();
        private static readonly DAL.Finance.FinanceExtraMapper BinanceExtraInfoMapper = new DAL.Finance.FinanceExtraMapper();
        private static readonly DAL.Finance.VehicleInfoMapper VehicleInfoMapper = new DAL.Finance.VehicleInfoMapper();

        /// <summary>
        /// 获取运营信息
        /// </summary>
        /// <param name="financeId">融资标识</param>
        /// <returns></returns>
        public OperatingInfo Get(int financeId)
        {
            var operatingInfo = new OperatingInfo();

            // 获取BinkInfos
            operatingInfo.BankInfos = BankInfoMapper.List(financeId);

            // 获取融资信息
            operatingInfo.Finance = BinanceInfoMapper.Find(financeId);

            // 获取融资扩展信息
            operatingInfo.FinanceExtra = BinanceExtraInfoMapper.Find(financeId);

            // 获取车辆信息
            operatingInfo.VehicleInfo = VehicleInfoMapper.Find(financeId);

            return operatingInfo;
        }

        /// <summary>
        /// 运营信息录入
        /// </summary>
        /// <param name="operatingInfo">运营</param>
        /// <returns>添加结果</returns>
        public bool Add(OperatingInfo operatingInfo)
        {
            using (System.Transactions.TransactionScope scope = new System.Transactions.TransactionScope())
            {
                var result = true;

                // 添加BinkInfos
                BankInfoMapper.Insert(operatingInfo.BankInfos[0]);
                result &= operatingInfo.BankInfos[0].FinanceId > 0;
                BankInfoMapper.Insert(operatingInfo.BankInfos[1]);
                result &= operatingInfo.BankInfos[1].FinanceId > 0;

                // 更新融资信息
                var finance = BinanceInfoMapper.Find(operatingInfo.Finance.FinanceId.Value);
                if (finance != null)
                {
                    finance.MarginMoney = operatingInfo.Finance.MarginMoney;
                    finance.PaymonthlyMoney = operatingInfo.Finance.PaymonthlyMoney;
                    finance.OnepayInterestMoney = operatingInfo.Finance.OnepayInterestMoney;
                    finance.ActualcashMoney = operatingInfo.Finance.ActualcashMoney;

                    result &= BinanceInfoMapper.Update(finance) > 0;
                }

                // 跟新融资扩展信息
                var financeExtra = BinanceExtraInfoMapper.Find(operatingInfo.Finance.FinanceId.Value);
                if (financeExtra != null)
                {
                    financeExtra.ActualVehiclePrice = operatingInfo.FinanceExtra.ActualVehiclePrice;
                    financeExtra.ActualPurchaseTaxPrice = operatingInfo.FinanceExtra.ActualPurchaseTaxPrice;
                    financeExtra.ActualBusinessInsurancePrice = operatingInfo.FinanceExtra.ActualBusinessInsurancePrice;
                    financeExtra.ActualTafficCompulsoryInsurancePrice = operatingInfo.FinanceExtra.ActualTafficCompulsoryInsurancePrice;
                    financeExtra.ActualVehicleVesselTaxPrice = operatingInfo.FinanceExtra.ActualVehicleVesselTaxPrice;
                    financeExtra.ActualExtendedWarrantyInsurancePrice = operatingInfo.FinanceExtra.ActualExtendedWarrantyInsurancePrice;
                    financeExtra.ActualOtherPrice = operatingInfo.FinanceExtra.ActualOtherPrice;

                    result &= BinanceExtraInfoMapper.Update(financeExtra) > 0;
                }

                // 跟新车辆信息
                var vehicle = VehicleInfoMapper.Find(operatingInfo.Finance.FinanceId.Value);
                if (vehicle != null)
                {
                    vehicle.PlateNo = operatingInfo.VehicleInfo.PlateNo;
                    vehicle.FrameNo = operatingInfo.VehicleInfo.FrameNo;
                    vehicle.EngineNo = operatingInfo.VehicleInfo.EngineNo;
                    vehicle.BuyCarPrice = operatingInfo.VehicleInfo.BuyCarPrice;
                    vehicle.RegisterCity = operatingInfo.VehicleInfo.RegisterCity;

                    result &= VehicleInfoMapper.Update(operatingInfo.Finance.FinanceId.Value, vehicle) > 0;
                }

                if (result)
                {
                    scope.Complete();
                }
            }

            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Models;
using Models.Finance;

namespace BLL.Finance
{
    public class Finance
    {
        private readonly static DAL.Finance.FinanceInfoMapper financeMapper = new DAL.Finance.FinanceInfoMapper();
        private readonly static DAL.Finance.FinanceExtraMapper financeExtraMapper = new DAL.Finance.FinanceExtraMapper();
        private readonly static DAL.Finance.VehicleInfoMapper vehicleMapper = new DAL.Finance.VehicleInfoMapper();
        private readonly static BLL.Finance.Applicant _applicant = new Applicant();

        /// <summary>
        /// 获取
        /// </summary>
        /// qiy		16.03.31
        /// zouql   16.07.29
        /// <param name="financeId">融资标识</param>
        /// <returns></returns>
        public FinanceInfo Get(int financeId)
        {
            FinanceInfo finance = financeMapper.Find(financeId);

            //if (finance != null)
            //{
            //    finance.VehicleInfo = vehicleMapper.Find(financeId);

            //    BLL.Vehicle.IVehicleOption _vehicle = new BLL.Vehicle.VehicleIautos();

            //    _vehicle.Get(finance.VehicleInfo);

            //    finance.Applicants = _applicant.List(financeId);


            //}

            return finance;
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// yand    16.09.09
        /// <param name="financeId">融资标识</param>
        /// <returns></returns>
        public FinanceNodeGroupInfo GetFinanceNodeGroupInfo(int financeId)
        {
            FinanceNodeGroupInfo fngi = new FinanceNodeGroupInfo();

            FinanceInfo finance = financeMapper.Find(financeId);

            if (finance != null)
            {
                fngi.FinanceInfo = finance;
                fngi.VehicleInfo = vehicleMapper.Find(financeId);
                fngi.FinanceExtraInfo = new FinanceExtra().Get(financeId);

                BLL.Vehicle.IVehicleOption _vehicle = new BLL.Vehicle.VehicleIautos();

                _vehicle.Get(fngi.VehicleInfo);

                fngi.Applicants = _applicant.List(financeId);
            }

            return fngi;
        }

        /// <summary>
        /// 获取当前授信主体所拥有的产品选项
        /// </summary>
        /// qiy     16.04.07
        /// <returns></returns>
        public List<ComboInfo> ProducesOptionByCredit()
        {
            Credit.Credit _credit = new Credit.Credit();
            Credit.Account _creditAccount = new Credit.Account();

            //获取当前登录用户并借此查询授信主体标识
            int userId = User.User.CurrentUserId;
            var creditAccount = _creditAccount.Get(userId);

            if (creditAccount == null || creditAccount.CreditId == 0)
                return null;

            //获取授信主体所拥有的产品
            List<Models.Produce.ProduceInfo> produces = _credit.GetProduces(creditAccount.CreditId);

            //转换为选项
            List<ComboInfo> options = Produce.Produce.ProducesToOption(produces);

            return options;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// qiy		16.03.31
        /// <param name="financeNodeGroup">值</param>
        /// <returns></returns>
        public bool Add(FinanceNodeGroupInfo financeNodeGroup)
        {
            bool result = true;

            var financeInfo = financeNodeGroup.FinanceInfo;
            var vehicleInfo = financeNodeGroup.VehicleInfo;
            var applicants = financeNodeGroup.Applicants;
            var financeExtraInfo = financeNodeGroup.FinanceExtraInfo;

            var _creditAccount = new Credit.Account();
            var creditAccount = _creditAccount.Get(User.User.CurrentUserId);

            financeInfo.Type = FinanceInfo.TypeEnum.车辆融资;
            financeInfo.CreateBy = creditAccount.UserId;
            financeInfo.CreateOf = creditAccount.CreditId;

            using (TransactionScope scope = new TransactionScope())
            {
                financeMapper.Insert(financeInfo);
                result &= financeInfo.FinanceId > 0;

                if (result)
                {
                    financeExtraInfo.FinanceId = financeInfo.FinanceId.Value;
                    result &= financeExtraMapper.Insert(financeExtraInfo) > 0;
                }

                if (result)
                {
                    vehicleMapper.Insert(financeInfo.FinanceId.Value, vehicleInfo);
                }

                if (applicants != null)
                {
                    foreach (var applicant in applicants)
                    {
                        applicant.FinanceId = financeInfo.FinanceId.Value;

                        result &= _applicant.Add(applicant);
                    }
                }

                if (result)
                    scope.Complete();
            }

            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// qiy		16.03.31
        /// qiy     16.05.31
        /// yangj   16.07.26    新增融资预估金额
        /// zouql   16.08.04    新增融资实际金额
        /// <param name="value">值</param>
        /// <returns></returns>
        public bool Modify(FinanceNodeGroupInfo financeNodeGroup)
        {
            bool result = true;

            var financeInfo = financeNodeGroup.FinanceInfo;
            var financeExtraInfo = financeNodeGroup.FinanceExtraInfo;
            var vehicleInfo = financeNodeGroup.VehicleInfo;
            var applicants = financeNodeGroup.Applicants;

            FinanceInfo finance = Get(financeInfo.FinanceId.Value);
            VehicleInfo vehicle = new Vehicle().Get(financeInfo.FinanceId.Value);
            FinanceExtraInfo financeExtra = new BLL.Finance.FinanceExtra().Get(financeInfo.FinanceId.Value);
            List<ApplicantInfo> applicantList = new Applicant().List(financeInfo.FinanceId.Value);

            if (finance == null)
            {
                return false;
            }

            using (TransactionScope scope = new TransactionScope())
            {
                if (vehicleInfo != null)
                {
                    // 车辆基本信息
                    vehicle.VehicleKey = vehicleInfo.VehicleKey;
                    vehicle.BuyCarPrice = vehicleInfo.BuyCarPrice;
                    vehicle.RegisterCity = vehicleInfo.RegisterCity;
                    vehicle.SallerName = vehicleInfo.SallerName;
                    vehicle.PlateNo = vehicleInfo.PlateNo;
                    vehicle.FrameNo = vehicleInfo.FrameNo;
                    vehicle.EngineNo = vehicleInfo.EngineNo;
                    vehicle.RegisterDate = vehicleInfo.RegisterDate;
                    vehicle.RunningMiles = vehicleInfo.RunningMiles;
                    vehicle.FactoryDate = vehicleInfo.FactoryDate;
                    vehicle.BuyCarYears = vehicleInfo.BuyCarYears;
                    vehicle.Color = vehicleInfo.Color;
                    result &= vehicleMapper.Update(finance.FinanceId.Value, vehicleInfo) > 0;
                }
                else
                {
                    result &= vehicleMapper.Delete(finance.FinanceId.Value) > 0;
                }

                // 存在申请信息
                if (applicants != null)
                {
                    // 融资信息不存在对应的申请人信息
                    if (applicantList == null) applicantList = new List<ApplicantInfo>();

                    result &= Applicants(applicants, applicantList);
                }
                // 不存在申请人信息
                else
                {
                    // 融资信息存在对应的申请人信息，删除申请人信息
                    if (applicantList != null)
                    {
                        foreach (var applicant in applicantList)
                        {
                            result &= _applicant.Delete(applicant.ApplicantId.Value);
                        }
                    }
                }

                // 融资基本信息
                finance.Type = FinanceInfo.TypeEnum.车辆融资;
                finance.ProduceId = financeInfo.ProduceId;
                finance.IntentionPrincipal = financeInfo.IntentionPrincipal;
                finance.OncePayMonths = financeInfo.OncePayMonths;
                finance.Remarks = financeInfo.Remarks;

                result &= financeMapper.Update(finance) > 0;

                if(financeExtra != null)
                {
                    if (financeExtraInfo != null)
                    {
                        result &= financeExtraMapper.Update(financeExtraInfo) > 0;
                    }
                }
                
               
                if (result)
                    scope.Complete();
            }

            return result;
        }

        /// <summary>
        /// 更新运营节点信息
        /// </summary>
        /// yaoy    16.08.03
        /// zouql   16.08.04    新增融资实际金额
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ModifyOptionInfo(OperatingInfo value)
        {
            bool result = true;
            var _bankInfo = new Bank();

            var financeInfo = value.Finance;
            var financeExtraInfo = value.FinanceExtra;
            var bankList = value.BankInfos;
            var vehicleInfo = value.VehicleInfo;

            FinanceInfo finance = Get(financeInfo.FinanceId.Value);

            if (finance == null)
            {
                return false;
            }

            FinanceExtraInfo financeExtra = new FinanceExtra().Get(financeInfo.FinanceId.Value);
            VehicleInfo vehicle = new Vehicle().Get(finance.FinanceId.Value);

            using (TransactionScope scope = new TransactionScope())
            {
                if (vehicle != null && vehicleInfo != null)
                {
                    // 车辆基本信息修改
                    vehicle.VehicleKey = vehicleInfo.VehicleKey ?? vehicle.VehicleKey;
                    vehicle.BuyCarPrice = vehicleInfo.BuyCarPrice ?? vehicle.BuyCarPrice;
                    vehicle.RegisterCity = vehicleInfo.RegisterCity ?? vehicle.RegisterCity;
                    vehicle.SallerName = vehicleInfo.SallerName ?? vehicle.SallerName;
                    vehicle.PlateNo = vehicleInfo.PlateNo ?? vehicle.PlateNo;
                    vehicle.FrameNo = vehicleInfo.FrameNo ?? vehicle.FrameNo;
                    vehicle.EngineNo = vehicleInfo.EngineNo ?? vehicle.EngineNo;
                    vehicle.RegisterDate = vehicleInfo.RegisterDate ?? vehicle.RegisterDate;
                    vehicle.RunningMiles = vehicleInfo.RunningMiles ?? vehicle.RunningMiles;
                    vehicle.FactoryDate = vehicleInfo.FactoryDate ?? vehicle.FactoryDate;
                    vehicle.BuyCarYears = vehicleInfo.BuyCarYears ?? vehicle.BuyCarYears;
                    vehicle.Color = vehicleInfo.Color ?? vehicle.Color;
                    result &= vehicleMapper.Update(finance.FinanceId.Value, vehicle) > 0;
                }

                finance.MarginMoney = financeInfo.MarginMoney;
                finance.PaymonthlyMoney = financeInfo.PaymonthlyMoney;
                finance.OnepayInterestMoney = financeInfo.OnepayInterestMoney;
                finance.ActualcashMoney = financeInfo.ActualcashMoney;

                if (financeExtra != null && financeExtraInfo!=null)
                {
                    // 添加融资实际金额
                    financeExtra.ActualVehiclePrice = financeExtraInfo.ActualVehiclePrice;
                    financeExtra.ActualPurchaseTaxPrice = financeExtraInfo.ActualPurchaseTaxPrice;
                    financeExtra.ActualBusinessInsurancePrice = financeExtraInfo.ActualBusinessInsurancePrice;
                    financeExtra.ActualTafficCompulsoryInsurancePrice = financeExtraInfo.ActualTafficCompulsoryInsurancePrice;
                    financeExtra.ActualVehicleVesselTaxPrice = financeExtraInfo.ActualVehicleVesselTaxPrice;
                    financeExtra.ActualExtendedWarrantyInsurancePrice = financeExtraInfo.ActualExtendedWarrantyInsurancePrice;
                    financeExtra.ActualOtherPrice = financeExtraInfo.ActualOtherPrice;

                    result &= financeExtraMapper.Update(financeExtra) > 0;
                }

                result &= financeMapper.Update(finance) > 0;

                if (bankList != null)
                {
                    bankList.ForEach(delegate(BankInfo bank) {
                        if (bank != null)
                        {
                            bank.FinanceId = finance.FinanceId.Value;
                            result &= _bankInfo.Add(bank);
                        }
                    });
                }

                if (result)
                    scope.Complete();
            }

            return result;
        }
        /// <summary>
        /// 信息补充
        /// </summary>
        /// yand    16.11.02
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ModifyInfoAdditional(OperatingInfo value)
        {
            bool result = true;
            var _bankInfo = new Bank();

            var financeInfo = value.Finance;
            var bankList = value.BankInfos;
            var vehicleInfo = value.VehicleInfo;

            FinanceExtraInfo financeExtra = new FinanceExtra().Get(financeInfo.FinanceId.Value);
            VehicleInfo vehicle = new Vehicle().Get(financeInfo.FinanceId.Value);

            using (TransactionScope scope = new TransactionScope())
            {
                if (vehicle != null && vehicleInfo != null)
                {
                    // 车辆基本信息修改
                    vehicle.VehicleKey = vehicleInfo.VehicleKey ?? vehicle.VehicleKey;
                    vehicle.BuyCarPrice = vehicleInfo.BuyCarPrice ?? vehicle.BuyCarPrice;
                    vehicle.RegisterCity = vehicleInfo.RegisterCity ?? vehicle.RegisterCity;
                    vehicle.SallerName = vehicleInfo.SallerName ?? vehicle.SallerName;
                    vehicle.PlateNo = vehicleInfo.PlateNo ?? vehicle.PlateNo;
                    vehicle.FrameNo = vehicleInfo.FrameNo ?? vehicle.FrameNo;
                    vehicle.EngineNo = vehicleInfo.EngineNo ?? vehicle.EngineNo;
                    vehicle.RegisterDate = vehicleInfo.RegisterDate ?? vehicle.RegisterDate;
                    vehicle.RunningMiles = vehicleInfo.RunningMiles ?? vehicle.RunningMiles;
                    vehicle.FactoryDate = vehicleInfo.FactoryDate ?? vehicle.FactoryDate;
                    vehicle.BuyCarYears = vehicleInfo.BuyCarYears ?? vehicle.BuyCarYears;
                    vehicle.Color = vehicleInfo.Color ?? vehicle.Color;

                    vehicle.NewCarEngineNo = vehicleInfo.NewCarEngineNo ?? vehicleInfo.NewCarEngineNo;
                    vehicle.NewCarFrameNo = vehicleInfo.NewCarFrameNo ?? vehicleInfo.NewCarFrameNo;
                    vehicle.NewCarPlateNo = vehicleInfo.NewCarPlateNo ?? vehicleInfo.NewCarPlateNo;
                    vehicle.Mileage = vehicleInfo.Mileage ?? vehicleInfo.Mileage;
                    result &= vehicleMapper.Update(financeInfo.FinanceId.Value, vehicle) > 0;
                }

                if (bankList != null)
                {
                    bankList.ForEach(delegate (BankInfo bank) {
                        if (bank != null)
                        {
                            bank.FinanceId = financeInfo.FinanceId.Value;
                            result &= _bankInfo.Add(bank);
                        }
                    });
                }

                if (result)
                    scope.Complete();
            }

            return result;
        }

        /// <summary>
        /// 修改申请人列表
        /// </summary>
        /// qiy     16.04.08
        /// <param name="newList">页面提交的数据</param>
        /// <param name="oldList">数据库中的数据</param>
        /// <returns></returns>
        private bool Applicants(List<ApplicantInfo> newList, List<ApplicantInfo> oldList)
        {
            bool result = true;

            foreach (var value in newList)
            {
                if (value.ApplicantId > 0 && _applicant.Get(value.ApplicantId.Value) != null)
                {
                    result &= _applicant.Modify(value);
                }
                else
                {
                    result &= _applicant.Add(value);
                }
            }

            foreach (var value in oldList)
            {
                if (!newList.Exists(i => i.ApplicantId == value.ApplicantId))
                {
                    result &= _applicant.Delete(value.ApplicantId.Value);
                }
            }

            return result;
        }
    }
}

using Models.Finance;

namespace BLL.Finance
{
    public class Vehicle
    {
        private static readonly DAL.Finance.VehicleInfoMapper VehicleInfoMapper = new DAL.Finance.VehicleInfoMapper();

        /// <summary>
        /// 查找
        /// </summary>
        /// yangj   16.09.08
        /// <param name="financeId">标识</param>
        /// <returns></returns>
        public VehicleInfo Get(int financeId)
        {
            return VehicleInfoMapper.Find(financeId);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// yangj   16.09.08
        /// <param name="financeId">融资标识</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public bool Add(int financeId, VehicleInfo value)
        {
            VehicleInfoMapper.Insert(financeId, value);

            return financeId > 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// yangj   16.09.08
        /// <param name="financeId">融资标识</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public bool Modify(int financeId, VehicleInfo value)
        {
            return VehicleInfoMapper.Update(financeId, value) > 0;
        }
    }
}

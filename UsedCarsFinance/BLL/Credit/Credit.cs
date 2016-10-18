using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Credit;
using System.Transactions;

namespace BLL.Credit
{
    public class Credit
    {
        private readonly static DAL.Credit.CreditInfoMapper creditMapper = new DAL.Credit.CreditInfoMapper();
        private readonly static DAL.Credit.ProcessUserMapper processMapper = new DAL.Credit.ProcessUserMapper();

        /// <summary>
        /// 获取授信主体
        /// </summary>
        /// qiy		16.03.29
        /// <param name="creditId">标识</param>
        /// <returns></returns>
        public CreditInfo Get(int creditId)
        {
            CreditInfo credit = creditMapper.Find(creditId);

            if (credit != null)
            {
                credit.Produces = GetProduces(creditId);
                credit.ProcessUser = processMapper.Find(creditId);
            }

            return credit;
        }

        /// <summary>
        /// 获取授信主体选项
        /// </summary>
        /// qiy		16.03.29
        /// <returns></returns>
        public List<ComboInfo> Option()
        {
            return creditMapper.Option();
        }

        /// <summary>
        /// 添加授信主体
        /// </summary>
        /// qiy		16.03.29
        /// <param name="value">值</param>
        /// <returns></returns>
        public bool Add(CreditInfo value)
        {
            bool result = true;

            using (TransactionScope scope = new TransactionScope())
            {
                creditMapper.Insert(value);
                result &= value.CreditId > 0;

                if (result)
                {
                    value.ProcessUser.CreditId = value.CreditId;
                    processMapper.Insert(value.ProcessUser);

                }

                if (result)
                    BindProduce(value);

                if (result)
                    scope.Complete();
            }

            return result;
        }

        /// <summary>
        /// 修改授信主体
        /// </summary>
        /// qiy		16.03.29
        /// <param name="value">值</param>
        /// <returns></returns>
        public bool Modify(CreditInfo value)
        {
            CreditInfo credit = Get(value.CreditId);

            if (credit == null) return false;

            credit.Name = value.Name;
            credit.Type = value.Type;
            credit.LineOfCredit = value.LineOfCredit;
            credit.Produces = value.Produces;
            credit.Remarks = value.Remarks;

            credit.ProcessUser.User1 = value.ProcessUser.User1;
            credit.ProcessUser.User2 = value.ProcessUser.User2;
            credit.ProcessUser.User3 = value.ProcessUser.User3;
            credit.ProcessUser.User4 = value.ProcessUser.User4;
            credit.ProcessUser.User5 = value.ProcessUser.User5;

            bool result = true;

            using (TransactionScope scope = new TransactionScope())
            {
                result &= creditMapper.Update(credit) > 0;

                result &= processMapper.Update(credit.ProcessUser) > 0;

                if (result)
                    BindProduce(credit);

                if (result)
                    scope.Complete();
            }

            return result;
        }


        private readonly static DAL.Credit.BindProduceMapper bindProduceMapper = new DAL.Credit.BindProduceMapper();

        /// <summary>
        /// 获取授信主体下的所有产品
        /// </summary>
        /// qiy		16.03.29
        /// <param name="creditId">标识</param>
        /// <returns></returns>
        public List<Model.Produce.ProduceInfo> GetProduces(int creditId)
        {
            Produce.Produce _produce = new Produce.Produce();

            List<int> producesId = bindProduceMapper.FindByCredit(creditId);
            List<Model.Produce.ProduceInfo> produces = new List<Model.Produce.ProduceInfo>();

            foreach (int produceId in producesId)
            {
                produces.Add(_produce.Get(produceId));
            }

            return produces;
        }

        /// <summary>
        /// 绑定产品
        /// </summary>
        /// qiy		16.03.29
        /// <param name="credit">授信主体</param>
        /// <returns></returns>
        private void BindProduce(CreditInfo credit)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                bindProduceMapper.DeleteByCredit(credit.CreditId);

                if (credit.Produces != null && credit.Produces.Count > 0)
                    bindProduceMapper.InsertByCredit(credit.CreditId, credit.Produces);

                scope.Complete();
            }
        }

        private readonly static DAL.Credit.CityMapper citymapper = new DAL.Credit.CityMapper();

        /// <summary>
        /// 查询所有的省，用于页面
        /// </summary>
        /// cais    16.05.09
        /// <returns></returns>
        public List<ComboInfo> OptionProvince()
        {
            return citymapper.FindProvince();
        }

        /// <summary>
        /// 通过省查询市，用于页面  列表(Combo)
        /// </summary>
        /// cais    16.05.09
        /// <returns></returns>
        public List<ComboInfo> OptionCitys(int ProvinceCode)
        {
            return citymapper.FindCitys(ProvinceCode);
        }

        /// <summary>
        /// 通过市区代码查询市，用于页面列表(Combo)
        /// </summary>
        /// cais    16.05.09
        /// <returns></returns>
        public List<ComboInfo> OptionCity(int CityCode)
        {
            return citymapper.FindCity(CityCode);
        }
    }
}

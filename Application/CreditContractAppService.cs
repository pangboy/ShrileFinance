namespace Application
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Core.Entities.Loan;
    using Core.Interfaces.Repositories;
    using ViewModels.LoanViewModels;
    using X.PagedList;

    public class CreditContractAppService
    {
        private readonly ICreditContractRepository repository;

        public CreditContractAppService(ICreditContractRepository repository)
        {
            this.repository = repository;
        }

        public void Create(CreditContractViewModel model)
        {
            var credit = Mapper.Map<CreditContract>(model);
            repository.Create(credit);
            repository.Commit();
        }

        public void Modify(CreditContractViewModel model)
        {
            var credit = Mapper.Map<CreditContract>(model);
            repository.Modify(credit);
            repository.Commit();
        }

        public CreditContractViewModel Get(Guid id)
        {
            var credit = repository.Get(id);
            CreditContractViewModel creditViewModel = Mapper.Map<CreditContractViewModel>(credit);

            return creditViewModel;
        }

        /// <summary>
        /// 额度变更
        /// </summary>
        /// <param name="model">授信实体</param>
        public void ChangeEffective(CreditContract model)
        {
            model.ChangeLimit(model.CreditLimit);
            repository.Modify(model);
            repository.Commit();
        }

        /// <summary>
        /// 合同有效期变更
        /// </summary>
        /// <param name="model">授信实体</param>
        public void ChangeExpirationDate(CreditContract model)
        {
            model.ChangeExpirationDate(model.ExpirationDate);
            repository.Modify(model);
            repository.Commit();
        }

        /// <summary>
        /// 可否申请贷款
        /// </summary>
        /// <param name="limit">贷款金额</param>
        /// <returns></returns>
        public bool CanApplyLoan(decimal limit)
        {
            CreditContract credit = new CreditContract();
            return credit.CanApplyLoan(limit);
        }

        public IPagedList<CreditContractViewModel> GetPageList(string serach,int page ,int size)
        {
            var creditContract = repository.GetAll();
            if (!string.IsNullOrEmpty(serach))
            {
                creditContract = creditContract.Where(m=>m.LoanCode.Contains(serach));
            }

            creditContract = creditContract.OrderByDescending(m => m.Id);
            var pageList = creditContract.ToPagedList(page, size);

            var models = Mapper.Map<IPagedList<CreditContractViewModel>>(pageList);

            return models;
        }
    }
}

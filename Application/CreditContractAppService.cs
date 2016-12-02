namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Core.Entities.Loan;
    using Core.Interfaces.Repositories;
    using ViewModels.Loan;
    using ViewModels.Loan.CreditViewModel;
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

        /// <summary>
        /// 根据合同号和机构客户号筛选
        /// </summary>
        /// <param name="serach">筛选条件</param>
        /// <param name="page">页码</param>
        /// <param name="size">每页数量</param>
        /// <returns></returns>
        public IPagedList<CreditContractViewModel> GetPageList(string serach, int page, int size)
        {
            var creditContract = repository.GetAll();
            if (!string.IsNullOrEmpty(serach))
            {
                creditContract = creditContract.Where(m => m.LoanCode.Contains(serach) || m.Organization.CustomerNumber.Contains(serach));
            }

            creditContract = creditContract.OrderByDescending(m => m.Id);
            var pageList = creditContract.ToPagedList(page, size);

            var models = Mapper.Map<IPagedList<CreditContractViewModel>>(pageList);

            return models;
        }
    }
}

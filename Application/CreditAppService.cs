namespace Application
{
    using System;
    using AutoMapper;
    using Core.Entities.Loan;
    using Core.Interfaces.Repositories;
    using ViewModels.LoanViewModels;

    public class CreditAppService
    {
        private readonly ICreditRepository repository;

        public CreditAppService(ICreditRepository repository)
        {
            this.repository = repository;
        }

        public void Create(CreditViewModel model)
        {
            var credit = Mapper.Map<CreditContract>(model);
            repository.Create(credit);
            repository.Commit();
        }

        public CreditViewModel Get(Guid id)
        {
            var credit = repository.Get(id);
            CreditViewModel creditViewModel = Mapper.Map<CreditViewModel>(credit);

            return creditViewModel;
        }

        /// <summary>
        /// 额度变更
        /// </summary>
        /// <param name="model"></param>
        public void ChangeEffective(CreditViewModel model)
        {
            var creditmodel = Mapper.Map<CreditContract>(model);
            CreditContract credit = new CreditContract();
            credit.ChangeLimit(creditmodel.CreditLimit);
            repository.Modify(credit);
            repository.Commit();
        }

        public void ChangeExpirationDate(CreditViewModel model)
        {
            var creditmodel = Mapper.Map<CreditContract>(model);
            CreditContract credit = new CreditContract();
            credit.ChangeLimit(creditmodel.CreditLimit);
            repository.Modify(credit);
            repository.Commit();
        }
    }
}

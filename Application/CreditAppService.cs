namespace Application
{
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

        public Credit Create(CreditViewModel model)
        {
            var credit = Mapper.Map<Credit>(model);
            repository.Create(credit);
            repository.Commit();

            return credit;
        }

        public Credit Recredit(CreditViewModel model)
        {
            var credit = Mapper.Map<Credit>(model);
            repository.Modify(credit);
            repository.Commit();

            return credit;
        }
    }
}

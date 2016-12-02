namespace Application
{
    using AutoMapper;
    using Core.Entities.Loan;
    using Core.Interfaces.Repositories;
    using Core.Services.Loan;
    using ViewModels.Loan.LoanViewModels;
    using X.PagedList;

    public class LoanAppService
    {
        private readonly ICreditContractRepository creditRepository;
        private readonly LoanService loanService;
        private readonly PaymentService paymentService;
        private readonly ILoanRepository repository;

        public LoanAppService(
            LoanService loanService,
            PaymentService paymentService,
            ILoanRepository repository,
            ICreditContractRepository creditRepository)
        {
            this.loanService = loanService;
            this.paymentService = paymentService;
            this.repository = repository;
            this.creditRepository = creditRepository;
        }

        /// <summary>
        /// 申请贷款
        /// </summary>
        /// <param name="model">借据视图模型</param>
        public void ApplyLoan(LoanViewModel model)
        {
            var credit = creditRepository.Get(model.CreditContractId);
            var loan = Mapper.Map<Loan>(model);

            loanService.Loan(loan, credit);

            repository.Create(loan);
            repository.Commit();
        }

        /// <summary>
        /// 还款
        /// </summary>
        /// <param name="model">还款记录视图模型</param>
        public void Payment(PaymentHistoryViewModel model)
        {
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="searchString">借据编号</param>
        /// <param name="page">页码</param>
        /// <param name="size">尺寸</param>
        /// <param name="status">借据状态</param>
        /// <returns></returns>
        public IPagedList<LoanViewModel> PagedList(string searchString, int page, int size, LoanStatusEnum? status)
        {
            var loans = repository.PagedList(searchString, page, size, status);

            var models = Mapper.Map<IPagedList<LoanViewModel>>(loans);

            return models;
        }
    }
}

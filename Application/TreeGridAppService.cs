namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Application.ViewModels.TreeGrid;
    using Core.Entities.Loan;
    using Core.Interfaces.Repositories;
    using ViewModels;
    using X.PagedList;

    public class TreeGridAppService
    {
        private readonly ICreditContractRepository repository;

        public TreeGridAppService(ICreditContractRepository repository)
        {
            this.repository = repository;
        }

        public List<CreditCountViewModel> GetByCreditCount(List<CreditContract> creditCount)
        {
            List<CreditCountViewModel> creditCountList = new List<CreditCountViewModel>();
            if (creditCount != null)
            {
                foreach (var credit in creditCount)
                {
                    List<CreditCountViewModel> children = new List<CreditCountViewModel>();

                    // 添加子项
                    if (credit.Loans != null)
                    {
                        foreach (var loan in credit.Loans)
                        {
                            children.Add(new CreditCountViewModel
                            {
                                Id = loan.Id,
                                Amount = loan.Principle,
                                Balance = loan.Balance,
                                Code = loan.ContractNumber,
                                CreateDate = loan.SpecialDate,
                                EndDate = loan.MatureDate
                            });
                        }
                    }

                    creditCountList.Add(new CreditCountViewModel
                    {
                        Code = credit.LoanCode,
                        Amount = credit.CreditLimit,
                        Balance = credit.CreditBalance,
                        CreateDate = credit.EffectiveDate,
                        EndDate = credit.ExpirationDate,
                        Id = credit.Id,
                        children = children,
                        state = "closed"
                    });
                }
            }

            return creditCountList;
        }

        public IPagedList<CreditCountViewModel> TreeGridPageList(Guid? organizateId, int page, int rows)
        {
            var creditContract = repository.GetAll().ToList();
            List<CreditCountViewModel> creditCountList = new List<CreditCountViewModel>();
            IEnumerable<CreditContract> creditCount;

            if (!string.IsNullOrEmpty(organizateId.ToString()))
            {
                creditCount = creditContract.Where(m => m.OrganizationId == organizateId);
                creditCountList = GetByCreditCount(creditCount.ToList());
            }
            else
            {
                creditCountList = GetByCreditCount(creditContract);
            }

            creditCountList = creditCountList.OrderByDescending(m => m.Id).ToList();
            var pagedList = creditCountList.ToPagedList(page, rows);

            return pagedList;
        }
    }
}

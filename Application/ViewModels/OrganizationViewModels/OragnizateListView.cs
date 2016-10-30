namespace Application.ViewModels.OrganizationViewModels
{
    using System.Collections.Generic;
    using X.PagedList;

    public class PagedListViewModel<Entity>
    {
        public PagedListViewModel(IPagedList<Entity> entitys)
        {
            rows = entitys;
            total = entitys.TotalItemCount;
        }

        public IEnumerable<Entity> rows { get; set; }

        public int total { get; set; }
    }

    public class OragnizateListItemViewModel
    {
        public string CustomerNumber { get; set; }

        public string ManagementerCode { get; set; }
        public string InstitutionChName { get; set; }
        public string LoanCardCode { get; set; }
        public string InstitutionCreditCode { get; set; }
    }
}

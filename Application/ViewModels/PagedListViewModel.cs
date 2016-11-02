namespace Application.ViewModels
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

}

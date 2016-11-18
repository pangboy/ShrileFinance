namespace Application.ViewModels
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using X.PagedList;

    public class PagedListViewModel<Entity>
    {
        public PagedListViewModel(IPagedList<Entity> entitys)
        {
            Rows = entitys;
            Total = entitys.TotalItemCount;
        }

        [JsonProperty(PropertyName = "rows")]
        public IEnumerable<Entity> Rows { get; set; }

        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }
    }
}

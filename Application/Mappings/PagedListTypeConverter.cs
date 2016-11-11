namespace Application.Mappings
{
    using System.Collections.Generic;
    using AutoMapper;
    using X.PagedList;

    public class PagedListTypeConverter<TSource, TDestination> : ITypeConverter<IPagedList<TSource>, IPagedList<TDestination>>
    {
        public IPagedList<TDestination> Convert(IPagedList<TSource> source, IPagedList<TDestination> destination, ResolutionContext context)
        {
            var pagedListMetaData = source.GetMetaData();
            var superset = context.Mapper.Map<IEnumerable<TDestination>>(source);

            return new PagedList<TDestination>(pagedListMetaData, superset);
        }
    }
}

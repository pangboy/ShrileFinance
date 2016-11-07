using System;
using System.Linq;
using Application.ViewModels;
using Application.ViewModels.ProduceViewModel;
using AutoMapper;
using Core.Entities.Produce;
using Core.Interfaces.Repositories;
using X.PagedList;

namespace Application
{
    public class ProduceAppService
    {
        private readonly IProduceRepository repository;

        public ProduceAppService(IProduceRepository repository)
        {
            this.repository = repository;
        }
        public ProduceViewModel Get(Guid id)
        {
            Produce produce = repository.Get(id);
            var produceViewModel = Mapper.Map<ProduceViewModel>(produce);

            return produceViewModel;
        }

        public void Create(ProduceViewModel value)
        {
            var proudce = Mapper.Map<Produce>(value);

            repository.Create(proudce);
            repository.Commit();
        }

        public void Modify(ProduceViewModel value)
        {
            var proudce = Mapper.Map<Produce>(value);

            repository.Modify(proudce);
            repository.Commit();
        }

        public PagedListViewModel<ProduceListViewModel> GetPageList(string Serach, int pageNumber, int pageSize)
        {
            var pagedlist =
                repository
                .PagedList(m => m.Name == Serach, pageNumber, pageSize);

            var list = pagedlist.Select(m =>
                new ProduceListViewModel
                {
                    Id = m.Id,
                    Code = m.Code,
                    FinancingPeriods = m.FinancingPeriods,
                    CreatedDate = m.CreatedDate,
                    Name = m.Name,
                    RepaymentMethod = m.RepaymentMethod,
                });

            return new PagedListViewModel<ProduceListViewModel>(new PagedList<ProduceListViewModel>(pagedlist.GetMetaData(), list));
        }
    }
}

using System;
using System.Collections.Generic;
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
        private readonly IFinancingProjectRepository projectRepository;

        public ProduceAppService(IProduceRepository repository, IFinancingProjectRepository projectRepository)
        {
            this.repository = repository;
            this.projectRepository = projectRepository;
        }
        public ProduceViewModel Get(Guid id)
        {
            Produce produce = repository.Get(id);
            var produceViewModel = Mapper.Map<ProduceViewModel>(produce);

            return produceViewModel;
        }

        public void Create(ProduceViewModel value)
        {
            var produce = Mapper.Map<Produce>(value);
            if (value.Poundage != null)
            {
                foreach (var item in value.Poundage)
                {
                    var financingItem = Mapper.Map<FinancingItem>(item);
                  
                    produce.FinancingItems.Add(financingItem);
                }
            }

            repository.Create(produce);
            repository.Commit();
        }

        public void Modify(ProduceViewModel model)
        {
            var produce = repository.Get(model.Id);
            Mapper.Map(model, produce);
            //var produce = Mapper.Map<Produce>(value);
            if (model.Poundage != null)
            {
                foreach (var item in model.Poundage)
                {
                    var financingItem = Mapper.Map<FinancingItem>(item);
                    model.FinancingItems.Add(item);
                }
            }

            new UpdateBind().Bind(produce.FinancingItems, model.FinancingItems);

            repository.Modify(produce);
            repository.Commit();
        }

        public List<ProduceViewModel> GetAll()
        {
            var list = repository.GetAll();
            List<ProduceViewModel> producelist = new List<ProduceViewModel>();

            // 判断是否查询到产品信息
            if (list != null)
            {
                foreach (var item in list)
                {
                    // 产品映射成对应的ViewModel
                    var produceViewModel = Mapper.Map<ProduceViewModel>(item);

                    producelist.Add(produceViewModel);
                }
            }
            return producelist;
        }

        public ProduceViewModel GetByCode(string code)
        {
            var produce = repository.GetAll().FirstOrDefault(m => m.Code == code);
            var produceViewModel = new ProduceViewModel();
            List<FinancingProjectListViewModel> List = new List<FinancingProjectListViewModel>();

            produceViewModel = Mapper.Map<ProduceViewModel>(produce);

            if (produceViewModel != null)
            {
                if (produceViewModel.FinancingItems.Count > 0)
                {
                    foreach (var financing in produceViewModel.FinancingItems)
                    {
                        // 融资项否则为手续费项目
                        if (financing.FinancingProject.IsFinancing == false)
                        {
                            produceViewModel.PoundageList.Add(new FinancingProjectListViewModel()
                            {
                                FinancingProjectId = financing.FinancingProjectId,
                                IsEdit = financing.IsEdit,
                                IsFinancing = financing.FinancingProject.IsFinancing,
                                Money = financing.Money,
                                Name = financing.FinancingProject.Name
                            });
                        }
                        else
                        {
                            var aaa = new FinancingProjectListViewModel()
                            {
                                FinancingProjectId = financing.FinancingProjectId,
                                IsEdit = financing.IsEdit,
                                IsFinancing = financing.FinancingProject.IsFinancing,
                                Money = financing.Money,
                                Name = financing.FinancingProject.Name
                            };
                            produceViewModel.FinancingItemsList.Add(aaa);
                        }
                    }
                }
            }

            return produceViewModel;
        }

        public PagedListViewModel<ProduceListViewModel> GetPageList(string Serach, int pageNumber, int pageSize)
        {
            if (Serach == null)
            {
                Serach = "";
            }
            var pagedlist =
                repository
                .PagedList(m => m.Name.Contains(Serach) || m.Code.Contains(Serach), pageNumber, pageSize);

            var list = pagedlist.Select(m =>
                new ProduceListViewModel
                {
                    Id = m.Id,
                    Code = m.Code,
                    FinancingPeriods = m.FinancingPeriods,
                    CreatedDate = m.CreatedDate,
                    Name = m.Name,
                    RepaymentMethod = m.RepaymentMethod,
                    RepaymentMethodDesc = m.RepaymentMethod.ToString(),
                    MaxFinancingRatio = m.MaxFinancingRatio,
                    MinFinancingRatio = m.MinFinancingRatio,
                    CostRate = m.CostRate,
                    FinalRatio = m.FinalRatio,
                    InterestRate = m.InterestRate,
                    CustomerBailRatio = m.CustomerBailRatio
                });

            return new PagedListViewModel<ProduceListViewModel>(new PagedList<ProduceListViewModel>(pagedlist.GetMetaData(), list));
        }
    }
}

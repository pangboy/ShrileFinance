using System.Collections.Generic;
using Application.ViewModels.ProduceViewModel;
using AutoMapper;
using Core.Entities.Produce;
using Core.Interfaces.Repositories;

namespace Application
{
    public class FinancingProjectAppService
    {
        private readonly IFinancingProjectRepository repository;

        public FinancingProjectAppService(IFinancingProjectRepository repository)
        {
            this.repository = repository;
        }

        public void Create(FinancingProjectViewModel value)
        {
            var financingProject = Mapper.Map<FinancingProject>(value);

            repository.Create(financingProject);
            repository.Commit();
        }

        public void Modify(FinancingProjectViewModel value)
        {
            var financingProject = Mapper.Map<FinancingProject>(value);

            repository.Modify(financingProject);
            repository.Commit();
        }

        public List<FinancingItemListViewModel> GetAll()
        {
            var financingProjectList = repository.GetAll();
            List<FinancingItemListViewModel> List = new List<FinancingItemListViewModel>();
            if (financingProjectList!=null)
            {
                foreach (var financingProject in financingProjectList)
                {
                    FinancingItemListViewModel financinglist = new FinancingItemListViewModel()
                    {
                        Name = financingProject.Name,
                        IsFinancing = financingProject.IsFinancing
                    };

                    List.Add(financinglist);
                }
            }

            return List;
        }
    }
}

namespace Application
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Core.Entities;
    using Core.Entities.Partner;
    using Core.Interfaces.Repositories;
    using Microsoft.AspNet.Identity;
    using ViewModels;
    using ViewModels.AccountViewModels;
    using ViewModels.PartnerViewModels;
    using ViewModels.ProduceViewModel;
    using X.PagedList;

    public class PartnerAppService
    {
        private readonly IPartnerRepository repository;
        private readonly IProduceRepository produceRepository;
        private readonly AppUserManager userManager;
        private AccountAppService accountService;

        public PartnerAppService(
            IPartnerRepository repository,
            IProduceRepository produceRepository,
            AppUserManager userManager,
            AccountAppService accountService)
        {
            this.repository = repository;
            this.produceRepository = produceRepository;
            this.userManager = userManager;
            this.accountService = accountService;
        }

        public PartnerViewModel Get(Guid key)
        {
            var partner = repository.Get(key);

            return Mapper.Map<PartnerViewModel>(partner);
        }

        public void Create(PartnerViewModel model)
        {
            var partner = Mapper.Map<Partner>(model);

            var produceIds = model.Produces.Select(m => m.Id);
            partner.Produces = produceRepository.GetAll(m => produceIds.Contains(m.Id)).ToList();

            partner.Approvers = userManager.Users.Where(m => model.Approvers.Contains(m.Id)).ToList();

            if (partner.Approvers.Select(m => m.RoleId).Count() != 5)
            {
                throw new Core.Exceptions.InvalidOperationAppException("每个角色有且仅有一个审批用户.");
            }

            repository.Create(partner);
            repository.Commit();
        }

        public void Modify(PartnerViewModel model)
        {
            var partner = repository.Get(model.Id.Value);
            Mapper.Map(model, partner);

            var produceIds = model.Produces.Select(m => m.Id);
            partner.Produces.Clear();
            partner.Produces = produceRepository.GetAll(m => produceIds.Contains(m.Id)).ToList();

            partner.Approvers.Clear();
            partner.Approvers = userManager.Users.Where(m => model.Approvers.Contains(m.Id)).ToList();

            if (partner.Approvers.Select(m => m.RoleId).Count() != 5)
            {
                throw new Core.Exceptions.InvalidOperationAppException("每个角色有且仅有一个审批用户.");
            }

            repository.Modify(partner);
            repository.Commit();
        }

        public async Task CreateAccount(UserViewModel model, Guid partnerId)
        {
            var partner = repository.Get(partnerId);

            if (model.Role != "C342BEE1-05A4-E611-80C5-507B9DE4A488" && model.Role != "C442BEE1-05A4-E611-80C5-507B9DE4A488")
            {
                throw new Core.Exceptions.InvalidOperationAppException("用户的角色只能是客户经理或渠道经理.");
            }

            var createResult = await accountService.CreateUserAsync(model);

            if (!createResult.Succeeded)
            {
                throw new InvalidOperationException("创建用户失败.");
            }

            var user = userManager.FindById(model.Id);

            partner.Accounts.Add(user);

            repository.Commit();
        }

        public IPagedList<PartnerViewModel> List(string searchString, int page, int size)
        {
            var partners = repository.GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                partners.Where(m => m.Name.Contains(searchString)
                    || m.ControllerName.Contains(searchString));
            }

            var list = partners.ToPagedList(page, size);

            var models = Mapper.Map<IPagedList<PartnerViewModel>>(list);

            return models;
        }

        public PagedListViewModel<ProduceListViewModel> GetPageListByPartner(string Serach, int pageNumber, int pageSize)
        {
            if (Serach == null)
            {
                Serach = "";
            }
            var CreateOf = repository.GetByUser(userManager.CurrentUser());
            var pagedlist =
                repository
                .PagedList(m => m.Id == CreateOf.Id && m.Produces.Any(t => t.Name.Contains(Serach) || t.Code.Contains(Serach)), pageNumber, pageSize);

            var list = pagedlist.SelectMany(m => m.Produces.Select(t => new ProduceListViewModel
            {
                Id = t.Id,
                Code = t.Code,
                FinancingPeriods = t.FinancingPeriods,
                CreatedDate = t.CreatedDate,
                Name = m.Name,
                RepaymentMethod = t.RepaymentMethod,
                RepaymentMethodDesc = t.RepaymentMethod.ToString(),
                MaxFinancingRatio = t.MaxFinancingRatio,
                MinFinancingRatio = t.MinFinancingRatio,
                CostRate = t.CostRate,
                FinalRatio = t.FinalRatio,
                InterestRate = t.InterestRate,
                CustomerBailRatio = t.CustomerBailRatio
            }));

            return new PagedListViewModel<ProduceListViewModel>(new PagedList<ProduceListViewModel>(pagedlist.GetMetaData(), list));
        }
    }
}

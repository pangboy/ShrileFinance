namespace Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Core.Entities.Produce;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ModelConfigurations;

    public class MyContext : IdentityDbContext
    {
        public MyContext()
            : base("name=MyContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations
                .Add(new AppUserConfiguration())
                .Add(new FlowConfiguration())
                .Add(new NodeConfiguration())
                .Add(new ActionConfiguration())
                .Add(new InstanceConfiguration())
                .Add(new LogConfiguration())
                .Add(new FormConfiguration())
                .Add(new FormNodeConfiguration())
                .Add(new FormRoleConfiguration())
                .Add(new OrganizationConfiguration())
                .Add(new ManagerConfiguration())
                .Add(new StockholderConfiguration())
                .Add(new AssociatedEnterpriseConfiguration())
                .Add(new FamilyMemberConfiguration())
                .Add(new BigEventConfiguration())
                .Add(new CashFlowConfiguration())
                .Add(new InstitutionIncomeExpenditureConfiguration())
                .Add(new InstitutionLiabilitiesConfiguration())
                .Add(new LiabilitiesConfiguration())
                .Add(new LitigationConfigruation())
                .Add(new ProfitConfiguration())
                .Add(new FinancialAffairsConfiguration())
                .Add(new ParentConfigration())
                .Add(new FinancingItemConfigration())
                .Add(new FinancingProjectConfigration())
                .Add(new ProduceConfigration())
                .Add(new FinanceConfigration())
                .Add(new CreditExamineConfiguration())
                .Add(new ContactConfiguration())
                .Add(new FinanceExtensionConfiguration())
                .Add(new ParentConfigration())
                .Add(new PartnerConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
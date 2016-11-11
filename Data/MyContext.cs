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
                // 融资
                .Add(new FinanceConfigration())
                // 信审报告
                .Add(new CreditExamineConfiguration())
                // 合同
                .Add(new ContactConfiguration())
                // 融资扩展
                .Add(new FinanceExtensionConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
namespace Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
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

            // Identity Configurations
            modelBuilder.Configurations
                .Add(new AppUserConfiguration());

            // Process Configurations
            modelBuilder.Configurations
                .Add(new FlowConfiguration())
                .Add(new NodeConfiguration())
                .Add(new ActionConfiguration())
                .Add(new InstanceConfiguration())
                .Add(new LogConfiguration())
                .Add(new FormConfiguration())
                .Add(new FormNodeConfiguration())
                .Add(new FormRoleConfiguration());

            // Produce Configurations
            modelBuilder.Configurations
                .Add(new FinancingItemConfigration())
                .Add(new FinancingProjectConfigration())
                .Add(new ProduceConfigration());

            // Partner and Draft Configurations
            modelBuilder.Configurations
                .Add(new PartnerConfiguration())
                .Add(new DraftConfiguration());

            // Finance Configurations
            modelBuilder.Configurations
                .Add(new FinanceConfigration())
                .Add(new FinanceProduceConfiguration())
                .Add(new ApplicantConfiguration())
                .Add(new VehicleConfigration())
                .Add(new FinanceExtensionConfiguration())
                .Add(new ContactConfiguration())
                .Add(new CreditExamineConfiguration());

            // Organization Configurations
            ////modelBuilder.Configurations
            ////    .Add(new OrganizationConfiguration())
            ////    .Add(new ManagerConfiguration())
            ////    .Add(new StockholderConfiguration())
            ////    .Add(new AssociatedEnterpriseConfiguration())
            ////    .Add(new FamilyMemberConfiguration())
            ////    .Add(new BigEventConfiguration())
            ////    .Add(new CashFlowConfiguration())
            ////    .Add(new InstitutionIncomeExpenditureConfiguration())
            ////    .Add(new InstitutionLiabilitiesConfiguration())
            ////    .Add(new LiabilitiesConfiguration())
            ////    .Add(new LitigationConfigruation())
            ////    .Add(new ProfitConfiguration())
            ////    .Add(new ParentConfigration())
            ////    .Add(new FinancialAffairsConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
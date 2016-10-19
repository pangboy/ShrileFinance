namespace Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using ModelConfigurations;

    public class MyContext : DbContext
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
                .Add(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
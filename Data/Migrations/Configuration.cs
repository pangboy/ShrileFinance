namespace Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Core.Entities.Produce;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.MyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Set<FinancingProject>().AddOrUpdate(
               m=> m.Id,
               new FinancingProject { Id = new Guid("{093C0A6D-ABA4-E611-80C5-507B9DE4A488}"), Name = "裸车价", IsFinancing = true },
               new FinancingProject { Id = new Guid("{0A3C0A6D-ABA4-E611-80C5-507B9DE4A488}"), Name = "购置税", IsFinancing = true },
               new FinancingProject { Id = new Guid("{0B3C0A6D-ABA4-E611-80C5-507B9DE4A488}"), Name = "商业险", IsFinancing = true },
               new FinancingProject { Id = new Guid("{0C3C0A6D-ABA4-E611-80C5-507B9DE4A488}"), Name = "交强险", IsFinancing = true },
               new FinancingProject { Id = new Guid("{0D3C0A6D-ABA4-E611-80C5-507B9DE4A488}"), Name = "车船税", IsFinancing = true },
               new FinancingProject { Id = new Guid("{0E3C0A6D-ABA4-E611-80C5-507B9DE4A488}"), Name = "延保险", IsFinancing = true },
               new FinancingProject { Id = new Guid("{0F3C0A6D-ABA4-E611-80C5-507B9DE4A488}"), Name = "其他", IsFinancing = true },
               new FinancingProject { Id = new Guid("{103C0A6D-ABA4-E611-80C5-507B9DE4A488}"), Name = "GPS费用", IsFinancing = false },
               new FinancingProject { Id = new Guid("{113C0A6D-ABA4-E611-80C5-507B9DE4A488}"), Name = "手续费", IsFinancing = false }
               );
        }
     
    }
}

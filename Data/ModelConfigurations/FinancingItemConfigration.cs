namespace Data.ModelConfigurations 
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Produce;

    /// <summary>
    /// 产品对应的融资项
    /// </summary>
    public class FinancingItemConfigration : EntityTypeConfiguration<FinancingItem>
    {
        public FinancingItemConfigration()
        {
            Property(m => m.Id);
            Property(m => m.Money);
            Property(m => m.IsEdit);

            ToTable("PROD_FinancingItem");
        }
    }
}

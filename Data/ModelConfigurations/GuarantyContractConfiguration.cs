namespace Data.ModelConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Loan;

    public class GuarantyContractConfiguration : EntityTypeConfiguration<GuarantyContract>
    {
        public GuarantyContractConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m=>m.SigningDate).IsOptional();
            Property(m => m.GuaranteeForm).IsOptional();
            Property(m => m.EffectiveState).IsOptional();
            HasOptional(m => m.IGuarantor).WithOptionalPrincipal().Map(m => m.MapKey("GuarantyContractId")).WillCascadeOnDelete(false);
        }
    }
}

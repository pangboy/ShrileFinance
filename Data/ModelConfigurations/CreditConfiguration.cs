namespace Data.ModelConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Loan;

    public class CreditConfiguration: EntityTypeConfiguration<Credit>
    {
        public CreditConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.LoanCode).HasMaxLength(60);
            Property(m => m.EffectiveDate);
            Property(m => m.ExpirationDate);
            Property(m => m.CreditLimit);
            Property(m => m.CreditBalance);
            Property(m => m.ValidStatus);
            Property(m => m.IsGuarantee);
            HasMany(m => m.GuarantyContract).WithOptional().Map(m => m.MapKey("LoanId")).WillCascadeOnDelete();

            ToTable("LOAN_LoanContranct");
        }
    }
}

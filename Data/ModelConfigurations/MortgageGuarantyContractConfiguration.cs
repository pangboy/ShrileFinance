namespace Data.ModelConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Loan;

    public class MortgageGuarantyContractConfiguration : EntityTypeConfiguration<GuarantyContractMortgage>
    {
        public MortgageGuarantyContractConfiguration()
        {
            Property(m => m.MortgageNumber).IsRequired().HasMaxLength(2);
            Property(m => m.AssessmentValue).IsRequired();
            Property(m => m.AssessmentDate).IsRequired();
            Property(m => m.AssessmentName).IsRequired().HasMaxLength(80);
            Property(m => m.AssessmentOrganizationCode).IsRequired().HasMaxLength(10);
            Property(m => m.CollateralType).IsRequired();
            Property(m => m.RegistrateAuthorit).IsRequired().HasMaxLength(80);
            Property(m => m.RegistrateDate).IsRequired();
            Property(m => m.CollateralInstruction).IsRequired().HasMaxLength(400);
        }
    }
}

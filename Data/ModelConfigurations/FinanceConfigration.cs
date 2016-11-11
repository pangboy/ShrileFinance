namespace Data.ModelConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Finance;

    public class FinanceConfigration : EntityTypeConfiguration<Finance>
    {
        public FinanceConfigration()
        {
            // 主键
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m=>m.Principal);
            Property(m => m.InterestRate);
            Property(m => m.Periods);
            Property(m => m.RepaymentInterval);
            Property(m => m.RepaymentDate);
            Property(m => m.RepaymentScheme);
            Property(m => m.Bail);
            Property(m => m.Cost);
            Property(m => m.State);
            Property(m => m.DateEffective);
            Property(m => m.DateCreated);
            Property(m => m.IntentionPrincipal);
            Property(m => m.OncePayMonths);
            Property(m => m.AdviceMoney);
            Property(m => m.AdviceRatio);
            Property(m => m.ApprovalMoney);
            Property(m => m.ApprovalRatio);
            Property(m => m.MonthMoney);
            Property(m => m.RepayDate);
            Property(m => m.RepayRentDate);

            // 信审报告
            HasOptional(m => m.CreditExamine).WithOptionalPrincipal().Map(m => m.MapKey("FinanceId")).WillCascadeOnDelete();
            //车辆信息
            HasOptional(m => m.VehicleInfo).WithOptionalPrincipal().Map(m => m.MapKey("FinanceId")).WillCascadeOnDelete();
            //联系人信息
            HasOptional(m => m.Applicant).WithOptionalPrincipal().Map(m => m.MapKey("FinanceId")).WillCascadeOnDelete();

            ToTable("FANC_Finance");
        }
    }
}

﻿namespace Data.ModelConfigurations.Loan
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Loan;

    public class GuarantyPersonConfiguration:EntityTypeConfiguration<GuarantorPerson>
    {
        public GuarantyPersonConfiguration()
        {
            //HasKey(m => m.Id);
            //Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //Property(m=>m.Name).IsRequired().HasMaxLength(80);
            Property(m => m.CertificateType).IsRequired().HasMaxLength(1);
            Property(m => m.CertificateNumber).IsRequired().HasMaxLength(18);
        }
    }
}

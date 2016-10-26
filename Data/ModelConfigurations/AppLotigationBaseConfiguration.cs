﻿namespace Data.ModelConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Concern;

    public class AppLotigationBaseConfiguration : EntityTypeConfiguration<LitigationBasePeriod>
    {
        public AppLotigationBaseConfiguration() : base()
        {
            Property(m => m.BorrowName).IsRequired().HasMaxLength(80);
            Property(m => m.BusinessDate).IsRequired().HasMaxLength(8);
            Property(m => m.InformationOperationType).IsRequired().HasMaxLength(1);
            Property(m => m.LoanCardCode).IsRequired().HasMaxLength(16).IsFixedLength();
        }
    }
}

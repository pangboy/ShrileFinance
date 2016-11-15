using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Finance;

namespace Data.ModelConfigurations
{
    public class FinanceProduceConfiguration : EntityTypeConfiguration<FinanceProduce>
    {
        public FinanceProduceConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.Money);
            Property(m => m.IsEdit);
            Property(m => m.IsFinancing);
            Property(m => m.Name);

            ToTable("FANC_FinanceProduce");
        }
    }
}

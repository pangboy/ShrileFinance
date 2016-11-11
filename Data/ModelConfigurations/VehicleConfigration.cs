namespace Data.ModelConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities.Vehicle;

    public class VehicleConfigration : EntityTypeConfiguration<Vehicle>
    {
        public VehicleConfigration()
        {
            // 主键
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            Property(m => m.VehicleKey).IsRequired().HasMaxLength(20);
            Property(m => m.RegisterCity).HasMaxLength(50);
            Property(m => m.SallerName).HasMaxLength(50);
            Property(m => m.PlateNo).HasMaxLength(50);
            Property(m => m.FrameNo).HasMaxLength(50);
            Property(m => m.EngineNo).HasMaxLength(50);
            Property(m => m.Color).HasMaxLength(50);

            ToTable("Finance_Vehicle");
        }
    }
}

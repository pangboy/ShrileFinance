namespace Data.ModelConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Entities;

    public class UserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public UserConfiguration() : base()
        {
            HasKey(m => m.Id);

            Property(m => m.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.Username)
                .IsRequired()
                .HasMaxLength(32)
                .HasUniqueIndexAnnotation();
            Property(m => m.PasswordHash)
                .IsRequired()
                .HasMaxLength(32)
                .HasColumnName("Password");
            Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(50);
            Property(m => m.Email)
                .HasMaxLength(50);
            Property(m => m.Phone)
                .HasMaxLength(50);

            Ignore(m => m.Password);
            ToTable("User");
        }
    }
}

namespace Data.ModelConfigurations
{
    using Core.Entities;

    public class UserConfiguration : EntityConfiguration<User>
    {
        public UserConfiguration() : base()
        {
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

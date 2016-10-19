namespace Data.ModelConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core.Interfaces;

    public abstract class EntityConfiguration<TEntity> : EntityTypeConfiguration<TEntity>
        where TEntity : class, IEntity
    {
        protected EntityConfiguration()
        {
            HasKey(m => m.Id);

            Property(m => m.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}

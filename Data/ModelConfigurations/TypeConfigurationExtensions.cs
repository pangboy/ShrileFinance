namespace Data.ModelConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.ModelConfiguration.Configuration;

    internal static class TypeConfigurationExtensions
    {
        /// <summary>
        /// 将属性配置为唯一约束
        /// </summary>
        /// <param name="property">属性</param>
        /// <returns></returns>
        public static PrimitivePropertyConfiguration HasUniqueIndexAnnotation(
            this PrimitivePropertyConfiguration property)
        {
            var indexAttribute = new IndexAttribute { IsUnique = true };
            var indexAnnotation = new IndexAnnotation(indexAttribute);

            return property.HasColumnAnnotation(IndexAnnotation.AnnotationName, indexAnnotation);
        }
    }
}

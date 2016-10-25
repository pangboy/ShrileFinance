namespace Application
{
    using AutoMapper;
    using Mappings;

    /// <summary>
    /// 自动映射的配置
    /// </summary>
    public partial class Startup
    {
        public void ConfigureMapper()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<DomainToViewModelMappingProfile>();
                config.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}

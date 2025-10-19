using AutoMapper;
using Domain.Config;

namespace CrudProductManagement.Configurations
{
    internal static class AutoMapperConfig
    {
        /// <summary>
        /// Add Auto Mapper Configuration
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        internal static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var mapperConfig = new MapperConfiguration(
                cfg => cfg.AddProfile<MappingProfile>(), 
                provider.GetRequiredService<ILoggerFactory>());
            IMapper mapper = mapperConfig.CreateMapper();
            return services.AddSingleton(mapper);
        }
    }
}

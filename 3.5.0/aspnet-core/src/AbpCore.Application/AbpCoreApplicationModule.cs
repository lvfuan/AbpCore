using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpCore.Authorization;
using AbpCore.IDtoMappings;
using Castle.MicroKernel.Registration;
using System.Reflection;

namespace AbpCore
{
    [DependsOn(
        typeof(AbpCoreCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AbpCoreApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AbpCoreAuthorizationProvider>();
        }
 

        public override void Initialize()
        {
            var thisAssembly = typeof(AbpCoreApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );

            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //注册IDtoMapping
            IocManager.IocContainer.Register(
                Classes.FromAssembly(Assembly.GetExecutingAssembly())
                    .IncludeNonPublicTypes()
                    .BasedOn<IDtoMapping>()
                    .WithService.Self()
                    .WithService.DefaultInterfaces()
                    .LifestyleTransient()
            );

            //解析依赖，并进行映射规则创建
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                var mappers = IocManager.IocContainer.ResolveAll<IDtoMapping>();
                foreach (var dtomap in mappers)
                    dtomap.CreateMapping(mapper);
            });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using AbpCore.Configuration;
using AbpCore.Web;

namespace AbpCore.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class AbpCoreDbContextFactory : IDesignTimeDbContextFactory<AbpCoreDbContext>
    {
        public AbpCoreDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AbpCoreDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            AbpCoreDbContextConfigurer.Configure(builder, configuration.GetConnectionString(AbpCoreConsts.ConnectionStringName));

            return new AbpCoreDbContext(builder.Options);
        }
    }
}

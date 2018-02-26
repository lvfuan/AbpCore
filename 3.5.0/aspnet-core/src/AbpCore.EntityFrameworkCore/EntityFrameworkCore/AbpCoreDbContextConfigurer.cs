using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AbpCore.EntityFrameworkCore
{
    public static class AbpCoreDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AbpCoreDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AbpCoreDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}

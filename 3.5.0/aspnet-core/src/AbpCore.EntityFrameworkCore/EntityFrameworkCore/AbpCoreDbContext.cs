using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AbpCore.Authorization.Roles;
using AbpCore.Authorization.Users;
using AbpCore.MultiTenancy;
using AbpCore.Models;

namespace AbpCore.EntityFrameworkCore
{
    public class AbpCoreDbContext : AbpZeroDbContext<Tenant, Role, User, AbpCoreDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<TestModel> Test { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public AbpCoreDbContext(DbContextOptions<AbpCoreDbContext> options)
            : base(options)
        {
        }
    }
}

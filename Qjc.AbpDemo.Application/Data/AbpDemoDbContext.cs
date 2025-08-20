using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Qjc.AbpDemo
{
    [ConnectionStringName("Default")]
    public class AbpDemoDbContext : AbpDbContext<AbpDemoDbContext>
    {
        public DbSet<Test> Tests { get; set; }

        public AbpDemoDbContext(DbContextOptions<AbpDemoDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Test>(b =>
            {
                b.ToTable("Test");
                b.ConfigureByConvention();
                b.Property(x => x.Name).IsRequired().HasMaxLength(128);
            });
        }
    }
}

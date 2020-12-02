using Domain.Models.Identities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<AppUser> Users { get; set; }

        public DbSet<UserClaim> UserClaims { get; set; }

        private readonly IConfiguration configuration;

        public AppDbContext() : base() { }

        public AppDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connectionString = configuration.GetConnectionString("AppDbContextConnection") != null ? configuration.GetConnectionString("AppDbContextConnection") : "Server=192.168.56.102;Port=30001;Database=Development;Uid=root;Pwd=Hkc64760575;SslMode=Preferred;";

            optionsBuilder.UseMySql(
                configuration.GetConnectionString("AppDbContextConnection"), 
                new MySqlServerVersion(new Version(8, 0, 21)), 
                MySQLOptions => MySQLOptions.CharSetBehavior(CharSetBehavior.NeverAppend)
            );
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

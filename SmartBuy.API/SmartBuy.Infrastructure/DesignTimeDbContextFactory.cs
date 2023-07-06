using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBuy.Core;

namespace SmartBuy.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            //var builder = new ConfigurationBuilder()
            //              .SetBasePath(Directory.GetCurrentDirectory())
            //              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            // var Configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=SmartBuyDB;Integrated Security=True;TrustServerCertificate=True;");

            //optionsBuilder.UseSqlServer(Configuration.GetConnectionString(KnownString.ConnectionName));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}

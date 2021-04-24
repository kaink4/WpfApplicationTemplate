using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplicationTemplate.Infrastructure;

namespace WpfApplicationTemplate.DataAccess
{
    public class SampleDbContextFactory : IDesignTimeDbContextFactory<SampleDbContext>
    {
        public SampleDbContext CreateDbContext(string[] args)
        {
            var configuration = ConfigurationFactory.GetConfiguration();

            var connectionString = configuration.GetConnectionString("SampleDbContext");

            var options = new DbContextOptionsBuilder<SampleDbContext>()
                .UseSqlite(connectionString).Options;

            return new SampleDbContext(options);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WpfApplicationTemplate.DataAccess;

namespace WpfApplicationTemplate.Services
{
    public class SampleService : ISampleService
    {
        private readonly IDbContextFactory<SampleDbContext> _contextFactory;

        public SampleService(IDbContextFactory<SampleDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public string GetCurrentDate() => DateTime.Now.ToLongDateString();

        public string GetProducts() 
        {
            using var context = _contextFactory.CreateDbContext();
            return JsonSerializer.Serialize(context.Products.ToList());
        }
    }
}
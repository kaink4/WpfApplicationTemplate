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
        private readonly SampleDbContext _context;

        public SampleService(SampleDbContext context)
        {
            _context = context;
        }

        public string GetCurrentDate() => DateTime.Now.ToLongDateString();

        public string GetProducts() => JsonSerializer.Serialize(_context.Products.ToList());
    }
}
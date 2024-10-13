using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlogApp.Data
{
    public class BlogAppContextFactory : IDesignTimeDbContextFactory<BlogAppContext>
    {
        public BlogAppContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<BlogAppContext>();
            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            return new BlogAppContext(builder.Options);
        }
    }
}

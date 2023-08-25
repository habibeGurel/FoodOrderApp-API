using RestAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RestAPI.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RestAPIDbContext>
    {
        public RestAPIDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<RestAPIDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}

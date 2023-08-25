using Microsoft.EntityFrameworkCore;
using RestAPI.Domain.Entities;
using RestAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.Persistence.Contexts
{
    public class RestAPIDbContext : DbContext
    {
        public RestAPIDbContext(DbContextOptions options) : base(options)
        {}
        //veritabanında bu isimlerde tablolar olacağını belirtir.
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Domain.Entities.File> Files { get; set; }
        public DbSet<ProductImageFile> ProductImageFiles { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker: Entity'ler üzerinden yapılan değişikliklerin ya da yeni eklenen verinin yakalanmasını sağlayan property'dir.
            //Update operasyonlarında Track edilen verileri yakalayıp elde etmeyi sağlar.
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var i in datas)
            {
                _ = i.State switch
                {
                    EntityState.Added => i.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => i.Entity.UpdateDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

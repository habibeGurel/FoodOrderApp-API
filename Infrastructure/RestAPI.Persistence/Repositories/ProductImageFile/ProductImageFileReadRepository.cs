using RestAPI.Application.Repositories;
using RestAPI.Persistence.Contexts;
using RestAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.Persistence.Repositories
{
    public class ProductImageFileReadRepository : ReadRepository<ProductImageFile>, IProductImageFileReadRepository
    {
        public ProductImageFileReadRepository(RestAPIDbContext context) : base(context)
        {
        }
    }
}

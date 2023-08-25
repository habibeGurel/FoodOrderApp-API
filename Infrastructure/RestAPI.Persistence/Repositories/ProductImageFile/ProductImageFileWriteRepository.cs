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
    public class ProductImageFileWriteRepository : WriteRepository<ProductImageFile>, IProductImageFileWriteRepository
    {
        public ProductImageFileWriteRepository(RestAPIDbContext context) : base(context)
        {
        }
    }
}

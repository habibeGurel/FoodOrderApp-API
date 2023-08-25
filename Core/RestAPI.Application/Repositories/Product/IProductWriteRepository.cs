using RestAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.Application.Repositories
{
    public interface IProductWriteRepository : IWriteRepository<Product>
    {
    }
}

using RestAPI.Application.Repositories;
using RestAPI.Domain.Entities;
using RestAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.Persistence.Repositories
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(RestAPIDbContext context) : base(context)
        {
        }
    }
}

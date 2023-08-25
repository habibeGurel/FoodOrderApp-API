using RestAPI.Application.Repositories;
using RestAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.Persistence.Repositories.File
{
    public class FileWriteRepository : WriteRepository<RestAPI.Domain.Entities.File>, IFileWriteRepository
    {
        public FileWriteRepository(RestAPIDbContext context) : base(context)
        {
        }
    }
}

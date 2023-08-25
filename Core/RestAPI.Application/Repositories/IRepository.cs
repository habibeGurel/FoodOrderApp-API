using Microsoft.EntityFrameworkCore;
using RestAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity //temel repository ozellikleri (evrensel) generic kullaniriz
    {
        DbSet<T> Table { get; } // yalnizca get cunku table alinir ancak herhangi bir set islemi yapilmaz
    }
}

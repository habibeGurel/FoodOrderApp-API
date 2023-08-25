using RestAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string TelNo { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}

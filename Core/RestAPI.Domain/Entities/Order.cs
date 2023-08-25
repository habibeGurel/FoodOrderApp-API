using RestAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid CustomerId { get; set; }

        public string Situation { get; set; } //siparisin durumu
       
        public string Address { get; set; }

        public ICollection<Product>Products { get; set; } //her sipariste birden fazla yemek olabilir
        public Customer Customer { get; set; }
    }
}

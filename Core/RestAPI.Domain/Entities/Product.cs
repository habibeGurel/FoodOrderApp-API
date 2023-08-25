using RestAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } //urunun adi vardir
        public int Stock { get; set; } //urunun stok bilgisi
        public float Price { get; set; } //urunun fiyati
        public string Category { get; set; } //urunun kategorisi

        public ICollection<Order> Orders { get; set;} //her yemegin birden fazla siparisi olabilir
        public ICollection<ProductImageFile> ProductImageFiles { get; set; }
    }
}

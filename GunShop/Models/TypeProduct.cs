using System;
using System.Collections.Generic;

namespace GunShop.Models
{
    public partial class TypeProduct
    {
        public TypeProduct()
        {
            Products = new HashSet<Product>();
        }

        public int IdTypeProduct { get; set; }
        public string NameTypeProduct { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}

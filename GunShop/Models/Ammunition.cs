using System;
using System.Collections.Generic;

namespace GunShop.Models
{
    public partial class Ammunition
    {
        public Ammunition()
        {
            Products = new HashSet<Product>();
            Weapons = new HashSet<Weapon>();
        }

        public int IdAmmunition { get; set; }
        public string Caliber { get; set; } = null!;
        public string Specification { get; set; } = null!;
        public decimal PriceAmmunition { get; set; }
        public int ManufacturerCompanyId { get; set; }

        public virtual ManufacturerCompany ManufacturerCompany { get; set; } = null!;
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Weapon> Weapons { get; set; }
    }
}

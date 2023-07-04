using System;
using System.Collections.Generic;

namespace GunShop.Models
{
    public partial class ManufacturerCompany
    {
        public ManufacturerCompany()
        {
            Ammunitions = new HashSet<Ammunition>();
            Weapons = new HashSet<Weapon>();
        }

        public int IdManufacturerCompany { get; set; }
        public string NameManufacturerCompany { get; set; } = null!;
        public int CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<Ammunition> Ammunitions { get; set; }
        public virtual ICollection<Weapon> Weapons { get; set; }
    }
}

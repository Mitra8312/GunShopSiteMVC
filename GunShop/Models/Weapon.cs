using System;
using System.Collections.Generic;

namespace GunShop.Models
{
    public partial class Weapon
    {
        public Weapon()
        {
            Products = new HashSet<Product>();
        }

        public int IdWeapon { get; set; }
        public decimal? WeightWithoutAmmunition { get; set; }
        public decimal? WeightWithAmmunition { get; set; }
        public decimal WeaponLength { get; set; }
        public decimal? BarrelLenth { get; set; }
        public decimal? CombatRateOfFire { get; set; }
        public decimal? SightingRange { get; set; }
        public int? MagazineCopacity { get; set; }
        public string History { get; set; } = null!;
        public decimal PriceWeapon { get; set; }
        public string DetailsOfWeapon { get; set; } = null!;
        public string NameOfWeapon { get; set; } = null!;
        public int TypeOfWeaponId { get; set; }
        public int AmmunitionId { get; set; }
        public int ManufacturerCompanyId { get; set; }
        public string? ImageOfWeapon { get; set; }

        public virtual Ammunition Ammunition { get; set; } = null!;
        public virtual ManufacturerCompany ManufacturerCompany { get; set; } = null!;
        public virtual TypeOfWeapon TypeOfWeapon { get; set; } = null!;
        public virtual ICollection<Product> Products { get; set; }
    }
}

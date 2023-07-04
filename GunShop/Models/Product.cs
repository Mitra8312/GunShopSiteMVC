using System;
using System.Collections.Generic;

namespace GunShop.Models
{
    public partial class Product
    {
        public Product()
        {
            Receipts = new HashSet<Receipt>();
        }

        public int IdProduct { get; set; }
        public string ArticleProduct { get; set; } = null!;
        public int? QuantityOfAmmunition { get; set; }
        public int? QuantityOfWeapons { get; set; }
        public int? WeaponId { get; set; }
        public int? AmmunitionId { get; set; }
        public int TypeProductId { get; set; }

        public virtual Ammunition? Ammunition { get; set; }
        public virtual TypeProduct TypeProduct { get; set; } = null!;
        public virtual Weapon? Weapon { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}

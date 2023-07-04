using System;
using System.Collections.Generic;

namespace GunShop.Models
{
    public partial class TypeOfWeapon
    {
        public TypeOfWeapon()
        {
            Weapons = new HashSet<Weapon>();
        }

        public int IdTypeOfWeapon { get; set; }
        public string NameTypeOfWeapon { get; set; } = null!;

        public virtual ICollection<Weapon> Weapons { get; set; }
    }
}

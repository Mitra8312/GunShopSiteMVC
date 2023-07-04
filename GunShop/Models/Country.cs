using System;
using System.Collections.Generic;

namespace GunShop.Models
{
    public partial class Country
    {
        public Country()
        {
            ManufacturerCompanies = new HashSet<ManufacturerCompany>();
        }

        public int IdCountry { get; set; }
        public string NameCountry { get; set; } = null!;

        public virtual ICollection<ManufacturerCompany> ManufacturerCompanies { get; set; }
    }
}

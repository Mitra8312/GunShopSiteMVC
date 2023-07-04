namespace GunShop.Models
{
    public class Cart
    {
        public Cart()
        {
            CartLines = new List<Weapon>();
        }

        public List<Weapon> CartLines { get; set; }

        public decimal? FinalPrice
        {
            get
            {
                decimal? sum = 0;
                foreach(var product in CartLines)
                {
                    sum += product.PriceWeapon;
                }
                return sum;
            }
        }
    }
}

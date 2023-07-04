using System.ComponentModel.DataAnnotations;

namespace GunShop.Models
{
    public class Send
    {
        [Required(ErrorMessage = "Bad Name")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Bad Email")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Can't be empty")]

        public string Message { get; set; }
    }
}

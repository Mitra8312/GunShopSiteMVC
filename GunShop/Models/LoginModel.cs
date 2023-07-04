using System.ComponentModel.DataAnnotations;

namespace GunShop.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Логин не указан")]

        public string LoginUser { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]

        public string PasswordUser { get; set; }

        public string WeaponPermitNumber { get; set; }
        public DateOnly YearOfBirth { get; set; }
        public string EmailAddressUser { get; set; } 
        public string Nickname { get; set; }
        public string FirstNameUser { get; set; }
        public string? MiddleNameUser { get; set; }
        public string SecondNameUser { get; set; }
        public int Role_ID { get; set; }
    }
}

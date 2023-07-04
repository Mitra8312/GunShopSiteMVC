using System.ComponentModel.DataAnnotations;

namespace GunShop.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Логин не указан")]

        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        [Required(ErrorMessage = "Не указано имя пользователя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Не указано отчество пользователя")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Не указана фамилия пользователя")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Не указан псевдоним пользователя")]
        public string NickName { get; set; }

        [Required(ErrorMessage = "Не указан номер разрешения на оружие пользователя")]
        public string WeaponPremitNumber { get; set; }

        [Required(ErrorMessage = "Не указана дата рождения пользователя")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "Не указан адрес электронной почты пользователя")]
        public string EmailAddress { get; set; }
    }
}

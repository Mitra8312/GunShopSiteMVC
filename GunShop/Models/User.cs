namespace GunShop.Models
{
    public partial class User
    {
        public User()
        {
            Receipts = new HashSet<Receipt>();
        }

        public int IdUser { get; set; }
        public string WeaponPermitNumber { get; set; } = null!;
        public DateTime YearOfBirth { get; set; }
        public string EmailAddressUser { get; set; } = null!;
        public string Nickname { get; set; } = null!;
        public string FirstNameUser { get; set; } = null!;
        public string? MiddleNameUser { get; set; }
        public string SecondNameUser { get; set; } = null!;
        public string LoginUser { get; set; } = null!;
        public string PasswordUser { get; set; } = null!;
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}

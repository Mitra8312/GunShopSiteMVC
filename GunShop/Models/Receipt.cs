using System;
using System.Collections.Generic;

namespace GunShop.Models
{
    public partial class Receipt
    {
        public int IdReceipt { get; set; }
        public string ReceiptNumber { get; set; } = null!;
        public DateTime DateOfBuy { get; set; }
        public TimeSpan TimeOfBuy { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public decimal FinalPrice { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}

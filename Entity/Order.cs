
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Order : BaseEntity
    {
        public decimal TotalAmount { get; set; }
        public PaymentType PaymentType { get; set; }
        public int BasketItemId { get; set; }
        [ForeignKey("BasketItemId")]
        public virtual BasketItem BasketItem { get; set; }

    }
    public enum PaymentType
    {
        CreditCard = 1,
        DebitCard = 2,
        Paypal = 3,
        Cash = 4,
    }
}


using System.ComponentModel.DataAnnotations.Schema;
using static ViewModel.EnumBase;

namespace Entity
{
    public class Order : BaseEntity
    {
        public decimal TotalAmount { get; set; }
        public PaymentType PaymentType { get; set; }
        public int BasketId { get; set; }
        [ForeignKey("BasketId")]
        public virtual Basket Basket { get; set; }

    }
}

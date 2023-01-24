﻿
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class BasketItem : BaseEntity
    {
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int BasketId { get; set; }
        public virtual Basket Basket { get; set; }
    }
}

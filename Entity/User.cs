using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<BasketItem> BasketItems { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User ProductOwner { get; set; }
    }
}

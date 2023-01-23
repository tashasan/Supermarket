using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}

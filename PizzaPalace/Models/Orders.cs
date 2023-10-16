using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaPalace.Models
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public List<OrderDetails> OrderDetails { get; set; }
    }
}
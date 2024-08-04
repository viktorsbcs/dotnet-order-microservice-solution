using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order.API.Entities
{
    [Table("userorders", Schema = "dbo")]
    public class UserOrder
    {
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("orderdate")]
        public DateTime OrderDate { get; set; }
    }
}

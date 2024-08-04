using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order.API.Entities
{
    [Table("UserOrders", Schema = "dbo")]
    public class UserOrder
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
    }
}

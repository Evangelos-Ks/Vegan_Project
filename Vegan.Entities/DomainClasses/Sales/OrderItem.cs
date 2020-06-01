using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vegan.Entities.DomainClasses.Sales
{
    public class OrderItem
    {
        [Key]
        [Column(Order = 1)]
        public int OrderItemId { get; set; }
        public Order Order { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
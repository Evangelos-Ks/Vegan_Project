using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegan.Entities
{
    public class Order
    {
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }
        public int Product { get; set; }
        public int Quantity { get; set; }
        [Display(Name = "Order stamp")]
        public DateTime OrderTime { get; set; }

        //======== Navigation Property  Relationships with
        // Product -->  many


        public virtual ICollection<Product> Products { get; set; }
    }
}

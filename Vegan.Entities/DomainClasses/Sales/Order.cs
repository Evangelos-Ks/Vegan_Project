using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vegan.Entities.Library;

namespace Vegan.Entities
{
    public class Order
    {
        //====================================== Properties ====================================================

        [Display(Name = "Order ID")]
        public int OrderId { get; set; }
        [Display(Name = "Order stamp")]
        public DateTime OrderStamp { get; set; } //that is the dateTime that will be created on submit

        //========================= Navigation Properties ======================================================

        //Plan A ===========> // Keeping the class in this form, means that from the server, on sumbit, we send to the db a list of products. In other words, this instanse recieves a list of products. In case a product has quantity > 1, it will be rewritten in the list for as many times as the quantity and this logic needs to be at the cart before the sumbit event.
        public virtual ICollection<Product> Products { get; set; }



        // ============================================== Constructor ==========================================

        public Order()
        {

        }
        public Order(DateTime orderStamp, ICollection<Product> products)
        {
            this.OrderStamp = orderStamp;
            this.Products = products;
        }

        // ============================================== Methods ===============================================


        //Calculates the total price of the Order
        public decimal CalculateTotal()
        {
            decimal totalPrice = this.Products.Sum(product => product.Price);
            return totalPrice;
        }


    }
}
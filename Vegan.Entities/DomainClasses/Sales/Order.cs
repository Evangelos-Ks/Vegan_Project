using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Vegan.Entities.DomainClasses.Sales;

namespace Vegan.Entities
{
    public class Order
    {
        //====================================== Properties ====================================================

        [Key]
        [Column(Order = 1)]
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }
        [Display(Name = "Order stamp")]
        public DateTime OrderStamp { get; set; } 
        public decimal Total { get; set; }
        public decimal Tax { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Shipping { get; set; }
        public string PayPalReference { get; set; }

        //========================= Navigation Properties =======================================================
        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }


        // ============================================== Constructor ===========================================

        public Order()
        {

            OrderItems = new List<OrderItem>();
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
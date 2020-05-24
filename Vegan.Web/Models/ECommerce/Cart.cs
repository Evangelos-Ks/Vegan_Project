using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Vegan.Web.Models.ECommerce
{
    public class Cart
    {
        public List<CartItem> CartItems { get; set; }

        public Cart()
        {
            CartItems = new List<CartItem>();
        }
    }
}
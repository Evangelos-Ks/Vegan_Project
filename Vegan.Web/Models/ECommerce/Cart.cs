using System.Collections.Generic;
using System.Linq;


namespace Vegan.Web.Models.ECommerce
{
    public class Cart
    {
        public List<CartItem> CartItems { get; set; }

        public Cart()
        {
            CartItems = new List<CartItem>();
        }

        public decimal Sum()
        {
            decimal sum = 0m;
            return sum = CartItems.Sum(x => x.Price * x.Quantity);
        }
    }
}
using System.Collections.Generic;
using Vegan.Entities;

namespace Vegan.Web.Models.ECommerce
{
    public class IndexVm
    {
        public List<Product> Products { get; set; }

        public IndexVm()
        {
            Products = new List<Product>();
        }
    }
}
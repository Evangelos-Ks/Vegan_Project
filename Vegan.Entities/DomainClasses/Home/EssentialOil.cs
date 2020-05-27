using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegan.Entities.Home
{
    public partial class EssentialOil : Home
    {
        public string SubCategory { get; set; } = "EssentialOil";
    }
}

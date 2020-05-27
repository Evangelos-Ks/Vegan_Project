using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegan.Entities.Care
{
    public class Hair : Care
    {
        public string SubCategory { get; set; } = "Hair";
    }
}

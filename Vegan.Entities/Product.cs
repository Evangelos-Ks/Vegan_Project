using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Vegan.Entities.CustomValidations;

namespace Vegan.Entities
{
    public class Product
    {
        [Display(Name = "Product ID")]
        public int Id { get; set; }
        
        [CustomValidation(typeof(ValidatingPrice), "ValidationGreaterOrEqualToZero")]
        public decimal Price { get; set; }
        [Required, MaxLength(150), MinLength(2)]
        public string Title { get; set; }
        [Display(Name = "Image")]
        public string ImageURL { get; set; }

        public string Description { get; set; }

        // public bool Availability { get; set; } // λεω να μπει εδω γιατι ολα την εχουν και ισως θελουμε να φαινεται και οταν καποιος βαζει το προιον στο cart

        //TODO after we reach the web: to Add Review


        //======== Navigation Property Relationships with
        // Order --> one or zero
        public virtual Order Order { get; set; }
    }
}

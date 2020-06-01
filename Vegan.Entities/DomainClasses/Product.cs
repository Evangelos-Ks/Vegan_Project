using System.ComponentModel.DataAnnotations;
using Vegan.Entities.CustomValidations;

namespace Vegan.Entities
{
    public class Product
    {
        [Display(Name = "Product ID")]
        public int Id { get; set; }
        [CustomValidation(typeof(PriceValidation), "ValidationGreaterOrEqualToZero")]
        public decimal Price { get; set; }
        [Required, MaxLength(150), MinLength(2)]
        public string Title { get; set; }
        [Display(Name = "Image")]
        public string ImageURL { get; set; }

        public string Description { get; set; }

        public virtual Order Order { get; set; }
    }
}

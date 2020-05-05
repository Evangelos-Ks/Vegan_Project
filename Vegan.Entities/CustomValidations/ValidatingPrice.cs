using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegan.Entities.CustomValidations
{
   public class ValidatingPrice
    {
        public static ValidationResult ValidationGreaterOrEqualToZero (decimal value, ValidationContext context)
        {
            bool isValid = true;
            if(value < 0m)
            {
                isValid = false;
            }

            if (isValid)
                return ValidationResult.Success;
            else
                return new ValidationResult(string.Format("The field {0} must be equal to or greater than 0. ", context.MemberName, new List<string> { context.MemberName }));
        }
    }
}

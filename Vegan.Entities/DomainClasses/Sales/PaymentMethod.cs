using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vegan.Entities.CustomValidations;

namespace Vegan.Entities.DomainClasses.Sales
{
    public abstract class PaymentMethod
    {
        //====================================== Properties ====================================================
        public int PaymentMethodId { get; set; }
        public abstract string Name { get; }

        [Display(Name = "Payment choice")]
        protected int PaymentChoice { get; set; }

        [Display(Name = "Total amount")]
        [CustomValidation(typeof(PriceValidation), "ValidationGreaterOrEqualToZero")]
        protected decimal PaymentAmount { get; set; }

        public static List<PaymentMethod> paymentMethods = new List<PaymentMethod>()
        {
            new PayPal(),
            new Cash()
        };

        //==================================== Navigation Property =============================================
                public virtual Order Order { get; set; }
        //==================================== Methods =========================================================

        protected PaymentMethod SelectPaymentMethod()
        {

            switch (PaymentChoice)
            {
                case 1:
                    return PaymentMethod.paymentMethods[0]; // PayPal
                case 2:
                    return PaymentMethod.paymentMethods[1]; //Cash
                default:
                    return PaymentMethod.paymentMethods[0]; //default is PayPal
            }
        }

    }

}

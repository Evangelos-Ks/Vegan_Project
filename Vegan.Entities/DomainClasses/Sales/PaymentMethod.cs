using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegan.Entities.DomainClasses.Sales
{
    public abstract class PaymentMethod
    {
        //====================================== Properties ====================================================
        public int PaymentMethodId { get; set; }
        public abstract string Name { get; }

       // protected decimal paymentAmount = Order.CalculateTotal(); // O constructor doesnt get a payment amount as a param, but it creates it throught the Order
        protected int PaymentChoice { get; set; }
        public abstract bool Pay(decimal amount);


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

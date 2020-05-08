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

        public abstract string Name { get; }
        public abstract bool Pay(decimal amount);

        public static List<PaymentMethod> paymentMethods = new List<PaymentMethod>()
        {
            new PayPal(),
            new Cash()
        };
    }
        
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegan.Entities.DomainClasses.Sales
{
    class PayPal : PaymentMethod
    {
            //========================= Properties ========================================
            public override string Name { get; } = "PayPal";

            //========================= Methods ===========================================
            public override bool Pay(decimal amount)
            {
                if (amount <= 0) return false;
                else return true;
            }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegan.Entities.DomainClasses.Sales
{
    class Cash : PaymentMethod
    {
        //========================= Properties ========================================
        public override string Name { get; } = "Cash";

        //========================= Methods ===========================================
        
    }
}

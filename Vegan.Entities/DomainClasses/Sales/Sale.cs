using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vegan.Entities.DomainClasses.Sales;

namespace Vegan.Entities.DomainClasses
{
    public class Sale
    {
        //====================================== Fields ========================================================

        protected int SaleId;
        protected decimal paymentAmount;
        public int PaymentChoice { get; set; }

        //===================================== Construstors ===================================================
        public Sale()
        {

        }
        public Sale(int paymentChoice)
        {
            this.paymentAmount = Order.CalculateTotal(); // O constructor doesnt get a payment amount as a param, but it creates it throught the Order
            this.PaymentChoice = paymentChoice;
        }

        //==================================== Navigation Property =============================================
        public virtual Order Order { get; set; }
        //==================================== Methods =========================================================

        protected PaymentMethod SelectPaymentMethod(int paymentChoice)
        {

            switch (paymentChoice)
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

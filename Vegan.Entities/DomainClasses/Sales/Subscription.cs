using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vegan.Entities.DomainClasses.Sales
{
    public class Subscription
    {
        [Key]
        [Column(Order = 1)]
        public int SubscriptionId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }
        public string PayPalPlanId { get; set; }
        public string PayPalAgreementToken { get; set; }
        public string PayPalAgreementId { get; set; }
    }
}
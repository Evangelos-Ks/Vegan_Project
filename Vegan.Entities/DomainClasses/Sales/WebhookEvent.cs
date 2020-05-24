using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Vegan.Entities.DomainClasses.Sales
{
    public class WebhookEvent
    {
        [Key]
        [Column(Order = 1)]
        public int WebhookEventId { get; set; }
        public string PayPalWebHookEventId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateReceived { get; set; }
        public string EventType { get; set; }
        public string Summary { get; set; }
        public string ResourceType { get; set; }
        public string ResourceJson { get; set; }
    }
}

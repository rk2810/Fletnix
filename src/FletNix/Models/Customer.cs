using System;
using System.Collections.Generic;

namespace FletNix.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerFeedback = new HashSet<CustomerFeedback>();
            Watchhistory = new HashSet<Watchhistory>();
        }

        public string CustomerMailAddress { get; set; }
        public string Name { get; set; }
        public string PaypalAccount { get; set; }
        public DateTime SubscriptionStart { get; set; }
        public DateTime? SubscriptionEnd { get; set; }
        public string Password { get; set; }

        public virtual ICollection<CustomerFeedback> CustomerFeedback { get; set; }
        public virtual ICollection<Watchhistory> Watchhistory { get; set; }
    }
}

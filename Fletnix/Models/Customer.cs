﻿using System;
using System.Collections.Generic;

namespace Fletnix.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Watchhistory = new HashSet<Watchhistory>();
        }

        public string CustomerMailAddress { get; set; }
        public string Name { get; set; }
        public string PaypalAccount { get; set; }
        public DateTime SubscriptionStart { get; set; }
        public DateTime? SubscriptionEnd { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Watchhistory> Watchhistory { get; set; }
    }
}

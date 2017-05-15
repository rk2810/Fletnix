﻿using System;
using System.Collections.Generic;

namespace FletNix.Models
{
    public partial class CustomerFeedback
    {
        public int MovieId { get; set; }
        public string CustomerMailAddress { get; set; }
        public DateTime FeedbackDate { get; set; }
        public string Comments { get; set; }
        public int Rating { get; set; }

        public virtual Customer CustomerMailAddressNavigation { get; set; }
        public virtual Movie Movie { get; set; }
    }
}

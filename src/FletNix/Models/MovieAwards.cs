using System;
using System.Collections.Generic;

namespace FletNix.Models
{
    public partial class MovieAwards
    {
        public int MovieId { get; set; }
        public string Award { get; set; }
        public string Result { get; set; }
        public string NumberOfAwards { get; set; }

        public virtual Movie Movie { get; set; }
    }
}

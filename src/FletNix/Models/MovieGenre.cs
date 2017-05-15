using System;
using System.Collections.Generic;

namespace FletNix.Models
{
    public partial class MovieGenre
    {
        public int MovieId { get; set; }
        public string GenreName { get; set; }

        public virtual Genre GenreNameNavigation { get; set; }
        public virtual Movie Movie { get; set; }
    }
}

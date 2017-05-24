using System.ComponentModel.DataAnnotations;

namespace FletNix.Models
{
    public class MovieListItem : Movie
    {
        [DisplayFormat(DataFormatString = "{0:n1}")]
        public double AverageRating { get; set; }
    }
}

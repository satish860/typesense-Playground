using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using typesense.domain.Attributes;

namespace typesense.domain.Tests
{
    [Document(DefaultSortingField = "rating_count")]
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        
        public string[] Authors { get; set; }

        public DateTime PublicationYears { get; set; }

        public int RatingCount { get; set; }

        public decimal AverageRating { get; set; }
    }
}

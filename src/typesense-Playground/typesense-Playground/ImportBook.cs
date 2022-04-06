using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using typesense.domain.Attributes;

namespace typesense_Playground
{
    [Document(DefaultSortingField = "rating_count")]
    internal class ImportBook2
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [Facet]
        public string[] Authors { get; set; }

        public DateTime PublicationYears { get; set; }

        public int RatingsCount { get; set; }

        public decimal AverageRating { get; set; }
    }
}

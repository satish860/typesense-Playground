using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace typesense.domain
{
    public class IndexSchema
    {
        public string Name { get; set; }

        public string? DefaultSortingField { get; set; }

        public IEnumerable<Field> Fields { get; set; } = Enumerable.Empty<Field>();

    }
}

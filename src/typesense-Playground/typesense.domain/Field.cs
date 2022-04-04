using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace typesense.domain
{
    public class Field
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public bool Facet { get; set; }

        public bool Index { get; set; }
    }
}

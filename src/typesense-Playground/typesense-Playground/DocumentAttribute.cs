using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace typesense_Playground
{
    [AttributeUsage(AttributeTargets.Class , AllowMultiple = false)]
    public class DocumentAttribute:Attribute
    {
        public string IndexName { get; set; }

        public string DefaultSortingField { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace typesense_Playground
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class FacetAttribute:Attribute
    {

    }
}

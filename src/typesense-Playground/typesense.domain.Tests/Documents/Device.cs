using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using typesense.domain.Attributes;

namespace typesense.domain.Tests.Documents
{
    [Document()]
    public class Device
    {
        public string Id { get; set; }

        public string FriendlyName { get; set; }

        public string ModelName { get; set; }
    }
}

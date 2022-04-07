using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace typesense.domain.Documents
{
    public class Result<T>
    {
        public bool Success { get; set; }

        public string Error { get; set; }

        public T Document { get; set; }
    }
}

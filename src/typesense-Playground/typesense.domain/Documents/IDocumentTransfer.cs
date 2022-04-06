using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace typesense.domain.Documents
{
    public interface IDocumentTransfer
    {
        Task Import(string FileName);

        Task<IEnumerable<T>> Export<T>(string indexName);
    }
}

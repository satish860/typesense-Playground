using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace typesense.domain.Documents
{
    public interface ITypeSenseDocument
    {
        Task<T> CreateDocument<T>(T document,string indexName);

        Task<IEnumerable<Result<T>>> InsertMultipleDocument<T>(IEnumerable<T> documents, string indexName);

        Task<T> Upsert<T>(T document, string indexName);
        Task<T> Delete<T>(string id, string indexName);
        Task<T> Update<T>(T document, string id, string indexName);
        Task<T> GetById<T>(string id, string name);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace typesense.domain.Search
{
    public interface IQueryDocument
    {
        Task<IEnumerable<T>> GetAll<T>();
    }
}

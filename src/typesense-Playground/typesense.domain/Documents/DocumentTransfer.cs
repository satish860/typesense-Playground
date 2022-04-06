using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using typesense.domain.Extensions;

namespace typesense.domain.Documents
{
    public class DocumentTransfer : IDocumentTransfer
    {
        public async Task<IEnumerable<T>> Export<T>(string indexName)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-TYPESENSE-API-KEY", "xyz");
            var response = await client.GetAsync($"http://localhost:8108/collections/{indexName}/documents/export");
            var responsecontent = await response.Content.ReadAsStringAsync();
            var documents = responsecontent.Split("\n");
            List<T> result = new List<T>();
            foreach (var document in documents)
            {
                var item = JsonSerializer.Deserialize<T>(document
                , new JsonSerializerOptions
                {
                    PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                });
                result.Add(item);
            }
            return result.AsEnumerable();
        }

        public Task Import(string FileName)
        {
            throw new NotImplementedException();
        }
    }
}

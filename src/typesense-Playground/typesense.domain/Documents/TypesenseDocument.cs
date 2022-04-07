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
    public class TypesenseDocument : ITypeSenseDocument
    {
        public async Task<T> CreateDocument<T>(T document, string indexName)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-TYPESENSE-API-KEY", "xyz");
            var documentjson = JsonSerializer.Serialize(document
                , new JsonSerializerOptions
                {
                    PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                });
            var content = new StringContent(documentjson, Encoding.UTF8, "appilcation/json");
            var response = await client.PostAsync($"http://localhost:8108/collections/{indexName}/documents", content);
            // Response comes back with 201. Verify that and the Error codes. 
            response.EnsureSuccessStatusCode();
            return document;
        }

        public async Task<T> Delete<T>(string id, string name)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-TYPESENSE-API-KEY", "xyz");
            var response = await client.DeleteAsync($"http://localhost:8108/collections/{name}/documents/{id}");
            var responsecontent = await response.Content.ReadAsStringAsync();
            var document = JsonSerializer.Deserialize<T>(responsecontent
               , new JsonSerializerOptions
               {
                   PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance,
                   DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
               });
            return document;
        }

        public async Task<T> GetById<T>(string id, string name)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-TYPESENSE-API-KEY", "xyz");
            var response = await client.GetAsync($"http://localhost:8108/collections/{name}/documents/{id}");
            var responsecontent = await response.Content.ReadAsStringAsync();
            var updatedDocument = JsonSerializer.Deserialize<T>(responsecontent
               , new JsonSerializerOptions
               {
                   PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance,
                   DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
               });
            return updatedDocument;
        }

        public async Task<IEnumerable<Result<T>>> InsertMultipleDocument<T>(IEnumerable<T> documents, string indexName)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-TYPESENSE-API-KEY", "xyz");
            List<string> contents = new List<string>();
            foreach (var document in documents)
            {
                var documentcontent = JsonSerializer.Serialize(document
                , new JsonSerializerOptions
                {
                    PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                });
                contents.Add(documentcontent);
            }
            var content = new StringContent(string.Join(Environment.NewLine, contents), Encoding.UTF8, "appilcation/json");
            var response = await client
                .PostAsync($"http://localhost:8108/collections/{indexName}/documents/import?action=upsert", content);
            response.EnsureSuccessStatusCode();
            var responsecontent = await response.Content.ReadAsByteArrayAsync();
            var insertedresponse = Encoding.UTF8.GetString(responsecontent);
            List<Result<T>> results = new List<Result<T>>();
            foreach (var item in insertedresponse.Split(Environment.NewLine))
            {
               var result = JsonSerializer.Deserialize<Result<T>>(item
                , new JsonSerializerOptions
                {
                    PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                });
                results.Add(result);
            }
            
            return results;
        }

        public async Task<T> Update<T>(T document, string id, string indexName)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-TYPESENSE-API-KEY", "xyz");
            var documentjson = JsonSerializer.Serialize(document
                , new JsonSerializerOptions
                {
                    PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                });
            var content = new StringContent(documentjson, Encoding.UTF8, "appilcation/json");
            var response = await client.PatchAsync($"http://localhost:8108/collections/{indexName}/documents/{id}", content);
            var responsecontent = await response.Content.ReadAsStringAsync();
            var updatedDocument = JsonSerializer.Deserialize<T>(responsecontent
               , new JsonSerializerOptions
               {
                   PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance,
                   DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
               });
            return updatedDocument;
        }

        public async Task<T> Upsert<T>(T document, string indexName)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-TYPESENSE-API-KEY", "xyz");
            var documentjson = JsonSerializer.Serialize(document
                , new JsonSerializerOptions
                {
                    PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                });
            var content = new StringContent(documentjson, Encoding.UTF8, "appilcation/json");
            var response = await client.PostAsync($"http://localhost:8108/collections/{indexName}/documents?action=upsert", content);
            // Response comes back with 201. Verify that and the Error codes. 
            response.EnsureSuccessStatusCode();
            return document;
        }
    }
}

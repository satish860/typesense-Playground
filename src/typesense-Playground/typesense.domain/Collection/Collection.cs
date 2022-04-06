using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using typesense.domain.Extensions;

namespace typesense.domain.Collection
{
    public class TypeSenseCollection : ITypeSenseCollection
    {
        public async Task<IndexSchema> CreateCollection<T>()
        {
            CollectionSchema collectionSchema = new CollectionSchema(typeof(T));
            var schema = collectionSchema.CreateIndex();

            var bookstring = JsonSerializer.Serialize(schema
                , new JsonSerializerOptions
                {
                    PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                });
            var content = new StringContent(bookstring, Encoding.UTF8, "appilcation/json");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-TYPESENSE-API-KEY", "xyz");
            var response = await client.PostAsync("http://localhost:8108/collections", content);
            response.EnsureSuccessStatusCode();
            return schema;
        }

        public async Task<bool> DeleteCollection<T>()
        {
            var indexName = typeof(T).Name.Pluralize().ToSnakeCase();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-TYPESENSE-API-KEY", "xyz");
            var response = await client.DeleteAsync($"http://localhost:8108/collections/{indexName}");
            return response.StatusCode == HttpStatusCode.OK;
        }

        public async Task<IndexSchema?> GetCollection<T>()
        {
            var indexName = typeof(T).Name.Pluralize().ToSnakeCase();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-TYPESENSE-API-KEY", "xyz");
            var response = await client.GetAsync($"http://localhost:8108/collections/{indexName}");
            var content = await response.Content.ReadAsStringAsync();
            IndexSchema? indexSchema = JsonSerializer.Deserialize<IndexSchema>(content, new JsonSerializerOptions
            {
                PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });
            return indexSchema;
        }

        public async Task<IEnumerable<IndexSchema>> ListAllCollection()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-TYPESENSE-API-KEY", "xyz");
            var indexSchema = await client.GetStringAsync("http://localhost:8108/collections");
            var collections = JsonSerializer.Deserialize<IEnumerable<IndexSchema>>(indexSchema);
            return collections;
        }
    }
}

using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using typesense.domain;
using typesense.domain.Collection;
using typesense_Playground;

TypeSenseCollection typeSenseCollection = new TypeSenseCollection();
var indexSchema = await typeSenseCollection.CreateCollection<Book>();

using (var httpClient = new HttpClient())
{
    using (var request = new HttpRequestMessage(new HttpMethod("POST"), $"http://localhost:8108/collections/{indexSchema.Name}/documents/import"))
    {
        request.Headers.TryAddWithoutValidation("X-TYPESENSE-API-KEY", "xyz");
        var content = File.ReadAllText(@"E:\typesense\tmp\books.jsonl\books.jsonl");
        request.Content = new StringContent(content);
        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

        var response = await httpClient.SendAsync(request);
       
        var importContent = await response.Content.ReadAsByteArrayAsync();
        var importresponseContent = Encoding.UTF8.GetString(importContent);
    }
}

using (var httpClient = new HttpClient())
{
    using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"http://localhost:8108/collections/{indexSchema.Name}/documents/search?q=harry+potter&query_by=title"))
    {
        request.Headers.TryAddWithoutValidation("X-TYPESENSE-API-KEY", "xyz");

        var response = await httpClient.SendAsync(request);
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }
}
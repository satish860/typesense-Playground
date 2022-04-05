using System.Text.Json;
using System.Text.Json.Serialization;
using typesense.domain;
using typesense_Playground;

CollectionSchema collectionSchema = new CollectionSchema(typeof(Book));
var Schema = collectionSchema.CreateIndex();

var bookstring = JsonSerializer.Serialize(Schema
    , new JsonSerializerOptions { 
        PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    });
var content = new StringContent(bookstring,System.Text.Encoding.UTF8,"appilcation/json");
HttpClient client = new HttpClient();
client.DefaultRequestHeaders.Add("X-TYPESENSE-API-KEY", "xyz");
var response = await client.PostAsync("http://localhost:8108/collections", content);
var status = await response.Content.ReadAsStringAsync();
Console.WriteLine(status);

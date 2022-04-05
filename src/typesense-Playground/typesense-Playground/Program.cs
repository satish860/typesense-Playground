using System.Text.Json;
using typesense.domain;
using typesense_Playground;

CollectionSchema collectionSchema = new CollectionSchema(typeof(Book));
IndexSchema Schema = new IndexSchema();
collectionSchema.GetDocumentDetails(Schema);
collectionSchema.GetFields(Schema);

var bookstring = JsonSerializer.Serialize(Schema
    , new JsonSerializerOptions { PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance });

Console.WriteLine(bookstring);

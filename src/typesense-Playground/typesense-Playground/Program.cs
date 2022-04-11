using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using typesense.domain;
using typesense.domain.Collection;
using typesense_Playground;

TypeSenseCollection typeSenseCollection = new TypeSenseCollection();
var indexSchema = await typeSenseCollection.CreateCollection<Device>();


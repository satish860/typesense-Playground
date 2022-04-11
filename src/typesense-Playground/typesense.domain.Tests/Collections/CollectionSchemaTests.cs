using System.Linq;
using Xunit;

namespace typesense.domain.Tests
{
    public class CollectionSchemaTests
    {
        [Fact]
        public void Should_be_able_to_Get_the_Document_Attribute()
        {
            CollectionSchema curator = new CollectionSchema(typeof(Book));
            IndexSchema schema = curator.GetDocumentDetails();
            Assert.Equal("books", schema.Name);
            Assert.Equal("rating_count", schema.DefaultSortingField);
        }

        [Fact]
        public void Should_Be_Able_Get_The_Fields_from_the_Document()
        {
            CollectionSchema curator = new CollectionSchema(typeof(Book));
            IndexSchema schema = curator.GetFields(new IndexSchema());
            Assert.Equal(6, schema.Fields.Count());
            Assert.True(schema.Fields.First(p => p.Name == "authors").Facet);
            Assert.Equal("int32", schema.Fields.First(p => p.Name == "publication_years").Type);
        }
    }
}
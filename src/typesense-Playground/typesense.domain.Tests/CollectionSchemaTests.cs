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
            Assert.Equal("books", schema.IndexName);
            Assert.Equal("rating_count", schema.DefaultSortingField);
        }
    }
}
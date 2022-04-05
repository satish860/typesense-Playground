using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using typesense.domain.Collection;
using Xunit;

namespace typesense.domain.Tests
{
    public class CollectionTests
    {
        [Fact]
        public async Task Should_be_able_to_Create_The_Collection()
        {
            var collection = new TypeSenseCollection();
            IndexSchema indexSchema = await collection.CreateCollection<Book>();
            Assert.Equal("books", indexSchema.Name);
        }

        [Fact]
        public async Task Should_be_able_to_List_All_the_Collection()
        {
            var collection = new TypeSenseCollection();
            var schemas = await collection.ListAllCollection();
            Assert.Single(schemas);
        }

        [Fact]
        public async Task Should_be_able_to_Delete_The_Collection()
        {
            var collection = new TypeSenseCollection();
            var isDeleted = await collection.DeleteCollection<Book>();
            Assert.True(isDeleted);
        }

        [Fact]
        public async Task Should_be_Able_to_Get_The_Collection()
        {
            var collection = new TypeSenseCollection();
            await collection.CreateCollection<Book>();
            var indexSchema = await collection.GetCollection<Book>();
            Assert.Equal("books", indexSchema.Name);
        }
    }
}

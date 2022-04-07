using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using typesense.domain.Documents;
using Xunit;

namespace typesense.domain.Tests.Documents
{
    public class TypesenseDocumentTests
    {
        [Fact]
        public async Task Should_be_Able_to_Create_Document()
        {
            ITypeSenseDocument document = new TypesenseDocument();
            Collection.TypeSenseCollection typeSenseCollection = new Collection.TypeSenseCollection();
            var indexSchema = await typeSenseCollection.GetCollection<Device>();
            if (indexSchema.Name == null)
                indexSchema = await typeSenseCollection.CreateCollection<Device>();
            var device = await document.CreateDocument<Device>(new Device
            {
                FriendlyName = "Hello World",
                Id = Guid.NewGuid().ToString(),
                ModelName = "Windows"
            }, indexSchema.Name);
            Assert.NotNull(device);
        }

        [Fact]
        public async Task Should_be_to_Able_to_Upsert_the_Documents()
        {
            ITypeSenseDocument document = new TypesenseDocument();
            Collection.TypeSenseCollection typeSenseCollection = new Collection.TypeSenseCollection();
            var indexSchema = await typeSenseCollection.GetCollection<Device>();
            if (indexSchema.Name == null)
                indexSchema = await typeSenseCollection.CreateCollection<Device>();
            var device = await document.Upsert<Device>(new Device
            {
                FriendlyName = "Hello World",
                Id = Guid.NewGuid().ToString(),
                ModelName = "Windows"
            }, indexSchema.Name);
            Assert.NotNull(device);
        }

        [Fact]
        public async Task Should_be_to_Able_to_Delete_the_Documents()
        {
            ITypeSenseDocument document = new TypesenseDocument();
            Collection.TypeSenseCollection typeSenseCollection = new Collection.TypeSenseCollection();
            var indexSchema = await typeSenseCollection.GetCollection<Device>();
            if (indexSchema.Name == null)
                indexSchema = await typeSenseCollection.CreateCollection<Device>();
            var id = Guid.NewGuid().ToString();
            var device = await document.Upsert<Device>(new Device
            {
                FriendlyName = "Hello World",
                Id = id,
                ModelName = "Windows"
            }, indexSchema.Name);
            device = await document.Delete<Device>(id, indexSchema.Name);
            Assert.NotNull(device);
        }

        [Fact]
        public async Task Should_be_to_Able_to_Update_the_Documents()
        {
            ITypeSenseDocument document = new TypesenseDocument();
            Collection.TypeSenseCollection typeSenseCollection = new Collection.TypeSenseCollection();
            var indexSchema = await typeSenseCollection.GetCollection<Device>();
            if (indexSchema.Name == null)
                indexSchema = await typeSenseCollection.CreateCollection<Device>();
            var id = Guid.NewGuid().ToString();
            var device = await document.Upsert<Device>(new Device
            {
                FriendlyName = "Hello World",
                Id = id,
                ModelName = "Windows"
            }, indexSchema.Name);
            var updatedDevice = await document.Update<Device>(new Device
            {
                ModelName = "Windows RT"
            }, id, indexSchema.Name);
            Assert.Equal("Windows RT", updatedDevice.ModelName);
        }

        [Fact]
        public async Task Should_be_Able_to_Get_Document_by_id()
        {
            ITypeSenseDocument document = new TypesenseDocument();
            Collection.TypeSenseCollection typeSenseCollection = new Collection.TypeSenseCollection();
            var indexSchema = await typeSenseCollection.GetCollection<Device>();
            if (indexSchema.Name == null)
                indexSchema = await typeSenseCollection.CreateCollection<Device>();
            var id = Guid.NewGuid().ToString();
            var device = await document.Upsert<Device>(new Device
            {
                FriendlyName = "Hello World",
                Id = id,
                ModelName = "Windows"
            }, indexSchema.Name);
            var updatedDevice = await document.GetById<Device>(id, indexSchema.Name);
            Assert.Equal(id, updatedDevice.Id);
        }

        [Fact]
        public async Task Should_be_Able_to_Insert_All_Documents()
        {
            ITypeSenseDocument document = new TypesenseDocument();
            Collection.TypeSenseCollection typeSenseCollection = new Collection.TypeSenseCollection();
            var indexSchema = await typeSenseCollection.GetCollection<Device>();
            if (indexSchema.Name == null)
                indexSchema = await typeSenseCollection.CreateCollection<Device>();
            var id = Guid.NewGuid().ToString();
            var device = await document.InsertMultipleDocument<Device>(new[]{ new Device
            {
                FriendlyName = "Hello World",
                Id = id,
                ModelName = "Windows"
            }}, indexSchema.Name);
        }
    }
}

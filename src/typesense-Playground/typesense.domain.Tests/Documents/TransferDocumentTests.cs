using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using typesense.domain.Documents;
using Xunit;

namespace typesense.domain.Tests.Documents
{
    public class TransferDocumentTests
    {
        [Fact]
        public async Task Should_be_Able_to_transfer_Documents()
        {
            IDocumentTransfer documentTransfer = new DocumentTransfer();
            var documents = await documentTransfer.Export<Book>("books");
            Assert.Equal(9976,documents.Count());  
        }
    }
}

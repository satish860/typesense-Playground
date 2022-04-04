using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using typesense.domain.Attributes;
using typesense.domain.Extensions;
using Humanizer;

namespace typesense.domain
{
    public class CollectionSchema
    {
        private readonly Type type;

        public CollectionSchema(Type type)
        {
            this.type = type;
        }

        public IndexSchema GetDocumentDetails()
        {
            IndexSchema indexSchema = new IndexSchema();
            DocumentAttribute? Attribute = type.GetCustomAttributes(typeof(DocumentAttribute), true).FirstOrDefault() as DocumentAttribute;
            if (Attribute != null)
            {
                indexSchema.DefaultSortingField = Attribute.DefaultSortingField.ToSnakeCase();
                if (indexSchema.IndexName != null)
                    indexSchema.IndexName = indexSchema.IndexName.ToSnakeCase();
                else
                    indexSchema.IndexName = type.Name.Pluralize().ToSnakeCase();
            }
            
            return indexSchema;
        }
    }
}

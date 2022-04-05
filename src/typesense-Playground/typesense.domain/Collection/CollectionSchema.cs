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

        public IndexSchema GetDocumentDetails(IndexSchema indexSchema = default(IndexSchema))
        {
            if (indexSchema == null)
                indexSchema = new IndexSchema();
            DocumentAttribute? Attribute = type.GetCustomAttributes(typeof(DocumentAttribute), true).FirstOrDefault() as DocumentAttribute;
            if (Attribute != null)
            {
                indexSchema.DefaultSortingField = Attribute.DefaultSortingField.ToSnakeCase();
                if (indexSchema.Name != null)
                    indexSchema.Name = indexSchema.Name.ToSnakeCase();
                else
                    indexSchema.Name = type.Name.Pluralize().ToSnakeCase();
            }

            return indexSchema;
        }

        public IndexSchema GetFields(IndexSchema schema)
        {
            List<Field> fields = new List<Field>();
            foreach (var item in type.GetProperties())
            {
                Field field = new Field();
                field.Name = item.Name.ToSnakeCase();
                field.Type = GetTypeSenseProperty(item.PropertyType.Name);
                var attribute = item.GetCustomAttributes(typeof(FacetAttribute), false).FirstOrDefault();
                if (attribute != null)
                    field.Facet = true;
                fields.Add(field);
            }
            schema.Fields = fields;
            return schema;
        }

        private string GetTypeSenseProperty(string name)
        {
            if (name == typeof(DateTime).Name)
                return typeof(int).Name;
            if (name == typeof(decimal).Name)
                return "float";
            return name;
        }
    }
}

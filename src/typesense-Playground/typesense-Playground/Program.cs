// See https://aka.ms/new-console-template for more information
using typesense_Playground;



DocumentAttribute Attribute = (DocumentAttribute)typeof(Book).GetCustomAttributes(typeof(DocumentAttribute), true).FirstOrDefault();
Console.WriteLine(Attribute.DefaultSortingField.ToSnakeCase());
foreach (var item in typeof(Book).GetProperties())
{
    Console.WriteLine(item.Name.ToSnakeCase() + "-" + GetTypeSenseProperty(item.PropertyType.Name));
    var attribute = item.GetCustomAttributes(typeof(FacetAttribute), false).FirstOrDefault();
    if (attribute != null)
        Console.WriteLine(item.Name.ToSnakeCase() + "- is searchable using Facet");

}

string GetTypeSenseProperty(string name)
{
    if (name == typeof(DateTime).Name)
        return typeof(int).Name;
    if (name == typeof(decimal).Name)
        return "float";
    return name;
}
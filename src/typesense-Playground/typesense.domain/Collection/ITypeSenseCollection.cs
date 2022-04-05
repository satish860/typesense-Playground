namespace typesense.domain.Collection
{
    public interface ITypeSenseCollection
    {
        Task<IndexSchema> CreateCollection<T>();

        Task<IndexSchema?> GetCollection<T>();

        Task<IEnumerable<IndexSchema>> ListAllCollection();

         Task<bool> DeleteCollection<T>();
    }
}
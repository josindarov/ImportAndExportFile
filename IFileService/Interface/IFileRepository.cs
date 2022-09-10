using Domain;

namespace Application.Interface
{
    public interface IFileRepository
    {
        public Task AddManyAsync(List<Model> models);
        public Task<int> SaveChangesAsync();
        public IQueryable<Model> GetAll();

    }
}

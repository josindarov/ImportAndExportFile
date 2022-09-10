using Application.Interface;
using Domain;

namespace Infrastructure.Repository
{
    public class FileRepository : IFileRepository
    {
        private readonly AppDbContext _appDbContext;

        public FileRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddManyAsync(List<Model> models)
        {
            foreach (var model in models)
            {
                await _appDbContext.AddAsync(model);
            }
        }

        public IQueryable<Model> GetAll()
        {
            return _appDbContext.Models;
        }
        public async Task<int> SaveChangesAsync()
        {
            var CreatedObjects = await _appDbContext.SaveChangesAsync();
            return CreatedObjects;
        }
    }

    
}

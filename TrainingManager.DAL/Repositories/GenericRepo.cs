using Microsoft.EntityFrameworkCore;
using TrainingManager.DAL.Repositories.Interfaces;
using TrainingManager.Data;

namespace TrainingManager.DAL.Repositories
{
    public class GenericRepo<T>(AppDbContext context) : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext context = context;

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetPageAsync(int page, int pageSize)
        {
            return await context.Set<T>()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            await Task.CompletedTask;
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            T? entity = await GetByIdAsync(Id);
            if(entity != null)
            {
                context.Set<T>().Remove(entity);
                return true;
            }
            return false;
        }

        public async Task<int> CountAsync()
        {
            var items = await context.Set<T>().ToListAsync();
            return items.Count;
        }
    }
}

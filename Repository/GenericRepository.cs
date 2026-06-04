using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ApiRest.Data;
namespace ApiRest.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly IMemoryCache _cache;
        protected readonly DbSet<T> _dbSet;
        protected readonly string _cacheKey;
        protected readonly int _cacheExpirationTime = 3600; // en segundos

        public GenericRepository(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
            _dbSet = _context.Set<T>();
            _cacheKey = $"{typeof(T).Name}CacheKey";
        }

        public async Task<bool> Save()
        {
            var result = await _context.SaveChangesAsync() >= 0;
            if (result)
                ClearCache();
            return result;
        }

        public void ClearCache()
        {
            _cache.Remove(_cacheKey);
        }

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            if (_cache.TryGetValue(_cacheKey, out ICollection<T> cachedData))
                return cachedData;

            var dataFromDb = await _dbSet.ToListAsync();
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(_cacheExpirationTime));

            _cache.Set(_cacheKey, dataFromDb, cacheOptions);
            return dataFromDb;
        }

        public virtual async Task<T> GetAsync(int id)
        {
            if (_cache.TryGetValue(_cacheKey, out ICollection<T> cachedData))
            {
                var entity = cachedData.FirstOrDefault(c =>
                {
                    var prop = c.GetType().GetProperty("Id");
                    if (prop == null) return false;
                    var value = prop.GetValue(c);
                    return value != null && (int)value == id;
                });

                if (entity != null)
                    return entity;
            }

            return await _dbSet.FindAsync(id);
        }


        public async Task<bool> ExistsAsync(int id)
        {
            return await _dbSet.AnyAsync(c => EF.Property<int>(c, "Id") == id);
        }

        public virtual async Task<bool> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return await Save();
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            if (entity == null) return false;

            _dbSet.Remove(entity);
            return await Save();
        }
    }
}

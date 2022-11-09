using GitHubInfoDownloader.Models;
using GitHubInfoDownloader.Repositories.Interfaces;
using System;

namespace GitHubInfoDownloader.Repositories.Implementation
{
    public class AppRepository<T> : IAppRepository<T> where T : class
    {
        protected readonly GitGetterContext _dbContext;
        public AppRepository(GitGetterContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }


        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

    }
}

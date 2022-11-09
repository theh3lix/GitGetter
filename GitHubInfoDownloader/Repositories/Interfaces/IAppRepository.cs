using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubInfoDownloader.Repositories.Interfaces
{
    public interface IAppRepository<T>
    {
        Task<T> AddAsync(T entity);
        void Add(T entity);
        List<T> GetAll();
    }
}

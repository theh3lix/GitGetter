using GitHubInfoDownloader.Models;
using GitHubInfoDownloader.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubInfoDownloader.Repositories.Implementation
{
    public class RepoRepository : AppRepository<Repo>, IRepoRepository
    {
        public RepoRepository(GitGetterContext dbContext) : base(dbContext) { }

        public Repo GetRepo(string name, int owner_id)
        {
            return _dbContext.repos.FirstOrDefault(x => x.name == name && x.ownerId == owner_id);
        }

    }
}

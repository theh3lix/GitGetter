using GitHubInfoDownloader.Models;
using GitHubInfoDownloader.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubInfoDownloader.Repositories.Implementation
{
    public class GitUserRepository : AppRepository<GitUser>, IGitUserRepository
    {
        public GitUserRepository(GitGetterContext dbContext) : base(dbContext) { }

        public GitUser GetUser(string username)
        {
            return _dbContext.gitUsers.FirstOrDefault(x => x.name == username);
        }

    }
}

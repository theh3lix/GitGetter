using GitHubInfoDownloader.Models;
using GitHubInfoDownloader.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubInfoDownloader.Repositories.Implementation
{
    public class CommitRepository : AppRepository<Commit>, ICommitRepository
    {
        public CommitRepository(GitGetterContext dbContext) : base(dbContext) { }

        public bool Exists(string sha)
        {
            return _dbContext.commits.Any(x => x.sha == sha);
        }
    }
}

using GitHubInfoDownloader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubInfoDownloader.Repositories.Interfaces
{
    public interface ICommitRepository : IAppRepository<Commit>
    {
        bool Exists(string sha);
    }
}

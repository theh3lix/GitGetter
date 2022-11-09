using GitHubInfoDownloader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubInfoDownloader.Repositories.Interfaces
{
    public interface IGitUserRepository : IAppRepository<GitUser>
    {
        GitUser GetUser(string username);
    }
}

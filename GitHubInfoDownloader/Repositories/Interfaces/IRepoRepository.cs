using GitHubInfoDownloader.Models;
using System.Threading.Tasks;

namespace GitHubInfoDownloader.Repositories.Interfaces
{
    public interface IRepoRepository : IAppRepository<Repo>
    {
        Repo GetRepo(string name, int owner_id);
    }
}

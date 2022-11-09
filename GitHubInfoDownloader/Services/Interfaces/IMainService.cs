using GitHubInfoDownloader.Models;

namespace GitHubInfoDownloader.Services.Interfaces
{
    public interface IMainService
    {
        Task<int> SaveRecords(List<GitHubResponseModel> records);
        void SetService(string repoName, string ownerName);
    }
}

using GitHubInfoDownloader.Models;

namespace GitHubInfoDownloader.Services.Interfaces
{
    public interface IMainService
    {
        Task<List<GitHubResponseModel>> GetCommits(string username, string repo);
        Task<int> SaveRecords(List<GitHubResponseModel> records);
        void SetService(string repoName, string ownerName);
    }
}

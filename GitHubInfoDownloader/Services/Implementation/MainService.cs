using GitHubInfoDownloader.Models;
using GitHubInfoDownloader.Repositories.Interfaces;
using GitHubInfoDownloader.Services.Interfaces;

namespace GitHubInfoDownloader.Services.Implementation
{
    public class MainService : IMainService
    {
        private readonly ICommitRepository _commitRepository;
        private readonly IGitUserRepository _userRepository;
        private readonly IRepoRepository _repoRepository;
        private string _repoName;
        private string _ownerName;

        public MainService(ICommitRepository commitRepository, IGitUserRepository userRepository, IRepoRepository repoRepository)
        {
            _commitRepository = commitRepository;
            _userRepository = userRepository;
            _repoRepository = repoRepository;
        }

        public void SetService(string repoName, string ownerName)
        {
            _repoName = repoName;
            _ownerName = ownerName;
        }

        public async Task<int> SaveRecords(List<GitHubResponseModel> records)
        {
            int cnt = 0;
            foreach(var record in records)
            {
                if (_commitRepository.Exists(record.sha))
                    continue;
                var toAdd = BuildCommit(record);
                try
                {
                    _commitRepository.Add(toAdd);
                    cnt++;
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return cnt;
        }

        private Commit BuildCommit(GitHubResponseModel record)
        {
            var committing_user = BuildCommittingUser(record.commit.committer.name, record.commit.committer.email);
            var owner = committing_user.name == _ownerName ? committing_user : BuildOwner();
            var repo = BuildRepo(owner);

            var commit = new Commit
            {
                committer = committing_user,
                repo = repo,
                date = record.commit.committer.date,
                message = record.commit.message,
                sha = record.sha
            };
            return commit;
        }

        private GitUser BuildCommittingUser(string name, string email)
        {
            var committing_user = _userRepository.GetUser(name);
            if (committing_user == null)
            {
                committing_user = new GitUser
                {
                    name = name,
                    email = email
                };
            } else 
                committing_user.email = email;
            return committing_user;
        }

        private Repo BuildRepo(GitUser owner)
        {
            var repo = _repoRepository.GetRepo(_repoName, owner.gituserId);
            if (repo == null)
            {
                repo = new Repo
                {
                    owner = owner,
                    name = _repoName
                };
            }
            return repo;
        }

        private GitUser BuildOwner()
        {
            var owner = _userRepository.GetUser(_ownerName);
            if (owner == null)
            {
                owner = new GitUser
                {
                    gituserId = 0,
                    name = _ownerName
                };
            }
            return owner;
        }
    }
}

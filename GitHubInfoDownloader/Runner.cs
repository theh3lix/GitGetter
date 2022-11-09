using GitHubInfoDownloader.Services;
using GitHubInfoDownloader.Services.Interfaces;

namespace GitHubInfoDownloader
{
    public class Runner
    {
        private readonly IMainService _mainService;
        private readonly IGitHubApiService _apiService;
        public Runner(IMainService mainService, IGitHubApiService apiService)
        {
            _mainService = mainService;
            _apiService = apiService;
        }

        public void Run()
        {
            ShowHeader();
            //get input data from the user
            var username = Helper.AskForParameter("Github user name");
            var repo = Helper.AskForParameter("Github repo name");
            Console.WriteLine();

            //download commits based on input data
            var result = _apiService.GetData($"repos/{username}/{repo}/commits").Result;
            if(result == null)
                return;

            //display downloaded commits in the console
            Helper.DisplayCommits(result, repo);

            if (Helper.AskIfSaving())
            {
                //save commits in the database
                _mainService.SetService(repo, username);
                int cnt = _mainService.SaveRecords(result).Result;
                Console.WriteLine($"{cnt} Records successfully saved in the database!");
            }
            else
            {
                Console.WriteLine("Not saving, okay");
            }
        }

        private void ShowHeader()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("-----GitHub Commit Info Downloader----");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine();
        }
    }
}

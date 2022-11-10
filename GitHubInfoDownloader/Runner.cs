using GitHubInfoDownloader.Services;
using GitHubInfoDownloader.Services.Interfaces;

namespace GitHubInfoDownloader
{
    public class Runner
    {
        private readonly IMainService _mainService;
        public Runner(IMainService mainService)
        {
            _mainService = mainService;
        }

        public void Run()
        {
            Helper.ShowHeader();
            //get input data from the user
            var username = Helper.AskForParameter("Github user name");
            var repo = Helper.AskForParameter("Github repo name");
            Console.WriteLine();

            //download commits based on input data
            var result = _mainService.GetCommits(username,repo).Result;
            if(result == default)
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
    }
}

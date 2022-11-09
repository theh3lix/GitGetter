using GitHubInfoDownloader.Models;
using GitHubInfoDownloader.Repositories.Implementation;
using GitHubInfoDownloader.Repositories.Interfaces;
using GitHubInfoDownloader.Services.Implementation;
using GitHubInfoDownloader.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GitHubInfoDownloader
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GitGetterContext>(options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=GitGetterDatabase;Trusted_Connection=True;"));

            services.AddTransient(typeof(IAppRepository<>), typeof(AppRepository<>));
            services.AddTransient<ICommitRepository, CommitRepository>();
            services.AddTransient<IGitUserRepository, GitUserRepository>();
            services.AddTransient<IRepoRepository, RepoRepository>();

            services.AddTransient<IMainService, MainService>();
            services.AddTransient<IGitHubApiService, GitHubApiService>();

            services.AddTransient<Runner>();
        }
    }
}

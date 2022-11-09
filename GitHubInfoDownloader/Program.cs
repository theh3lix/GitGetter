using GitHubInfoDownloader.Models;
using GitHubInfoDownloader.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Configuration;
using GitHubInfoDownloader.Services.Interfaces;
using GitHubInfoDownloader.Services.Implementation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace GitHubInfoDownloader
{
    public class Program
    {
        
        public static void Main()
        {
            var services = new ServiceCollection();
            var startup = new Startup();
            startup.ConfigureServices(services);
            
            var provider = services.BuildServiceProvider();

            provider.GetService<Runner>().Run();
        }

    }

}
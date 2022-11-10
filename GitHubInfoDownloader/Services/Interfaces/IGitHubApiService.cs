using GitHubInfoDownloader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubInfoDownloader.Services.Interfaces
{
    public interface IGitHubApiService
    {
        Task<T> GetData<T>(string url);
    }
}

using GitHubInfoDownloader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubInfoDownloader.Services
{
    public class Helper
    {
        public static void ShowHeader()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("-----GitHub Commit Info Downloader----");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine();
        }
        public static string AskForParameter(string parametername)
        {
            Console.WriteLine($"{parametername}: ");
            return Console.ReadLine();
        }

        public static void DisplayCommits(List<GitHubResponseModel> commits, string repo)
        {
            foreach (var commit in commits)
            {
                Console.WriteLine($"{repo}/{commit}");
            }
        }

        public static bool AskIfSaving()
        {
            Console.WriteLine("Do you want to save the result in the Database? (Y/n)");
            string answer = Console.ReadLine().ToLower();
            switch (answer)
            {
                case "y":
                case "":
                    return true;
                case "n":
                    return false;
                default:
                    Console.WriteLine("Incorrect option. Try again.");
                    return AskIfSaving();
            }
        }
    }
}

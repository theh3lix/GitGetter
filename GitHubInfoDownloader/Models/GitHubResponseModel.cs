using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubInfoDownloader.Models
{
    public sealed class GitHubResponseModel
    {
        public string sha { get; set; }
        public CommitEntry commit { get; set; }
        public override string ToString()
        {
            return $"{sha}: {commit}";
        }
        public partial class CommitEntry
        {
            public string message { get; set; }
            public Committer committer { get; set; }
            public override string ToString()
            {
                return $"{message} [{committer}]";
            }
        }

        public partial class Committer
        {
            public string name { get; set; }
            public string email { get; set; }
            public DateTime date { get; set; }
            public override string ToString()
            {
                return $"Committed by {name} ({email}) on {date:dd-MM-yyyy}";
            }
        }
    }
}

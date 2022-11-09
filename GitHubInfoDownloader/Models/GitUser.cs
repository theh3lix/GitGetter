using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubInfoDownloader.Models
{
    public class GitUser
    {
        [Key]
        public int gituserId { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public ICollection<Repo> repos { get; set; }
        public ICollection<Commit> commits { get; set; }
    }
}

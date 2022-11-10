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
        public int gitUserId { get; set; }
        [MaxLength(39)]
        public string name { get; set; }
        [MaxLength(320)]
        public string email { get; set; }

        public ICollection<Repo> repos { get; set; }
        public ICollection<Commit> commits { get; set; }
    }
}

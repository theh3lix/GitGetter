using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubInfoDownloader.Models
{
    public class Commit
    {
        [Key]
        public string sha { get; set; }
        public string message { get; set; }
        public DateTime date { get; set; }

        public int repoId { get; set; }
        [ForeignKey("repoId")]
        public Repo repo { get; set; }

        public int committerId { get; set; }
        [ForeignKey("committerId")]
        public GitUser committer { get; set; }
    }

}

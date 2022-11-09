using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubInfoDownloader.Models
{
    public class Repo
    {
        [Key]
        public int repoId { get; set; }
        public string name { get; set; }

        public int ownerId { get; set; }
        [ForeignKey("ownerId")]
        public GitUser owner { get; set; }
        ICollection<Commit> commits { get; set; }

    }
}

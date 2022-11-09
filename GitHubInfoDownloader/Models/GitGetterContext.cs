using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubInfoDownloader.Models
{
    public class GitGetterContext : DbContext
    {
        public GitGetterContext() : base() { }
        public GitGetterContext(DbContextOptions<GitGetterContext> options) : base(options) { }


        public DbSet<Commit> commits { get; set; }
        public DbSet<Repo> repos { get; set; }
        public DbSet<GitUser> gitusers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=GitGetterDatabase;Trusted_Connection=True;");
            }
        }

    }

}

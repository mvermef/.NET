using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Github.Models
{
    public class GithubContext : DbContext
    {
        public GithubContext (DbContextOptions<GithubContext> options)
            : base(options)
        {
        }

        public DbSet<gitd> Gitd { get; set; }
    }
}

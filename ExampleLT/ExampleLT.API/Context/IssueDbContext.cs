using ExampleLT.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleLT.API.Context
{
    public class IssueDbContext : DbContext
    {
        public IssueDbContext(DbContextOptions<IssueDbContext> options) : base(options)
        {

        }

        public DbSet<Issue> Issues { get; set; }

    }
}

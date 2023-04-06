using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Domain;
using Microsoft.EntityFrameworkCore;

namespace Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Data
{
    public class WalkDbContext : DbContext
    {
        public WalkDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Ragion> Ragions { get; set; }
    }
}

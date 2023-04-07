using Azure.Identity;
using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Domain;
using Microsoft.EntityFrameworkCore;

namespace Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Data
{
    public class WalkDbContext : DbContext 
    {
        public WalkDbContext(DbContextOptions<WalkDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Ragion> Ragions { get; set; }


        // Create Seed Data 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seed The Data For Difficulty
            var DifficultySeedData = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("a1958455-e9c3-4735-877e-5c027507566a"),
                    Name = "Easy",
                },
                new Difficulty()
                {
                    Id = Guid.Parse("77e275f6-3971-4df7-baa9-b671db84cfb0"),
                    Name = "Medium",
                }, 
                new Difficulty()
                {
                    Id = Guid.Parse("b87727ba-4bf4-4f02-ae97-3ef980ad83c7"),
                    Name = "Hard",
                }
            };
            // Seed Difficulty To Database 
            modelBuilder.Entity<Difficulty>().HasData(DifficultySeedData);


        }
    }
}

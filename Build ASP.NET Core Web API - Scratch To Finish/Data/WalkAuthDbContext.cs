using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Data
{
    public class WalkAuthDbContext : IdentityDbContext
    {
        public WalkAuthDbContext(DbContextOptions<WalkAuthDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var onlyRedaerRoleId = "92474726-aa23-4637-b049-33f6d6adaa97";
            var onlyWriteRoleId = "f44abd48-a5e4-4f2f-88de-4a65c1a21ba5";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = onlyRedaerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper(),
                    //ConcurrencyStamp = new DateTime()
                },
                new IdentityRole
                {
                    Id = onlyWriteRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper(),
                    //ConcurrencyStamp = new DateTime()
                }

            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}

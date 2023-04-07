using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Data;
using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Domain;

namespace Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Repositories.IRepositoriesWalks
{
    public class SQLWalksRepositories : IRepositoriesWalks
    {

        private readonly WalkDbContext dbContext;
        public SQLWalksRepositories(WalkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Walk> CreateNewWalk(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }
    }
}

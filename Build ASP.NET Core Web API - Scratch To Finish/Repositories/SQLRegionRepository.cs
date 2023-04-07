using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Data;
using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Domain;
using Microsoft.EntityFrameworkCore;

namespace Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly WalkDbContext dbContext;
        public SQLRegionRepository(WalkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Ragion> CreateNewReagion(Ragion ragion)
        {
            await dbContext.Ragions.AddAsync(ragion);
            await dbContext.SaveChangesAsync();
            return ragion;
        }

        public async Task<Ragion?> DelatetReagion(Guid id)
        {
            var ExistingRegion = await dbContext.Ragions.FirstOrDefaultAsync(x => x.Id == id);
            if (ExistingRegion == null)
            {
                return null;
            }
            dbContext.Ragions.Remove(ExistingRegion);
            await dbContext.SaveChangesAsync();
            return ExistingRegion;
        }

        public async Task<List<Ragion>> GetAllAsync()
        {
            return await dbContext.Ragions.ToListAsync();
        }

        public async Task<Ragion?> GetRagionById(Guid id)
        {
            return await dbContext.Ragions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Ragion?> Update(Guid id, Ragion ragion)
        {
            var ExistingRegion = await dbContext.Ragions.FirstOrDefaultAsync(x => x.Id == id);
            if (ExistingRegion == null)
            {
                return null;
            }
            ExistingRegion.Code = ragion.Code;
            ExistingRegion.Name = ragion.Name;
            ExistingRegion.Region_UmageUrl = ragion.Region_UmageUrl;
            await dbContext.SaveChangesAsync();
            return ragion;
        }

    }
}

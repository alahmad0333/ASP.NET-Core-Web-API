using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Data;
using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Domain;
using Microsoft.EntityFrameworkCore;

namespace Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Repositories.IRepositoriesReagion
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
            ragion.DateTime = DateTime.Now;
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

        public async Task<List<Ragion>> GetAllAsync(
            string? FilterOn, string? FilterQuery,
            string? sortBy, bool isAscending = true,
            int pageNumber = 1, int pageSize = 1000
            )
        {
            //return await dbContext.Ragions.ToListAsync();
            var _region = dbContext.Ragions.AsQueryable();
            // Fltering 
            if (string.IsNullOrWhiteSpace(FilterOn) == false && string.IsNullOrWhiteSpace(FilterQuery) == false)
            {
                if (FilterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    _region = _region.Where(x => x.Name.Contains(FilterQuery));

                }
                if (FilterOn.Equals("Code", StringComparison.OrdinalIgnoreCase))
                {
                    _region = _region.Where(x => x.Code.Contains(FilterQuery));

                }
                if (FilterOn.Equals("DateTime", StringComparison.OrdinalIgnoreCase))
                {
                    _region = _region.Where(x => x.DateTime.HasValue && x.DateTime.Value.ToString().Contains(FilterQuery));
                }
            }

            // Sorting 
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    _region = isAscending ? _region.OrderBy(x => x.Name) : _region.OrderByDescending(x => x.Name);
                }
                if (sortBy.Equals("DateTime", StringComparison.OrdinalIgnoreCase))
                {
                    _region = isAscending ? _region.OrderBy(x => x.DateTime) : _region.OrderByDescending(x => x.DateTime);
                }
            }

            // Pagination 
            var skipResulet = (pageNumber -1) * pageSize;

            return await _region.Skip(skipResulet).Take(pageSize).ToListAsync();
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

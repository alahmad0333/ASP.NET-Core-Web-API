using AutoMapper;
using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Data;
using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Domain;
using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Models.DTOs.Walks;
using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Repositories.IRepositoriesWalks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IRepositoriesWalks repositoriesWalks;
        private readonly WalkDbContext dbContext;
        public WalksController(IMapper mapper, IRepositoriesWalks repositoriesWalks, WalkDbContext dbContext)
        {
            this.mapper = mapper;
            this.repositoriesWalks = repositoriesWalks;
            this.dbContext = dbContext;
        }


        // Create Walk
        // POST : api/Walks
        [HttpPost]
        public async Task<IActionResult> CreateWalks([FromBody] AddWalksDto addWalksDto)
        {
            try
            {
                var walksDto = new Walk()
                {
                    Description = addWalksDto.Description,
                    DifficultyId = addWalksDto.Difficulty_ID,
                    Region_UmageUrl = addWalksDto.Region_UmageUrl,
                    LengthInKm = addWalksDto.LengthInKm,
                    RagionId = addWalksDto.Region_Id                    
                };

                var walkToDomine = new AddWalksDto()
                {
                    Difficulty_ID = addWalksDto.Difficulty_ID,
                    Description = addWalksDto.Description,
                    LengthInKm = addWalksDto.LengthInKm,
                    Region_Id = addWalksDto.Region_Id,
                    Region_UmageUrl = addWalksDto.Region_UmageUrl
                };
                await dbContext.Walks.AddAsync(walksDto);
                await dbContext.SaveChangesAsync();
                return Ok(walkToDomine);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}


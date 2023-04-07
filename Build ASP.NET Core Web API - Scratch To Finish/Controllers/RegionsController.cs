using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Data;
using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Domain;
using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Models.DTOs;
using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Controllers
{
    //https://localhost:7184/api
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly WalkDbContext DbContext;
        private readonly IRegionRepository regionRepository;

        public RegionsController(WalkDbContext dbContext, IRegionRepository regionRepository)
        {
            DbContext = dbContext;
            this.regionRepository = regionRepository;
        }




        // GET ALL REGIONS
        // GET : https://localhost:7184/api/Regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // GET DATA FORM DATABASE - DOMINE MODELS
            var regionsDomine = await regionRepository.GetAllAsync();

            // MAP DOMAINE MODELS TO DTOS 
            var refionsDto = new List<RegionDto>();
            foreach (var regionDomine in regionsDomine)
            {
                refionsDto.Add(new RegionDto()
                {
                    Id = regionDomine.Id,
                    Name = regionDomine.Name,
                    Code = regionDomine.Code,
                    Region_UmageUrl = regionDomine.Region_UmageUrl,

                });
            }
            // RETUERN DTOS
            return Ok(refionsDto);
        }





        // GET Singal REGIONS BY ID 
        // GET : https://localhost:7184/api/Regions/{id}?
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetByID([FromRoute] Guid id)
        {
            var regionDomine = await regionRepository.GetRagionById(id);

            if (regionDomine == null)
            {
                return NotFound();
            }
            else
            {
                // MAP DOMAINE MODELS TO DTOS 

                var regionDto = new RegionDto
                {
                    Id = regionDomine.Id,
                    Name = regionDomine.Name,
                    Code = regionDomine.Code,
                    Region_UmageUrl = regionDomine.Region_UmageUrl,

                };

                return Ok(regionDto);
            }


        }





        // POST : Add New Region
        [HttpPost]
        public async Task<IActionResult> CreateNewReagion([FromBody] AddRegionDto ragion)
        {
            var regionDots = new Ragion
            {
                Name = ragion.Name,
                Code = ragion.Code,
                Region_UmageUrl = ragion.Region_UmageUrl,
            };
            var regionModel = await regionRepository.CreateNewReagion(regionDots);
            return Ok(regionModel);
        }


        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateReagion([FromBody] AddRegionDto ragion, Guid id)
        {
            var regionToModel = new Ragion
            {
                Name = ragion.Name,
                Code = ragion.Code,
                Region_UmageUrl = ragion.Region_UmageUrl,
            };
            var reagionModel = await regionRepository.Update(id, regionToModel);
            if (reagionModel != null)
            {
                return NotFound();
            }

            return Ok(reagionModel);
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DelatetReagion([FromRoute] Guid id)
        {

            var regionToModel = await regionRepository.DelatetReagion(id);
            if (regionToModel == null)
            {
                return NotFound();
            }
            return Ok(regionToModel);
        }


    }
}

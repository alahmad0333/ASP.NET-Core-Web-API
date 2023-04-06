using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Data;
using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Domain;
using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Models.DTOs;
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

        public RegionsController(WalkDbContext dbContext)
        {
            DbContext = dbContext;
        }

        // GET ALL REGIONS
        // GET : https://localhost:7184/api/Regions
        [HttpGet]
        public IActionResult GetAll()
        {
            // GET DATA FORM DATABASE - DOMINE MODELS
            var regionsDomine = DbContext.Ragions.ToList();




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
        [Route("{id}")]
        public IActionResult GetByID([FromRoute] Guid id)
        {
            var regionDomine = DbContext.Ragions.Find(id);

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


        [HttpPost]
        public IActionResult CreateNewReagion([FromBody]AddRegionDto ragion)
        {
            var regionDomineModel = new Ragion
            {
                Code = ragion.Code,
                Name=ragion.Name,
                Region_UmageUrl=ragion.Region_UmageUrl,
            };
            DbContext.Ragions.Add(regionDomineModel);
            DbContext.SaveChanges();
            return Ok(regionDomineModel);
        
        }


    }
}

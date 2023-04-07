using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Models.DTOs.Reagion;
using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Domain;
using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Repositories.IRepositoriesReagion;
using Microsoft.AspNetCore.Authorization;

namespace Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Controllers
{
    //https://localhost:7184/api
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        // GET ALL REGIONS
        // GET : https://localhost:7184/api/Regions
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? FilterOn, [FromQuery] string? FilterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending
            ,[FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000
            )
        {
            //var RegionDto = new List<RegionDto>();
            //foreach (var RegionDomain in IrepostryReagion)
            //{
            //    RegionDto.Add(new RegionDto
            //    {
            //        Id = RegionDomain.Id,
            //        Name = RegionDomain.Name,
            //        Code = RegionDomain.Code,
            //        Region_UmageUrl = RegionDomain.Region_UmageUrl,
            //    });

            //}

            var IrepostryReagion = await regionRepository.GetAllAsync(FilterOn , FilterQuery , sortBy , isAscending?? true , pageNumber , pageSize);
            return Ok(mapper.Map<List<RegionDto>>(IrepostryReagion));
        }




        // GET Singal REGIONS BY ID 
        // GET : https://localhost:7184/api/Regions/{id}?
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetByID([FromRoute] Guid id)
        {
            var IrepostryReagion = await regionRepository.GetRagionById(id);

            if (IrepostryReagion == null)
            {
                return NotFound();
            }
            else
            {
                //var RegionDomine = new RegionDto
                //{
                //    Id = IrepostryReagion.Id,
                //    Name = IrepostryReagion.Name,
                //    Code = IrepostryReagion.Code,
                //    Region_UmageUrl = IrepostryReagion.Region_UmageUrl
                //};

                return Ok(mapper.Map<RegionDto>(IrepostryReagion));
            }


        }


        //// POST : Add New Region
        [HttpPost]
        public async Task<IActionResult> CreateNewReagion(AddRegionDto addRegion)
        {
            // DominModel to Dtos 
            var regionDomineModel = mapper.Map<Ragion>(addRegion);

            // Add Dtos to IrepostryReagion To Added To Database
            regionDomineModel = await regionRepository.CreateNewReagion(regionDomineModel);

            // then return Dto to Dmoine Model To Veiw  
            return Ok(mapper.Map<AddRegionDto>(regionDomineModel));

        }


        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateReagion([FromBody] UpdateRegionDto updateRegion, [FromRoute] Guid id)
        {

            // DominModel to Dtos 
            var regionDomineModel = mapper.Map<Ragion>(updateRegion);

            regionDomineModel = await regionRepository.Update(id, regionDomineModel);
            if (regionDomineModel == null)
            {
                return NotFound();
            }
            else
            {
                // then return Dto to Dmoine Model To Veiw  
                return Ok(mapper.Map<RegionDto>(regionDomineModel));
            }

        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DelatetReagion([FromRoute] Guid id)
        {
            var IrepostryReagion = await regionRepository.DelatetReagion(id);

            if (IrepostryReagion == null) { return NotFound(); }
            // then return Dto to Dmoine Model To Veiw  
            return Ok(mapper.Map<RegionDto>(IrepostryReagion));
        }


    }
}

using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Data;
using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Domain;
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
            var regions = DbContext.Ragions.ToList();
            return Ok(regions);
        }

        // GET Singal REGIONS
        // GET : https://localhost:7184/api/Regions/id?
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetByID(Guid id)
        {
            var regions = DbContext.Ragions.Find(id);
            return Ok(regions);
        }
    }
}

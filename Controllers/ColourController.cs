using Docker.Les.Admin.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Docker.Les.Admin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColourController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ColourController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Colour>> GetColourItems()
        {
            return _context.Colours;
        }
    }
}

using System.Threading.Tasks;
using Database.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FixturesController : ControllerBase
    {
        private readonly SoccerSimContext _context;

        public FixturesController(SoccerSimContext context)
        {
            _context = context;
        }
    }
}
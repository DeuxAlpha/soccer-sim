using Database.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.FunctionalControllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagementController : ControllerBase
    {
        private readonly SoccerSimContext _context;

        public ManagementController(SoccerSimContext context)
        {
            _context = context;
        }
    }
}
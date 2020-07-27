using System.Linq;
using API.Dtos;
using Database.Contexts;
using Microsoft.AspNetCore.Mvc;
using Querying.Query.Models;
using Querying.Query.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly SoccerSimContext _context;

        public TeamsController(SoccerSimContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTeams(QueryRequest request)
        {
            var response = QueryService.GetQueryResponse(_context.Teams.Select(t => new TeamDto(t)), request);
            return Ok(response);
        }
    }
}
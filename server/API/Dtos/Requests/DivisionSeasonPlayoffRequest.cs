using System.Collections.Generic;

namespace API.Dtos.Requests;

public class DivisionSeasonPlayoffRequest
{
    public IEnumerable<string> Teams { get; set; }
}
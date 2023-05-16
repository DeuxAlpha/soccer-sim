using System.Collections.Generic;

namespace API.Dtos.Views;

public class PlayoffResultDto
{
    public string Champion { get; set; }
    public IEnumerable<string> Losers { get; set; }
    public IEnumerable<string> Results { get; set; }
}
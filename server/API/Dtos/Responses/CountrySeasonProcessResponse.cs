using System.Collections.Generic;
using API.Dtos.Views;

namespace API.Dtos.Responses;

public class CountrySeasonProcessResponse
{
    public string NewSeason { get; set; }
    public List<PlayoffResultDto> Playoffs { get; set; }
    public List<LeagueInfoDto> Leagues { get; set; }
}
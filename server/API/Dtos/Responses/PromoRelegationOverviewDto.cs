using System.Collections.Generic;

namespace API.Dtos.Responses;

public class PromoRelegationOverviewDto
{
    public IEnumerable<TeamDto> PromotedTeams { get; set; }
    public IEnumerable<TeamDto> RelegatedTeams { get; set; }
    public IEnumerable<TeamDto> PromoPlayoffTeams { get; set; }
    public IEnumerable<TeamDto> RelegationPlayoffTeams { get; set; }
}
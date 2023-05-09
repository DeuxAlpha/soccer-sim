using System.Collections.Generic;

namespace API.Dtos;

public class DivisionProcessingStatus
{
    public IEnumerable<TeamDto> PromotedTeams { get; set; }
    public IEnumerable<TeamDto> RelegatedTeams { get; set; }
    public IEnumerable<TeamDto> PromoPlayoffTeams { get; set; }
    public IEnumerable<TeamDto> RelegationPlayoffTeams { get; set; }
    public IEnumerable<TeamDto> PromotedIntoThisDivision { get; set; }
    public IEnumerable<TeamDto> RelegatedIntoThisDivision { get; set; }
}
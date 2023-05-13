using System.Collections.Generic;

namespace API.Dtos.Requests;

public class LeagueGameUpdateRequest
{
    public string HomeTeamName { get; set; }
    public ICollection<TeamScoreEvent> HomeScoreEvents { get; set; }
    public string AwayTeamName { get; set; }
    public ICollection<TeamScoreEvent> AwayScoreEvents { get; set; }
}

public class TeamScoreEvent
{
    public int Minute { get; set; }
    public int OvertimeMinute { get; set; }
}
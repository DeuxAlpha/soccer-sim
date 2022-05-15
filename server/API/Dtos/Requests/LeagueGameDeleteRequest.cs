namespace API.Dtos.Requests
{
    public class LeagueGameDeleteRequest
    {
        public string HomeTeamName { get; set; }
        public string AwayTeamName{get;set;}
        public bool IncludeNonGoals { get; set; }
    }
}
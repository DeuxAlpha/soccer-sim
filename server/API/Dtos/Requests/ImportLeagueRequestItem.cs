using System.Collections.Generic;

namespace API.Dtos.Requests
{
    public class ImportLeagueRequest
    {
        public IEnumerable<ImportLeagueRequestItem> Collection { get; set; }
        public string Continent { get; set; }
        public string Country { get; set; }
        public string League { get; set; }
        public string Division { get; set; }
    }

    public enum Result
    {
        HomeWin,
        AwayWin,
        Draw
    }

    public class ImportLeagueRequestItem
    {
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public int HomeHalfTimeGoals { get; set; }
        public int AwayHalfTimeGoals { get; set; }

        public int HomeFullTimeGoals { get; set; }

        public string Timestamp { get; set; }
    }
}
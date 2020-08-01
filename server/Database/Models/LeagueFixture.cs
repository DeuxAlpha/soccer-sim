using System.Collections.Generic;

namespace Database.Models
{
    public class LeagueFixture
    {
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public string Season { get; set; }
        public string LeagueName { get; set; }
        public int GameDayNumber { get; set; }

        public int HalfFieldLength { get; set; }
        public int ActionsPerMinute { get; set; }
        public int MaxOvertime { get; set; }
        public double ShotAccuracyModifier { get; set; }
        public double PaceModifier { get; set; }
        public double MaxHomeAdvantage { get; set; }
        public double MaxAwayDisadvantage { get; set; }

        public int? HomePossession { get; set; }
        public int? AwayPossession { get; set; }

        public League League { get; set; }
        public LeagueGameDay GameDay { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public ICollection<LeagueFixtureEvent> Events { get; set; }
    }
}
using Database.Models;

namespace API.Dtos
{
    public class LeagueDto
    {
        public string Season { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public double ShotAccuracyModifier { get; set; }
        public double PaceModifier { get; set; }
        public double MaxHomeAdvantage { get; set; }
        public double MaxAwayDisadvantage { get; set; }
        public string DivisionName { get; set; }
        public string Image { get; set; }

        public LeagueDto()
        {

        }

        public LeagueDto(League league)
        {
            Season = league.Season;
            Name = league.Name;
            Abbreviation = league.Abbreviation;
            ShotAccuracyModifier = league.ShotAccuracyModifier;
            PaceModifier = league.PaceModifier;
            MaxHomeAdvantage = league.MaxHomeAdvantage;
            MaxAwayDisadvantage = league.MaxAwayDisadvantage;
            DivisionName = league.DivisionName;
            Image = league.Image;
        }

        public League Map()
        {
            return new League
            {
                Season = Season,
                Name = Name,
                Abbreviation = Abbreviation,
                ShotAccuracyModifier = ShotAccuracyModifier,
                PaceModifier = PaceModifier,
                MaxHomeAdvantage = MaxHomeAdvantage,
                MaxAwayDisadvantage = MaxAwayDisadvantage,
                DivisionName = DivisionName,
                Image = Image,
            };
        }

        public void MapUpdate(League league)
        {
            league.Abbreviation = Abbreviation;
            league.ShotAccuracyModifier = ShotAccuracyModifier;
            league.PaceModifier = PaceModifier;
            league.MaxHomeAdvantage = MaxHomeAdvantage;
            league.MaxAwayDisadvantage = MaxAwayDisadvantage;
            league.DivisionName = DivisionName;
            league.Image = Image;
        }
    }
}
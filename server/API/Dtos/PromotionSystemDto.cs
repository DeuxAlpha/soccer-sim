using Database.Models;

namespace API.Dtos
{
    public class PromotionSystemDto
    {
        public string Season { get; set; }
        public string LeagueName { get; set; }
        public int PromotedTeamsStart { get; set; }
        public int PromotedTeamsEnd { get; set; }
        public int PromotionPlayOffTeamsStart { get; set; }
        public int PromotionPlayOffTeamsEnd { get; set; }
        public int RelegatedTeamsStart { get; set; }
        public int RelegatedTeamsEnd { get; set; }
        public int RelegationPlayOffTeamsStart { get; set; }
        public int RelegationPlayOffTeamsEnd { get; set; }

        public PromotionSystemDto()
        {

        }

        public PromotionSystemDto(PromotionSystem promotionSystem)
        {
            Season = promotionSystem.Season;
            LeagueName = promotionSystem.LeagueName;
            PromotedTeamsStart = promotionSystem.PromotedTeamsStart;
            PromotedTeamsEnd = promotionSystem.PromotedTeamsEnd;
            PromotionPlayOffTeamsStart = promotionSystem.PromotionPlayOffTeamsStart;
            PromotionPlayOffTeamsEnd = promotionSystem.PromotionPlayOffTeamsEnd;
            RelegatedTeamsStart = promotionSystem.RelegatedTeamsStart;
            RelegatedTeamsEnd = promotionSystem.RelegatedTeamsEnd;
            RelegationPlayOffTeamsStart = promotionSystem.RelegationPlayOffTeamsStart;
            RelegationPlayOffTeamsEnd = promotionSystem.RelegationPlayOffTeamsEnd;
        }

        public PromotionSystem Map()
        {
            return new PromotionSystem
            {
                Season = Season,
                LeagueName = LeagueName,
                PromotedTeamsStart = PromotedTeamsStart,
                PromotedTeamsEnd = PromotedTeamsEnd,
                PromotionPlayOffTeamsStart = PromotionPlayOffTeamsStart,
                PromotionPlayOffTeamsEnd = PromotionPlayOffTeamsEnd,
                RelegatedTeamsStart = RelegatedTeamsStart,
                RelegatedTeamsEnd = RelegatedTeamsEnd,
                RelegationPlayOffTeamsStart = RelegationPlayOffTeamsStart,
                RelegationPlayOffTeamsEnd = RelegationPlayOffTeamsEnd,
            };
        }
    }
}
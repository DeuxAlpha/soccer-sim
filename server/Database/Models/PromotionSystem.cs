namespace Database.Models
{
    public class PromotionSystem
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
        // Potentially more fields for things such as game rules, playoff rules, etc.

        public League League { get; set; }
    }
}
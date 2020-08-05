using System.Collections.Generic;
using System.Linq;
using Database.Models;

namespace API.Dtos.Views.Table
{
    public class TableDto
    {
        public List<TablePositionDto> Positions { get; set; }
        public List<TablePositionDto> HomePositions { get; set; }
        public List<TablePositionDto> AwayPositions { get; set; }
        public List<TablePositionDto> PreviousPositions { get; set; }
        public List<TablePositionDto> PreviousHomePositions { get; set; }
        public List<TablePositionDto> PreviousAwayPositions { get; set; }
        public int PromotedTeamsStart { get; set; }
        public int PromotedTeamsEnd { get; set; }
        public int PromotionPlayOffTeamsStart { get; set; }
        public int PromotionPlayOffTeamsEnd { get; set; }
        public int RelegatedTeamsStart { get; set; }
        public int RelegatedTeamsEnd { get; set; }
        public int RelegationPlayOffTeamsStart { get; set; }
        public int RelegationPlayOffTeamsEnd { get; set; }

        public TableDto(League league)
        {
            // Need to be done thrice because each need to be different tables.
            Positions = league.Teams.Select(team => new TablePositionDto
            {
                TeamName = team.Name
            }).ToList();
            HomePositions = league.Teams.Select(team => new TablePositionDto
            {
                TeamName = team.Name
            }).ToList();
            AwayPositions = league.Teams.Select(team => new TablePositionDto
            {
                TeamName = team.Name
            }).ToList();
            PreviousPositions = league.Teams.Select(team => new TablePositionDto
            {
                TeamName = team.Name
            }).ToList();
            PreviousHomePositions = league.Teams.Select(team => new TablePositionDto
            {
                TeamName = team.Name
            }).ToList();
            PreviousAwayPositions = league.Teams.Select(team => new TablePositionDto
            {
                TeamName = team.Name
            }).ToList();
            PromotedTeamsStart = league.PromotionSystem?.PromotedTeamsStart ?? 0;
            PromotedTeamsEnd = league.PromotionSystem?.PromotedTeamsEnd ?? 0;
            PromotionPlayOffTeamsStart = league.PromotionSystem?.PromotionPlayOffTeamsStart ?? 0;
            PromotionPlayOffTeamsEnd = league.PromotionSystem?.PromotionPlayOffTeamsEnd ?? 0;
            RelegatedTeamsStart = league.PromotionSystem?.RelegatedTeamsStart ?? 0;
            RelegatedTeamsEnd = league.PromotionSystem?.RelegatedTeamsEnd ?? 0;
            RelegationPlayOffTeamsStart = league.PromotionSystem?.RelegationPlayOffTeamsStart ?? 0;
            RelegationPlayOffTeamsEnd = league.PromotionSystem?.RelegationPlayOffTeamsEnd ?? 0;
        }

        public void AddFixture(ResultDto result)
        {
            var firstPosition = Positions.First(p => p.TeamName == result.HomeTeamName);
            var secondPosition = Positions.First(p => p.TeamName == result.AwayTeamName);
            var homePosition = HomePositions.First(p => p.TeamName == result.HomeTeamName);
            var awayPosition = AwayPositions.First(p => p.TeamName == result.AwayTeamName);
            PreviousPositions[PreviousPositions.FindIndex(p => p.TeamName == firstPosition.TeamName)] =
                firstPosition.Clone();
            PreviousPositions[PreviousPositions.FindIndex(p => p.TeamName == secondPosition.TeamName)] =
                secondPosition.Clone();
            PreviousHomePositions[PreviousHomePositions.FindIndex(p => p.TeamName == homePosition.TeamName)] =
                homePosition.Clone();
            PreviousAwayPositions[PreviousAwayPositions.FindIndex(p => p.TeamName == awayPosition.TeamName)] =
                awayPosition.Clone();
            if (result.HomeGoals == result.AwayGoals)
            {
                firstPosition.Draws++;
                secondPosition.Draws++;
                homePosition.Draws++;
                awayPosition.Draws++;
            }
            else if (result.HomeGoals > result.AwayGoals)
            {
                firstPosition.Wins++;
                secondPosition.Losses++;
                homePosition.Wins++;
                awayPosition.Losses++;
            }
            else
            {
                firstPosition.Losses++;
                secondPosition.Wins++;
                homePosition.Losses++;
                awayPosition.Wins++;
            }

            firstPosition.GoalsFor += result.HomeGoals;
            firstPosition.GoalsAgainst += result.AwayGoals;
            firstPosition.Shots += result.HomeShots;
            firstPosition.ShotsOnGoal += result.HomeShotsOnGoal;
            firstPosition.ShotsAgainst += result.AwayShots;
            firstPosition.ShotsAgainstGoal += result.AwayShotsOnGoal;
            secondPosition.GoalsFor += result.AwayGoals;
            secondPosition.GoalsAgainst += result.HomeGoals;
            secondPosition.Shots += result.AwayShots;
            secondPosition.ShotsOnGoal += result.AwayShotsOnGoal;
            secondPosition.ShotsAgainst += result.HomeShots;
            secondPosition.ShotsAgainstGoal += result.HomeShotsOnGoal;
            homePosition.GoalsFor += result.HomeGoals;
            homePosition.GoalsAgainst += result.AwayGoals;
            homePosition.Shots += result.HomeShots;
            homePosition.ShotsOnGoal += result.HomeShotsOnGoal;
            homePosition.ShotsAgainst += result.AwayShots;
            homePosition.ShotsAgainstGoal += result.AwayShotsOnGoal;
            awayPosition.GoalsFor += result.AwayGoals;
            awayPosition.GoalsAgainst += result.HomeGoals;
            awayPosition.Shots += result.AwayShots;
            awayPosition.ShotsOnGoal += result.AwayShotsOnGoal;
            awayPosition.ShotsAgainst += result.HomeShots;
            awayPosition.ShotsAgainstGoal += result.HomeShotsOnGoal;
        }

        public void ApplyPositions()
        {
            StorePosition(Positions);
            StorePosition(HomePositions);
            StorePosition(AwayPositions);
            StorePosition(PreviousPositions);
            StorePosition(PreviousHomePositions);
            StorePosition(PreviousAwayPositions);

            Positions = Positions.OrderBy(p => p.Position).ToList();
            HomePositions = HomePositions.OrderBy(p => p.Position).ToList();
            AwayPositions = AwayPositions.OrderBy(p => p.Position).ToList();
            PreviousPositions = PreviousPositions.OrderBy(p => p.Position).ToList();
            PreviousHomePositions = PreviousHomePositions.OrderBy(p => p.Position).ToList();
            PreviousAwayPositions = PreviousAwayPositions.OrderBy(p => p.Position).ToList();
        }

        private static void StorePosition(IEnumerable<TablePositionDto> positions)
        {
            var currentPosition = 1;
            foreach (var position in positions
                .OrderByDescending(p => p.Points)
                .ThenByDescending(p => p.GoalDifference)
                .ThenByDescending(p => p.GoalsFor)
                .ThenByDescending(p => p.Wins))
            {
                position.Position = currentPosition;
                currentPosition++;
            }
        }
    }
}
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

        public TableDto()
        {
            Positions = new List<TablePositionDto>();
        }

        public void AddFixture(ResultDto result)
        {
            var firstPosition = Positions.First(p => p.TeamName == result.HomeTeamName);
            var secondPosition = Positions.First(p => p.TeamName == result.AwayTeamName);
            var homePosition = HomePositions.First(p => p.TeamName == result.HomeTeamName);
            var awayPosition = AwayPositions.First(p => p.TeamName == result.AwayTeamName);
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
            var currentPosition = 1;
            foreach (var position in Positions
                .OrderByDescending(p => p.Points)
                .ThenByDescending(p => p.GoalDifference)
                .ThenByDescending(p => p.GoalsFor)
                .ThenByDescending(p => p.Wins))
            {
                position.Position = currentPosition;
                currentPosition++;
            }

            currentPosition = 1;
            foreach (var position in HomePositions
                .OrderByDescending(p => p.Points)
                .ThenByDescending(p => p.GoalDifference)
                .ThenByDescending(p => p.GoalsFor)
                .ThenByDescending(p => p.Wins))
            {
                position.Position = currentPosition;
                currentPosition++;
            }

            currentPosition = 1;
            foreach (var position in AwayPositions
                .OrderByDescending(p => p.Points)
                .ThenByDescending(p => p.GoalDifference)
                .ThenByDescending(p => p.GoalsFor)
                .ThenByDescending(p => p.Wins))
            {
                position.Position = currentPosition;
                currentPosition++;
            }

            Positions = Positions.OrderBy(p => p.Position).ToList();
            HomePositions = HomePositions.OrderBy(p => p.Position).ToList();
            AwayPositions = AwayPositions.OrderBy(p => p.Position).ToList();
        }
    }
}
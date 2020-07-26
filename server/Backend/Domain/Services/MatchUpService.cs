using System.Collections.Generic;
using System.Linq;
using Domain.Extensions;
using Domain.Models;

namespace Domain.Services
{
    public static class MatchUpService
    {
        public static IEnumerable<GameDay> CreateRoundRobin(int teams, bool reverseFixtures)
        {
            var overallGameDays = teams % 2 == 0 ? teams - 1 : teams;
            var sideToggle = true;
            var teamIndices = new List<TeamIndex>();
            for (var teamIndex = 0; teamIndex < teams; teamIndex++)
            {
                teamIndices.Add(new TeamIndex
                {
                    Place = teamIndex + 1,
                    TeamId = teamIndex
                });
            }

            var gameDays = new List<GameDay>();
            for (var gameDayIndex = 0; gameDayIndex < overallGameDays; gameDayIndex++)
            {
                var gameDay = new GameDay();
                var firstTeam = -1;
                foreach (var teamIndex in teamIndices.OrderBy(i => i.Place))
                {
                    if (firstTeam == -1)
                        firstTeam = teamIndex.TeamId;
                    else
                    {
                        gameDay.Games.Add(new MatchUp
                        {
                            HomeId = sideToggle && teamIndex.Place == 2 ? firstTeam : teamIndex.TeamId,
                            AwayId = sideToggle && teamIndex.Place == 2 ? teamIndex.TeamId : firstTeam
                        });
                        firstTeam = -1;
                    }
                }

                gameDay.Games = gameDay.Games.Shuffle().ToList();
                gameDays.Add(gameDay);
                sideToggle = !sideToggle;
                Rotate(teamIndices);
            }

            if (!reverseFixtures) return gameDays;
            {
                var reverseGames = new List<GameDay>();
                foreach (var gameDay in gameDays)
                {
                    var reverseGameDay = new GameDay();
                    foreach (var game in gameDay.Games)
                    {
                        reverseGameDay.Games.Add(new MatchUp
                        {
                            HomeId = game.AwayId,
                            AwayId = game.HomeId
                        });
                    }

                    reverseGames.Add(reverseGameDay);
                }

                gameDays.AddRange(reverseGames);
            }
            return gameDays;
        }

        private static void Rotate(IReadOnlyCollection<TeamIndex> teamIndices)
        {
            var maxPlace = teamIndices.Count;
            foreach (var teamIndex in teamIndices.Where(teamIndex => teamIndex.TeamId != 0))
            {
                if (teamIndex.Place == maxPlace) teamIndex.Place = 2;
                else teamIndex.Place++;
            }
        }

        private class TeamIndex
        {
            public int TeamId { get; set; }
            public int Place { get; set; }
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Domain.Extensions;
using Domain.Models;

namespace Domain.Services
{
    public static class MatchUpService
    {
        public static IEnumerable<GameDay<T>> CreateRoundRobin<T>(List<T> participants, bool reverseFixtures)
        {
            var participantCount = participants.Count;
            var overallGameDays = participantCount % 2 == 0 ? participantCount - 1 : participantCount;
            var sideToggle = true;
            var teamIndices = new List<TeamIndex<T>>();
            for (var teamIndex = 0; teamIndex < participantCount; teamIndex++)
            {
                var participant = participants[teamIndex];
                teamIndices.Add(new TeamIndex<T>
                {
                    Place = teamIndex + 1,
                    Team = participant
                });
            }

            var gameDays = new List<GameDay<T>>();
            for (var gameDayIndex = 0; gameDayIndex < overallGameDays; gameDayIndex++)
            {
                var gameDay = new GameDay<T>();
                var firstTeamAssigned = false;
                T firstTeam = default;
                foreach (var teamIndex in teamIndices.OrderBy(i => i.Place))
                {
                    if (firstTeamAssigned == false)
                    {
                        firstTeam = teamIndex.Team;
                        firstTeamAssigned = true;
                    }
                    else
                    {
                        gameDay.Games.Add(new MatchUp<T>
                        {
                            Home = sideToggle && teamIndex.Place == 2 ? firstTeam : teamIndex.Team,
                            Away = sideToggle && teamIndex.Place == 2 ? teamIndex.Team : firstTeam
                        });
                        firstTeamAssigned = false;
                    }
                }

                gameDay.Games = gameDay.Games.Shuffle().ToList();
                gameDays.Add(gameDay);
                sideToggle = !sideToggle;
                Rotate(teamIndices);
            }

            if (!reverseFixtures) return gameDays;
            {
                var reverseGames = new List<GameDay<T>>();
                foreach (var gameDay in gameDays)
                {
                    var reverseGameDay = new GameDay<T>();
                    foreach (var game in gameDay.Games)
                    {
                        reverseGameDay.Games.Add(new MatchUp<T>
                        {
                            Home = game.Away,
                            Away = game.Home
                        });
                    }

                    reverseGames.Add(reverseGameDay);
                }

                gameDays.AddRange(reverseGames);
            }
            return gameDays;
        }

        private static void Rotate<T>(IReadOnlyCollection<TeamIndex<T>> teamIndices)
        {
            var maxPlace = teamIndices.Count;
            foreach (var teamIndex in teamIndices.Where(teamIndex => teamIndex.Place != 1))
            {
                if (teamIndex.Place == maxPlace) teamIndex.Place = 2;
                else teamIndex.Place++;
            }
        }

        private class TeamIndex<T>
        {
            public T Team { get; set; }
            public int Place { get; set; }
        }
    }
}
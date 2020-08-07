using System.Collections.Generic;
using System.Linq;
using Domain.Extensions;
using Domain.Models;

namespace Domain.Services
{
    public static class MatchUpService
    {
        public static IEnumerable<GameDay<T>> CreateRoundRobin<T>(List<T> participants, int rounds)
        {
            var participantCount = participants.Count;
            var overallGameDays = participantCount % 2 == 0 ? participantCount - 1 : participantCount;
            var sideToggle = true;
            var places = Enumerable.Range(1, participants.Count).ToList();
            var teamIndices = participants
                .Select(participant => new TeamIndex<T>
                {
                    Place = places.PopRandom(),
                    Team = participant
                }).ToList();

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
                            Home = sideToggle ? firstTeam : teamIndex.Team,
                            Away = sideToggle ? teamIndex.Team : firstTeam
                        });
                        firstTeamAssigned = false;
                    }
                }

                gameDay.Games = gameDay.Games.Shuffle().ToList();
                gameDays.Add(gameDay);
                sideToggle = !sideToggle;
                Rotate(teamIndices, participantCount % 2 == 0);
            }

            var roundsToAdd = new List<GameDay<T>>();

            for (var round = 1; round < rounds; round++)
            {
                var nextRoundGames = new List<GameDay<T>>();
                foreach (var gameDay in gameDays)
                {
                    var nextRoundGameDay = new GameDay<T>();
                    foreach (var game in gameDay.Games)
                    {
                        var switchHome = round % 2 != 0;
                        nextRoundGameDay.Games.Add(new MatchUp<T>
                        {
                            Home = switchHome ? game.Away : game.Home,
                            Away = switchHome ? game.Home : game.Away
                        });
                    }

                    nextRoundGames.Add(nextRoundGameDay);
                }

                roundsToAdd.AddRange(nextRoundGames);
            }

            gameDays.AddRange(roundsToAdd);

            return gameDays;
        }

        private static void Rotate<T>(ICollection<TeamIndex<T>> teamIndices, bool even)
        {
            // round-robin
            var maxPlace = teamIndices.Count;
            foreach (var teamIndex in teamIndices)
            {
                if (teamIndex.Place == 1) continue;
                if (teamIndex.Place % 2 != 0)
                {
                    if (teamIndex.Place + 2 > maxPlace)
                        teamIndex.Place += even ? 1 : -1;
                    else
                        teamIndex.Place += 2;
                }
                else
                {
                    if (teamIndex.Place - 2 <= 0)
                        teamIndex.Place = 3;
                    else
                        teamIndex.Place -= 2;
                }
            }
        }

        private class TeamIndex<T>
        {
            public T Team { get; set; }
            public int Place { get; set; }
        }
    }
}
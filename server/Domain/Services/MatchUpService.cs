using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Extensions;
using Domain.Models;

namespace Domain.Services
{
    public static class MatchUpService
    {
        public static IReadOnlyCollection<GameDay<T>> CreateRoundRobin<T>(List<T> participants, int rounds)
        {
            if (participants == null || participants.Count == 0)
            {
                throw new ArgumentException("Participants list cannot be empty.", nameof(participants));
            }

            if (rounds < 1)
            {
                throw new ArgumentException("Number of rounds must be greater than or equal to 1.", nameof(rounds));
            }

            var participantCount = participants.Count;
            var isOdd = participantCount % 2 != 0;
            var overallGameDays = isOdd ? participantCount - 1 : participantCount;
            var sideToggle = true;
            var places = Enumerable.Range(1, participants.Count).ToList();
            var teamIndices = participants
                .Select(participant => new TeamIndex<T>
                {
                    Place = places.PopRandom(),
                    Team = participant
                }).ToList();

            var gameDays = new List<GameDay<T>>();
            for (var gameDayIndex = 0; gameDayIndex < (isOdd ? overallGameDays : overallGameDays - 1); gameDayIndex++)
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

                gameDay.Games = gameDay.Games
                    .Shuffle()
                    .ToList();
                gameDays.Add(gameDay);
                sideToggle = !sideToggle;
                // Don't rotate on the last round
                if (gameDayIndex < overallGameDays - 1)
                    Rotate(teamIndices, !isOdd);
            }

            if (isOdd)
            {
                RotateLastOddRound(teamIndices);
                FillLastRound(teamIndices, sideToggle, gameDays);
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

        private static void FillLastRound<T>(List<TeamIndex<T>> teamIndices, bool sideToggle, List<GameDay<T>> gameDays)
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
        }

        private static void Rotate<T>(ICollection<TeamIndex<T>> teamIndices, bool even)
        {
            // round-robin
            var maxPlace = teamIndices.Count;

            foreach (var teamIndex in teamIndices)
            {
                if (teamIndex.Place == 1)
                    continue;

                if (teamIndex.Place % 2 != 0)
                {
                    teamIndex.Place = GetUpdatedPlaceForOdd(teamIndex.Place, maxPlace, even);
                }
                else
                {
                    teamIndex.Place = GetUpdatedPlaceForEven(teamIndex.Place, maxPlace);
                }
            }
        }

        private static void RotateLastOddRound<T>(ICollection<TeamIndex<T>> teamIndices)
        {
            var maxPlace = teamIndices.Count;

            foreach (var teamIndex in teamIndices)
            {
                if (teamIndex.Place == 1) teamIndex.Place = maxPlace;
                else if (teamIndex.Place == maxPlace) teamIndex.Place -= 1;
                else if (teamIndex.Place == 2) teamIndex.Place = 1;
                else if (teamIndex.Place % 2 != 0) teamIndex.Place -= 2;
                // Else teamindex place stays put.
            }
        }

        private static int GetUpdatedPlaceForOdd(int currentPlace, int maxPlace, bool even)
        {
            if (currentPlace + 2 > maxPlace)
                return even ? currentPlace + 1 : currentPlace - 1;

            return currentPlace + 2;
        }

        private static int GetUpdatedPlaceForEven(int currentPlace, int maxPlace)
        {
            if (currentPlace - 2 <= 0)
                return 3;

            return currentPlace - 2;
        }

        private class TeamIndex<T>
        {
            public T Team { get; set; }
            public int Place { get; set; }
        }
    }
}
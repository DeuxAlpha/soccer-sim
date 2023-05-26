using System.Globalization;
using Config2;
using CsvHelper;
using CsvHelper.Configuration;
using Database.Contexts;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using Seed.Models;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs\\log.txt", rollingInterval: RollingInterval.Day)
    .ReadFrom.Configuration(StaticConfig.Configuration)
    .CreateLogger();
    
Log.Information("Starting up...");
Log.Information("Soccer Seed v1993-01");

try
{

    // Create the following countries and leagues: England, Premier League, Championship, League One, League Two, etc.
    
    // var context = new SoccerSimContext();
    // var bundesligaFixtures1993 = Get1993Fixtures("1993-1994", "D1");
    // await StoreLeagueInfo1993(context, bundesligaFixtures1993, "1993-1994", "Germany", "Bundesliga", 1);
    //
    // context = new SoccerSimContext();
    // var bundesliga2Fixtures1993 = Get1993Fixtures("1993-1994", "D2");
    // await StoreLeagueInfo1993(context, bundesliga2Fixtures1993, "1993-1994", "Germany", "Bundesliga 2", 2);
    //
    // context = new SoccerSimContext();
    // var englishPremierLeagueFixtures1993 = Get1993Fixtures("1993-1994", "E0");
    // await StoreLeagueInfo1993(context, englishPremierLeagueFixtures1993, "1993-1994", "England", "Premier League", 1);
    //
    // context = new SoccerSimContext();
    // var englishChampionshipFixtures1993 = Get1993Fixtures("1993-1994", "E1");
    // await StoreLeagueInfo1993(context, englishChampionshipFixtures1993, "1993-1994", "England", "Championship", 2);
    //
    // context = new SoccerSimContext();
    // var englishLeagueOneFixtures1993 = Get1993Fixtures("1993-1994", "E2");
    // await StoreLeagueInfo1993(context, englishLeagueOneFixtures1993, "1993-1994", "England", "League One", 3);
    //
    // context = new SoccerSimContext();
    // var englishLeagueTwoFixtures1993 = Get1993Fixtures("1993-1994", "E3");
    // await StoreLeagueInfo1993(context, englishLeagueTwoFixtures1993, "1993-1994", "England", "League Two", 4);
    //
    // context = new SoccerSimContext();
    // var frenchLigue1Fixtures1993 = Get1993Fixtures("1993-1994", "F1");
    // await StoreLeagueInfo1993(context, frenchLigue1Fixtures1993, "1993-1994", "France", "Ligue 1", 1);
    //
    // context = new SoccerSimContext();
    // var italianSerieAFixtures1993 = Get1993Fixtures("1993-1994", "I1");
    // await StoreLeagueInfo1993(context, italianSerieAFixtures1993, "1993-1994", "Italy", "Serie A", 1);
    //
    // context = new SoccerSimContext();
    // var netherlandsEredivisieFixtures1993 = Get1993Fixtures("1993-1994", "N1");
    // await StoreLeagueInfo1993(context, netherlandsEredivisieFixtures1993, "1993-1994", "Netherlands", "Eredivisie", 1);
    //
    // context = new SoccerSimContext();
    // var spanishLaLigaFixtures1993 = Get1993Fixtures("1993-1994", "SP1");
    // await StoreLeagueInfo1993(context, spanishLaLigaFixtures1993, "1993-1994", "Spain", "La Liga", 1);

    // var context = new SoccerSimContext();
    // var germanBundesligaFixtures1994 = GetFixtures("1994-1995", "D1");
    // await StoreLeagueInfo(context, germanBundesligaFixtures1994, "1994-1995", "Germany", "Bundesliga", 1);
    //
    // context = new SoccerSimContext();
    // var germanBundesliga2Fixtures1994 = GetFixtures("1994-1995", "D2");
    // await StoreLeagueInfo(context, germanBundesliga2Fixtures1994, "1994-1995", "Germany", "Bundesliga 2", 2);
    //
    // context = new SoccerSimContext();
    // var englishPremierLeagueFixtures1994 = GetFixtures("1994-1995", "E0");
    // await StoreLeagueInfo(context, englishPremierLeagueFixtures1994, "1994-1995", "England", "Premier League", 1);
    //
    // context = new SoccerSimContext();
    // var englishChampionshipFixtures1994 = GetFixtures("1994-1995", "E1");
    // await StoreLeagueInfo(context, englishChampionshipFixtures1994, "1994-1995", "England", "Championship", 2);
    //
    // context = new SoccerSimContext();
    // var englishLeagueOneFixtures1994 = GetFixtures("1994-1995", "E2");
    // await StoreLeagueInfo(context, englishLeagueOneFixtures1994, "1994-1995", "England", "League One", 3);  
    //
    // context = new SoccerSimContext();
    // var englishLeagueTwoFixtures1994 = GetFixtures("1994-1995", "E3");
    // await StoreLeagueInfo(context, englishLeagueTwoFixtures1994, "1994-1995", "England", "League Two", 4);
    //
    // context = new SoccerSimContext();
    // var frenchLigue1Fixtures1994 = GetFixtures("1994-1995", "F1");
    // await StoreLeagueInfo(context, frenchLigue1Fixtures1994, "1994-1995", "France", "Ligue 1", 1);
    //
    // context = new SoccerSimContext();
    // var greeceSuperLeagueFixtures1994 = GetFixtures("1994-1995", "G1");
    // await StoreLeagueInfo(context, greeceSuperLeagueFixtures1994, "1994-1995", "Greece", "Super League", 1);
    //
    // context = new SoccerSimContext();
    // var italianSerieAFixtures1994 = GetFixtures("1994-1995", "I1");
    // await StoreLeagueInfo(context, italianSerieAFixtures1994, "1994-1995", "Italy", "Serie A", 1);
    //
    // context = new SoccerSimContext();
    // var netherlandsEredivisieFixtures1994 = GetFixtures("1994-1995", "N1");
    // await StoreLeagueInfo(context, netherlandsEredivisieFixtures1994, "1994-1995", "Netherlands", "Eredivisie", 1);
    //
    // context = new SoccerSimContext();
    // var portugalPrimeiraLigaFixtures1994 = GetFixtures("1994-1995", "P1");
    // await StoreLeagueInfo(context, portugalPrimeiraLigaFixtures1994, "1994-1995", "Portugal", "Primeira Liga", 1);
    //
    // context = new SoccerSimContext();
    // var scottishPremiershipFixtures1994 = GetFixtures("1994-1995", "SC0");
    // await StoreLeagueInfo(context, scottishPremiershipFixtures1994, "1994-1995", "Scotland", "Premiership", 1);
    //
    // context = new SoccerSimContext();
    // var scottishChampionshipFixtures1994 = GetFixtures("1994-1995", "SC1");
    // await StoreLeagueInfo(context, scottishChampionshipFixtures1994, "1994-1995", "Scotland", "Championship", 2);
    //
    // context = new SoccerSimContext();
    // var spanishLaLigaFixtures1994 = GetFixtures("1994-1995", "SP1");
    // await StoreLeagueInfo(context, spanishLaLigaFixtures1994, "1994-1995", "Spain", "La Liga", 1);
    //
    // context = new SoccerSimContext();
    // var turkishSuperLigFixtures1994 = GetFixtures("1994-1995", "T1");
    // await StoreLeagueInfo(context, turkishSuperLigFixtures1994, "1994-1995", "Turkey", "Super Lig", 1);
    
    // var context = new SoccerSimContext();
    // var belgiumFirstDivisionAFixtures1995 = GetFixtures("1995-1996", "B1");
    // await StoreLeagueInfo(context, belgiumFirstDivisionAFixtures1995, "1995-1996", "Belgium", "First Division A", 1);
    //
    // context = new SoccerSimContext();
    // var germanBundesligaFixtures1995 = GetFixtures("1995-1996", "D1");
    // await StoreLeagueInfo(context, germanBundesligaFixtures1995, "1995-1996", "Germany", "Bundesliga", 1);
    //
    // context = new SoccerSimContext();
    // var germanBundesliga2Fixtures1995 = GetFixtures("1995-1996", "D2");
    // await StoreLeagueInfo(context, germanBundesliga2Fixtures1995, "1995-1996", "Germany", "Bundesliga 2", 2);
    //
    // context = new SoccerSimContext();
    // var englishPremierLeagueFixtures1995 = GetFixtures("1995-1996", "E0");  
    // await StoreLeagueInfo(context, englishPremierLeagueFixtures1995, "1995-1996", "England", "Premier League", 1);
    //
    // context = new SoccerSimContext();
    // var englishChampionshipFixtures1995 = GetFixtures("1995-1996", "E1");
    // await StoreLeagueInfo(context, englishChampionshipFixtures1995, "1995-1996", "England", "Championship", 2);
    //
    // context = new SoccerSimContext();
    // var englishLeagueOneFixtures1995 = GetFixtures("1995-1996", "E2");
    // await StoreLeagueInfo(context, englishLeagueOneFixtures1995, "1995-1996", "England", "League One", 3);
    //
    // context = new SoccerSimContext();
    // var englishLeagueTwoFixtures1995 = GetFixtures("1995-1996", "E3");
    // await StoreLeagueInfo(context, englishLeagueTwoFixtures1995, "1995-1996", "England", "League Two", 4);
    //
    // context = new SoccerSimContext();
    // var frenchLigue1Fixtures1995 = GetFixtures("1995-1996", "F1");
    // await StoreLeagueInfo(context, frenchLigue1Fixtures1995, "1995-1996", "France", "Ligue 1", 1);
    //
    // context = new SoccerSimContext();
    // var greeceSuperLeagueFixtures1995 = GetFixtures("1995-1996", "G1");
    // await StoreLeagueInfo(context, greeceSuperLeagueFixtures1995, "1995-1996", "Greece", "Super League", 1);
    //
    // context = new SoccerSimContext();
    // var italianSerieAFixtures1995 = GetFixtures("1995-1996", "I1");
    // await StoreLeagueInfo(context, italianSerieAFixtures1995, "1995-1996", "Italy", "Serie A", 1);
    //
    // context = new SoccerSimContext();
    // var netherlandsEredivisieFixtures1995 = GetFixtures("1995-1996", "N1");
    // await StoreLeagueInfo(context, netherlandsEredivisieFixtures1995, "1995-1996", "Netherlands", "Eredivisie", 1);
    //
    // context = new SoccerSimContext();
    // var portugalPrimeiraLigaFixtures1995 = GetFixtures("1995-1996", "P1");
    // await StoreLeagueInfo(context, portugalPrimeiraLigaFixtures1995, "1995-1996", "Portugal", "Primeira Liga", 1);
    //
    // context = new SoccerSimContext();
    // var scottishPremiershipFixtures1995 = GetFixtures("1995-1996", "SC0");
    // await StoreLeagueInfo(context, scottishPremiershipFixtures1995, "1995-1996", "Scotland", "Premiership", 1);
    //
    // context = new SoccerSimContext();
    // var scottishChampionshipFixtures1995 = GetFixtures("1995-1996", "SC1");
    // await StoreLeagueInfo(context, scottishChampionshipFixtures1995, "1995-1996", "Scotland", "Championship", 2);
    //
    // context = new SoccerSimContext();
    // var spanishLaLigaFixtures1995 = GetFixtures("1995-1996", "SP1");
    // await StoreLeagueInfo(context, spanishLaLigaFixtures1995, "1995-1996", "Spain", "La Liga", 1);
    //
    // context = new SoccerSimContext();
    // var turkishSuperLigFixtures1995 = GetFixtures("1995-1996", "T1");
    // await StoreLeagueInfo(context, turkishSuperLigFixtures1995, "1995-1996", "Turkey", "Super Lig", 1);

    // var context = new SoccerSimContext();
    // var belgiumFirstDivisionAFixtures1996 = GetFixtures("1996-1997", "B1");
    // await StoreLeagueInfo(context, belgiumFirstDivisionAFixtures1996, "1996-1997", "Belgium", "First Division A", 1);
    //
    // context = new SoccerSimContext();
    // var germanBundesligaFixtures1996 = GetFixtures("1996-1997", "D1");
    // await StoreLeagueInfo(context, germanBundesligaFixtures1996, "1996-1997", "Germany", "Bundesliga", 1);
    //
    // context = new SoccerSimContext();
    // var germanBundesliga2Fixtures1996 = GetFixtures("1996-1997", "D2");
    // await StoreLeagueInfo(context, germanBundesliga2Fixtures1996, "1996-1997", "Germany", "Bundesliga 2", 2);
    //
    // context = new SoccerSimContext();
    // var englishPremierLeagueFixtures1996 = GetFixtures("1996-1997", "E0");
    // await StoreLeagueInfo(context, englishPremierLeagueFixtures1996, "1996-1997", "England", "Premier League", 1);
    //
    // context = new SoccerSimContext();
    // var englishChampionshipFixtures1996 = GetFixtures("1996-1997", "E1");
    // await StoreLeagueInfo(context, englishChampionshipFixtures1996, "1996-1997", "England", "Championship", 2);
    //
    // context = new SoccerSimContext();
    // var englishLeagueOneFixtures1996 = GetFixtures("1996-1997", "E2");
    // await StoreLeagueInfo(context, englishLeagueOneFixtures1996, "1996-1997", "England", "League One", 3);
    //
    // context = new SoccerSimContext();
    // var englishLeagueTwoFixtures1996 = GetFixtures("1996-1997", "E3");
    // await StoreLeagueInfo(context, englishLeagueTwoFixtures1996, "1996-1997", "England", "League Two", 4);
    //
    // context = new SoccerSimContext();
    // var frenchLigue1Fixtures1996 = GetFixtures("1996-1997", "F1");
    // await StoreLeagueInfo(context, frenchLigue1Fixtures1996, "1996-1997", "France", "Ligue 1", 1);
    //
    // context = new SoccerSimContext();
    // var frenchLigue2Fixtures1996 = GetFixtures("1996-1997", "F2");
    // await StoreLeagueInfo(context, frenchLigue2Fixtures1996, "1996-1997", "France", "Ligue 2", 2);
    //
    // context = new SoccerSimContext();
    // var greeceSuperLeagueFixtures1996 = GetFixtures("1996-1997", "G1");
    // await StoreLeagueInfo(context, greeceSuperLeagueFixtures1996, "1996-1997", "Greece", "Super League", 1);
    //
    // context = new SoccerSimContext();
    // var italianSerieAFixtures1996 = GetFixtures("1996-1997", "I1");
    // await StoreLeagueInfo(context, italianSerieAFixtures1996, "1996-1997", "Italy", "Serie A", 1);
    //
    // context = new SoccerSimContext();
    // var netherlandsEredivisieFixtures1996 = GetFixtures("1996-1997", "N1");
    // await StoreLeagueInfo(context, netherlandsEredivisieFixtures1996, "1996-1997", "Netherlands", "Eredivisie", 1);
    //
    // context = new SoccerSimContext();
    // var portugalPrimeiraLigaFixtures1996 = GetFixtures("1996-1997", "P1");
    // await StoreLeagueInfo(context, portugalPrimeiraLigaFixtures1996, "1996-1997", "Portugal", "Primeira Liga", 1);
    //
    // context = new SoccerSimContext();
    // var scottishPremiershipFixtures1996 = GetFixtures("1996-1997", "SC0");
    // await StoreLeagueInfo(context, scottishPremiershipFixtures1996, "1996-1997", "Scotland", "Premiership", 1);
    //
    // context = new SoccerSimContext();
    // var scottishChampionshipFixtures1996 = GetFixtures("1996-1997", "SC1");
    // await StoreLeagueInfo(context, scottishChampionshipFixtures1996, "1996-1997", "Scotland", "Championship", 2);
    //
    // context = new SoccerSimContext();
    // var spanishLaLigaFixtures1996 = GetFixtures("1996-1997", "SP1");
    // await StoreLeagueInfo(context, spanishLaLigaFixtures1996, "1996-1997", "Spain", "La Liga", 1);
    //
    // context = new SoccerSimContext();
    // var spanishSegundaDivisionFixtures1996 = GetFixtures("1996-1997", "SP2");
    // await StoreLeagueInfo(context, spanishSegundaDivisionFixtures1996, "1996-1997", "Spain", "Segunda Division", 2);
    //
    // context = new SoccerSimContext();
    // var turkishSuperLigFixtures1996 = GetFixtures("1996-1997", "T1");
    // await StoreLeagueInfo(context, turkishSuperLigFixtures1996, "1996-1997", "Turkey", "Super Lig", 1);

}
catch (Exception exception)
{
    Log.Error("Unhandled exception: {Exception}", exception);
}

Log.Information("Shutting down...");
Log.CloseAndFlush();

async Task<Continent?> GetYearContinent(SoccerSimContext context, string season)
{
    var result = await context.Continents.FirstOrDefaultAsync(c => c.Season == season);
    return result;
}

List<OnwardBaseFixture1993> GetFixtures(string season, string division)
{
    var file = new FileInfo($"{season}/{division}.csv");
    var onwardBaseFixture1993S = new List<OnwardBaseFixture1993>();
    Log.Information("Reading file {File}", file);
    using var reader = new StreamReader(file.FullName);
    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
        HasHeaderRecord = true,
        MissingFieldFound = null,
        HeaderValidated = null,
        BadDataFound = null,
    };
    using var csv = new CsvReader(reader, csvConfig);
    var records = csv.GetRecords<OnwardBaseFixture1993>();
    onwardBaseFixture1993S.AddRange(records);

    return onwardBaseFixture1993S;
}

async Task StoreLeagueInfo(SoccerSimContext soccerSimContext, List<OnwardBaseFixture1993> fixtures, string season, string country, string div, int lvl)
{
    var continent = await soccerSimContext.Continents.FirstOrDefaultAsync(c => c.Season == season);
    if (continent == null)
    {
        var newContinent = await soccerSimContext.Continents.AddAsync(new Continent
        {
            Season = season,
            Name = "Europe",
        });
        await soccerSimContext.SaveChangesAsync();
        continent = newContinent.Entity;
    }

    var existingCountry = await soccerSimContext.Countries.FirstOrDefaultAsync(c => c.Name == country && c.Season == season);
    if (existingCountry == null)
    {
        var newCountry = await soccerSimContext.Countries.AddAsync(new Country
        {
            Season = season,
            Name = country,
            ContinentName = continent.Name,
            Abbreviation = country[..3],
            AttackStrength = 750,
            DefenseStrength = 800,
            GoalieStrength = 775,
            PotentialNegativeChance = 0.1,
            PotentialPositiveChance = 0.1,
            PotentialPositiveShift = 10,
            PotentialNegativeShift = 10,
            ShotOnGoalRate = 0.4,
            MaxPace = 40,
            Image = ""
        });
        await soccerSimContext.SaveChangesAsync();
        existingCountry = newCountry.Entity;
    }
    
    var existingDivision = await soccerSimContext.Divisions.FirstOrDefaultAsync(d => d.Name == div && d.Season == season);
    if (existingDivision == null)
    {
        var division = await soccerSimContext.Divisions.AddAsync(new Division
        {
            Abbreviation = div[..3],
            Name = div,
            Season = season,
            CountryName = existingCountry.Name,
            Level = lvl,
            OnlyFirstTeams = true
        });
        await soccerSimContext.SaveChangesAsync();
        existingDivision = division.Entity;
    }
    
    var existingLeague = await soccerSimContext.Leagues.FirstOrDefaultAsync(l => l.Name == div && l.Season == season);
    if (existingLeague == null)
    {
        var newLeague = await soccerSimContext.Leagues.AddAsync(new League
        {
            Abbreviation = div[..3],
            Name = div,
            Season = season,
            DivisionName = existingDivision.Name,
            Image = "",
            Rounds = 2,
            PaceModifier = 1,
            ActionsPerMinute = 5,
            MaxAwayDisadvantage = 50,
            MaxHomeAdvantage = 50,
            MaxProgressChance = 0.8,
            MinProgressChance = 0.2,
            ShotAccuracyModifier = 1
        });
        await soccerSimContext.SaveChangesAsync();
        existingLeague = newLeague.Entity;
    }
    
    var teams = fixtures.Select(x => x.HomeTeam).Distinct().Where(t => !string.IsNullOrWhiteSpace(t)).ToList();
    var leagueTeams = new List<Team>();
    foreach (var team in teams)
    {
        try
        {
            var newTeam = await soccerSimContext.Teams.AddAsync(new Team
            {
                Season = season,
                Name = team,
                Abbreviation = team[..3],
                LeagueName = existingLeague.Name,
                AttackStrength = 750,
                DefenseStrength = 800,
                GoalieStrength = 775,
                PotentialNegativeChance = 0.1,
                PotentialPositiveChance = 0.1,
                PotentialPositiveShift = 10,
                PotentialNegativeShift = 10,
                ShotOnGoalRate = 0.4,
                MaxPace = 40,
                Image = ""
            });
            await soccerSimContext.SaveChangesAsync();
            leagueTeams.Add(newTeam.Entity);
        }
        catch (Exception ex)
        {
            Log.Error("Error adding team {Team}: {Exception}", team, ex);
        }
    }

    Log.Information("Cleaning up fixtures for {League}", existingLeague.Name);
    // Clean up context
    soccerSimContext = new SoccerSimContext();
    var existingFixtures = await soccerSimContext.LeagueGameDays.Where(f => f.LeagueName == existingLeague.Name && f.Season == season).ToListAsync();
    soccerSimContext.LeagueGameDays.RemoveRange(existingFixtures);
    await soccerSimContext.SaveChangesAsync();
    
    Log.Information("Adding fixtures for {League}", existingLeague.Name);
    var onwardBaseFixturesByDate = fixtures.GroupBy(f => f.Date);
    var fixtureGameDay = 1;
    foreach (var gameDay in onwardBaseFixturesByDate)
    {
        await soccerSimContext.LeagueGameDays.AddAsync(new LeagueGameDay
        {
            LeagueName = existingLeague.Name,
            GameDayNumber = fixtureGameDay,
            Season = season
        });
        foreach (var fixture in gameDay)
        {
            try
            {
                try
                {
                    await soccerSimContext.LeagueFixtures.AddAsync(new LeagueFixture
                    {
                        Season = season,
                        LeagueName = existingLeague.Name,
                        HomeTeamName = fixture.HomeTeam,
                        AwayTeamName = fixture.AwayTeam,
                        GameDayNumber = fixtureGameDay,
                    });
                    await soccerSimContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Log.Error("Error adding fixture {HomeTeam} vs {AwayTeam}: {Exception}", fixture.HomeTeam, fixture.AwayTeam, ex);
                }
                
                for (var homeGoals = 0; homeGoals < fixture.HTHG; homeGoals++)
                {
                    await soccerSimContext.LeagueFixtureEvents.AddAsync(new LeagueFixtureEvent
                    {
                        Season = season,
                        LeagueName = existingLeague.Name,
                        HomeTeamName = fixture.HomeTeam,
                        AwayTeamName = fixture.AwayTeam,
                        GameDayNumber = fixtureGameDay,
                        EventTeamName = fixture.HomeTeam,
                        AddedMinute = 0,
                        Minute = homeGoals + 1,
                        IsGoal = true
                    });
                }

                for (var awayGoals = 0; awayGoals < fixture.HTAG; awayGoals++)
                {
                    await soccerSimContext.LeagueFixtureEvents.AddAsync(new LeagueFixtureEvent
                    {
                        Season = season,
                        LeagueName = existingLeague.Name,
                        HomeTeamName = fixture.HomeTeam,
                        AwayTeamName = fixture.AwayTeam,
                        GameDayNumber = fixtureGameDay,
                        EventTeamName = fixture.AwayTeam,
                        Minute = 25 + awayGoals + 1,
                        AddedMinute = 0,
                        IsGoal = true
                    });
                }

                for (var homeGoals = fixture.HTHG; homeGoals < fixture.FTHG; homeGoals++)
                {
                    await soccerSimContext.LeagueFixtureEvents.AddAsync(new LeagueFixtureEvent
                    {
                        Season = season,
                        LeagueName = existingLeague.Name,
                        HomeTeamName = fixture.HomeTeam,
                        AwayTeamName = fixture.AwayTeam,
                        GameDayNumber = fixtureGameDay,
                        EventTeamName = fixture.HomeTeam,
                        AddedMinute = 0,
                        Minute = 45 + homeGoals + 1,
                        IsGoal = true
                    });
                }
                
                for (var awayGoals = fixture.HTAG; awayGoals < fixture.FTAG; awayGoals++)
                {
                    await soccerSimContext.LeagueFixtureEvents.AddAsync(new LeagueFixtureEvent
                    {
                        Season = season,
                        LeagueName = existingLeague.Name,
                        HomeTeamName = fixture.HomeTeam,
                        AwayTeamName = fixture.AwayTeam,
                        GameDayNumber = fixtureGameDay,
                        EventTeamName = fixture.AwayTeam,
                        Minute = 45 + 25 + awayGoals + 1,
                        AddedMinute = 0,
                        IsGoal = true
                    });
                }

                await soccerSimContext.SaveChangesAsync();
                // Clean up context
                soccerSimContext = new SoccerSimContext();
            }
            catch (Exception exception)
            {
                Log.Error("Error adding fixture {HomeTeam} vs {AwayTeam}: {Exception}", fixture.HomeTeam, fixture.AwayTeam, exception);
            }
            
        }
        Log.Information("Added fixtures for {League} game day {GameDay}", existingLeague.Name, fixtureGameDay);
        fixtureGameDay++;
    }
}
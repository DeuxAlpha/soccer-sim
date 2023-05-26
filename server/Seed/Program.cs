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
    #region 1993

    
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
    #endregion

    #region 1994

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

    #endregion

    #region 1995

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

    #endregion

    #region 1996

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

    #endregion

    #region 1997

    var context = new SoccerSimContext();
    var belgiumJupilerLeagueFixtures1997 = GetFixtures("1997-1998", "B1");
    await StoreLeagueInfo(context, belgiumJupilerLeagueFixtures1997, "1997-1998", "Belgium", "Jupiler League", 1);
    
    context = new SoccerSimContext();
    var germanBundesligaFixtures1997 = GetFixtures("1997-1998", "D1");
    await StoreLeagueInfo(context, germanBundesligaFixtures1997, "1997-1998", "Germany", "Bundesliga", 1);
    
    context = new SoccerSimContext();
    var german2BundesligaFixtures1997 = GetFixtures("1997-1998", "D2");
    await StoreLeagueInfo(context, german2BundesligaFixtures1997, "1997-1998", "Germany", "2. Bundesliga", 2);
    
    context = new SoccerSimContext();
    var englishPremierLeagueFixtures1997 = GetFixtures("1997-1998", "E0");
    await StoreLeagueInfo(context, englishPremierLeagueFixtures1997, "1997-1998", "England", "Premier League", 1);
    
    context = new SoccerSimContext();
    var englishChampionshipFixtures1997 = GetFixtures("1997-1998", "E1");
    await StoreLeagueInfo(context, englishChampionshipFixtures1997, "1997-1998", "England", "Championship", 2);
    
    context = new SoccerSimContext();
    var englishLeagueOneFixtures1997 = GetFixtures("1997-1998", "E2");
    await StoreLeagueInfo(context, englishLeagueOneFixtures1997, "1997-1998", "England", "League One", 3);
    
    context = new SoccerSimContext();
    var englishLeagueTwoFixtures1997 = GetFixtures("1997-1998", "E3");
    await StoreLeagueInfo(context, englishLeagueTwoFixtures1997, "1997-1998", "England", "League Two", 4);
    
    context = new SoccerSimContext();
    var frenchLigue1Fixtures1997 = GetFixtures("1997-1998", "F1");
    await StoreLeagueInfo(context, frenchLigue1Fixtures1997, "1997-1998", "France", "Ligue 1", 1);
    
    context = new SoccerSimContext();
    var frenchLigue2Fixtures1997 = GetFixtures("1997-1998", "F2");
    await StoreLeagueInfo(context, frenchLigue2Fixtures1997, "1997-1998", "France", "Ligue 2", 2);
    
    context = new SoccerSimContext();
    var greekSuperLeagueFixtures1997 = GetFixtures("1997-1998", "G1");
    await StoreLeagueInfo(context, greekSuperLeagueFixtures1997, "1997-1998", "Greece", "Super League", 1);
    
    context = new SoccerSimContext();
    var italianSerieAFixtures1997 = GetFixtures("1997-1998", "I1");
    await StoreLeagueInfo(context, italianSerieAFixtures1997, "1997-1998", "Italy", "Serie A", 1);
    
    context = new SoccerSimContext();
    var italianSerieBFixtures1997 = GetFixtures("1997-1998", "I2");
    await StoreLeagueInfo(context, italianSerieBFixtures1997, "1997-1998", "Italy", "Serie B", 2);
    
    context = new SoccerSimContext();
    var dutchEredivisieFixtures1997 = GetFixtures("1997-1998", "N1");
    await StoreLeagueInfo(context, dutchEredivisieFixtures1997, "1997-1998", "Netherlands", "Eredivisie", 1);
    
    context = new SoccerSimContext();
    var portuguesePrimeiraLigaFixtures1997 = GetFixtures("1997-1998", "P1");
    await StoreLeagueInfo(context, portuguesePrimeiraLigaFixtures1997, "1997-1998", "Portugal", "Primeira Liga", 1);
    
    context = new SoccerSimContext();
    var scottishPremiershipFixtures1997 = GetFixtures("1997-1998", "SC0");
    await StoreLeagueInfo(context, scottishPremiershipFixtures1997, "1997-1998", "Scotland", "Premiership", 1);
    
    context = new SoccerSimContext();
    var scottishChampionshipFixtures1997 = GetFixtures("1997-1998", "SC1");
    await StoreLeagueInfo(context, scottishChampionshipFixtures1997, "1997-1998", "Scotland", "Championship", 2);
    
    context = new SoccerSimContext();
    var scottishLeagueOneFixtures1997 = GetFixtures("1997-1998", "SC2");
    await StoreLeagueInfo(context, scottishLeagueOneFixtures1997, "1997-1998", "Scotland", "League One", 3);
    
    context = new SoccerSimContext();
    var scottishLeagueTwoFixtures1997 = GetFixtures("1997-1998", "SC3");
    await StoreLeagueInfo(context, scottishLeagueTwoFixtures1997, "1997-1998", "Scotland", "League Two", 4);
    
    context = new SoccerSimContext();
    var spanishLaLigaFixtures1997 = GetFixtures("1997-1998", "SP1");
    await StoreLeagueInfo(context, spanishLaLigaFixtures1997, "1997-1998", "Spain", "La Liga", 1);
    
    context = new SoccerSimContext();
    var spanishSegundaDivisionFixtures1997 = GetFixtures("1997-1998", "SP2");
    await StoreLeagueInfo(context, spanishSegundaDivisionFixtures1997, "1997-1998", "Spain", "Segunda Division", 2);
    
    context = new SoccerSimContext();
    var turkishSuperLigFixtures1997 = GetFixtures("1997-1998", "T1");
    await StoreLeagueInfo(context, turkishSuperLigFixtures1997, "1997-1998", "Turkey", "Super Lig", 1);

    #endregion

    #region 1998

    context = new SoccerSimContext();
    var belgianFirstDivisionFixtures1998 = GetFixtures("1998-1999", "B1");
    await StoreLeagueInfo(context, belgianFirstDivisionFixtures1998, "1998-1999", "Belgium", "First Division", 1);
    
    context = new SoccerSimContext();
    var germanBundesligaFixtures1998 = GetFixtures("1998-1999", "D1");
    await StoreLeagueInfo(context, germanBundesligaFixtures1998, "1998-1999", "Germany", "Bundesliga", 1);
    
    context = new SoccerSimContext();
    var german2BundesligaFixtures1998 = GetFixtures("1998-1999", "D2");
    await StoreLeagueInfo(context, german2BundesligaFixtures1998, "1998-1999", "Germany", "2. Bundesliga", 2);
    
    context = new SoccerSimContext();
    var englishPremierLeagueFixtures1998 = GetFixtures("1998-1999", "E0");
    await StoreLeagueInfo(context, englishPremierLeagueFixtures1998, "1998-1999", "England", "Premier League", 1);
    
    context = new SoccerSimContext();
    var englishChampionshipFixtures1998 = GetFixtures("1998-1999", "E1");
    await StoreLeagueInfo(context, englishChampionshipFixtures1998, "1998-1999", "England", "Championship", 2);
    
    context = new SoccerSimContext();
    var englishLeagueOneFixtures1998 = GetFixtures("1998-1999", "E2");
    await StoreLeagueInfo(context, englishLeagueOneFixtures1998, "1998-1999", "England", "League One", 3);
    
    context = new SoccerSimContext();
    var englishLeagueTwoFixtures1998 = GetFixtures("1998-1999", "E3");
    await StoreLeagueInfo(context, englishLeagueTwoFixtures1998, "1998-1999", "England", "League Two", 4);
    
    context = new SoccerSimContext();
    var frenchLigue1Fixtures1998 = GetFixtures("1998-1999", "F1");
    await StoreLeagueInfo(context, frenchLigue1Fixtures1998, "1998-1999", "France", "Ligue 1", 1);
    
    context = new SoccerSimContext();
    var frenchLigue2Fixtures1998 = GetFixtures("1998-1999", "F2");
    await StoreLeagueInfo(context, frenchLigue2Fixtures1998, "1998-1999", "France", "Ligue 2", 2);
    
    context = new SoccerSimContext();
    var greekSuperLeagueFixtures1998 = GetFixtures("1998-1999", "G1");
    await StoreLeagueInfo(context, greekSuperLeagueFixtures1998, "1998-1999", "Greece", "Super League", 1);
    
    context = new SoccerSimContext();
    var italianSerieAFixtures1998 = GetFixtures("1998-1999", "I1");
    await StoreLeagueInfo(context, italianSerieAFixtures1998, "1998-1999", "Italy", "Serie A", 1);

    context = new SoccerSimContext();
    var italianSerieBFixtures1998 = GetFixtures("1998-1999", "I2");
    await StoreLeagueInfo(context, italianSerieBFixtures1998, "1998-1999", "Italy", "Serie B", 2);
    
    context = new SoccerSimContext();
    var dutchEredivisieFixtures1998 = GetFixtures("1998-1999", "N1");
    await StoreLeagueInfo(context, dutchEredivisieFixtures1998, "1998-1999", "Netherlands", "Eredivisie", 1);
    
    context = new SoccerSimContext();
    var portuguesePrimeiraLigaFixtures1998 = GetFixtures("1998-1999", "P1");
    await StoreLeagueInfo(context, portuguesePrimeiraLigaFixtures1998, "1998-1999", "Portugal", "Primeira Liga", 1);
    
    context = new SoccerSimContext();
    var scottishPremiershipFixtures1998 = GetFixtures("1998-1999", "SC0");
    await StoreLeagueInfo(context, scottishPremiershipFixtures1998, "1998-1999", "Scotland", "Premiership", 1);
    
    context = new SoccerSimContext();
    var scottishChampionshipFixtures1998 = GetFixtures("1998-1999", "SC1");
    await StoreLeagueInfo(context, scottishChampionshipFixtures1998, "1998-1999", "Scotland", "Championship", 2);
    
    context = new SoccerSimContext();
    var scottishLeagueOneFixtures1998 = GetFixtures("1998-1999", "SC2");
    await StoreLeagueInfo(context, scottishLeagueOneFixtures1998, "1998-1999", "Scotland", "League One", 3);
    
    context = new SoccerSimContext();
    var scottishLeagueTwoFixtures1998 = GetFixtures("1998-1999", "SC3");
    await StoreLeagueInfo(context, scottishLeagueTwoFixtures1998, "1998-1999", "Scotland", "League Two", 4);
    
    context = new SoccerSimContext();
    var spanishLaLigaFixtures1998 = GetFixtures("1998-1999", "SP1");
    await StoreLeagueInfo(context, spanishLaLigaFixtures1998, "1998-1999", "Spain", "La Liga", 1);
    
    context = new SoccerSimContext();
    var spanishSegundaFixtures1998 = GetFixtures("1998-1999", "SP2");
    await StoreLeagueInfo(context, spanishSegundaFixtures1998, "1998-1999", "Spain", "Segunda", 2);
    
    context = new SoccerSimContext();
    var turkishSuperLigFixtures1998 = GetFixtures("1998-1999", "T1");
    await StoreLeagueInfo(context, turkishSuperLigFixtures1998, "1998-1999", "Turkey", "Super Lig", 1);

    #endregion


    #region 1999
    
    context = new SoccerSimContext();
    var belgianFirstDivisionFixtures1999 = GetFixtures("1999-2000", "B1");
    await StoreLeagueInfo(context, belgianFirstDivisionFixtures1999, "1999-2000", "Belgium", "First Division", 1);
    
    context = new SoccerSimContext();
    var germanBundesligaFixtures1999 = GetFixtures("1999-2000", "D1");
    await StoreLeagueInfo(context, germanBundesligaFixtures1999, "1999-2000", "Germany", "Bundesliga", 1);
    
    context = new SoccerSimContext();
    var german2BundesligaFixtures1999 = GetFixtures("1999-2000", "D2");
    await StoreLeagueInfo(context, german2BundesligaFixtures1999, "1999-2000", "Germany", "2. Bundesliga", 2);
    
    context = new SoccerSimContext();
    var englishPremierLeagueFixtures1999 = GetFixtures("1999-2000", "E0");
    await StoreLeagueInfo(context, englishPremierLeagueFixtures1999, "1999-2000", "England", "Premier League", 1);
    
    context = new SoccerSimContext();
    var englishChampionshipFixtures1999 = GetFixtures("1999-2000", "E1");
    await StoreLeagueInfo(context, englishChampionshipFixtures1999, "1999-2000", "England", "Championship", 2);
    
    context = new SoccerSimContext();
    var englishLeagueOneFixtures1999 = GetFixtures("1999-2000", "E2");
    await StoreLeagueInfo(context, englishLeagueOneFixtures1999, "1999-2000", "England", "League One", 3);
    
    context = new SoccerSimContext();
    var englishLeagueTwoFixtures1999 = GetFixtures("1999-2000", "E3");
    await StoreLeagueInfo(context, englishLeagueTwoFixtures1999, "1999-2000", "England", "League Two", 4);
    
    context = new SoccerSimContext();
    var frenchLigue1Fixtures1999 = GetFixtures("1999-2000", "F1");
    await StoreLeagueInfo(context, frenchLigue1Fixtures1999, "1999-2000", "France", "Ligue 1", 1);
    
    context = new SoccerSimContext();
    var frenchLigue2Fixtures1999 = GetFixtures("1999-2000", "F2");
    await StoreLeagueInfo(context, frenchLigue2Fixtures1999, "1999-2000", "France", "Ligue 2", 2);
    
    context = new SoccerSimContext();
    var greekSuperLeagueFixtures1999 = GetFixtures("1999-2000", "G1");
    await StoreLeagueInfo(context, greekSuperLeagueFixtures1999, "1999-2000", "Greece", "Super League", 1);
    
    context = new SoccerSimContext();
    var italianSerieAFixtures1999 = GetFixtures("1999-2000", "I1");
    await StoreLeagueInfo(context, italianSerieAFixtures1999, "1999-2000", "Italy", "Serie A", 1);
    
    context = new SoccerSimContext();
    var italianSerieBFixtures1999 = GetFixtures("1999-2000", "I2");
    await StoreLeagueInfo(context, italianSerieBFixtures1999, "1999-2000", "Italy", "Serie B", 2);
    
    context = new SoccerSimContext();
    var dutchEredivisieFixtures1999 = GetFixtures("1999-2000", "N1");
    await StoreLeagueInfo(context, dutchEredivisieFixtures1999, "1999-2000", "Netherlands", "Eredivisie", 1);
    
    context = new SoccerSimContext();
    var portugueseLigaFixtures1999 = GetFixtures("1999-2000", "P1");
    await StoreLeagueInfo(context, portugueseLigaFixtures1999, "1999-2000", "Portugal", "Liga", 1);
    
    context = new SoccerSimContext();
    var scottishPremiershipFixtures1999 = GetFixtures("1999-2000", "SC0");
    await StoreLeagueInfo(context, scottishPremiershipFixtures1999, "1999-2000", "Scotland", "Premiership", 1);
    
    context = new SoccerSimContext();
    var scottishChampionshipFixtures1999 = GetFixtures("1999-2000", "SC1");
    await StoreLeagueInfo(context, scottishChampionshipFixtures1999, "1999-2000", "Scotland", "Championship", 2);
    
    context = new SoccerSimContext();
    var scottishLeagueOneFixtures1999 = GetFixtures("1999-2000", "SC2");
    await StoreLeagueInfo(context, scottishLeagueOneFixtures1999, "1999-2000", "Scotland", "League One", 3);
    
    context = new SoccerSimContext();
    var scottishLeagueTwoFixtures1999 = GetFixtures("1999-2000", "SC3");
    await StoreLeagueInfo(context, scottishLeagueTwoFixtures1999, "1999-2000", "Scotland", "League Two", 4);
    
    context = new SoccerSimContext();
    var spanishPrimeraFixtures1999 = GetFixtures("1999-2000", "SP1");
    await StoreLeagueInfo(context, spanishPrimeraFixtures1999, "1999-2000", "Spain", "Primera Division", 1);
    
    context = new SoccerSimContext();
    var spanishSegundaFixtures1999 = GetFixtures("1999-2000", "SP2");
    await StoreLeagueInfo(context, spanishSegundaFixtures1999, "1999-2000", "Spain", "Segunda Division", 2);
    
    context = new SoccerSimContext();
    var turkishSuperLigFixtures1999 = GetFixtures("1999-2000", "T1");
    await StoreLeagueInfo(context, turkishSuperLigFixtures1999, "1999-2000", "Turkey", "Super Lig", 1);

    #endregion

    #region 2000

    context = new SoccerSimContext();
    var belgianFirstDivisionFixtures2000 = GetFixtures("2000-2001", "B1");
    await StoreLeagueInfo(context, belgianFirstDivisionFixtures2000, "2000-2001", "Belgium", "First Division", 1);
    
    context = new SoccerSimContext();
    var germanBundesligaFixtures2000 = GetFixtures("2000-2001", "D1");
    await StoreLeagueInfo(context, germanBundesligaFixtures2000, "2000-2001", "Germany", "Bundesliga", 1);
    
    context = new SoccerSimContext();
    var german2BundesligaFixtures2000 = GetFixtures("2000-2001", "D2");
    await StoreLeagueInfo(context, german2BundesligaFixtures2000, "2000-2001", "Germany", "2. Bundesliga", 2);
    
    context = new SoccerSimContext();
    var englishPremierLeagueFixtures2000 = GetFixtures("2000-2001", "E0");
    await StoreLeagueInfo(context, englishPremierLeagueFixtures2000, "2000-2001", "England", "Premier League", 1);
    
    context = new SoccerSimContext();
    var englishChampionshipFixtures2000 = GetFixtures("2000-2001", "E1");
    await StoreLeagueInfo(context, englishChampionshipFixtures2000, "2000-2001", "England", "Championship", 2);
    
    context = new SoccerSimContext();
    var englishLeagueOneFixtures2000 = GetFixtures("2000-2001", "E2");
    await StoreLeagueInfo(context, englishLeagueOneFixtures2000, "2000-2001", "England", "League One", 3);
    
    context = new SoccerSimContext();
    var englishLeagueTwoFixtures2000 = GetFixtures("2000-2001", "E3");
    await StoreLeagueInfo(context, englishLeagueTwoFixtures2000, "2000-2001", "England", "League Two", 4);
    
    // context = new SoccerSimContext();
    // var englishConferenceFixtures2000 = GetFixtures("2000-2001", "EC");
    // await StoreLeagueInfo(context, englishConferenceFixtures2000, "2000-2001", "England", "Conference", 5);
    
    context = new SoccerSimContext();
    var frenchLigue1Fixtures2000 = GetFixtures("2000-2001", "F1");
    await StoreLeagueInfo(context, frenchLigue1Fixtures2000, "2000-2001", "France", "Ligue 1", 1);
    
    context = new SoccerSimContext();
    var frenchLigue2Fixtures2000 = GetFixtures("2000-2001", "F2");
    await StoreLeagueInfo(context, frenchLigue2Fixtures2000, "2000-2001", "France", "Ligue 2", 2);
    
    context = new SoccerSimContext();
    var greecesuperLeagueFixtures2000 = GetFixtures("2000-2001", "G1");
    await StoreLeagueInfo(context, greecesuperLeagueFixtures2000, "2000-2001", "Greece", "Super League", 1);
    
    context = new SoccerSimContext();
    var italianserieAFixtures2000 = GetFixtures("2000-2001", "I1");
    await StoreLeagueInfo(context, italianserieAFixtures2000, "2000-2001", "Italy", "Serie A", 1);
    
    context = new SoccerSimContext();
    var italianserieBFixtures2000 = GetFixtures("2000-2001", "I2");
    await StoreLeagueInfo(context, italianserieBFixtures2000, "2000-2001", "Italy", "Serie B", 2);
    
    context = new SoccerSimContext();
    var dutchEredivisieFixtures2000 = GetFixtures("2000-2001", "N1");
    await StoreLeagueInfo(context, dutchEredivisieFixtures2000, "2000-2001", "Netherlands", "Eredivisie", 1);
    
    context = new SoccerSimContext();
    var portugueseLigaFixtures2000 = GetFixtures("2000-2001", "P1");
    await StoreLeagueInfo(context, portugueseLigaFixtures2000, "2000-2001", "Portugal", "Liga", 1);
    
    context = new SoccerSimContext();
    var scottishPremiership = GetFixtures("2000-2001", "SC0");
    await StoreLeagueInfo(context, scottishPremiership, "2000-2001", "Scotland", "Premier", 1);
    
    context = new SoccerSimContext();
    var scottishChampionship = GetFixtures("2000-2001", "SC1");
    await StoreLeagueInfo(context, scottishChampionship, "2000-2001", "Scotland", "Championship", 2);
    
    context = new SoccerSimContext();
    var scottishLeagueOne = GetFixtures("2000-2001", "SC2");
    await StoreLeagueInfo(context, scottishLeagueOne, "2000-2001", "Scotland", "League One", 3);
    
    context = new SoccerSimContext();
    var scottishLeagueTwo = GetFixtures("2000-2001", "SC3");
    await StoreLeagueInfo(context, scottishLeagueTwo, "2000-2001", "Scotland", "League Two", 4);
    
    context = new SoccerSimContext();
    var spanishPrimeraDivision = GetFixtures("2000-2001", "SP1");
    await StoreLeagueInfo(context, spanishPrimeraDivision, "2000-2001", "Spain", "Primera Division", 1);
    
    context = new SoccerSimContext();
    var spanishSegundaDivision = GetFixtures("2000-2001", "SP2");
    await StoreLeagueInfo(context, spanishSegundaDivision, "2000-2001", "Spain", "Segunda Division", 2);
    
    context = new SoccerSimContext();
    var turkishSuperLig = GetFixtures("2000-2001", "T1");
    await StoreLeagueInfo(context, turkishSuperLig, "2000-2001", "Turkey", "Super Lig", 1);

    #endregion

    #region 2001

    context = new SoccerSimContext();
    var belgianFirstDivision = GetFixtures("2001-2002", "B1");
    await StoreLeagueInfo(context, belgianFirstDivision, "2001-2002", "Belgium", "First Division", 1);

    context = new SoccerSimContext();
    var germanBundesliga = GetFixtures("2001-2002", "D1");
    await StoreLeagueInfo(context, germanBundesliga, "2001-2002", "Germany", "Bundesliga", 1);
    
    context = new SoccerSimContext();
    var german2Bundesliga = GetFixtures("2001-2002", "D2");
    await StoreLeagueInfo(context, german2Bundesliga, "2001-2002", "Germany", "2. Bundesliga", 2);
    
    context = new SoccerSimContext();
    var englishPremierLeague = GetFixtures("2001-2002", "E0");
    await StoreLeagueInfo(context, englishPremierLeague, "2001-2002", "England", "Premier League", 1);
    
    context = new SoccerSimContext();
    var englishChampionship = GetFixtures("2001-2002", "E1");
    await StoreLeagueInfo(context, englishChampionship, "2001-2002", "England", "Championship", 2);
    
    context = new SoccerSimContext();
    var englishLeagueOne = GetFixtures("2001-2002", "E2");
    await StoreLeagueInfo(context, englishLeagueOne, "2001-2002", "England", "League One", 3);
    
    context = new SoccerSimContext();
    var englishLeagueTwo = GetFixtures("2001-2002", "E3");
    await StoreLeagueInfo(context, englishLeagueTwo, "2001-2002", "England", "League Two", 4);
    
    context = new SoccerSimContext();
    var frenchLigue1 = GetFixtures("2001-2002", "F1");
    await StoreLeagueInfo(context, frenchLigue1, "2001-2002", "France", "Ligue 1", 1);
    
    context = new SoccerSimContext();
    var frenchLigue2 = GetFixtures("2001-2002", "F2");
    await StoreLeagueInfo(context, frenchLigue2, "2001-2002", "France", "Ligue 2", 2);
    
    context = new SoccerSimContext();
    var greekSuperLeague = GetFixtures("2001-2002", "G1");
    await StoreLeagueInfo(context, greekSuperLeague, "2001-2002", "Greece", "Super League", 1);
    
    context = new SoccerSimContext();
    var italianSerieA = GetFixtures("2001-2002", "I1");
    await StoreLeagueInfo(context, italianSerieA, "2001-2002", "Italy", "Serie A", 1);
    
    context = new SoccerSimContext();
    var italianSerieB = GetFixtures("2001-2002", "I2");
    await StoreLeagueInfo(context, italianSerieB, "2001-2002", "Italy", "Serie B", 2);
    
    context = new SoccerSimContext();
    var dutchEredivisie = GetFixtures("2001-2002", "N1");
    await StoreLeagueInfo(context, dutchEredivisie, "2001-2002", "Netherlands", "Eredivisie", 1);
    
    context = new SoccerSimContext();
    var portuguesePrimeiraLiga = GetFixtures("2001-2002", "P1");
    await StoreLeagueInfo(context, portuguesePrimeiraLiga, "2001-2002", "Portugal", "Primeira Liga", 1);
    
    context = new SoccerSimContext();
    var scottishPremiership2001 = GetFixtures("2001-2002", "SC0");
    await StoreLeagueInfo(context, scottishPremiership2001, "2001-2002", "Scotland", "Premiership", 1);
    
    context = new SoccerSimContext();
    var scottishChampionship2001 = GetFixtures("2001-2002", "SC1");
    await StoreLeagueInfo(context, scottishChampionship2001, "2001-2002", "Scotland", "Championship", 2);
    
    context = new SoccerSimContext();
    var scottishLeagueOne2001 = GetFixtures("2001-2002", "SC2");
    await StoreLeagueInfo(context, scottishLeagueOne2001, "2001-2002", "Scotland", "League One", 3);
    
    context = new SoccerSimContext();
    var scottishLeagueTwo2001 = GetFixtures("2001-2002", "SC3");
    await StoreLeagueInfo(context, scottishLeagueTwo2001, "2001-2002", "Scotland", "League Two", 4);
    
    context = new SoccerSimContext();
    var spanishPrimeraDivision2001 = GetFixtures("2001-2002", "SP1");
    await StoreLeagueInfo(context, spanishPrimeraDivision2001, "2001-2002", "Spain", "Primera Division", 1);
    
    context = new SoccerSimContext();
    var spanishSegundaDivision2001 = GetFixtures("2001-2002", "SP2");
    await StoreLeagueInfo(context, spanishSegundaDivision2001, "2001-2002", "Spain", "Segunda Division", 2);
    
    context = new SoccerSimContext();
    var turkishSuperLig2001 = GetFixtures("2001-2002", "T1");
    await StoreLeagueInfo(context, turkishSuperLig2001, "2001-2002", "Turkey", "Super Lig", 1);

    #endregion
    
    #region 2002
    
    context = new SoccerSimContext();
    var belgianFirstDivision2002 = GetFixtures("2002-2003", "B1");
    await StoreLeagueInfo(context, belgianFirstDivision2002, "2002-2003", "Belgium", "First Division", 1);

    context = new SoccerSimContext();
    var germanBundesliga2002 = GetFixtures("2002-2003", "D1");
    await StoreLeagueInfo(context, germanBundesliga2002, "2002-2003", "Germany", "Bundesliga", 1);
    
    context = new SoccerSimContext();
    var german2Bundesliga2002 = GetFixtures("2002-2003", "D2");
    await StoreLeagueInfo(context, german2Bundesliga2002, "2002-2003", "Germany", "2. Bundesliga", 2);
    
    context = new SoccerSimContext();
    var englishPremierLeague2002 = GetFixtures("2002-2003", "E0");
    await StoreLeagueInfo(context, englishPremierLeague2002, "2002-2003", "England", "Premier League", 1);
    
    context = new SoccerSimContext();
    var englishChampionship2002 = GetFixtures("2002-2003", "E1");
    await StoreLeagueInfo(context, englishChampionship2002, "2002-2003", "England", "Championship", 2);
    
    context = new SoccerSimContext();
    var englishLeagueOne2002 = GetFixtures("2002-2003", "E2");
    await StoreLeagueInfo(context, englishLeagueOne2002, "2002-2003", "England", "League One", 3);
    
    context = new SoccerSimContext();
    var englishLeagueTwo2002 = GetFixtures("2002-2003", "E3");
    await StoreLeagueInfo(context, englishLeagueTwo2002, "2002-2003", "England", "League Two", 4);
    
    context = new SoccerSimContext();
    var frenchLigue12002 = GetFixtures("2002-2003", "F1");
    await StoreLeagueInfo(context, frenchLigue12002, "2002-2003", "France", "Ligue 1", 1);
    
    context = new SoccerSimContext();
    var frenchLigue22002 = GetFixtures("2002-2003", "F2");
    await StoreLeagueInfo(context, frenchLigue22002, "2002-2003", "France", "Ligue 2", 2);
    
    context = new SoccerSimContext();
    var greecesuperLeague2002 = GetFixtures("2002-2003", "G1");
    await StoreLeagueInfo(context, greecesuperLeague2002, "2002-2003", "Greece", "Super League", 1);
    
    context = new SoccerSimContext();
    var italianSerieA2002 = GetFixtures("2002-2003", "I1");
    await StoreLeagueInfo(context, italianSerieA2002, "2002-2003", "Italy", "Serie A", 1);
    
    context = new SoccerSimContext();
    var italianSerieB2002 = GetFixtures("2002-2003", "I2");
    await StoreLeagueInfo(context, italianSerieB2002, "2002-2003", "Italy", "Serie B", 2);
    
    context = new SoccerSimContext();
    var dutchEredivisie2002 = GetFixtures("2002-2003", "N1");
    await StoreLeagueInfo(context, dutchEredivisie2002, "2002-2003", "Netherlands", "Eredivisie", 1);
    
    context = new SoccerSimContext();
    var portugueseLiga2002 = GetFixtures("2002-2003", "P1");
    await StoreLeagueInfo(context, portugueseLiga2002, "2002-2003", "Portugal", "Liga", 1);
    
    context = new SoccerSimContext();
    var scottishPremierLeague2002 = GetFixtures("2002-2003", "SC0");
    await StoreLeagueInfo(context, scottishPremierLeague2002, "2002-2003", "Scotland", "Premier League", 1);

    context = new SoccerSimContext();
    var scottishLeagueOne2002 = GetFixtures("2002-2003", "SC1");
    await StoreLeagueInfo(context, scottishLeagueOne2002, "2002-2003", "Scotland", "League One", 2);
    
    context = new SoccerSimContext();
    var scottishLeagueTwo2002 = GetFixtures("2002-2003", "SC2");
    await StoreLeagueInfo(context, scottishLeagueTwo2002, "2002-2003", "Scotland", "League Two", 3);
    
    context = new SoccerSimContext();
    var scottishLeagueCup2002 = GetFixtures("2002-2003", "SC3");
    await StoreLeagueInfo(context, scottishLeagueCup2002, "2002-2003", "Scotland", "League Cup", 4);
    
    context = new SoccerSimContext();
    var spanishPrimeraDivision2002 = GetFixtures("2002-2003", "SP1");
    await StoreLeagueInfo(context, spanishPrimeraDivision2002, "2002-2003", "Spain", "Primera Division", 1);
    
    context = new SoccerSimContext();
    var spanishSegundaDivision2002 = GetFixtures("2002-2003", "SP2");
    await StoreLeagueInfo(context, spanishSegundaDivision2002, "2002-2003", "Spain", "Segunda Division", 2);
    
    context = new SoccerSimContext();
    var turkishSuperLig2002 = GetFixtures("2002-2003", "T1");
    await StoreLeagueInfo(context, turkishSuperLig2002, "2002-2003", "Turkey", "Super Lig", 1);

    #endregion

    #region 2003

    context = new SoccerSimContext();
    var belgianJupilerLeague2003 = GetFixtures("2003-2004", "B1");
    await StoreLeagueInfo(context, belgianJupilerLeague2003, "2003-2004", "Belgium", "Jupiler League", 1);
    
    context = new SoccerSimContext();
    var germanBundesliga2003 = GetFixtures("2003-2004", "D1");
    await StoreLeagueInfo(context, germanBundesliga2003, "2003-2004", "Germany", "Bundesliga", 1);
    
    context = new SoccerSimContext();
    var germanBundesliga22003 = GetFixtures("2003-2004", "D2");
    await StoreLeagueInfo(context, germanBundesliga22003, "2003-2004", "Germany", "Bundesliga 2", 2);
    
    context = new SoccerSimContext();
    var englishPremierLeague2003 = GetFixtures("2003-2004", "E0");
    await StoreLeagueInfo(context, englishPremierLeague2003, "2003-2004", "England", "Premier League", 1);
    
    context = new SoccerSimContext();
    var englishChampionship2003 = GetFixtures("2003-2004", "E1");
    await StoreLeagueInfo(context, englishChampionship2003, "2003-2004", "England", "Championship", 2);
    
    context = new SoccerSimContext();
    var englishLeagueOne2003 = GetFixtures("2003-2004", "E2");
    await StoreLeagueInfo(context, englishLeagueOne2003, "2003-2004", "England", "League One", 3);
    
    context = new SoccerSimContext();
    var englishLeagueTwo2003 = GetFixtures("2003-2004", "E3");
    await StoreLeagueInfo(context, englishLeagueTwo2003, "2003-2004", "England", "League Two", 4);
    
    context = new SoccerSimContext();
    var frenchLigue12003 = GetFixtures("2003-2004", "F1");
    await StoreLeagueInfo(context, frenchLigue12003, "2003-2004", "France", "Ligue 1", 1);
    
    context = new SoccerSimContext();
    var frenchLigue22003 = GetFixtures("2003-2004", "F2");
    await StoreLeagueInfo(context, frenchLigue22003, "2003-2004", "France", "Ligue 2", 2);
    
    context = new SoccerSimContext();
    var greekSuperLeague2003 = GetFixtures("2003-2004", "G1");
    await StoreLeagueInfo(context, greekSuperLeague2003, "2003-2004", "Greece", "Super League", 1);
    
    context = new SoccerSimContext();
    var italianSerieA2003 = GetFixtures("2003-2004", "I1");
    await StoreLeagueInfo(context, italianSerieA2003, "2003-2004", "Italy", "Serie A", 1);
    
    context = new SoccerSimContext();
    var italianSerieB2003 = GetFixtures("2003-2004", "I2");
    await StoreLeagueInfo(context, italianSerieB2003, "2003-2004", "Italy", "Serie B", 2);
    
    context = new SoccerSimContext();
    var dutchEredivisie2003 = GetFixtures("2003-2004", "N1");
    await StoreLeagueInfo(context, dutchEredivisie2003, "2003-2004", "Netherlands", "Eredivisie", 1);
    
    context = new SoccerSimContext();
    var portugueseLiga2003 = GetFixtures("2003-2004", "P1");
    await StoreLeagueInfo(context, portugueseLiga2003, "2003-2004", "Portugal", "Liga", 1);
    
    context = new SoccerSimContext();
    var scottishPremierLeague2003 = GetFixtures("2003-2004", "SC0");
    await StoreLeagueInfo(context, scottishPremierLeague2003, "2003-2004", "Scotland", "Premier League", 1);
    
    context = new SoccerSimContext();
    var scottishDivisionOne2003 = GetFixtures("2003-2004", "SC1");
    await StoreLeagueInfo(context, scottishDivisionOne2003, "2003-2004", "Scotland", "Division 1", 2);
    
    context = new SoccerSimContext();
    var scottishDivisionTwo2003 = GetFixtures("2003-2004", "SC2");
    await StoreLeagueInfo(context, scottishDivisionTwo2003, "2003-2004", "Scotland", "Division 2", 3);
    
    context = new SoccerSimContext();
    var scottishDivisionThree2003 = GetFixtures("2003-2004", "SC3");
    await StoreLeagueInfo(context, scottishDivisionThree2003, "2003-2004", "Scotland", "Division 3", 4);
    
    context = new SoccerSimContext();
    var spanishPrimeraDivision2003 = GetFixtures("2003-2004", "SP1");
    await StoreLeagueInfo(context, spanishPrimeraDivision2003, "2003-2004", "Spain", "Primera Division", 1);
    
    context = new SoccerSimContext();
    var spanishSegundaDivision2003 = GetFixtures("2003-2004", "SP2");
    await StoreLeagueInfo(context, spanishSegundaDivision2003, "2003-2004", "Spain", "Segunda Division", 2);
    
    context = new SoccerSimContext();
    var turkishSuperLig2003 = GetFixtures("2003-2004", "T1");
    await StoreLeagueInfo(context, turkishSuperLig2003, "2003-2004", "Turkey", "Super Lig", 1);

    #endregion

    #region 2004

    context = new SoccerSimContext();
    var belgianJupilerLeague2004 = GetFixtures("2004-2005", "B1");
    await StoreLeagueInfo(context, belgianJupilerLeague2004, "2004-2005", "Belgium", "Jupiler League", 1);
    
    context = new SoccerSimContext();
    var germanBundesliga2004 = GetFixtures("2004-2005", "D1");
    await StoreLeagueInfo(context, germanBundesliga2004, "2004-2005", "Germany", "Bundesliga", 1);
    
    context = new SoccerSimContext();
    var german2Bundesliga2004 = GetFixtures("2004-2005", "D2");
    await StoreLeagueInfo(context, german2Bundesliga2004, "2004-2005", "Germany", "2. Bundesliga", 2);
    
    context = new SoccerSimContext();
    var englishPremierLeague2004 = GetFixtures("2004-2005", "E0");
    await StoreLeagueInfo(context, englishPremierLeague2004, "2004-2005", "England", "Premier League", 1);
    
    context = new SoccerSimContext();
    var englishChampionship2004 = GetFixtures("2004-2005", "E1");
    await StoreLeagueInfo(context, englishChampionship2004, "2004-2005", "England", "Championship", 2);
    
    context = new SoccerSimContext();
    var englishLeagueOne2004 = GetFixtures("2004-2005", "E2");
    await StoreLeagueInfo(context, englishLeagueOne2004, "2004-2005", "England", "League One", 3);
    
    context = new SoccerSimContext();
    var englishLeagueTwo2004 = GetFixtures("2004-2005", "E3");
    await StoreLeagueInfo(context, englishLeagueTwo2004, "2004-2005", "England", "League Two", 4);
    
    context = new SoccerSimContext();
    var frenchLigueOne2004 = GetFixtures("2004-2005", "F1");
    await StoreLeagueInfo(context, frenchLigueOne2004, "2004-2005", "France", "Ligue 1", 1);
    
    context = new SoccerSimContext();
    var frenchLigueTwo2004 = GetFixtures("2004-2005", "F2");
    await StoreLeagueInfo(context, frenchLigueTwo2004, "2004-2005", "France", "Ligue 2", 2);
    
    context = new SoccerSimContext();
    var greekSuperLeague2004 = GetFixtures("2004-2005", "G1");
    await StoreLeagueInfo(context, greekSuperLeague2004, "2004-2005", "Greece", "Super League", 1);
    
    context = new SoccerSimContext();
    var italianSerieA2004 = GetFixtures("2004-2005", "I1");
    await StoreLeagueInfo(context, italianSerieA2004, "2004-2005", "Italy", "Serie A", 1);
    
    context = new SoccerSimContext();
    var italianSerieB2004 = GetFixtures("2004-2005", "I2");
    await StoreLeagueInfo(context, italianSerieB2004, "2004-2005", "Italy", "Serie B", 2);
    
    context = new SoccerSimContext();
    var dutchEredivisie2004 = GetFixtures("2004-2005", "N1");
    await StoreLeagueInfo(context, dutchEredivisie2004, "2004-2005", "Netherlands", "Eredivisie", 1);
    
    context = new SoccerSimContext();
    var portugueseSuperLiga2004 = GetFixtures("2004-2005", "P1");
    await StoreLeagueInfo(context, portugueseSuperLiga2004, "2004-2005", "Portugal", "Super Liga", 1);
    
    context = new SoccerSimContext();
    var scottishPremierLeague2004 = GetFixtures("2004-2005", "SC0");
    await StoreLeagueInfo(context, scottishPremierLeague2004, "2004-2005", "Scotland", "Premier League", 1);
    
    context = new SoccerSimContext();
    var scottishDivisionOne2004 = GetFixtures("2004-2005", "SC1");
    await StoreLeagueInfo(context, scottishDivisionOne2004, "2004-2005", "Scotland", "Division 1", 2);
    
    context = new SoccerSimContext();
    var scottishDivisionTwo2004 = GetFixtures("2004-2005", "SC2");
    await StoreLeagueInfo(context, scottishDivisionTwo2004, "2004-2005", "Scotland", "Division 2", 3);
    
    context = new SoccerSimContext();
    var scottishDivisionThree2004 = GetFixtures("2004-2005", "SC3");
    await StoreLeagueInfo(context, scottishDivisionThree2004, "2004-2005", "Scotland", "Division 3", 4);
    
    context = new SoccerSimContext();
    var spanishPrimeraDivision2004 = GetFixtures("2004-2005", "SP1");
    await StoreLeagueInfo(context, spanishPrimeraDivision2004, "2004-2005", "Spain", "Primera Division", 1);
    
    context = new SoccerSimContext();
    var spanishSegundaDivision2004 = GetFixtures("2004-2005", "SP2");
    await StoreLeagueInfo(context, spanishSegundaDivision2004, "2004-2005", "Spain", "Segunda Division", 2);
    
    context = new SoccerSimContext();
    var turkishSuperLig2004 = GetFixtures("2004-2005", "T1");
    await StoreLeagueInfo(context, turkishSuperLig2004, "2004-2005", "Turkey", "Super Lig", 1);

    #endregion

    #region 2005

    context = new SoccerSimContext();
    var belgianJupilerLeague2005 = GetFixtures("2005-2006", "B1");
    await StoreLeagueInfo(context, belgianJupilerLeague2005, "2005-2006", "Belgium", "Jupiler League", 1);
    
    context = new SoccerSimContext();
    var germanBundesliga2005 = GetFixtures("2005-2006", "D1");
    await StoreLeagueInfo(context, germanBundesliga2005, "2005-2006", "Germany", "Bundesliga", 1);
    
    context = new SoccerSimContext();
    var german2Bundesliga2005 = GetFixtures("2005-2006", "D2");
    await StoreLeagueInfo(context, german2Bundesliga2005, "2005-2006", "Germany", "2. Bundesliga", 2);
    
    context = new SoccerSimContext();
    var englishPremierLeague2005 = GetFixtures("2005-2006", "E0");
    await StoreLeagueInfo(context, englishPremierLeague2005, "2005-2006", "England", "Premier League", 1);
    
    context = new SoccerSimContext();
    var englishChampionship2005 = GetFixtures("2005-2006", "E1");
    await StoreLeagueInfo(context, englishChampionship2005, "2005-2006", "England", "Championship", 2);
    
    context = new SoccerSimContext();
    var englishLeagueOne2005 = GetFixtures("2005-2006", "E2");
    await StoreLeagueInfo(context, englishLeagueOne2005, "2005-2006", "England", "League One", 3);
    
    context = new SoccerSimContext();
    var englishLeagueTwo2005 = GetFixtures("2005-2006", "E3");
    await StoreLeagueInfo(context, englishLeagueTwo2005, "2005-2006", "England", "League Two", 4);
    
    context = new SoccerSimContext();
    var frenchLigueOne2005 = GetFixtures("2005-2006", "F1");
    await StoreLeagueInfo(context, frenchLigueOne2005, "2005-2006", "France", "Ligue 1", 1);
    
    context = new SoccerSimContext();
    var frenchLigueTwo2005 = GetFixtures("2005-2006", "F2");
    await StoreLeagueInfo(context, frenchLigueTwo2005, "2005-2006", "France", "Ligue 2", 2);
    
    context = new SoccerSimContext();
    var greekSuperLeague2005 = GetFixtures("2005-2006", "G1");
    await StoreLeagueInfo(context, greekSuperLeague2005, "2005-2006", "Greece", "Super League", 1);
    
    context = new SoccerSimContext();
    var italianSerieA2005 = GetFixtures("2005-2006", "I1");
    await StoreLeagueInfo(context, italianSerieA2005, "2005-2006", "Italy", "Serie A", 1);
    
    context = new SoccerSimContext();
    var italianSerieB2005 = GetFixtures("2005-2006", "I2");
    await StoreLeagueInfo(context, italianSerieB2005, "2005-2006", "Italy", "Serie B", 2);
    
    context = new SoccerSimContext();
    var dutchEredivisie2005 = GetFixtures("2005-2006", "N1");
    await StoreLeagueInfo(context, dutchEredivisie2005, "2005-2006", "Netherlands", "Eredivisie", 1);
    
    context = new SoccerSimContext();
    var portugueseSuperLiga2005 = GetFixtures("2005-2006", "P1");
    await StoreLeagueInfo(context, portugueseSuperLiga2005, "2005-2006", "Portugal", "Super Liga", 1);
    
    context = new SoccerSimContext();
    var scottishPremierLeague2005 = GetFixtures("2005-2006", "SC0");
    await StoreLeagueInfo(context, scottishPremierLeague2005, "2005-2006", "Scotland", "Premier League", 1);
    
    context = new SoccerSimContext();
    var scottishDivisionOne2005 = GetFixtures("2005-2006", "SC1");
    await StoreLeagueInfo(context, scottishDivisionOne2005, "2005-2006", "Scotland", "Division 1", 2);
    
    context = new SoccerSimContext();
    var scottishDivisionTwo2005 = GetFixtures("2005-2006", "SC2");
    await StoreLeagueInfo(context, scottishDivisionTwo2005, "2005-2006", "Scotland", "Division 2", 3);
    
    context = new SoccerSimContext();
    var scottishDivisionThree2005 = GetFixtures("2005-2006", "SC3");
    await StoreLeagueInfo(context, scottishDivisionThree2005, "2005-2006", "Scotland", "Division 3", 4);
    
    context = new SoccerSimContext();
    var spanishPrimeraLiga2005 = GetFixtures("2005-2006", "SP1");
    await StoreLeagueInfo(context, spanishPrimeraLiga2005, "2005-2006", "Spain", "Primera Liga", 1);
    
    context = new SoccerSimContext();
    var spanishSegundaLiga2005 = GetFixtures("2005-2006", "SP2");
    await StoreLeagueInfo(context, spanishSegundaLiga2005, "2005-2006", "Spain", "Segunda Liga", 2);
    
    context = new SoccerSimContext();
    var turkishSuperLig2005 = GetFixtures("2005-2006", "T1");
    await StoreLeagueInfo(context, turkishSuperLig2005, "2005-2006", "Turkey", "Super Lig", 1);

    #endregion
    
    #region 2006

    context = new SoccerSimContext();
    var belgiumJupilerLeague2006 = GetFixtures("2006-2007", "B1");
    await StoreLeagueInfo(context, belgiumJupilerLeague2006, "2006-2007", "Belgium", "Jupiler League", 1);
    
    context = new SoccerSimContext();
    var germanBundesliga2006 = GetFixtures("2006-2007", "D1");
    await StoreLeagueInfo(context, germanBundesliga2006, "2006-2007", "Germany", "Bundesliga", 1);
    
    context = new SoccerSimContext();
    var germanBundesliga22006 = GetFixtures("2006-2007", "D2");
    await StoreLeagueInfo(context, germanBundesliga22006, "2006-2007", "Germany", "Bundesliga 2", 2);
    
    context = new SoccerSimContext();
    var englishPremierLeague2006 = GetFixtures("2006-2007", "E0");
    await StoreLeagueInfo(context, englishPremierLeague2006, "2006-2007", "England", "Premier League", 1);
    
    context = new SoccerSimContext();
    var englishChampionship2006 = GetFixtures("2006-2007", "E1");
    await StoreLeagueInfo(context, englishChampionship2006, "2006-2007", "England", "Championship", 2);
    
    context = new SoccerSimContext();
    var englishLeagueOne2006 = GetFixtures("2006-2007", "E2");
    await StoreLeagueInfo(context, englishLeagueOne2006, "2006-2007", "England", "League One", 3);
    
    context = new SoccerSimContext();
    var englishLeagueTwo2006 = GetFixtures("2006-2007", "E3");
    await StoreLeagueInfo(context, englishLeagueTwo2006, "2006-2007", "England", "League Two", 4);
    
    context = new SoccerSimContext();
    var englishConference2006 = GetFixtures("2006-2007", "EC");
    await StoreLeagueInfo(context, englishConference2006, "2006-2007", "England", "Conference", 5);
    
    context = new SoccerSimContext();
    var frenchLigue12006 = GetFixtures("2006-2007", "F1");
    await StoreLeagueInfo(context, frenchLigue12006, "2006-2007", "France", "Ligue 1", 1);
    
    context = new SoccerSimContext();
    var frenchLigue22006 = GetFixtures("2006-2007", "F2");
    await StoreLeagueInfo(context, frenchLigue22006, "2006-2007", "France", "Ligue 2", 2);
    
    context = new SoccerSimContext();
    var greekSuperLeague2006 = GetFixtures("2006-2007", "G1");
    await StoreLeagueInfo(context, greekSuperLeague2006, "2006-2007", "Greece", "Super League", 1);
    
    context = new SoccerSimContext();
    var italianSerieA2006 = GetFixtures("2006-2007", "I1");
    await StoreLeagueInfo(context, italianSerieA2006, "2006-2007", "Italy", "Serie A", 1);
    
    context = new SoccerSimContext();
    var italianSerieB2006 = GetFixtures("2006-2007", "I2");
    await StoreLeagueInfo(context, italianSerieB2006, "2006-2007", "Italy", "Serie B", 2);
    
    context = new SoccerSimContext();
    var dutchEredivisie2006 = GetFixtures("2006-2007", "N1");
    await StoreLeagueInfo(context, dutchEredivisie2006, "2006-2007", "Netherlands", "Eredivisie", 1);
    
    context = new SoccerSimContext();
    var portugueseSuperLiga2006 = GetFixtures("2006-2007", "P1");
    await StoreLeagueInfo(context, portugueseSuperLiga2006, "2006-2007", "Portugal", "Super Liga", 1);
    
    context = new SoccerSimContext();
    var scottishPremierLeague2006 = GetFixtures("2006-2007", "SC0");
    await StoreLeagueInfo(context, scottishPremierLeague2006, "2006-2007", "Scotland", "Premier League", 1);
    
    context = new SoccerSimContext();
    var scottishDivisionOne2006 = GetFixtures("2006-2007", "SC1");
    await StoreLeagueInfo(context, scottishDivisionOne2006, "2006-2007", "Scotland", "Division 1", 2);
    
    context = new SoccerSimContext();
    var scottishDivisionTwo2006 = GetFixtures("2006-2007", "SC2");
    await StoreLeagueInfo(context, scottishDivisionTwo2006, "2006-2007", "Scotland", "Division 2", 3);
    
    context = new SoccerSimContext();
    var scottishDivisionThree2006 = GetFixtures("2006-2007", "SC3");
    await StoreLeagueInfo(context, scottishDivisionThree2006, "2006-2007", "Scotland", "Division 3", 4);
    
    context = new SoccerSimContext();
    var spanishPrimeraLiga2006 = GetFixtures("2006-2007", "SP1");
    await StoreLeagueInfo(context, spanishPrimeraLiga2006, "2006-2007", "Spain", "Primera Liga", 1);
    
    context = new SoccerSimContext();
    var spanishSegundaLiga2006 = GetFixtures("2006-2007", "SP2");
    await StoreLeagueInfo(context, spanishSegundaLiga2006, "2006-2007", "Spain", "Segunda Liga", 2);
    
    context = new SoccerSimContext();
    var turkishSuperLig2006 = GetFixtures("2006-2007", "T1");
    await StoreLeagueInfo(context, turkishSuperLig2006, "2006-2007", "Turkey", "Super Lig", 1);

    #endregion

    #region 2007

    context = new SoccerSimContext();
    var belgianJupilerLeague2007 = GetFixtures("2007-2008", "B1");
    await StoreLeagueInfo(context, belgianJupilerLeague2007, "2007-2008", "Belgium", "Jupiler League", 1);
    
    context = new SoccerSimContext();
    var germanBundesliga2007 = GetFixtures("2007-2008", "D1");
    await StoreLeagueInfo(context, germanBundesliga2007, "2007-2008", "Germany", "Bundesliga", 1);
    
    context = new SoccerSimContext();
    var germanBundesliga22007 = GetFixtures("2007-2008", "D2");
    await StoreLeagueInfo(context, germanBundesliga22007, "2007-2008", "Germany", "Bundesliga 2", 2);
    
    context = new SoccerSimContext();
    var englishPremierLeague2007 = GetFixtures("2007-2008", "E0");
    await StoreLeagueInfo(context, englishPremierLeague2007, "2007-2008", "England", "Premier League", 1);
    
    context = new SoccerSimContext();
    var englishChampionship2007 = GetFixtures("2007-2008", "E1");
    await StoreLeagueInfo(context, englishChampionship2007, "2007-2008", "England", "Championship", 2);
    
    context = new SoccerSimContext();
    var englishLeagueOne2007 = GetFixtures("2007-2008", "E2");
    await StoreLeagueInfo(context, englishLeagueOne2007, "2007-2008", "England", "League One", 3);
    
    context = new SoccerSimContext();
    var englishLeagueTwo2007 = GetFixtures("2007-2008", "E3");
    await StoreLeagueInfo(context, englishLeagueTwo2007, "2007-2008", "England", "League Two", 4);
    
    context = new SoccerSimContext();
    var englishConference2007 = GetFixtures("2007-2008", "EC");
    await StoreLeagueInfo(context, englishConference2007, "2007-2008", "England", "Conference", 5);
    
    context = new SoccerSimContext();
    var frenchLigue12007 = GetFixtures("2007-2008", "F1");
    await StoreLeagueInfo(context, frenchLigue12007, "2007-2008", "France", "Ligue 1", 1);
    
    context = new SoccerSimContext();
    var frenchLigue22007 = GetFixtures("2007-2008", "F2");
    await StoreLeagueInfo(context, frenchLigue22007, "2007-2008", "France", "Ligue 2", 2);

    context = new SoccerSimContext();
    var greekSuperLeague2007 = GetFixtures("2007-2008", "G1");
    await StoreLeagueInfo(context, greekSuperLeague2007, "2007-2008", "Greece", "Super League", 1);
    
    context = new SoccerSimContext();
    var italianSerieA2007 = GetFixtures("2007-2008", "I1");
    await StoreLeagueInfo(context, italianSerieA2007, "2007-2008", "Italy", "Serie A", 1);
    
    context = new SoccerSimContext();
    var italianSerieB2007 = GetFixtures("2007-2008", "I2");
    await StoreLeagueInfo(context, italianSerieB2007, "2007-2008", "Italy", "Serie B", 2);
    
    context = new SoccerSimContext();
    var dutchEredivisie2007 = GetFixtures("2007-2008", "N1");
    await StoreLeagueInfo(context, dutchEredivisie2007, "2007-2008", "Netherlands", "Eredivisie", 1);
    
    context = new SoccerSimContext();
    var portugueseSuperLiga2007 = GetFixtures("2007-2008", "P1");
    await StoreLeagueInfo(context, portugueseSuperLiga2007, "2007-2008", "Portugal", "Super Liga", 1);
    
    context = new SoccerSimContext();
    var scottishPremierLeague2007 = GetFixtures("2007-2008", "SC0");
    await StoreLeagueInfo(context, scottishPremierLeague2007, "2007-2008", "Scotland", "Premier League", 1);
    
    context = new SoccerSimContext();
    var scottishDivisionOne2007 = GetFixtures("2007-2008", "SC1");
    await StoreLeagueInfo(context, scottishDivisionOne2007, "2007-2008", "Scotland", "Division 1", 2);
    
    context = new SoccerSimContext();
    var scottishDivisionTwo2007 = GetFixtures("2007-2008", "SC2");
    await StoreLeagueInfo(context, scottishDivisionTwo2007, "2007-2008", "Scotland", "Division 2", 3);
    
    context = new SoccerSimContext();
    var scottishDivisionThree2007 = GetFixtures("2007-2008", "SC3");
    await StoreLeagueInfo(context, scottishDivisionThree2007, "2007-2008", "Scotland", "Division 3", 4);
    
    context = new SoccerSimContext();
    var spanishPrimeraLiga2007 = GetFixtures("2007-2008", "SP1");
    await StoreLeagueInfo(context, spanishPrimeraLiga2007, "2007-2008", "Spain", "Primera Liga", 1);
    
    context = new SoccerSimContext();
    var spanishSegundaLiga2007 = GetFixtures("2007-2008", "SP2");
    await StoreLeagueInfo(context, spanishSegundaLiga2007, "2007-2008", "Spain", "Segunda Liga", 2);
    
    context = new SoccerSimContext();
    var turkishSuperLig2007 = GetFixtures("2007-2008", "T1");
    await StoreLeagueInfo(context, turkishSuperLig2007, "2007-2008", "Turkey", "Super Lig", 1);

    #endregion

    #region 2008

    context = new SoccerSimContext();
    var belgianJupilerLeague2008 = GetFixtures("2008-2009", "B1");
    await StoreLeagueInfo(context, belgianJupilerLeague2008, "2008-2009", "Belgium", "Jupiler League", 1);

    context = new SoccerSimContext();
    var germanBundesliga2008 = GetFixtures("2008-2009", "D1");
    await StoreLeagueInfo(context, germanBundesliga2008, "2008-2009", "Germany", "Bundesliga", 1);
    
    context = new SoccerSimContext();
    var germanBundesliga22008 = GetFixtures("2008-2009", "D2");
    await StoreLeagueInfo(context, germanBundesliga22008, "2008-2009", "Germany", "Bundesliga 2", 2);
    
    context = new SoccerSimContext();
    var englishPremierLeague2008 = GetFixtures("2008-2009", "E0");
    await StoreLeagueInfo(context, englishPremierLeague2008, "2008-2009", "England", "Premier League", 1);
    
    context = new SoccerSimContext();
    var englishChampionship2008 = GetFixtures("2008-2009", "E1");
    await StoreLeagueInfo(context, englishChampionship2008, "2008-2009", "England", "Championship", 2);
    
    context = new SoccerSimContext();
    var englishLeagueOne2008 = GetFixtures("2008-2009", "E2");
    await StoreLeagueInfo(context, englishLeagueOne2008, "2008-2009", "England", "League One", 3);
    
    context = new SoccerSimContext();
    var englishLeagueTwo2008 = GetFixtures("2008-2009", "E3");
    await StoreLeagueInfo(context, englishLeagueTwo2008, "2008-2009", "England", "League Two", 4);
    
    context = new SoccerSimContext();
    var frenchLigue12008 = GetFixtures("2008-2009", "F1");
    await StoreLeagueInfo(context, frenchLigue12008, "2008-2009", "France", "Ligue 1", 1);
    
    context = new SoccerSimContext();
    var frenchLigue22008 = GetFixtures("2008-2009", "F2");
    await StoreLeagueInfo(context, frenchLigue22008, "2008-2009", "France", "Ligue 2", 2);
    
    context = new SoccerSimContext();
    var greekSuperLeague2008 = GetFixtures("2008-2009", "G1");
    await StoreLeagueInfo(context, greekSuperLeague2008, "2008-2009", "Greece", "Super League", 1);
    
    context = new SoccerSimContext();
    var italianSerieA2008 = GetFixtures("2008-2009", "I1");
    await StoreLeagueInfo(context, italianSerieA2008, "2008-2009", "Italy", "Serie A", 1);
    
    context = new SoccerSimContext();
    var italianSerieB2008 = GetFixtures("2008-2009", "I2");
    await StoreLeagueInfo(context, italianSerieB2008, "2008-2009", "Italy", "Serie B", 2);
    
    context = new SoccerSimContext();
    var dutchEredivisie2008 = GetFixtures("2008-2009", "N1");
    await StoreLeagueInfo(context, dutchEredivisie2008, "2008-2009", "Netherlands", "Eredivisie", 1);
    
    context = new SoccerSimContext();
    var portugueseSuperLiga2008 = GetFixtures("2008-2009", "P1");
    await StoreLeagueInfo(context, portugueseSuperLiga2008, "2008-2009", "Portugal", "Super Liga", 1);
    
    context = new SoccerSimContext();
    var scottishPremierLeague2008 = GetFixtures("2008-2009", "SC0");
    await StoreLeagueInfo(context, scottishPremierLeague2008, "2008-2009", "Scotland", "Premier League", 1);
    
    context = new SoccerSimContext();
    var scottishDivisionOne2008 = GetFixtures("2008-2009", "SC1");
    await StoreLeagueInfo(context, scottishDivisionOne2008, "2008-2009", "Scotland", "Division 1", 2);
    
    context = new SoccerSimContext();
    var scottishDivisionTwo2008 = GetFixtures("2008-2009", "SC2");
    await StoreLeagueInfo(context, scottishDivisionTwo2008, "2008-2009", "Scotland", "Division 2", 3);
    
    context = new SoccerSimContext();
    var scottishDivisionThree2008 = GetFixtures("2008-2009", "SC3");
    await StoreLeagueInfo(context, scottishDivisionThree2008, "2008-2009", "Scotland", "Division 3", 4);
    
    context = new SoccerSimContext();
    var spanishPrimeraDivision2008 = GetFixtures("2008-2009", "SP1");
    await StoreLeagueInfo(context, spanishPrimeraDivision2008, "2008-2009", "Spain", "Primera Division", 1);
    
    context = new SoccerSimContext();
    var spanishSegundaDivision2008 = GetFixtures("2008-2009", "SP2");
    await StoreLeagueInfo(context, spanishSegundaDivision2008, "2008-2009", "Spain", "Segunda Division", 2);
    
    context = new SoccerSimContext();
    var turkishSuperLig2008 = GetFixtures("2008-2009", "T1");
    await StoreLeagueInfo(context, turkishSuperLig2008, "2008-2009", "Turkey", "Super Lig", 1);

    #endregion

    #region 2009

    context = new SoccerSimContext();
    var belgianJupilerLeague2009 = GetFixtures("2009-2010", "B1");
    await StoreLeagueInfo(context, belgianJupilerLeague2009, "2009-2010", "Belgium", "Jupiler League", 1);
    
    context = new SoccerSimContext();
    var germanBundesliga2009 = GetFixtures("2009-2010", "D1");
    await StoreLeagueInfo(context, germanBundesliga2009, "2009-2010", "Germany", "Bundesliga", 1);
    
    context = new SoccerSimContext();
    var germanBundesliga22009 = GetFixtures("2009-2010", "D2");
    await StoreLeagueInfo(context, germanBundesliga22009, "2009-2010", "Germany", "Bundesliga 2", 2);
    
    context = new SoccerSimContext();
    var englishPremierLeague2009 = GetFixtures("2009-2010", "E0");
    await StoreLeagueInfo(context, englishPremierLeague2009, "2009-2010", "England", "Premier League", 1);
    
    context = new SoccerSimContext();
    var englishChampionship2009 = GetFixtures("2009-2010", "E1");
    await StoreLeagueInfo(context, englishChampionship2009, "2009-2010", "England", "Championship", 2);
    
    context = new SoccerSimContext();
    var englishLeagueOne2009 = GetFixtures("2009-2010", "E2");
    await StoreLeagueInfo(context, englishLeagueOne2009, "2009-2010", "England", "League One", 3);
    
    context = new SoccerSimContext();
    var englishLeagueTwo2009 = GetFixtures("2009-2010", "E3");
    await StoreLeagueInfo(context, englishLeagueTwo2009, "2009-2010", "England", "League Two", 4);
    
    context = new SoccerSimContext();
    var frenchLigue12009 = GetFixtures("2009-2010", "F1");
    await StoreLeagueInfo(context, frenchLigue12009, "2009-2010", "France", "Ligue 1", 1);
    
    context = new SoccerSimContext();
    var frenchLigue22009 = GetFixtures("2009-2010", "F2");
    await StoreLeagueInfo(context, frenchLigue22009, "2009-2010", "France", "Ligue 2", 2);
    
    context = new SoccerSimContext();
    var greekSuperLeague2009 = GetFixtures("2009-2010", "G1");
    await StoreLeagueInfo(context, greekSuperLeague2009, "2009-2010", "Greece", "Super League", 1);
    
    context = new SoccerSimContext();
    var italianSerieA2009 = GetFixtures("2009-2010", "I1");
    await StoreLeagueInfo(context, italianSerieA2009, "2009-2010", "Italy", "Serie A", 1);
    
    context = new SoccerSimContext();
    var italianSerieB2009 = GetFixtures("2009-2010", "I2");
    await StoreLeagueInfo(context, italianSerieB2009, "2009-2010", "Italy", "Serie B", 2);
    
    context = new SoccerSimContext();
    var dutchEredivisie2009 = GetFixtures("2009-2010", "N1");
    await StoreLeagueInfo(context, dutchEredivisie2009, "2009-2010", "Netherlands", "Eredivisie", 1);
    
    context = new SoccerSimContext();
    var portugueseLiga2009 = GetFixtures("2009-2010", "P1");
    await StoreLeagueInfo(context, portugueseLiga2009, "2009-2010", "Portugal", "Liga", 1);
    
    context = new SoccerSimContext();
    var scottishPremierLeague2009 = GetFixtures("2009-2010", "SC0");
    await StoreLeagueInfo(context, scottishPremierLeague2009, "2009-2010", "Scotland", "Premier League", 1);
    
    context = new SoccerSimContext();
    var scottishDivisionOne2009 = GetFixtures("2009-2010", "SC1");
    await StoreLeagueInfo(context, scottishDivisionOne2009, "2009-2010", "Scotland", "Division 1", 2);
    
    context = new SoccerSimContext();
    var scottishDivisionTwo2009 = GetFixtures("2009-2010", "SC2");
    await StoreLeagueInfo(context, scottishDivisionTwo2009, "2009-2010", "Scotland", "Division 2", 3);
    
    context = new SoccerSimContext();
    var scottishDivisionThree2009 = GetFixtures("2009-2010", "SC3");
    await StoreLeagueInfo(context, scottishDivisionThree2009, "2009-2010", "Scotland", "Division 3", 4);
    
    context = new SoccerSimContext();
    var spanishPrimeraDivision2009 = GetFixtures("2009-2010", "SP1");
    await StoreLeagueInfo(context, spanishPrimeraDivision2009, "2009-2010", "Spain", "Primera Division", 1);
    
    context = new SoccerSimContext();
    var spanishSegundaDivision2009 = GetFixtures("2009-2010", "SP2");
    await StoreLeagueInfo(context, spanishSegundaDivision2009, "2009-2010", "Spain", "Segunda Division", 2);
    
    context = new SoccerSimContext();
    var turkishSuperLig2009 = GetFixtures("2009-2010", "T1");
    await StoreLeagueInfo(context, turkishSuperLig2009, "2009-2010", "Turkey", "Super Lig", 1);

    #endregion

    #region 2010

    context = new SoccerSimContext();
    var belgianProLeague2010 = GetFixtures("2010-2011", "B1");
    await StoreLeagueInfo(context, belgianProLeague2010, "2010-2011", "Belgium", "Pro League", 1);
    
    context = new SoccerSimContext();
    var germanBundesliga2010 = GetFixtures("2010-2011", "D1");
    await StoreLeagueInfo(context, germanBundesliga2010, "2010-2011", "Germany", "Bundesliga", 1);
    
    context = new SoccerSimContext();
    var german2Bundesliga2010 = GetFixtures("2010-2011", "D2");
    await StoreLeagueInfo(context, german2Bundesliga2010, "2010-2011", "Germany", "2. Bundesliga", 2);
    
    context = new SoccerSimContext();
    var englishPremierLeague2010 = GetFixtures("2010-2011", "E0");
    await StoreLeagueInfo(context, englishPremierLeague2010, "2010-2011", "England", "Premier League", 1);
    
    context = new SoccerSimContext();
    var englishChampionship2010 = GetFixtures("2010-2011", "E1");
    await StoreLeagueInfo(context, englishChampionship2010, "2010-2011", "England", "Championship", 2);
    
    context = new SoccerSimContext();
    var englishLeagueOne2010 = GetFixtures("2010-2011", "E2");
    await StoreLeagueInfo(context, englishLeagueOne2010, "2010-2011", "England", "League One", 3);
    
    context = new SoccerSimContext();
    var englishLeagueTwo2010 = GetFixtures("2010-2011", "E3");
    await StoreLeagueInfo(context, englishLeagueTwo2010, "2010-2011", "England", "League Two", 4);
    
    context = new SoccerSimContext();
    var englishConference2010 = GetFixtures("2010-2011", "EC");
    await StoreLeagueInfo(context, englishConference2010, "2010-2011", "England", "Conference", 5);
    
    context = new SoccerSimContext();
    var frenchLigue12010 = GetFixtures("2010-2011", "F1");
    await StoreLeagueInfo(context, frenchLigue12010, "2010-2011", "France", "Ligue 1", 1);
    
    context = new SoccerSimContext();
    var frenchLigue22010 = GetFixtures("2010-2011", "F2");
    await StoreLeagueInfo(context, frenchLigue22010, "2010-2011", "France", "Ligue 2", 2);
    
    context = new SoccerSimContext();
    var italianSerieA2010 = GetFixtures("2010-2011", "I1");
    await StoreLeagueInfo(context, italianSerieA2010, "2010-2011", "Italy", "Serie A", 1);
    
    context = new SoccerSimContext();
    var italianSerieB2010 = GetFixtures("2010-2011", "I2");
    await StoreLeagueInfo(context, italianSerieB2010, "2010-2011", "Italy", "Serie B", 2);
    
    context = new SoccerSimContext();
    var dutchEredivisie2010 = GetFixtures("2010-2011", "N1");
    await StoreLeagueInfo(context, dutchEredivisie2010, "2010-2011", "Netherlands", "Eredivisie", 1);
    
    context = new SoccerSimContext();
    var portugueseLiga2010 = GetFixtures("2010-2011", "P1");
    await StoreLeagueInfo(context, portugueseLiga2010, "2010-2011", "Portugal", "Liga", 1);
    
    context = new SoccerSimContext();
    var scottishPremierLeague2010 = GetFixtures("2010-2011", "SC0");
    await StoreLeagueInfo(context, scottishPremierLeague2010, "2010-2011", "Scotland", "Premier League", 1);
    
    context = new SoccerSimContext();
    var scottishDivisionOne2010 = GetFixtures("2010-2011", "SC1");
    await StoreLeagueInfo(context, scottishDivisionOne2010, "2010-2011", "Scotland", "Division 1", 2);
    
    context = new SoccerSimContext();
    var scottishDivisionTwo2010 = GetFixtures("2010-2011", "SC2");
    await StoreLeagueInfo(context, scottishDivisionTwo2010, "2010-2011", "Scotland", "Division 2", 3);
        
    context = new SoccerSimContext();
    var scottishDivisionThree2010 = GetFixtures("2010-2011", "SC3");
    await StoreLeagueInfo(context, scottishDivisionThree2010, "2010-2011", "Scotland", "Division 3", 4);
    
    context = new SoccerSimContext();
    var spanishPrimeraDivision2010 = GetFixtures("2010-2011", "SP1");
    await StoreLeagueInfo(context, spanishPrimeraDivision2010, "2010-2011", "Spain", "Primera Division", 1);
    
    context = new SoccerSimContext();
    var spanishSegundaDivision2010 = GetFixtures("2010-2011", "SP2");
    await StoreLeagueInfo(context, spanishSegundaDivision2010, "2010-2011", "Spain", "Segunda Division", 2);
    
    context = new SoccerSimContext();
    var turkishSuperLig2010 = GetFixtures("2010-2011", "T1");
    await StoreLeagueInfo(context, turkishSuperLig2010, "2010-2011", "Turkey", "Super Lig", 1);

    #endregion

    #region 2011

    context = new SoccerSimContext();
    var belgianProLeague2011 = GetFixtures("2011-2012", "B1");
    await StoreLeagueInfo(context, belgianProLeague2011, "2011-2012", "Belgium", "Pro League", 1);
    
    context = new SoccerSimContext();
    var germanBundesliga2011 = GetFixtures("2011-2012", "D1");
    await StoreLeagueInfo(context, germanBundesliga2011, "2011-2012", "Germany", "Bundesliga", 1);
    
    context = new SoccerSimContext();
    var germanBundesliga22011 = GetFixtures("2011-2012", "D2");
    await StoreLeagueInfo(context, germanBundesliga22011, "2011-2012", "Germany", "Bundesliga 2", 2);
    
    context = new SoccerSimContext();
    var englishPremierLeague2011 = GetFixtures("2011-2012", "E0");
    await StoreLeagueInfo(context, englishPremierLeague2011, "2011-2012", "England", "Premier League", 1);
    
    context = new SoccerSimContext();
    var englishChampionship2011 = GetFixtures("2011-2012", "E1");
    await StoreLeagueInfo(context, englishChampionship2011, "2011-2012", "England", "Championship", 2);
    
    context = new SoccerSimContext();
    var englishLeagueOne2011 = GetFixtures("2011-2012", "E2");
    await StoreLeagueInfo(context, englishLeagueOne2011, "2011-2012", "England", "League One", 3);
    
    context = new SoccerSimContext();
    var englishLeagueTwo2011 = GetFixtures("2011-2012", "E3");
    await StoreLeagueInfo(context, englishLeagueTwo2011, "2011-2012", "England", "League Two", 4);
    
    context = new SoccerSimContext();
    var englishConference2011 = GetFixtures("2011-2012", "EC");
    await StoreLeagueInfo(context, englishConference2011, "2011-2012", "England", "Conference", 5);
    
    context = new SoccerSimContext();
    var frenchLigue12011 = GetFixtures("2011-2012", "F1");
    await StoreLeagueInfo(context, frenchLigue12011, "2011-2012", "France", "Ligue 1", 1);
    
    context = new SoccerSimContext();
    var frenchLigue22011 = GetFixtures("2011-2012", "F2");
    await StoreLeagueInfo(context, frenchLigue22011, "2011-2012", "France", "Ligue 2", 2);
    
    context = new SoccerSimContext();
    var italianSerieA2011 = GetFixtures("2011-2012", "I1");
    await StoreLeagueInfo(context, italianSerieA2011, "2011-2012", "Italy", "Serie A", 1);
    
    context = new SoccerSimContext();
    var italianSerieB2011 = GetFixtures("2011-2012", "I2");
    await StoreLeagueInfo(context, italianSerieB2011, "2011-2012", "Italy", "Serie B", 2);
    
    context = new SoccerSimContext();
    var dutchEredivisie2011 = GetFixtures("2011-2012", "N1");
    await StoreLeagueInfo(context, dutchEredivisie2011, "2011-2012", "Netherlands", "Eredivisie", 1);
    
    context = new SoccerSimContext();
    var portugueseLiga2011 = GetFixtures("2011-2012", "P1");
    await StoreLeagueInfo(context, portugueseLiga2011, "2011-2012", "Portugal", "Liga", 1);
    
    context = new SoccerSimContext();
    var scottishPremierLeague2011 = GetFixtures("2011-2012", "SC0");
    await StoreLeagueInfo(context, scottishPremierLeague2011, "2011-2012", "Scotland", "Premier League", 1);
    
    context = new SoccerSimContext();
    var scottishDivisionOne2011 = GetFixtures("2011-2012", "SC1");
    await StoreLeagueInfo(context, scottishDivisionOne2011, "2011-2012", "Scotland", "Division 1", 2);
    
    context = new SoccerSimContext();
    var scottishDivisionTwo2011 = GetFixtures("2011-2012", "SC2");
    await StoreLeagueInfo(context, scottishDivisionTwo2011, "2011-2012", "Scotland", "Division 2", 3);
    
    context = new SoccerSimContext();
    var scottishDivisionThree2011 = GetFixtures("2011-2012", "SC3");
    await StoreLeagueInfo(context, scottishDivisionThree2011, "2011-2012", "Scotland", "Division 3", 4);
    
    context = new SoccerSimContext();
    var spanishPrimeraDivision2011 = GetFixtures("2011-2012", "SP1");
    await StoreLeagueInfo(context, spanishPrimeraDivision2011, "2011-2012", "Spain", "Primera Division", 1);
    
    context = new SoccerSimContext();
    var spanishSegundaDivision2011 = GetFixtures("2011-2012", "SP2");
    await StoreLeagueInfo(context, spanishSegundaDivision2011, "2011-2012", "Spain", "Segunda Division", 2);
    
    context = new SoccerSimContext();
    var turkishSuperLig2011 = GetFixtures("2011-2012", "T1");
    await StoreLeagueInfo(context, turkishSuperLig2011, "2011-2012", "Turkey", "Super Lig", 1);

    #endregion

    #region 2012

    context = new SoccerSimContext();
    var belgianProLeague2012 = GetFixtures("2012-2013", "B1");
    await StoreLeagueInfo(context, belgianProLeague2012, "2012-2013", "Belgium", "Pro League", 1);
    
    context = new SoccerSimContext();
    var germanBundesliga2012 = GetFixtures("2012-2013", "D1");
    await StoreLeagueInfo(context, germanBundesliga2012, "2012-2013", "Germany", "Bundesliga", 1);
    
    context = new SoccerSimContext();
    var germanBundesliga22012 = GetFixtures("2012-2013", "D2");
    await StoreLeagueInfo(context, germanBundesliga22012, "2012-2013", "Germany", "Bundesliga 2", 2);
    
    context = new SoccerSimContext();
    var englishPremierLeague2012 = GetFixtures("2012-2013", "E0");
    await StoreLeagueInfo(context, englishPremierLeague2012, "2012-2013", "England", "Premier League", 1);
    
    context = new SoccerSimContext();
    var englishChampionship2012 = GetFixtures("2012-2013", "E1");
    await StoreLeagueInfo(context, englishChampionship2012, "2012-2013", "England", "Championship", 2);
    
    context = new SoccerSimContext();
    var englishLeagueOne2012 = GetFixtures("2012-2013", "E2");
    await StoreLeagueInfo(context, englishLeagueOne2012, "2012-2013", "England", "League One", 3);
    
    context = new SoccerSimContext();
    var englishLeagueTwo2012 = GetFixtures("2012-2013", "E3");
    await StoreLeagueInfo(context, englishLeagueTwo2012, "2012-2013", "England", "League Two", 4);

    context = new SoccerSimContext();
    var englishConference2012 = GetFixtures("2012-2013", "EC");
    await StoreLeagueInfo(context, englishConference2012, "2012-2013", "England", "Conference", 5);
    
    context = new SoccerSimContext();
    var frenchLigue12012 = GetFixtures("2012-2013", "F1");
    await StoreLeagueInfo(context, frenchLigue12012, "2012-2013", "France", "Ligue 1", 1);

    context = new SoccerSimContext();
    var frenchLigue22012 = GetFixtures("2012-2013", "F2");
    await StoreLeagueInfo(context, frenchLigue22012, "2012-2013", "France", "Ligue 2", 2);
    
    context = new SoccerSimContext();
    var greekSuperLeague2012 = GetFixtures("2012-2013", "G1");
    await StoreLeagueInfo(context, greekSuperLeague2012, "2012-2013", "Greece", "Super League", 1);
    
    context = new SoccerSimContext();
    var italianSerieA2012 = GetFixtures("2012-2013", "I1");
    await StoreLeagueInfo(context, italianSerieA2012, "2012-2013", "Italy", "Serie A", 1);
    
    context = new SoccerSimContext();
    var italianSerieB2012 = GetFixtures("2012-2013", "I2");
    await StoreLeagueInfo(context, italianSerieB2012, "2012-2013", "Italy", "Serie B", 2);
    
    context = new SoccerSimContext();
    var dutchEredivisie2012 = GetFixtures("2012-2013", "N1");
    await StoreLeagueInfo(context, dutchEredivisie2012, "2012-2013", "Netherlands", "Eredivisie", 1);
    
    context = new SoccerSimContext();
    var portugueseLiga2012 = GetFixtures("2012-2013", "P1");
    await StoreLeagueInfo(context, portugueseLiga2012, "2012-2013", "Portugal", "Liga", 1);
    
    context = new SoccerSimContext();
    var scottishPremierLeague2012 = GetFixtures("2012-2013", "SC0");
    await StoreLeagueInfo(context, scottishPremierLeague2012, "2012-2013", "Scotland", "Premier League", 1);
    
    context = new SoccerSimContext();
    var scottishDivisionOne2012 = GetFixtures("2012-2013", "SC1");
    await StoreLeagueInfo(context, scottishDivisionOne2012, "2012-2013", "Scotland", "Division 1", 2);
    
    context = new SoccerSimContext();
    var scottishDivisionTwo2012 = GetFixtures("2012-2013", "SC2");
    await StoreLeagueInfo(context, scottishDivisionTwo2012, "2012-2013", "Scotland", "Division 2", 3);
    
    context = new SoccerSimContext();
    var scottishDivisionThree2012 = GetFixtures("2012-2013", "SC3");
    await StoreLeagueInfo(context, scottishDivisionThree2012, "2012-2013", "Scotland", "Division 3", 4);
    
    context = new SoccerSimContext();
    var spanishPrimeraDivision2012 = GetFixtures("2012-2013", "SP1");
    await StoreLeagueInfo(context, spanishPrimeraDivision2012, "2012-2013", "Spain", "Primera Division", 1);
    
    context = new SoccerSimContext();
    var spanishSegundaDivision2012 = GetFixtures("2012-2013", "SP2");
    await StoreLeagueInfo(context, spanishSegundaDivision2012, "2012-2013", "Spain", "Segunda Division", 2);
    
    context = new SoccerSimContext();
    var turkishSuperLig2012 = GetFixtures("2012-2013", "T1");
    await StoreLeagueInfo(context, turkishSuperLig2012, "2012-2013", "Turkey", "Super Lig", 1);

    #endregion

    #region 2013

    context = new SoccerSimContext();
    var belgianProLeague2013 = GetFixtures("2013-2014", "B1");
    await StoreLeagueInfo(context, belgianProLeague2013, "2013-2014", "Belgium", "Pro League", 1);
    
    context = new SoccerSimContext();
    var germanBundesliga2013 = GetFixtures("2013-2014", "D1");
    await StoreLeagueInfo(context, germanBundesliga2013, "2013-2014", "Germany", "Bundesliga", 1);
    
    context = new SoccerSimContext();
    var germanBundesliga22013 = GetFixtures("2013-2014", "D2");
    await StoreLeagueInfo(context, germanBundesliga22013, "2013-2014", "Germany", "Bundesliga 2", 2);
    
    context = new SoccerSimContext();
    var englishPremierLeague2013 = GetFixtures("2013-2014", "E0");
    await StoreLeagueInfo(context, englishPremierLeague2013, "2013-2014", "England", "Premier League", 1);
    
    context = new SoccerSimContext();
    var englishChampionship2013 = GetFixtures("2013-2014", "E1");
    await StoreLeagueInfo(context, englishChampionship2013, "2013-2014", "England", "Championship", 2);
    
    context = new SoccerSimContext();
    var englishLeagueOne2013 = GetFixtures("2013-2014", "E2");
    await StoreLeagueInfo(context, englishLeagueOne2013, "2013-2014", "England", "League One", 3);
    
    context = new SoccerSimContext();
    var englishLeagueTwo2013 = GetFixtures("2013-2014", "E3");
    await StoreLeagueInfo(context, englishLeagueTwo2013, "2013-2014", "England", "League Two", 4);
    
    context = new SoccerSimContext();
    var englishConference2013 = GetFixtures("2013-2014", "EC");
    await StoreLeagueInfo(context, englishConference2013, "2013-2014", "England", "Conference", 5);
    
    context = new SoccerSimContext();
    var frenchLigue12013 = GetFixtures("2013-2014", "F1");
    await StoreLeagueInfo(context, frenchLigue12013, "2013-2014", "France", "Ligue 1", 1);
    
    context = new SoccerSimContext();
    var frenchLigue22013 = GetFixtures("2013-2014", "F2");
    await StoreLeagueInfo(context, frenchLigue22013, "2013-2014", "France", "Ligue 2", 2);
    
    context = new SoccerSimContext();
    var greecesuperLeague2013 = GetFixtures("2013-2014", "G1");
    await StoreLeagueInfo(context, greecesuperLeague2013, "2013-2014", "Greece", "Super League", 1);
    
    context = new SoccerSimContext();
    var italianSerieA2013 = GetFixtures("2013-2014", "I1");
    await StoreLeagueInfo(context, italianSerieA2013, "2013-2014", "Italy", "Serie A", 1);
    
    context = new SoccerSimContext();
    var italianSerieB2013 = GetFixtures("2013-2014", "I2");
    await StoreLeagueInfo(context, italianSerieB2013, "2013-2014", "Italy", "Serie B", 2);
    
    context = new SoccerSimContext();
    var dutchEredivisie2013 = GetFixtures("2013-2014", "N1");
    await StoreLeagueInfo(context, dutchEredivisie2013, "2013-2014", "Netherlands", "Eredivisie", 1);
    
    context = new SoccerSimContext();
    var portugueseLiga2013 = GetFixtures("2013-2014", "P1");
    await StoreLeagueInfo(context, portugueseLiga2013, "2013-2014", "Portugal", "Liga", 1);
    
    context = new SoccerSimContext();
    var scottishPremiership2013 = GetFixtures("2013-2014", "SC0");
    await StoreLeagueInfo(context, scottishPremiership2013, "2013-2014", "Scotland", "Premiership", 1);
    
    context = new SoccerSimContext();
    var scottishChampionship2013 = GetFixtures("2013-2014", "SC1");
    await StoreLeagueInfo(context, scottishChampionship2013, "2013-2014", "Scotland", "Championship", 2);
    
    context = new SoccerSimContext();
    var scottishLeagueOne2013 = GetFixtures("2013-2014", "SC2");
    await StoreLeagueInfo(context, scottishLeagueOne2013, "2013-2014", "Scotland", "League One", 3);
    
    context = new SoccerSimContext();
    var scottishLeagueTwo2013 = GetFixtures("2013-2014", "SC3");
    await StoreLeagueInfo(context, scottishLeagueTwo2013, "2013-2014", "Scotland", "League Two", 4);
    
    context = new SoccerSimContext();
    var spanishPrimeraDivision2013 = GetFixtures("2013-2014", "SP1");
    await StoreLeagueInfo(context, spanishPrimeraDivision2013, "2013-2014", "Spain", "Primera Division", 1);
    
    context = new SoccerSimContext();
    var spanishSegundaDivision2013 = GetFixtures("2013-2014", "SP2");
    await StoreLeagueInfo(context, spanishSegundaDivision2013, "2013-2014", "Spain", "Segunda Division", 2);
    
    context = new SoccerSimContext();
    var turkishSuperLig2013 = GetFixtures("2013-2014", "T1");
    await StoreLeagueInfo(context, turkishSuperLig2013, "2013-2014", "Turkey", "Super Lig", 1);

    #endregion
    
    #region 2014

    context = new SoccerSimContext();
    var belgianProLeague2014 = GetFixtures("2014-2015", "B1");
    await StoreLeagueInfo(context, belgianProLeague2014, "2014-2015", "Belgium", "Pro League", 1);
    
    context = new SoccerSimContext();
    var germanBundesliga2014 = GetFixtures("2014-2015", "D1");
    await StoreLeagueInfo(context, germanBundesliga2014, "2014-2015", "Germany", "Bundesliga", 1);
    
    context = new SoccerSimContext();
    var german2Bundesliga2014 = GetFixtures("2014-2015", "D2");
    await StoreLeagueInfo(context, german2Bundesliga2014, "2014-2015", "Germany", "2. Bundesliga", 2);
    
    context = new SoccerSimContext();
    var englishPremierLeague2014 = GetFixtures("2014-2015", "E0");
    await StoreLeagueInfo(context, englishPremierLeague2014, "2014-2015", "England", "Premier League", 1);
    
    context = new SoccerSimContext();
    var englishChampionship2014 = GetFixtures("2014-2015", "E1");
    await StoreLeagueInfo(context, englishChampionship2014, "2014-2015", "England", "Championship", 2);
    
    context = new SoccerSimContext();
    var englishLeagueOne2014 = GetFixtures("2014-2015", "E2");
    await StoreLeagueInfo(context, englishLeagueOne2014, "2014-2015", "England", "League One", 3);
    
    context = new SoccerSimContext();
    var englishLeagueTwo2014 = GetFixtures("2014-2015", "E3");
    await StoreLeagueInfo(context, englishLeagueTwo2014, "2014-2015", "England", "League Two", 4);
    
    context = new SoccerSimContext();
    var englishConference2014 = GetFixtures("2014-2015", "EC");
    await StoreLeagueInfo(context, englishConference2014, "2014-2015", "England", "Conference", 5);
    
    context = new SoccerSimContext();
    var frenchLigue12014 = GetFixtures("2014-2015", "F1");
    await StoreLeagueInfo(context, frenchLigue12014, "2014-2015", "France", "Ligue 1", 1);
    
    context = new SoccerSimContext();
    var frenchLigue22014 = GetFixtures("2014-2015", "F2");
    await StoreLeagueInfo(context, frenchLigue22014, "2014-2015", "France", "Ligue 2", 2);
    
    context = new SoccerSimContext();
    var greecesuperLeague2014 = GetFixtures("2014-2015", "G1");
    await StoreLeagueInfo(context, greecesuperLeague2014, "2014-2015", "Greece", "Super League", 1);
    
    context = new SoccerSimContext();
    var italianSerieA2014 = GetFixtures("2014-2015", "I1");
    await StoreLeagueInfo(context, italianSerieA2014, "2014-2015", "Italy", "Serie A", 1);
    
    context = new SoccerSimContext();
    var italianSerieB2014 = GetFixtures("2014-2015", "I2");
    await StoreLeagueInfo(context, italianSerieB2014, "2014-2015", "Italy", "Serie B", 2);
    
    context = new SoccerSimContext();
    var dutchEredivisie2014 = GetFixtures("2014-2015", "N1");
    await StoreLeagueInfo(context, dutchEredivisie2014, "2014-2015", "Netherlands", "Eredivisie", 1);
    
    context = new SoccerSimContext();
    var portugueseLiga2014 = GetFixtures("2014-2015", "P1");
    await StoreLeagueInfo(context, portugueseLiga2014, "2014-2015", "Portugal", "Liga ZON Sagres", 1);
    
    context = new SoccerSimContext();
    var scottishPremiership2014 = GetFixtures("2014-2015", "SC0");
    await StoreLeagueInfo(context, scottishPremiership2014, "2014-2015", "Scotland", "Premiership", 1);
    
    context = new SoccerSimContext();
    var scottishChampionship2014 = GetFixtures("2014-2015", "SC1");
    await StoreLeagueInfo(context, scottishChampionship2014, "2014-2015", "Scotland", "Championship", 2);
    
    context = new SoccerSimContext();
    var scottishLeagueOne2014 = GetFixtures("2014-2015", "SC2");
    await StoreLeagueInfo(context, scottishLeagueOne2014, "2014-2015", "Scotland", "League One", 3);
    
    context = new SoccerSimContext();
    var scottishLeagueTwo2014 = GetFixtures("2014-2015", "SC3");
    await StoreLeagueInfo(context, scottishLeagueTwo2014, "2014-2015", "Scotland", "League Two", 4);
    
    context = new SoccerSimContext();
    var spanishPrimeraDivision2014 = GetFixtures("2014-2015", "SP1");
    await StoreLeagueInfo(context, spanishPrimeraDivision2014, "2014-2015", "Spain", "Primera Division", 1);
    
    context = new SoccerSimContext();
    var spanishSegundaDivision2014 = GetFixtures("2014-2015", "SP2");
    await StoreLeagueInfo(context, spanishSegundaDivision2014, "2014-2015", "Spain", "Segunda Division", 2);
    
    context = new SoccerSimContext();
    var turkishSuperLig2014 = GetFixtures("2014-2015", "T1");
    await StoreLeagueInfo(context, turkishSuperLig2014, "2014-2015", "Turkey", "Super Lig", 1);

    #endregion
    
    #region 2015

    context = new SoccerSimContext();
    var belgianProLeague2015 = GetFixtures("2015-2016", "B1");
    await StoreLeagueInfo(context, belgianProLeague2015, "2015-2016", "Belgium", "Pro League", 1);
    
    context = new SoccerSimContext();
    var germanBundesliga2015 = GetFixtures("2015-2016", "D1");
    await StoreLeagueInfo(context, germanBundesliga2015, "2015-2016", "Germany", "Bundesliga", 1);
    
    context = new SoccerSimContext();
    var germanBundesliga22015 = GetFixtures("2015-2016", "D2");
    await StoreLeagueInfo(context, germanBundesliga22015, "2015-2016", "Germany", "Bundesliga 2", 2);
    
    context = new SoccerSimContext();
    var englishPremierLeague2015 = GetFixtures("2015-2016", "E0");
    await StoreLeagueInfo(context, englishPremierLeague2015, "2015-2016", "England", "Premier League", 1);
    
    context = new SoccerSimContext();
    var englishChampionship2015 = GetFixtures("2015-2016", "E1");
    await StoreLeagueInfo(context, englishChampionship2015, "2015-2016", "England", "Championship", 2);
    
    context = new SoccerSimContext();
    var englishLeagueOne2015 = GetFixtures("2015-2016", "E2");
    await StoreLeagueInfo(context, englishLeagueOne2015, "2015-2016", "England", "League One", 3);

    context = new SoccerSimContext();
    var englishLeagueTwo2015 = GetFixtures("2015-2016", "E3");
    await StoreLeagueInfo(context, englishLeagueTwo2015, "2015-2016", "England", "League Two", 4);
    
    context = new SoccerSimContext();
    var englishConference2015 = GetFixtures("2015-2016", "EC");
    await StoreLeagueInfo(context, englishConference2015, "2015-2016", "England", "Conference", 5);
    
    context = new SoccerSimContext();
    var frenchLigue12015 = GetFixtures("2015-2016", "F1");
    await StoreLeagueInfo(context, frenchLigue12015, "2015-2016", "France", "Ligue 1", 1);
    
    context = new SoccerSimContext();
    var frenchLigue22015 = GetFixtures("2015-2016", "F2");
    await StoreLeagueInfo(context, frenchLigue22015, "2015-2016", "France", "Ligue 2", 2);
    
    context= new SoccerSimContext();
    var greecSuperLeague2015 = GetFixtures("2015-2016", "G1");  
    await StoreLeagueInfo(context, greecSuperLeague2015, "2015-2016", "Greece", "Super League", 1);
    
    context = new SoccerSimContext();
    var italianSerieA2015 = GetFixtures("2015-2016", "I1");
    await StoreLeagueInfo(context, italianSerieA2015, "2015-2016", "Italy", "Serie A", 1);
    
    context = new SoccerSimContext();
    var italianSerieB2015 = GetFixtures("2015-2016", "I2");
    await StoreLeagueInfo(context, italianSerieB2015, "2015-2016", "Italy", "Serie B", 2);
    
    context = new SoccerSimContext();
    var dutchEredivisie2015 = GetFixtures("2015-2016", "N1");
    await StoreLeagueInfo(context, dutchEredivisie2015, "2015-2016", "Netherlands", "Eredivisie", 1);
    
    context = new SoccerSimContext();
    var portugueseLiga2015 = GetFixtures("2015-2016", "P1");
    await StoreLeagueInfo(context, portugueseLiga2015, "2015-2016", "Portugal", "Liga", 1);
    
    context = new SoccerSimContext();
    var scottishPremiership2015 = GetFixtures("2015-2016", "SC0");
    await StoreLeagueInfo(context, scottishPremiership2015, "2015-2016", "Scotland", "Premiership", 1);
    
    context = new SoccerSimContext();
    var scottishChampionship2015 = GetFixtures("2015-2016", "SC1");
    await StoreLeagueInfo(context, scottishChampionship2015, "2015-2016", "Scotland", "Championship", 2);
    
    context = new SoccerSimContext();
    var scottishLeagueOne2015 = GetFixtures("2015-2016", "SC2");
    await StoreLeagueInfo(context, scottishLeagueOne2015, "2015-2016", "Scotland", "League One", 3);
    
    context = new SoccerSimContext();
    var scottishLeagueTwo2015 = GetFixtures("2015-2016", "SC3");
    await StoreLeagueInfo(context, scottishLeagueTwo2015, "2015-2016", "Scotland", "League Two", 4);
    
    context = new SoccerSimContext();
    var spanishPrimera2015 = GetFixtures("2015-2016", "SP1");
    await StoreLeagueInfo(context, spanishPrimera2015, "2015-2016", "Spain", "Primera Division", 1);
    
    context = new SoccerSimContext();
    var spanishSegunda2015 = GetFixtures("2015-2016", "SP2");
    await StoreLeagueInfo(context, spanishSegunda2015, "2015-2016", "Spain", "Segunda Division", 2);
    
    context = new SoccerSimContext();
    var turkishSuperLig2015 = GetFixtures("2015-2016", "T1");
    await StoreLeagueInfo(context, turkishSuperLig2015, "2015-2016", "Turkey", "Super Lig", 1);

    #endregion
    
    #region 2016
    
    context = new SoccerSimContext();
    var belgianFirstDivisionA2016 = GetFixtures("2016-2017", "B1");
    await StoreLeagueInfo(context, belgianFirstDivisionA2016, "2016-2017", "Belgium", "First Division A", 1);
    
    context = new SoccerSimContext();
    var germanBundesliga2016 = GetFixtures("2016-2017", "D1");
    await StoreLeagueInfo(context, germanBundesliga2016, "2016-2017", "Germany", "Bundesliga", 1);
    
    context = new SoccerSimContext();
    var germanBundesliga22016 = GetFixtures("2016-2017", "D2");
    await StoreLeagueInfo(context, germanBundesliga22016, "2016-2017", "Germany", "Bundesliga 2", 2);
    
    context = new SoccerSimContext();
    var englishPremierLeague2016 = GetFixtures("2016-2017", "E0");
    await StoreLeagueInfo(context, englishPremierLeague2016, "2016-2017", "England", "Premier League", 1);

    context = new SoccerSimContext();
    var englishChampionship2016 = GetFixtures("2016-2017", "E1");
    await StoreLeagueInfo(context, englishChampionship2016, "2016-2017", "England", "Championship", 2);
    
    context = new SoccerSimContext();
    var englishLeagueOne2016 = GetFixtures("2016-2017", "E2");
    await StoreLeagueInfo(context, englishLeagueOne2016, "2016-2017", "England", "League One", 3);
    
    context = new SoccerSimContext();
    var englishLeagueTwo2016 = GetFixtures("2016-2017", "E3");
    await StoreLeagueInfo(context, englishLeagueTwo2016, "2016-2017", "England", "League Two", 4);
    
    context = new SoccerSimContext();
    var englishConference2016 = GetFixtures("2016-2017", "EC");
    await StoreLeagueInfo(context, englishConference2016, "2016-2017", "England", "Conference", 5);
    
    context = new SoccerSimContext();
    var frenchLigue12016 = GetFixtures("2016-2017", "F1");
    await StoreLeagueInfo(context, frenchLigue12016, "2016-2017", "France", "Ligue 1", 1);
    
    context = new SoccerSimContext();
    var frenchLigue22016 = GetFixtures("2016-2017", "F2");
    await StoreLeagueInfo(context, frenchLigue22016, "2016-2017", "France", "Ligue 2", 2);
    
    context = new SoccerSimContext();
    var greecSuperLeague2016 = GetFixtures("2016-2017", "G1");
    await StoreLeagueInfo(context, greecSuperLeague2016, "2016-2017", "Greece", "Super League", 1);
    
    context = new SoccerSimContext();
    var italianSerieA2016 = GetFixtures("2016-2017", "I1");
    await StoreLeagueInfo(context, italianSerieA2016, "2016-2017", "Italy", "Serie A", 1);
    
    context = new SoccerSimContext();
    var italianSerieB2016 = GetFixtures("2016-2017", "I2");
    await StoreLeagueInfo(context, italianSerieB2016, "2016-2017", "Italy", "Serie B", 2);
    
    context = new SoccerSimContext();
    var dutchEredivisie2016 = GetFixtures("2016-2017", "N1");
    await StoreLeagueInfo(context, dutchEredivisie2016, "2016-2017", "Netherlands", "Eredivisie", 1);
    
    context = new SoccerSimContext();
    var portugueseLiga2016 = GetFixtures("2016-2017", "P1");
    await StoreLeagueInfo(context, portugueseLiga2016, "2016-2017", "Portugal", "Liga ZON Sagres", 1);
    
    context = new SoccerSimContext();
    var scottishPremiership2016 = GetFixtures("2016-2017", "SC0");
    await StoreLeagueInfo(context, scottishPremiership2016, "2016-2017", "Scotland", "Premiership", 1);
    
    context = new SoccerSimContext();
    var scottishChampionship2016 = GetFixtures("2016-2017", "SC1");
    await StoreLeagueInfo(context, scottishChampionship2016, "2016-2017", "Scotland", "Championship", 2);
    
    context = new SoccerSimContext();
    var scottishLeagueOne2016 = GetFixtures("2016-2017", "SC2");
    await StoreLeagueInfo(context, scottishLeagueOne2016, "2016-2017", "Scotland", "League One", 3);
    
    context = new SoccerSimContext();
    var scottishLeagueTwo2016 = GetFixtures("2016-2017", "SC3");
    await StoreLeagueInfo(context, scottishLeagueTwo2016, "2016-2017", "Scotland", "League Two", 4);
    
    context = new SoccerSimContext();
    var spanishPrimeraDivision2016 = GetFixtures("2016-2017", "SP1");
    await StoreLeagueInfo(context, spanishPrimeraDivision2016, "2016-2017", "Spain", "Primera Division", 1);
    
    context = new SoccerSimContext();
    var spanishSegundaDivision2016 = GetFixtures("2016-2017", "SP2");
    await StoreLeagueInfo(context, spanishSegundaDivision2016, "2016-2017", "Spain", "Segunda Division", 2);
    
    context = new SoccerSimContext();
    var turkishSuperLig2016 = GetFixtures("2016-2017", "T1");
    await StoreLeagueInfo(context, turkishSuperLig2016, "2016-2017", "Turkey", "Super Lig", 1);
    
    #endregion
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
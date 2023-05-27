using CsvHelper.Configuration.Attributes;

namespace Seed.Models;

public class OnwardBaseFixture2020
{
    [Index(0)]
    public string Div { get; set; }
    [Index(1)]
    public string Date { get; set; }
    [Index(2)]
    public string Time { get; set; }
    [Index(3)]
    public string HomeTeam { get; set; }
    [Index(4)]
    public string AwayTeam { get; set; }
    [Index(5)]
    public int? FTHG { get; set; }
    [Index(6)]
    public int? FTAG { get; set; }
    [Index(7)]
    public string FTR { get; set; }

    [Index(8)] [Default(0)] public int? HTHG { get; set; }
    [Index(9)] [Default(0)] public int? HTAG { get; set; }
    [Index(10)]
    public string HTR { get; set; }
}

public class OnwardBaseFixture1993 {
    //    Div,Date,HomeTeam,AwayTeam,FTHG,FTAG,FTR,,,,,,,,,,,,,,,,,,,,,
    [Index(0)]
    public string Div { get; set; }
    [Index(1)]
    public string Date { get; set; }
    [Index(2)]
    public string HomeTeam { get; set; }
    [Index(3)]
    public string AwayTeam { get; set; }
    [Index(4)]
    public int? FTHG { get; set; }
    [Index(5)]
    public int? FTAG { get; set; }
    [Index(6)]
    public string FTR { get; set; }

    [Index(7)] [Default(0)] public int? HTHG { get; set; }
    [Index(8)] [Default(0)] public int? HTAG { get; set; }
    [Index(9)]
    public string HTR { get; set; }
}
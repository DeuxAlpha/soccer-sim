namespace Database.Enums
{
    public enum CompetitionType
    {
        /// <summary>E.g. To decide who gets promoted/relegated.</summary>
        PlayOff,
        /// <summary>Cup played within a country. E.g. DFB-Pokal</summary>
        NationalCup,
        /// <summary>Cup played within a continent. E.g. Champions League</summary>
        ContinentalCup,
        /// <summary>Cup played on a world level. E.g. Club World Cup</summary>
        IntercontinentalCup,
        /// <summary>Cup played by national teams within a continent. E.g. Euro</summary>
        InternationalContinentalCup,
        /// <summary>Cup played by national teams on a world level. E.g. World Cup</summary>
        InternationalWorldCup
    }
}
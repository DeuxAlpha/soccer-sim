export type ImportRequest = {
  Collection: Item[];
  Continent
  Country
  League
  Division
}

type Item = {
  HomeTeamName
  AwayTeamName
  HomeHalfTimeGoals
  AwayHalfTimeGoals
  HomeFullTimeGoals
  AwayFullTimeGoals
  Timestamp
}


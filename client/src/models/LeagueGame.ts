export type LeagueGame = {
  awayTeamName: string;
  awayGoals: number;
  awayHalfGoals: number;
  awayPossession: number;
  awayShots: number;
  awayShotsOnGoal: number;
  homeTeamName: string;
  homeGoals: number;
  homeHalfGoals: number;
  homePossession: number;
  homeShots: number;
  homeShotsOnGoal: number;
  fixture: string;
  score: string;
  halfTimeScore: string;
  possession: string;
  shots: string;
  shotsOnGoal: string;
  story: string[];
  gameDay: number;
}
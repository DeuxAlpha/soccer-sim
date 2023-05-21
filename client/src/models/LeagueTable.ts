export type LeagueTable = {
  positions: LeagueTablePosition[];
  homePositions: LeagueTablePosition[];
  awayPositions: LeagueTablePosition[];
  previousPositions: LeagueTablePosition[];
  previousHomePositions: LeagueTablePosition[];
  previousAwayPositions: LeagueTablePosition[];
  promotedTeamsStart: number;
  promotedTeamsEnd: number;
  promotionPlayOffTeamsStart: number;
  promotionPlayOffTeamsEnd: number;
  relegatedTeamsStart: number;
  relegatedTeamsEnd: number;
  relegationPlayOffTeamsStart: number;
  relegationPlayOffTeamsEnd: number;
}

export type LeagueTablePosition = {
  teamName: string;
  attackStrength: number;
  defenseStrength: number;
  goalieStrength: number;
  averageStrength: number;
  inferredStrength?: number;
  position: number;
  points: number;
  goalsFor: number;
  goalsAgainst: number;
  goalDifference: number;
  wins: number;
  draws: number;
  losses: number;
  games: number;
  shots: number;
  shotsOnGoal: number;
  shotsAgainst: number;
  shotsAgainstGoal: number;
  championFlag: boolean;
  promotionFlag: boolean;
  relegationFlag: boolean;
}

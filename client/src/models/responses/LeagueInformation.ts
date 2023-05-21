export type LeagueInformation = {
  season: string;
  name: string;
  abbreviation?: string;
  shotAccuracyModifier: number;
  paceModifier: number;
  maxHomeAdvantage: number;
  maxAwayDisadvantage: number;
  actionsPerMinute: number;
  maxProgressChance: number;
  minProgressChance: number;
  rounds: number;
  divisionName: string;
  image?: string;
}


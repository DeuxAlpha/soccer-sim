import {GameQuery} from "@/types/queries/GameQuery";
import {AppQuery} from "@/types/queries/AppQuery";

export class StaticQueryManager<T> {
  public static GameQuery: GameQuery | any = {};
  public static AppQuery: AppQuery | any = {};

  static BuildFinalQuery() {
    const query: any = {};
    if (this.GameQuery.season) query.season = this.GameQuery.season;
    if (this.GameQuery.gameDay) query.gameDay = this.GameQuery.gameDay;
    if (this.GameQuery.league) query.league = this.GameQuery.league;
    if (this.GameQuery.continent) query.continent = this.GameQuery.continent;
    if (this.GameQuery.division) query.division = this.GameQuery.division;
    if(this.GameQuery.country) query.country = this.GameQuery.country;
    if (this.AppQuery.sidepanel) query.sidepanl = this.AppQuery.sidepanel;
    return query;
  }
}

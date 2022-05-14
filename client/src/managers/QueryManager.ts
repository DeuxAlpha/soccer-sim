import {GameQuery} from "@/types/queries/GameQuery";
import {AppQuery} from "@/types/queries/AppQuery";

// This is not working because each component defines its own manager
export class QueryManager {
  public GameQuery: GameQuery | any = {};
  public AppQuery: AppQuery | any = {};

  BuildFinalQuery() {
    const query: any = {};
    if (this.GameQuery.season) query.season = this.GameQuery.season;
    if (this.GameQuery.gameDay) query.gameDay = this.GameQuery.gameDay;
    if (this.GameQuery.league) query.league = this.GameQuery.league;
    if (this.GameQuery.continent) query.continent = this.GameQuery.continent;
    if (this.GameQuery.division) query.division = this.GameQuery.division;
    if (this.GameQuery.country) query.country = this.GameQuery.country;
    if (this.AppQuery.sidepanel) query.sidepanel = this.AppQuery.sidepanel;
    return query;
  }
}

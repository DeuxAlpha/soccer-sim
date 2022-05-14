<template>
  <div id="home-page" class="flex-1">
    <div class="flex flex-row justify-between">
      <div class="flex flex-row justify-start text-sm">
        <span v-if="selectedSeason" @click="onResetSeasonClicked">
          > {{ selectedSeason }}
        </span>
        <span v-if="selectedContinent" @click="onResetContinentClicked">
          > {{ selectedContinent }}
        </span>
        <span v-if="selectedCountry" @click="onResetCountryClicked">
          > {{ selectedCountry }}
        </span>
        <span v-if="selectedDivision" @click="onResetDivisionClicked">
          > {{ selectedDivision }}
        </span>
        <span v-if="selectedLeague" @click="onResetLeagueClicked">
          > {{ selectedLeague }}
        </span>
      </div>
      <div v-show="leagueTable != null" class="flex flex-row justify-end text-sm">
        <div class="flex flex-col">
          <label for="average-strength">Avg. Strength</label>
          <input id="average-strength" type="number" step=".1" v-model="avgStrength">
        </div>
        <div class="flex flex-col">
          <label for="strength-variance">Var. Strength</label>
          <input id="strength-variance" type="number" step=".1" v-model="varStrength">
        </div>
        <button @click="getStrengthsToThisGameDay">Get Strengths up to this game day</button>
      </div>
    </div>
    <div class="text-lg">
      <span v-if="!selectedSeason" v-for="season of seasons" :key="season"
            @click="onSeasonClicked(season)">
        {{ season }}
      </span>
      <span v-if="!selectedContinent" v-for="continent of continents" :key="continent.name"
            @click="onContinentClicked(continent.name)">
        {{ continent.name }}
      </span>
      <span v-if="!selectedCountry" v-for="country of countries" :key="country.name"
            @click="onCountryClicked(country.name)">
        {{ country.name }}
      </span>
      <span v-if="!selectedDivision" v-for="division of divisions" :key="division.name"
            @click="onDivisionClicked(division.name)">
        {{ division.name }}
      </span>
      <span v-if="!selectedLeague" v-for="league of leagues" :key="league.name" @click="onLeagueClicked(league.name)">
        {{ league.name }}
      </span>
    </div>
    <label for="game-day" v-show="lastMatchDay !== 0">
      <span>Game Day</span>
      <select v-model="selectedGameDay" id="game-day" @change="onGameDayChanged">
        <option v-for="gameDay of lastMatchDay" :value="gameDay">{{ gameDay }}</option>
      </select>
    </label>
    <div class="flex md:flex-row flex-col space-x-2">
      <div class="md:w-1/4 w-full">
        <CGamePlan @game-selected="onGameSelected" :games="leagueGames"/>
      </div>
      <div class="md:w-3/4 w-full">
        <CTable league="leagueName" :season="selectedSeason" :table="leagueTable"/>
      </div>
    </div>
    <transition name="game-view-transition">
      <ADialog v-if="openGameDialog" @close-request="openGameDialog = $event">
        <CGameView :game="selectedGame"
                   :league="selectedLeague"
                   :season="selectedSeason"
                   @update-results="onResultsUpdated"
                   @exit-request="openGameDialog=false"/>
      </ADialog>
    </transition>
    <div v-show="leagueTable" class="flex h-8 flex-col space-y-4 my-8 justify-around">
      <ASeparator x-margin="2" color="red">Danger Zone</ASeparator>
      <div class="flex flex-row space-x-2">
        <button
            @click="onRecreateGamePlanClicked"
            class="py-2 px-4 bg-blue-300 text-white hover:bg-blue-400 focus:bg-blue-500 active:bg-blue-500">
          Create new gameplan
        </button>
        <button
            @click="onResimulateGamesClicked"
            class="py-2 px-4 bg-blue-300 text-white hover:bg-blue-400 focus:bg-blue-500 active:bg-blue-500">
          Resimulate games
        </button>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import {Vue, Component, Provide} from "vue-property-decorator";
import {LeagueGame} from "@/models/LeagueGame";
import CGamePlan from "@/components/structure/CGamePlan.vue";
import {LeagueTable} from "@/models/LeagueTable";
import CTable from "@/components/structure/CTable.vue";
import {StrengthResponse} from "@/models/responses/StrengthResponse";
import {GameQuery} from "@/types/queries/GameQuery";
import CGameView from "@/components/structure/CGameView.vue";
import ADialog from '@/components/functionality/dialog/ADialog.vue';
import ASeparator from "@/components/functionality/separator/ASeparator.vue"
import {GameScore} from "@/types/GameScore";
import {QueryManager} from "@/managers/QueryManager";

@Component({
  name: 'Home',
  components: {CTable, CGamePlan, CGameView, ADialog, ASeparator}
})
export default class Home extends Vue {
  seasons: string[] = [];
  continents: any[] = [];
  countries: any[] = [];
  divisions: any[] = [];
  leagues: any[] = [];

  selectedSeason = '';
  selectedContinent = '';
  selectedCountry = '';
  selectedDivision = '';
  selectedLeague = '';

  leagueGames: LeagueGame[] = [];
  leagueTable: LeagueTable | null = null;

  selectedGameDay = 1;
  lastMatchDay = 0;
  lastCompletedMatchDay = 0;

  avgStrength = 900;
  varStrength = 500;

  selectedGame?: LeagueGame;
  openGameDialog = false;


  async mounted() {
    const querySeason = this.$route.query.season;
    if (querySeason) this.selectedSeason = querySeason as string;
    const queryContinent = this.$route.query.continent;
    if (queryContinent) this.selectedContinent = queryContinent as string;
    const queryCountry = this.$route.query.country;
    if (queryCountry) this.selectedCountry = queryCountry as string;
    const queryDivision = this.$route.query.division;
    if (queryDivision) this.selectedDivision = queryDivision as string;
    const queryLeague = this.$route.query.league;
    if (queryLeague) this.selectedLeague = queryLeague as string;
    const queryGameDay = this.$route.query.gameDay;
    if (queryGameDay) this.selectedGameDay = parseInt(queryGameDay as string);
    await this.getAppropriateNextCollection();
  }

  async getAppropriateNextCollection(): Promise<void> {
    if (this.selectedLeague) {
      if (this.selectedGameDay)
        await this.getGames(this.selectedGameDay);
      else
        await this.getGames(1);
    } else if (this.selectedDivision) {
      await this.getLeagues();
    } else if (this.selectedCountry) {
      await this.getDivisions();
    } else if (this.selectedContinent) {
      await this.getCountries();
    } else if (this.selectedSeason) {
      await this.getContinents();
    } else {
      await this.getSeasons();
    }
  }

  async getSeasons(): Promise<void> {
    await this.axios.get('continents/seasons')
        .then(response => this.seasons = response.data)
        .catch(error => console.dir(error));
  }

  async onSeasonClicked(season: string) {
    this.selectedSeason = season;
    await this.updateRoute();
    await this.getContinents();
  }

  async getContinents(): Promise<void> {
    await this.axios.get(`continents/seasons/${this.selectedSeason}`)
        .then(response => {
          this.continents = response.data
          console.log('continents', this.continents);
        })
        .catch(error => console.dir(error));
  }

  async onContinentClicked(continent: string) {
    this.selectedContinent = continent;
    await this.updateRoute();
    await this.getCountries();
  }

  async getCountries(): Promise<void> {
    await this.axios.get(`countries/continents/${this.selectedContinent}/${this.selectedSeason}`)
        .then(response => {
          this.countries = response.data
          console.log('countries', this.countries);
        })
        .catch(error => console.dir(error));
  }

  async onCountryClicked(country: string) {
    this.selectedCountry = country;
    await this.updateRoute();
    await this.getDivisions();
  }

  async getDivisions(): Promise<void> {
    await this.axios.get(`divisions/countries/${this.selectedCountry}/${this.selectedSeason}`)
        .then(response => {
          this.divisions = response.data
          console.log('divisions', this.divisions);
        })
        .catch(error => console.dir(error));
  }

  async onDivisionClicked(division: string) {
    this.selectedDivision = division;
    await this.updateRoute();
    await this.getLeagues();
  }

  async updateRoute(): Promise<void> {
    const query: GameQuery = {};
    if (this.selectedSeason) query.season = this.selectedSeason;
    if (this.selectedContinent) query.continent = this.selectedContinent;
    if (this.selectedCountry) query.country = this.selectedCountry;
    if (this.selectedDivision) query.division = this.selectedDivision;
    if (this.selectedLeague) query.league = this.selectedLeague;
    if (this.selectedGameDay) query.gameDay = this.selectedGameDay.toString();
    await this.$router.push({
      path: '/',
      query
    })
  }

  async getLeagues(): Promise<void> {
    await this.axios.get(`leagues/divisions/${this.selectedDivision}/${this.selectedSeason}`)
        .then(response => {
          this.leagues = response.data
          console.log('leagues', this.leagues);
        })
        .catch(error => console.dir(error));
  }

  async onLeagueClicked(league: string) {
    this.selectedLeague = league;
    await this.updateRoute();
    await this.getGames(this.selectedGameDay);
  }

  async getGames(matchDay: number): Promise<void> {
    await this.axios.get(`leagues/${this.selectedLeague}/${this.selectedSeason}/matches`)
        .then(async response => {
          this.lastMatchDay = response.data.lastMatchDay;
          this.lastCompletedMatchDay = response.data.lastCompletedMatchDay;
          this.selectedGameDay = matchDay;
          await this.loadMatchDay(matchDay);
        })
        .catch(error => console.dir(error));
  }

  async onGameDayChanged() {
    await this.getGames(this.selectedGameDay);
    await this.updateRoute();
  }

  async loadMatchDay(gameDay: number) {
    await this.axios.get(`leagues/${this.selectedLeague}/${this.selectedSeason}/fixtures/${gameDay}`)
        .then(response => this.leagueGames = response.data)
        .catch(error => console.dir(error));
    await this.axios.get(`leagues/${this.selectedLeague}/${this.selectedSeason}/table/${gameDay}`)
        .then(response => {
          this.leagueTable = response.data
        })
        .catch(error => console.dir(error));
  }

  async onRecreateGamePlanClicked() {
    await this.axios.post(`leagues/gameplan/${this.selectedLeague}/${this.selectedSeason}/override`)
        .then(() => window.location.reload());
  }

  async onResimulateGamesClicked() {
    await this.axios.post(`leagues/${this.selectedLeague}/${this.selectedSeason}/simulate/override`)
        .then(() => window.location.reload());
  }

  async getStrengthsToThisGameDay() {
    const gameDay = this.selectedGameDay;
    await this.axios.post(`leagues/${this.selectedLeague}/${this.selectedSeason}/rank/${gameDay}`, {
      averageStrength: this.avgStrength,
      strengthVariance: this.varStrength
    })
        .then(response => {
          const inferredStrengths = response.data as StrengthResponse[];
          if (!this.leagueTable) return;
          // Planting inferred strengths in current positions view.
          this.leagueTable.positions = this.leagueTable.positions.map(p => {
            p.inferredStrength = inferredStrengths.find(s => s.teamName === p.teamName)!.strength
            return p
          });
          // TODO: Analyze home and away performance.
        }).catch(error => console.dir(error));
  }

  async onGameSelected(game: LeagueGame) {
    this.selectedGame = game;
    this.openGameDialog = true;
  }

  async onResetSeasonClicked() {
    this.selectedSeason = '';
    this.selectedContinent = '';
    this.selectedCountry = '';
    this.selectedDivision = '';
    this.selectedLeague = '';
    this.continents = [];
    this.countries = [];
    this.divisions = [];
    this.leagues = [];
    this.resetSelection();
    await this.updateRoute()
  }

  async onResetContinentClicked() {
    this.selectedContinent = '';
    this.selectedCountry = '';
    this.selectedDivision = '';
    this.selectedLeague = '';
    this.countries = [];
    this.divisions = [];
    this.leagues = [];
    this.resetSelection();
    await this.updateRoute();
  }

  async onResetCountryClicked() {
    this.selectedCountry = '';
    this.selectedDivision = '';
    this.selectedLeague = '';
    this.divisions = [];
    this.leagues = [];
    this.resetSelection();
    await this.updateRoute();
  }

  async onResetDivisionClicked() {
    this.selectedDivision = '';
    this.selectedLeague = '';
    this.leagues = [];
    this.resetSelection();
    await this.updateRoute();
  }

  async onResetLeagueClicked() {
    this.selectedLeague = '';
    this.resetSelection();
    await this.updateRoute();
  }

  resetSelection() {
    this.leagueGames = [];
    this.leagueTable = null;
    this.selectedGameDay = 1;
    this.lastMatchDay = 0;
    this.lastCompletedMatchDay = 0;
  }

  onResultsUpdated(results: GameScore) {
    console.log('new score line', results);
    window.location.reload();
  }
}
</script>

<style lang="scss" scoped>
.game-view-transition-enter-active, .game-view-transition-leave-active {
  transition: opacity .4s ease;
}

.game-view-transition-enter-from, .game-view-transition-leave-to {
  opacity: 0;
}

/* we will explain what these classes do next! */
.v-enter-active,
.v-leave-active {
  transition: opacity 0.5s ease;
}

.v-enter-from,
.v-leave-to {
  opacity: 0;
}
</style>

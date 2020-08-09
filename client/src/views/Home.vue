<template>
  <div id="home-page" class="flex-1">
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
    <CGamePlan :games="leagueGames" :table="leagueTable"/>
    <CTable :table="leagueTable"/>
  </div>
</template>

<script lang="ts">
import {Vue, Component} from "vue-property-decorator";
import {LeagueGame} from "@/models/LeagueGame";
import CGamePlan from "@/components/structure/CGamePlan.vue";
import {LeagueTable} from "@/models/LeagueTable";
import CTable from "@/components/structure/CTable.vue";

@Component({
  name: 'Home',
  components: {CTable, CGamePlan}
})
export default class Home extends Vue {
  seasons: string[] = [];
  continents: object[] = [];
  countries: object[] = [];
  divisions: object[] = [];
  leagues: object[] = [];

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

  async mounted() {
    await this.axios.get('continents/seasons')
        .then(response => this.seasons = response.data)
        .catch(error => console.dir(error));
  }

  async onSeasonClicked(season: string) {
    this.selectedSeason = season;
    await this.axios.get(`continents/seasons/${this.selectedSeason}`)
        .then(response => this.continents = response.data)
        .catch(error => console.dir(error));
  }

  async onContinentClicked(continent: string) {
    this.selectedContinent = continent;
    await this.axios.get(`countries/continents/${this.selectedContinent}/${this.selectedSeason}`)
        .then(response => this.countries = response.data)
        .catch(error => console.dir(error));
  }

  async onCountryClicked(country: string) {
    this.selectedCountry = country;
    await this.axios.get(`divisions/countries/${this.selectedCountry}/${this.selectedSeason}`)
        .then(response => this.divisions = response.data)
        .catch(error => console.dir(error));
  }

  async onDivisionClicked(division: string) {
    this.selectedDivision = division;
    await this.axios.get(`leagues/divisions/${this.selectedDivision}/${this.selectedSeason}`)
        .then(response => this.leagues = response.data)
        .catch(error => console.dir(error));
  }

  async onLeagueClicked(league: string) {
    this.selectedLeague = league;
    await this.axios.get(`leagues/${this.selectedLeague}/${this.selectedSeason}/matches`)
        .then(async response => {
          this.lastMatchDay = response.data.lastMatchDay;
          this.lastCompletedMatchDay = response.data.lastCompletedMatchDay;
          await this.loadMatchDay(this.selectedGameDay);
        })
        .catch(error => console.dir(error));
  }

  async onGameDayChanged() {
    await this.loadMatchDay(this.selectedGameDay);
  }

  async loadMatchDay(gameDay: number) {
    await this.axios.get(`leagues/${this.selectedLeague}/${this.selectedSeason}/fixtures/${gameDay}`)
        .then(response => this.leagueGames = response.data)
        .catch(error => console.dir(error));
    await this.axios.get(`leagues/${this.selectedLeague}/${this.selectedSeason}/table/${gameDay}`)
        .then(response => this.leagueTable = response.data)
        .catch(error => console.dir(error));
  }

  onResetSeasonClicked() {
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
  }

  onResetContinentClicked() {
    this.selectedContinent = '';
    this.selectedCountry = '';
    this.selectedDivision = '';
    this.selectedLeague = '';
    this.countries = [];
    this.divisions = [];
    this.leagues = [];
    this.resetSelection();
  }

  onResetCountryClicked() {
    this.selectedCountry = '';
    this.selectedDivision = '';
    this.selectedLeague = '';
    this.divisions = [];
    this.leagues = [];
    this.resetSelection();
  }

  onResetDivisionClicked() {
    this.selectedDivision = '';
    this.selectedLeague = '';
    this.leagues = [];
    this.resetSelection();
  }

  onResetLeagueClicked() {
    this.selectedLeague = '';
    this.resetSelection();
  }

  resetSelection() {
    this.leagueGames = [];
    this.leagueTable = null;
    this.selectedGameDay = 1;
    this.lastMatchDay = 0;
    this.lastCompletedMatchDay = 0;
  }
}
</script>

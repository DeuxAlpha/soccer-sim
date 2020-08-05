<template>
  <div id="home-page" class="flex-1">
    <div class="flex flex-row justify-start text-sm">
      {{ selectedSeason }} > {{ selectedContinent }} > {{ selectedCountry }} > {{ selectedDivision }} >
      {{ selectedLeague }}
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
      <select v-model="selectedGameDay" id="game-day" @input="onGameDayChanged">
        <option v-for="gameDay of lastMatchDay" :value="gameDay">{{ gameDay }}</option>
      </select>
    </label>
    <CGamePlan :games="leagueGames"/>
  </div>
</template>

<script lang="ts">
import {Vue, Component} from "vue-property-decorator";
import {LeagueGame} from "@/models/LeagueGame";
import CGamePlan from "@/components/structure/CGamePlan.vue";

@Component({
  name: 'Home',
  components: {CGamePlan}
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
          this.selectedGameDay = this.lastMatchDay;
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
        .then(response => console.dir(response))
        .catch(error => console.dir(error));
  }
}
</script>

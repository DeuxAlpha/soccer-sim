<template>
  <div id="home-page" class="flex-1">
    <AModal v-if="selectedGame">
      <div class="flex flex-col justify-center w-full">
        <div class="self-end cursor-pointer" @click="onCloseGameClicked">X</div>
        <div class="w-full underline flex justify-center">{{ selectedGame.gameDay }}</div>
        <div class="w-full flex justify-center">{{ selectedGame.homeTeamName }} - {{ selectedGame.awayTeamName }}</div>
        <div class="w-full flex justify-center">{{ selectedGame.homeGoals }} - {{ selectedGame.awayGoals }}</div>
        <div class="w-full flex justify-center">({{ selectedGame.homeHalfGoals }} - {{
            selectedGame.awayHalfGoals
          }})
        </div>
        <div class="flex flex-row w-full justify-center">
          <div class="flex flex-col justify-center w-full">
            <div class="self-center">Shots</div>
            <div class="self-center">{{ selectedGame.homeShots }} - {{ selectedGame.awayShots }}</div>
          </div>
          <div class="flex flex-col justify-center w-full">
            <div class="self-center">Shots on goal</div>
            <div class="self-center">{{ selectedGame.homeShotsOnGoal }} - {{ selectedGame.awayShotsOnGoal }}</div>
          </div>
        </div>
        <div class="flex flex-row w-full justify-center">
          <div class="flex flex-col justify-center w-full">
            <div class="self-center">Ball possession</div>
            <div class="self-center">{{ selectedGame.homePossession }} - {{ selectedGame.awayPossession }}</div>
          </div>
        </div>
        <div class="flex flex-col w-full justify-center" v-if="selectedGame">
          <div class="flex flex-col justify-center w-full">
            <div class="self-center">Story</div>
          </div>
          <div class="flex flex-row justify-center" v-for="story in gameStory(selectedGame)">{{ story }}</div>
        </div>
        <div class="flex flex-col w-full justify-center mt-2">
          <APrimaryButton @click="resimulate(selectedGame)" class="self-center">Resimulate</APrimaryButton>
        </div>
        <div class="flex flex-col items-center">
          <h3 class="">
            Override
          </h3>
          <div class="flex flex-row items-center justify-center">
            <input class="w-4" v-model="secondHalfHomeTeamGoals">
            -
            <input class="w-4" v-model="secondHalfAwayTeamGoals">
            (
            <input class="w-4" v-model="firstHalfHomeTeamGoals">
            -
            <input class="w-4" v-model="firstHalfAwayTeamGoals">
            )
          </div>
          <APrimaryButton @click="onOverrideScoreClicked">Override Score</APrimaryButton>
        </div>
      </div>

    </AModal>
    <div class="flex flex-row justify-between">
      <div class="flex flex-row justify-start text-sm">
      <span class="cursor-pointer hover:underline text-blue-600 hover:text-blue-700" v-if="selectedSeason" @click="onResetSeasonClicked">
        > {{ selectedSeason }}
      </span>
      <span class="cursor-pointer hover:underline text-blue-600 hover:text-blue-700" v-if="selectedContinent" @click="onResetContinentClicked">
        > {{ selectedContinent }}
      </span>
      <span class="cursor-pointer hover:underline text-blue-600 hover:text-blue-700" v-if="selectedCountry" @click="onResetCountryClicked">
        > {{ selectedCountry }}
      </span>
      <span class="cursor-pointer hover:underline text-blue-600 hover:text-blue-700" v-if="selectedDivision" @click="onResetDivisionClicked">
        > {{ selectedDivision }}
      </span>
      <span class="cursor-pointer hover:underline text-blue-600 hover:text-blue-700" v-if="selectedLeague" @click="onResetLeagueClicked">
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
      <span class="cursor-pointer hover:underline" v-if="!selectedSeason" v-for="season of seasons" :key="season"
            @click="onSeasonClicked(season)">
        {{ season }}
      </span>
      <span class="cursor-pointer hover:underline" v-if="!selectedContinent" v-for="continent of continents" :key="continent.name"
            @click="onContinentClicked(continent.name)">
        {{ continent.name }}
      </span>
      <span class="cursor-pointer hover:underline" v-if="!selectedCountry" v-for="country of countries" :key="country.name"
            @click="onCountryClicked(country.name)">
        {{ country.name }}
      </span>
      <span class="cursor-pointer hover:underline" v-if="!selectedDivision" v-for="division of divisions" :key="division.name"
            @click="onDivisionClicked(division.name)">
        {{ division.name }}
      </span>
      <span class="cursor-pointer hover:underline" v-if="!selectedLeague" v-for="league of leagues" :key="league.name" @click="onLeagueClicked(league.name)">
        {{ league.name }}
      </span>
    </div>
    <div class="flex flex-row items-baseline">
      <label for="game-day" v-show="lastMatchDay !== 0">
        <span>Game Day</span>
        <select v-model="selectedGameDay" id="game-day" @change="onGameDayChanged">
          <option v-for="gameDay of lastMatchDay" :value="gameDay">{{ gameDay }}</option>
        </select>
      </label>
      <APrimaryButton v-show="lastMatchDay !== 0" @click="onResimulateGameDayClicked">Resimulate Game Day
      </APrimaryButton>
      <APrimaryButton v-show="lastMatchDay !== 0" @click="onDeleteGameDayClicked">Delete Game Day</APrimaryButton>
    </div>
    <div class="flex md:flex-row flex-col space-x-2">
      <CGamePlan @game-click="onGameClicked($event)" :games="leagueGames" :table="leagueTable"/>
      <CTable :promotion-system="promotionSystem" league="leagueName" :season="selectedSeason"
              :table="leagueTable"/>
      <div class="flex flex-col" v-if="leagueTable">
        <h4 class="text-lg">League Information</h4>
        <label for="league-shot-accuracy-modifier">Shot accuracy modifier</label>
        <input id="league-shot-accuracy-modifier" type="number" step=".01" v-model="shotAccuracyModifier">
        <label for="league-pace-modifier">Pace modifier</label>
        <input id="league-pace-modifier" type="number" step=".01" v-model="paceModifier">
        <label for="league-max-home-advantage">Max home advantage</label>
        <input id="league-max-home-advantage" type="number" step="1" v-model="maxHomeAdvantage">
        <label for="league-max-away-disadvantage">Max away disadvantage</label>
        <input id="league-max-away-disadvantage" type="number" step="1" v-model="maxAwayDisadvantage">
        <label for="league-actions-per-minute">Actions per minute</label>
        <input id="league-actions-per-minute" type="number" step="1" v-model="actionsPerMinute">
        <label for="league-max-progress-chance">Max progress chance</label>
        <input id="league-max-progress-chance" type="number" step=".01" v-model="maxProgressChance">
        <label for="league-min-progress-chance">Min progress chance</label>
        <input id="league-min-progress-chance" type="number" step=".01" v-model="minProgressChance">
        <label for="league-rounds">Rounds</label>
        <input id="league-rounds" type="number" step="1" v-model="rounds">
        <APrimaryButton @click="onSaveLeagueInformationClicked">Save League</APrimaryButton>
      </div>
    </div>

    <div v-if="isNewLeague">
      <button
          @click="onRecreateGamePlanClicked"
          class="py-2 px-4 bg-blue-300 text-white hover:bg-blue-400 focus:bg-blue-500 active:bg-blue-500">
        Create new gameplan
      </button>
    </div>
    <div v-show="leagueTable" class="flex h-8 flex-col space-y-4 mt-8 mb-4 justify-around">
      <div class="flex flex-row">
        <div class="w-full h-full flex-1 flex flex-row justify-center items-center">
          <div class="w-full border-b border-red-300"></div>
        </div>
        <div class="text-red-600 text-lg font-bold">Danger Zone</div>
        <div class="w-full h-full flex-1 flex flex-row justify-center items-center">
          <div class="w-full border-b border-red-300"></div>
        </div>
      </div>
    </div>
    <div v-show="leagueTable">
      <div class="flex flex-row items-start space-x-2">
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
        <div class="flex flex-col">
          <label for="new-season">New Season</label>
          <input v-model="newSeason" id="new-season">
          <APrimaryButton @click="onProcessCountryClicked">Process Country</APrimaryButton>
        </div>
        <button @click="onDeleteLeagueClicked"
                class="py-2 px-4 bg-red-300 text-white hover:bg-red-400 focus:bg-red-500 active:bg-red-500">
          Delete League
        </button>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import {Component, Vue} from "vue-property-decorator";
import {LeagueGame} from "@/models/LeagueGame";
import CGamePlan from "@/components/structure/CGamePlan.vue";
import {LeagueTable} from "@/models/LeagueTable";
import CTable from "@/components/structure/CTable.vue";
import {StrengthResponse} from "@/models/responses/StrengthResponse";
import AModal from "@/components/functionality/AModal.vue";
import {PromotionSystem} from "@/models/responses/PromotionSystem";
import APrimaryButton from "@/components/functionality/buttons/APrimaryButton.vue";
import {GameService} from "@/services/GameService";
import {LeagueInformation} from "@/models/responses/LeagueInformation";

@Component({
  name: 'Home',
  components: {APrimaryButton, AModal, CTable, CGamePlan}
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
  promotionSystem: PromotionSystem | null = null;

  leagueGames: LeagueGame[] = [];
  leagueTable: LeagueTable | null = null;

  selectedGameDay = 1;
  lastMatchDay = 0;
  lastCompletedMatchDay = 0;

  avgStrength = 900;
  varStrength = 500;

  firstHalfAwayTeamGoals = 0;
  firstHalfHomeTeamGoals = 0;
  secondHalfHomeTeamGoals = 0;
  secondHalfAwayTeamGoals = 0;

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
      await this.getLeagueInformation();
      await this.getPromotionSystem();
      if (this.selectedGameDay) {
        await this.getGames(this.selectedGameDay);
      } else {
        await this.getGames(1);
      }
    } else if (this.selectedDivision) {
      await this.getLeagues();
    } else if (this.selectedCountry) {
      await this.getDivisions();
    } else if (this.selectedContinent) {
      await this.getLeagues();
    } else if (this.selectedSeason) {
      await this.getContinents();
    } else {
      await this.getSeasons();
    }
  }

  async updateRoute(): Promise<void> {
    const query = {};
    if (this.selectedSeason) query['season'] = this.selectedSeason;
    if (this.selectedContinent) query['continent'] = this.selectedContinent;
    if (this.selectedCountry) query['country'] = this.selectedCountry;
    if (this.selectedDivision) query['division'] = this.selectedDivision;
    if (this.selectedLeague) query['league'] = this.selectedLeague;
    if (this.selectedGameDay !== 0 && this.selectedGameDay !== 1) query['gameDay'] = this.selectedGameDay;
    await this.$router.push({query});
    await this.getSeasons();
  }

  async getGames(matchDay: number): Promise<void> {
    await this.axios.get(`leagues/${this.selectedLeague}/${this.selectedSeason}/matches`)
        .then(async response => {
          this.lastMatchDay = response.data.lastMatchDay;
          this.lastCompletedMatchDay = response.data.lastCompletedMatchDay;
          this.selectedGameDay = matchDay;
          await this.loadMatchDay(matchDay);
        })
        .catch(error => {
          this.isNewLeague = true;
        })
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
        .then(response => this.continents = response.data)
        .catch(error => console.dir(error));
  }

  async onContinentClicked(continent: string) {
    this.selectedContinent = continent;
    await this.updateRoute();
    await this.getCountries();
  }

  async getCountries(): Promise<void> {
    await this.axios.get(`countries/continents/${this.selectedContinent}/${this.selectedSeason}`)
        .then(response => this.countries = response.data)
        .catch(error => console.dir(error));
  }

  async onCountryClicked(country: string) {
    this.selectedCountry = country;
    await this.updateRoute();
    await this.getDivisions();
  }

  async getDivisions(): Promise<void> {
    await this.axios.get(`divisions/countries/${this.selectedCountry}/${this.selectedSeason}`)
        .then(response => this.divisions = response.data)
        .catch(error => console.dir(error));
  }

  async onDivisionClicked(division: string) {
    this.selectedDivision = division;
    await this.updateRoute();
    await this.getLeagues();
  }

  async getLeagues(): Promise<void> {
    await this.axios.get(`leagues/divisions/${this.selectedDivision}/${this.selectedSeason}`)
        .then(response => this.leagues = response.data)
        .catch(error => console.dir(error));
  }

  isNewLeague = false;

  async onLeagueClicked(league: string) {
    this.selectedLeague = league;
    await this.updateRoute();
    await this.getGames(this.selectedGameDay);
    await this.getPromotionSystem();
    await this.getLeagueInformation();
  }


  async getPromotionSystem() {
    await this.axios.get(`leagues/${this.selectedLeague}/${this.selectedSeason}/promotion-system`)
        .then(response => this.promotionSystem = response.data)
        .catch(error => {
          console.dir(error)
          this.promotionSystem = {
            season: this.selectedSeason,
            leagueName: this.selectedLeague,
            relegatedTeamsStart: 0,
            promotionPlayOffTeamsEnd: 0,
            relegationPlayOffTeamsEnd: 0,
            relegationPlayOffTeamsStart: 0,
            promotedTeamsEnd: 0,
            promotedTeamsStart: 0,
            promotionPlayOffTeamsStart: 0,
            relegatedTeamsEnd: 0
          };
        });
  }

  async onGameDayChanged() {
    await this.loadMatchDay(this.selectedGameDay);
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

  async onResetSeasonClicked() {
    this.selectedGameDay = 0;
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
    await this.updateRoute();
    await this.getAppropriateNextCollection();
  }

  async onResetContinentClicked() {
    this.selectedGameDay = 0;
    this.selectedContinent = '';
    this.selectedCountry = '';
    this.selectedDivision = '';
    this.selectedLeague = '';
    this.countries = [];
    this.divisions = [];
    this.leagues = [];
    this.resetSelection();
    await this.updateRoute();
    await this.getAppropriateNextCollection();
  }

  async onResetCountryClicked() {
    this.selectedGameDay = 0;
    this.selectedCountry = '';
    this.selectedDivision = '';
    this.selectedLeague = '';
    this.divisions = [];
    this.leagues = [];
    this.resetSelection();
    await this.updateRoute();
    await this.getAppropriateNextCollection();
  }

  async onResetDivisionClicked() {
    this.selectedGameDay = 0;
    this.selectedDivision = '';
    this.selectedLeague = '';
    this.leagues = [];
    this.resetSelection();
    await this.updateRoute();
    await this.getAppropriateNextCollection();
  }

  async onResetLeagueClicked() {
    this.selectedGameDay = 0;
    this.selectedLeague = '';
    this.resetSelection();
    await this.updateRoute();
    await this.getAppropriateNextCollection();
  }

  resetSelection() {
    this.leagueGames = [];
    this.leagueTable = null;
    this.selectedGameDay = 1;
    this.lastMatchDay = 0;
    this.lastCompletedMatchDay = 0;
  }

  selectedGame: LeagueGame | null = null;

  onGameClicked(game: LeagueGame) {
    this.selectedGame = game;
    this.firstHalfHomeTeamGoals = this.selectedGame.homeHalfGoals;
    this.firstHalfAwayTeamGoals = this.selectedGame.awayHalfGoals;
    this.secondHalfHomeTeamGoals = this.selectedGame.homeGoals;
    this.secondHalfAwayTeamGoals = this.selectedGame.awayGoals;
  }

  gameStory = (game: LeagueGame) => {
    if (!game) return [];
    return game.story;
  }

  resimulated: boolean = false;

  async resimulate(game: LeagueGame | null) {
    if (!game) return;
    this.resimulated = true;
    await this.axios.post(`teams/${game.homeTeamName}/${this.selectedSeason}/simulate/${this.selectedGameDay}`)
        .then(response => this.selectedGame = response.data)
        .catch(error => console.log(error));
  }

  async onCloseGameClicked(): Promise<void> {
    this.selectedGame = null;
    if (this.resimulated) {
      window.location.reload();
    }
  }

  newSeason: string = '';

  async onProcessCountryClicked(): Promise<void> {
    if (!this.selectedCountry) return;
    if (!this.newSeason) return;
    await this.axios.post(`countries/${this.selectedCountry}/${this.selectedSeason}/process/${this.newSeason}`)
        .then(response => {
          alert('Playoffs: ' + JSON.stringify(response.data.playoffs));
          this.selectedSeason = response.data.newSeason;
          this.updateRoute();
          window.location.reload()
        })
        .catch(error => console.dir(error));
  }

  async onOverrideScoreClicked(): Promise<void> {
    if (this.firstHalfAwayTeamGoals > this.secondHalfAwayTeamGoals) return;
    if (this.firstHalfHomeTeamGoals > this.secondHalfHomeTeamGoals) return;

    const homeScoreEvents = GameService.CreateRangeOfEvents(this.firstHalfHomeTeamGoals, 0, 45, 8);
    homeScoreEvents.push(...GameService.CreateRangeOfEvents(this.secondHalfHomeTeamGoals - this.firstHalfHomeTeamGoals, 45, 90, 8));
    const awayScoreEvents = GameService.CreateRangeOfEvents(this.firstHalfAwayTeamGoals, 0, 45, 8);
    awayScoreEvents.push(...GameService.CreateRangeOfEvents(this.secondHalfAwayTeamGoals - this.firstHalfAwayTeamGoals, 45, 90, 8));


    await this.axios.put(`leagues/${this.selectedLeague}/${this.selectedSeason}/${this.selectedGameDay}/fixture`, {
      homeTeamName: this.selectedGame?.homeTeamName,
      awayTeamName: this.selectedGame?.awayTeamName,
      homeScoreEvents: homeScoreEvents,
      awayScoreEvents: awayScoreEvents
    }).then(() => {
      window.location.reload()
    })
        .catch(error => console.error(error));
  }

  async onResimulateGameDayClicked(): Promise<void> {
    await this.axios.post(`leagues/${this.selectedLeague}/${this.selectedSeason}/simulate/${this.selectedGameDay}/override`)
        .then(() => window.location.reload())
        .catch(error => console.error(error));
  }

  async onDeleteGameDayClicked(): Promise<void> {
    await this.axios.delete(`leagues/${this.selectedLeague}/${this.selectedSeason}/${this.selectedGameDay}`)
        .then(() => window.location.reload())
        .catch(error => console.error(error));
  }

  shotAccuracyModifier: number = 0;
  paceModifier: number = 0;
  maxHomeAdvantage: number = 0;
  maxAwayDisadvantage: number = 0;
  actionsPerMinute: number = 0;
  maxProgressChance: number = 0;
  minProgressChance: number = 0;
  rounds: number = 0;

  async getLeagueInformation(): Promise<void> {
    await this.axios.get(`leagues/${this.selectedLeague}/${this.selectedSeason}`)
        .then(response => {
          this.shotAccuracyModifier = response.data.shotAccuracyModifier;
          this.paceModifier = response.data.paceModifier;
          this.maxHomeAdvantage = response.data.maxHomeAdvantage;
          this.maxAwayDisadvantage = response.data.maxAwayDisadvantage;
          this.actionsPerMinute = response.data.actionsPerMinute;
          this.maxProgressChance = response.data.maxProgressChance;
          this.minProgressChance = response.data.minProgressChance;
          this.rounds = response.data.rounds;
        })
        .catch(error => console.error(error));
  }

  async onSaveLeagueInformationClicked(): Promise<void> {
    const leagueInformation: LeagueInformation = {
      shotAccuracyModifier: this.shotAccuracyModifier,
      paceModifier: this.paceModifier,
      maxHomeAdvantage: this.maxHomeAdvantage,
      maxAwayDisadvantage: this.maxAwayDisadvantage,
      actionsPerMinute: this.actionsPerMinute,
      maxProgressChance: this.maxProgressChance,
      minProgressChance: this.minProgressChance,
      rounds: this.rounds,
      name: this.selectedLeague,
      season: this.selectedSeason,
      divisionName: this.selectedDivision
    }
    await this.axios.put(`leagues/${this.selectedLeague}/${this.selectedSeason}`, leagueInformation)
        .then(() => window.location.reload())
        .catch(error => console.error(error));
  }

  async onDeleteLeagueClicked(): Promise<void> {
    await this.axios.delete(`leagues/${this.selectedLeague}/${this.selectedSeason}`)
        .then(() => window.location.reload())
        .catch(error => console.error(error));
  }
}
</script>

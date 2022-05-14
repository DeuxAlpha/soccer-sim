<template>
  <div ref="gameView"
       class="relative md:mx-12 md:my-4 flex flex-col justify-center items-center bg-gray-200 shadow rounded border border-gray-300 backdrop-blur">
    <div id="menu-row" class="flex flex-row justify-between w-full">
      <button @keydown.esc="onEscClicked"
              @click.prevent="onExitClicked"
              class="self-start mx-2 my-2 px-2 py-2 shadow rounded-sm bg-gray-200 hover:bg-gray-300 active:bg-gray-100 focus:bg-gray-100 hover:shadow-md text-gray-800">
        x
      </button>
      <div class="mx-2 my-2 px-2 py-2" id="buttons">
        <div class="flex flex-col">
          <div class="flex flex-row">
            <div class="flex flex-col">
              <label for="home-score-first-half" class="text-xs font-thin">Home Team Goals 1st Half</label>
              <input @update="homeScoreSecondHalf < homeScoreFirstHalf ? homeScoreSecondHalf = homeScoreFirstHalf : null" type="number" class="w-12 font-sm" id="home-score-first-half" v-model="homeScoreFirstHalf">
            </div>
            <div class="flex flex-col">
              <label for="away-score-first-half" class="text-xs font-thin">Away Team Goals 1st Half</label>
              <input @update="awayScoreSecondHalf < awayScoreFirstHalf ? awayScoreSecondHalf = awayScoreFirstHalf : null" type="number" class="w-12 font-sm" id="away-score-first-half" v-model="awayScoreFirstHalf">
            </div>
          </div>
          <div class="flex flex-row">
            <div class="flex flex-col">
              <label for="home-score-second-half" class="text-xs font-thin">Home Team Goals 2nd Half</label>
              <input type="number" class="w-12 font-sm" id="home-score-second-half" v-model="homeScoreSecondHalf">
            </div>
            <div class="flex flex-col">
              <label for="away-score-second-half" class="text-xs font-thin">Away Team Goals 2nd Half</label>
              <input type="number" class="w-12 font-sm" id="away-score-second-half" v-model="awayScoreSecondHalf">
            </div>
          </div>
          <APrimaryButton @click="onOverrideScoreClicked">Override score</APrimaryButton>
        </div>
      </div>
    </div>
    <h1 class=" my-2 flex flex-row justify-center items-baseline font-bold text-gray-600 text-xl">
      {{ league }}
    </h1>
    <div class="flex flex-row w-full">
      <div id="home-team" class="w-5/12 flex flex-col justify-center items-center">
        <h2 id="home-team-name">{{ game.homeTeamName }}</h2>
      </div>
      <div id="score-keeper" class="w-2/12 flex flex-col justify-center">
        <div id="final-score" class="flex flex-row justify-center font-bold">
          {{ game.score }}
        </div>
        <div id="half-time-score" class="flex flex-row justify-center font-thin text-gray-600">
          {{ game.halfTimeScore }}
        </div>
      </div>
      <div id="away-team" class="w-5/12 flex flex-col justify-center items-center">
        <h2 id="away-team-name">{{ game.awayTeamName }}</h2>
      </div>
    </div>
    <div class="my-2 w-full h-full flex flex-col">
      <ASeparator>Story</ASeparator>
    </div>
    <div class="my-2 w-full flex flex-row" v-for="story of game.story">
      <div v-if="story.split(' ')[0] === game.homeTeamName"
           class="w-full md:px-4 px-2 flex flex-row justify-start">{{ story }}
      </div>
      <div v-else-if="story.split(' ')[0] === game.awayTeamName"
           class="w-full md:px-4 px-2 flex flex-row justify-end">{{ story }}
      </div>
      <div v-else
           class="w-full md:px-4 px-2 flex flex-row justify-center">{{ story }}
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import {Component, Emit, Prop, Ref, Vue} from 'vue-property-decorator';
import {LeagueGame} from "@/models/LeagueGame";
import ASeparator from "@/components/functionality/separator/ASeparator.vue";
import APrimaryButton from "@/components/functionality/buttons/APrimaryButton.vue";
import {GameScoreEvent, GameService} from "@/services/GameService";
import {GameScore} from "@/types/GameScore";

@Component({
  name: 'CGameView',
  components: {APrimaryButton, ASeparator}
})
export default class CGameView extends Vue {
  @Prop({type: String, required: true}) readonly league!: string;
  @Prop({type: String, required: true}) readonly season!: string;
  @Prop({type: Object, required: true}) readonly game!: LeagueGame;
  @Ref('gameView') readonly gameView!: HTMLDivElement;

  homeScoreFirstHalf = 0;
  homeScoreSecondHalf = 0;
  awayScoreFirstHalf = 0;
  awayScoreSecondHalf = 0;

  @Emit('exit-request')
  emitExitRequest() {
    return true;
  }

  onEscClicked() {
    this.emitExitRequest();
  }

  onExitClicked() {
    this.emitExitRequest();
  }

  @Emit('update-results')
  emitResultUpdates(): GameScore {
    return {
      HomeScoreFirstHalf: this.homeScoreFirstHalf,
      HomeScoreSecondHalf: this.homeScoreSecondHalf,
      AwayScoreFirstHalf: this.awayScoreFirstHalf,
      AwayScoreSecondHalf: this.awayScoreSecondHalf
    }
  }

  async onOverrideScoreClicked() {
    // Check sanity
    const ScoresBreakTimeContinuum: () => boolean= () =>  {
      if (this.homeScoreFirstHalf > this.homeScoreSecondHalf) {return true;}
      if (this.awayScoreFirstHalf > this.awayScoreSecondHalf) {return true;}
      return false;
    }

    if (ScoresBreakTimeContinuum()) return;

    const homeScoreEvents: GameScoreEvent[] = GameService.CreateRangeOfEvents(
        this.homeScoreFirstHalf, 0, 45, 8);
    homeScoreEvents.push(...GameService.CreateRangeOfEvents(
        this.homeScoreSecondHalf - this.homeScoreFirstHalf, 45, 90, 8));
    console.log('home score events', homeScoreEvents);
    const awayScoreEvents: GameScoreEvent[] = GameService.CreateRangeOfEvents(
        this.awayScoreFirstHalf, 0, 45, 8);
    awayScoreEvents.concat(GameService.CreateRangeOfEvents(
        this.awayScoreSecondHalf - this.awayScoreFirstHalf, 45, 90, 8));
    console.log('away score events', awayScoreEvents);

    const request: GameUpdateRequest = {
      HomeTeamName: this.game.homeTeamName,
      AwayTeamName: this.game.awayTeamName,
      HomeScoreEvents: homeScoreEvents,
      AwayScoreEvents: awayScoreEvents
    }
    const urlQuery = encodeURI(`leagues/${this.league}/${this.season}/${this.game.gameDay}/fixture`)

    await this.axios.put(urlQuery, request)
        .then(response => {
          if (response.status=== 200) {
            this.emitResultUpdates();
          }
        })
        .catch(error => {
          console.log('error response', error);
        })
  }
}

type GameUpdateRequest = {
  HomeTeamName: string;
  AwayTeamName: string;
  HomeScoreEvents: GameScoreEvent[];
  AwayScoreEvents: GameScoreEvent[];
}
</script>

<style scoped>
</style>

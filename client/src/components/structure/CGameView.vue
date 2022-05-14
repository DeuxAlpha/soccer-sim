<template>
  <div ref="gameView"
       class="relative md:mx-12 md:my-4 flex flex-col justify-center items-center bg-gray-200 shadow rounded border border-gray-300 backdrop-blur">
    <button @keydown.esc="onEscClicked"
            @click.prevent="onExitClicked"
            class="absolute top-0 left-0 mx-2 my-2 px-2 py-2 shadow rounded-sm bg-gray-200 hover:bg-gray-300 active:bg-gray-100 focus:bg-gray-100 hover:shadow-md text-gray-800">
      x
    </button>
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

@Component({
  name: 'CGameView',
  components: {ASeparator}
})
export default class CGameView extends Vue {
  @Prop({type: String, required: true}) readonly league!: string;
  @Prop({type: Object, required: true}) readonly game!: LeagueGame;
  @Ref('gameView') readonly gameView!: HTMLDivElement;

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
}
</script>

<style scoped>
</style>

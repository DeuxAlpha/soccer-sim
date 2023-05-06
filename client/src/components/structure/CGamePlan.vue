<template>
  <div class="border border-gray-200 p-2" v-if="games.length > 0 && table !== null">
    <div @click="onGameClicked(game)" class="bg-gray-300 cursor-pointer hover:bg-gray-400 hover:shadow-sm flex items-center justify-between my-1" v-for="game of games" :key="game.homeTeamName + game.awayTeamName">
      <div class="w-5/12 text-right">
        <span class="text-gray-500 mr-2">({{getPosition(game.homeTeamName)}})</span>
        <span>{{game.homeTeamName}}</span>
      </div>
      <div class="w-2/12 flex flex-col">
        <div class="flex flex-row justify-center">
          <span>{{game.homeGoals}}</span>
          <span>-</span>
          <span>{{game.awayGoals}}</span>
        </div>
        <div class="flex flex-row justify-center text-gray-600">
          <span>({{game.homeHalfGoals}}</span>
          <span>-</span>
          <span>{{game.awayHalfGoals}})</span>
        </div>
      </div>
      <div class="w-5/12">
        <span>{{game.awayTeamName}}</span>
        <span class="text-gray-500 ml-2">({{getPosition(game.awayTeamName)}})</span>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import {Vue, Component, Prop, Emit} from 'vue-property-decorator';
import {LeagueGame} from "@/models/LeagueGame";
import {LeagueTable} from "@/models/LeagueTable";

@Component
export default class CGamePlan extends Vue {
  @Prop({type: Array, required: true}) readonly games!: LeagueGame[];
  @Prop({type: Object, default: null}) readonly table!: LeagueTable;

  getPosition(homeTeamName: string): number {
    return this.table.previousPositions.find(p => p.teamName === homeTeamName)!.position;
  }

  @Emit('game-click')
  onGameClicked(game: LeagueGame): LeagueGame {
    return game;
  }
}
</script>

<style scoped lang="scss">

</style>
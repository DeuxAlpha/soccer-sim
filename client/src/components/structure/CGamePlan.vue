<template>
  <div class="border border-gray-200 p-2">
    <div class="bg-gray-300 flex items-center justify-between my-1" v-for="game of games" :key="game.homeTeamName + game.awayTeamName">
      <div class="w-5/12 text-right">{{game.homeTeamName}}</div>
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
      <div class="w-5/12">{{game.awayTeamName}}</div>
    </div>
  </div>
</template>

<script lang="ts">
import {Vue, Component, Prop} from 'vue-property-decorator';
import {LeagueGame} from "@/models/LeagueGame";

@Component
export default class CGamePlan extends Vue {
  @Prop({type: Array, required: true}) readonly games!: LeagueGame[];
}
</script>

<style scoped lang="scss">

</style>
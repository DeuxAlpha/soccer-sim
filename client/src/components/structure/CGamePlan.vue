<template>
  <div class="border border-gray-200 p-2">
    <div class="bg-gray-300 flex flex-row" v-for="game of games" :key="game.homeTeamName + game.awayTeamName">
      <div class="">{{game.homeTeamName}}</div>
      <div class="flex flex-col">
        <div class="flex flex-row">
          <div class="">{{game.homeGoals}}</div>
          <div class="">-</div>
          <div class="">{{game.awayGoals}}</div>
        </div>
        <div class="flex flex-row">
          <div class="">({{game.homeHalfGoals}}</div>
          <div class="">-</div>
          <div class="">{{game.awayHalfGoals}})</div>
        </div>
      </div>
      <div class="">{{game.awayTeamName}}</div>
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
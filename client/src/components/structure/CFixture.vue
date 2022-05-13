<template>
  <div class="bg-gray-300 hover:bg-gray-400 hover:shadow relative flex items-center justify-between my-1"
       :key="game.homeTeamName + game.awayTeamName" @click="onFixtureClicked">
    <div class="w-5/12 text-right">{{ game.homeTeamName }}</div>
    <div class="w-2/12 flex flex-col">
      <div class="flex flex-row justify-center">
        <span>{{ game.homeGoals }}</span>
        <span>-</span>
        <span>{{ game.awayGoals }}</span>
      </div>
      <div class="flex flex-row justify-center text-gray-600">
        <span>({{ game.homeHalfGoals }}</span>
        <span>-</span>
        <span>{{ game.awayHalfGoals }})</span>
      </div>
    </div>
    <div class="w-5/12">{{ game.awayTeamName }}</div>
  </div>
</template>

<script lang="ts">

import {Vue, Component, Prop, Emit} from "vue-property-decorator";
import {LeagueGame} from "@/models/LeagueGame";

@Component({
  name: 'CFixture'
})
export default class CFixture extends Vue {
  @Prop({type: Object, required: true}) readonly game!: LeagueGame;

  @Emit('click')
  onFixtureClicked() {
    return this.game;
  }
}
</script>

<style scoped>

</style>

<template>
  <div class="border border-gray-200 p-2">
    <CFixture :key="`${game.homeTeamName}-${game.awayTeamName}`" :game="game" @click="onFixtureClicked" v-for="game of games" />
  </div>
</template>

<script lang="ts">
import {Vue, Component, Prop} from 'vue-property-decorator';
import {LeagueGame} from "@/models/LeagueGame";
import CFixture from "@/components/structure/CFixture.vue";

@Component({
  name: 'CGamePlan',
  components: {CFixture}
})
export default class CGamePlan extends Vue {
  @Prop({type: Array, required: true}) readonly games!: LeagueGame[];

  onFixtureClicked(game: LeagueGame) {

  }
}
</script>

<style scoped lang="scss">

</style>

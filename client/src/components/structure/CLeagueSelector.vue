<template>
  <div class="flex flex-col">
    <div class="flex flex-row justify-between">
      <div class="flex flex-row justify-start text-sm">
        <span v-if="season" @click="resetSeason">
          > {{ season }}
        </span>
        <span v-if="continent" @click="resetContinent">
          > {{ continent }}
        </span>
        <span v-if="country" @click="resetCountry">
          > {{ country }}
        </span>
        <span v-if="division" @click="resetDivision">
          > {{ division }}
        </span>
        <span v-if="league" @click="resetLeague">
          > {{ league }}
        </span>
      </div>
    </div>
    <div class="text-lg">
      <span v-if="!season" v-for="seasonOption of seasons" :key="seasonOption"
            @click="seasonUpdate(seasonOption)">
        {{ seasonOption }}
      </span>
      <span v-if="!continent" v-for="continentOption of continents" :key="continentOption"
            @click="continentUpdate(continentOption)">
        {{ continentOption }}
      </span>
      <span v-if="!country" v-for="countryOption of countries" :key="countryOption"
            @click="countryUpdate(countryOption)">
        {{ countryOption }}
      </span>
      <span v-if="!division" v-for="divisionOption of divisions" :key="divisionOption"
            @click="divisionUpdate(divisionOption)">
        {{ divisionOption }}
      </span>
      <span v-if="!league" v-for="leagueOption of leagues" :key="leagueOption"
            @click="leagueUpdate(leagueOption)">
        {{ leagueOption }}
      </span>
    </div>
  </div>
</template>

<script lang="ts">
import {Vue, Component, Prop, Emit} from 'vue-property-decorator';
import {type} from "os";

@Component({
  name: 'CLeagueSelector'
})

export default class CLeagueSelector extends Vue{
  @Prop({type: String}) readonly season?: string;
  @Prop({type: String}) readonly continent?: string;
  @Prop({type: String}) readonly country?: string;
  @Prop({type: String}) readonly division?: string;
  @Prop({type: String}) readonly league?: string;

  @Prop({type: Array}) readonly seasons?: string[];
  @Prop({type: Array}) readonly continents?: string[];
  @Prop({type: Array}) readonly countries?: string[];
  @Prop({type: Array}) readonly divisions?: string[];
  @Prop({type: Array}) readonly leagues?: string[];

  @Emit('reset-season')
  resetSeason() {
    return true;
  }

  @Emit('reset-continent')
  resetContinent() {
    return true;
  }

  @Emit('reset-country')
  resetCountry() {
    return true;
  }

  @Emit('reset-division')
  resetDivision() {
    return true;
  }

  @Emit('reset-league')
  resetLeague() {
    return true;
  }

  @Emit('season-update')
  seasonUpdate(seasonOption: string) {
    return seasonOption;
  }

  @Emit('continent-update')
  continentUpdate(continentOption: string) {
    return continentOption;
  }

  @Emit('country-update')
  countryUpdate(countryOption: string) {
    return countryOption;
  }

  @Emit('division-update')
  divisionUpdate(divisionOption: string) {
    return divisionOption;
  }

  @Emit('league-update')
  leagueUpdate(leagueOption: string) {
    return leagueOption;
  }
}
</script>

<style scoped>

</style>

<template>
  <div class="flex flex-row justify-end text-sm">
    <div class="flex flex-col">
      <label for="average-strength">Avg. Strength</label>
      <input class="rounded border focus:shadow focus:outline-none"
             id="average-strength"
             type="number"
             step="1"
             v-model="avgStrength">
    </div>
    <div class="flex flex-col">
      <label for="strength-variance">Var. Strength</label>
      <input class="rounded border focus:shadow focus:outline-none"
             id="strength-variance"
             type="number"
             step="1"
             v-model="varStrength">
    </div>
    <button @click="emitStrengthRequest">Get Strengths up to this game day</button>
  </div>
</template>

<script lang="ts">
import {Vue, Component, Emit, Prop} from "vue-property-decorator";

@Component({
  name: 'CLeagueStrengthProvider'
})
export default class CLeagueStrengthConfiguration extends Vue{
  @Prop(Number) readonly averageStrength?: number;
  @Prop(Number) readonly variableStrength?: number;

  avgStrength = 900;
  varStrength = 500;

  mounted() {
    if (this.averageStrength) this.avgStrength = this.averageStrength
    if (this.variableStrength) this.varStrength = this.variableStrength;
  }

  @Emit('strength-request')
  emitStrengthRequest() {
    return {
      averageStrength: this.avgStrength,
      variableStrength: this.varStrength
    }
  }
}
</script>

<style scoped>

</style>

<template>
  <div class="flex flex-col md:mx-8 md:my-4 bg-gray-200 rounded shadow">
    <div id="actions" class="flex flex-row justify-center">
      <div id="addShotHome">
        <AFutbol/>
      </div>
      <div id="addShotGoalHome"></div>
      <div id="addGoalHome"></div>
      <div id="addShotAway"></div>
      <div id="addShotGoalAway"></div>
      <div id="addGoalAway"></div>
    </div>
  </div>
</template>

<script lang="ts">
import {Vue, Component, Prop} from 'vue-property-decorator';
import AFutbol from "@/components/functionality/icons/AFutbol.vue";

@Component({
  name: 'CLiveGame',
  components: {AFutbol}
})
export default class CLiveGame extends Vue {
  @Prop({type: Number, default: 5}) readonly minutes!: number;
  @Prop({type: String, required: true}) readonly homeTeam!: string;
  @Prop({type: String, required: true}) readonly awayTeam!: string;
}
</script>

<style lang="scss" scoped>

</style>

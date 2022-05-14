<template>
  <div class="flex flex-row justify-center items-center">
    <div class="w-full h-full flex-1 flex flex-row justify-center items-center mt-px">
      <div :class="`w-full border-b border-${color}-300`"></div>
    </div>
    <div :class="`text-${color}-600 text-lg font-bold mx-${xMargin}`">
      <slot></slot>
    </div>
    <div class="w-full h-full flex-1 flex flex-row justify-center items-center mt-px">
      <div :class="`w-full border-b border-${color}-300`"></div>
    </div>
  </div>
</template>

<script lang="ts">
import {Vue, Component, Prop} from "vue-property-decorator";

@Component({
  name: 'ASeparator'
})
export default class ASeparator extends Vue {
  @Prop({type: String, default: 'gray'}) readonly color!: string;
  @Prop({type: String, default: '0'}) readonly xMargin!: string;
}
</script>

<style scoped>

</style>

<template>
  <div id="administration-page" class="px-4 py-2 bg-gray-300 flex flex-col flex-1">
    <div class="flex flex-row justify-between">
      <button class="flex flex-row justify-center px-2 py-2 mx-2 bg-blue-200 flex-1">Continents</button>
      <button class="flex flex-row justify-center px-2 py-2 mx-2 bg-blue-200 flex-1">Countries</button>
      <button class="flex flex-row justify-center px-2 py-2 mx-2 bg-blue-200 flex-1">Divisions</button>
      <button class="flex flex-row justify-center px-2 py-2 mx-2 bg-blue-200 flex-1">Leagues</button>
      <button class="flex flex-row justify-center px-2 py-2 mx-2 bg-blue-200 flex-1">Divisions</button>
    </div>
  </div>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator';

@Component({
  name: 'Administration'
})
export default class Administration extends Vue {
}
</script>

<style scoped lang="scss">

</style>
<template>
  <div id="administration-page" class="px-4 py-2 bg-gray-300 flex flex-col flex-1">
    <div class="flex flex-row justify-between">
      <APrimaryButton class="flex-1">Continents</APrimaryButton>
      <APrimaryButton class="flex-1">Countries</APrimaryButton>
      <APrimaryButton class="flex-1">Divisions</APrimaryButton>
      <APrimaryButton class="flex-1">Leagues</APrimaryButton>
      <APrimaryButton class="flex-1">Divisions</APrimaryButton>
    </div>
  </div>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator';
import APrimaryButton from "@/components/functionality/buttons/APrimaryButton.vue";

@Component({
  name: 'Administration',
  components: {APrimaryButton}
})
export default class Administration extends Vue {
}
</script>

<style scoped lang="scss">

</style>
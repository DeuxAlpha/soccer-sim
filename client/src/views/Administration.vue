<template>
  <div id="administration-page" class="px-4 py-2 bg-gray-300 flex flex-col flex-1">
    <div class="flex flex-row justify-between">
      <APrimaryButton @click="selection = 'continents'" class="flex-1">Continents</APrimaryButton>
      <APrimaryButton @click="selection = 'countries'" class="flex-1">Countries</APrimaryButton>
      <APrimaryButton @click="selection = 'divisions'" class="flex-1">Divisions</APrimaryButton>
      <APrimaryButton @click="selection = 'leagues'" class="flex-1">Leagues</APrimaryButton>
      <APrimaryButton @click="selection = 'teams'" class="flex-1">Teams</APrimaryButton>
    </div>
    <div class="px-2 py-2" v-if="selection === 'continents'">
      <AAdminContinents/>
    </div>
    <div class="px-2 py-2" v-if="selection === 'countries'">
      <AAdminCountries/>
    </div>
    <div class="px-2 py-2" v-if="selection === 'divisions'">
      <AAdminDivisions/>
    </div>
    <div class="px-2 py-2" v-if="selection === 'leagues'">
      <AAdminLeagues/>
    </div>
    <div class="px-2 py-2" v-if="selection === 'teams'">
      <AAdminTeams/>
    </div>
  </div>
</template>

<script lang="ts">
import {Vue, Component} from 'vue-property-decorator';
import APrimaryButton from "@/components/functionality/buttons/APrimaryButton.vue";
import AAdminContinents from "@/components/structure/admin/AAdminContinents.vue";
import AAdminCountries from "@/components/structure/admin/AAdminCountries.vue";
import AAdminDivisions from "@/components/structure/admin/AAdminDivisions.vue";
import AAdminLeagues from "@/components/structure/admin/AAdminLeagues.vue";
import AAdminTeams from "@/components/structure/admin/AAdminTeams.vue";

@Component({
  name: 'Administration',
  components: {AAdminTeams, AAdminLeagues, AAdminDivisions, AAdminCountries, AAdminContinents, APrimaryButton}
})
export default class Administration extends Vue {
  selection = '';
}
</script>

<style scoped lang="scss">

</style>
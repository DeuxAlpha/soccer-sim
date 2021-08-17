<template>
  <div class="flex flex-col justify-center items-center mt-8">
    <router-link class="my-2" to="/Administration/Continents">
      <PrimaryButton>Continents</PrimaryButton>
    </router-link>
    <router-link class="my-2" to="/Administration/Countries">
      <PrimaryButton>Countries</PrimaryButton>
    </router-link>
    <router-link class="my-2" to="/Administration/Leagues">
      <PrimaryButton>Leagues</PrimaryButton>
    </router-link>
    <router-link class="my-2" to="/Administration/Teams">
      <PrimaryButton>Teams</PrimaryButton>
    </router-link>
  </div>
</template>

<script lang="ts">
import {defineComponent} from "vue";
import PrimaryButton from "../../components/functionality/PrimaryButton.vue";

export default defineComponent({
  name: "Administration",
  components: {PrimaryButton}
});
</script>

<style scoped lang="scss">

</style>
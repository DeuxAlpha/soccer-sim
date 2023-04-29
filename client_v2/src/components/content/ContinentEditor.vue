<template>
  <form @submit.prevent="onContinentSubmitted" class="flex flex-col">
    <label for="continentName">Continent Name</label>
    <input type="text" id="continentName" v-model="continentName">
    <label for="continentSeason">Continent Season</label>
    <input type="text" id="continentSeason" v-model="continentSeason">
    <button type="submit">Submit</button>
  </form>
</template>

<script lang="ts" setup>
import {ref} from "vue";
import axios from 'axios';

const continentName = ref("");
const continentSeason = ref("");

const onContinentSubmitted = () => {
  axios.post("https://localhost:5001/continents", {
    name: continentName.value,
    season: continentSeason.value
  }).then(response => {
    console.log(response);
  }).catch(error => {
    console.log(error);
  });
}
</script>

<style scoped lang="scss">

</style>
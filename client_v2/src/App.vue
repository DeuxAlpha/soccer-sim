<template>
  <Header/>
  <router-view/>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import Header from "./components/layout/Header.vue";

export default defineComponent({
  name: 'App',
  components: {
    Header
  }
})
</script>

<style lang="scss">
</style>

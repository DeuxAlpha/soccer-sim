<template>
  <div id="app" class="min-h-screen">
    <div id="nav" class="bg-gray-100 flex flex-col min-h-screen">
      <router-link class="transition duration-100 py-2 px-1 text-xl text-gray-800 hover:underline" to="/" :active-class="ActiveClass">Home</router-link>
    </div>
    <router-view/>
  </div>
</template>

<script lang="ts">
import {Vue, Component} from "vue-property-decorator";

@Component
export default class App extends Vue {
  get ActiveClass(): string {
    return 'bg-blue-200';
  }
}
</script>

<style lang="scss">
#nav {
  width: 200px;
}
</style>

<template>
  <div class="flex flex-row justify-center">
    <router-link to="/Administration">
      <div class="py-4 px-4 relative">
        <h6 class="link-text">Administration</h6>
        <div class="absolute bottom-0 left-0 link-border"/>
      </div>
    </router-link>
    <router-link to="/Simulation">
      <div class="py-4 px-4 relative">
        <h6 class="link-text">Simulation</h6>
        <div class="absolute bottom-0 left-0 link-border"/>
      </div>
    </router-link>
  </div>
</template>

<script lang="ts">
import {defineComponent} from "vue";

export default defineComponent({
  name: 'Header'
})

</script>

<style scoped lang="scss">
.router-link-active {

  .link-border {
    width: 100%;
  }
  .link-text {
    color: darken(#d9547f, 10%)
  }
}

.link-border{
  height: 2px;
  width: 0;
  background-color: cornflowerblue;
  transition: width 500ms ease;
}

.link-text {
  color: #d9547f;
  transition: color 200ms ease;
}

</style>
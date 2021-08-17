<template>
  <button class="button py-2 px-1 rounded relative" type="button">
    <slot/>
    <span class="button-border absolute bottom-0 left-0"/>
  </button>
</template>

<script lang="ts">
import {defineComponent} from "vue";

export default defineComponent({
  name: "PrimaryButton"
});
</script>

<style scoped lang="scss">
.button {
  background: lighten(#74a2e8, 25%);
  &:hover .button-border {
    width: 100%;
  }
}

.button-border {
  width: 0;
  height: 3px;
  background: #74a2e8;
  transition: width 300ms ease;
}
</style>
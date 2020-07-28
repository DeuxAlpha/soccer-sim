<template>
  <button class="flex flex-row justify-center px-2 py-2 mx-2 bg-blue-200" :class="ButtonClass" @click="emitClick"><slot/></button>
</template>

<script lang="ts">
import {Vue, Component, Emit} from 'vue-property-decorator';

@Component
export default class APrimaryButton extends Vue {
  get ButtonClass(): object {
    return {
      'hover:shadow-md hover:underline active:bg-blue-300': true,
    }
  }

  @Emit('click')
  emitClick() {}
}
</script>

<style scoped lang="scss">

</style>
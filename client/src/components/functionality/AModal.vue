<script lang="ts">
import {Vue, Component} from 'vue-property-decorator';

@Component({})
export default class AModal extends Vue {
}
</script>

<template>
<div class="absolute inset-0 bg-gray-900 bg-opacity-50 flex justify-center items-center">
  <div class="bg-white rounded-lg shadow-lg p-4">
    <slot></slot>
  </div>
</div>
</template>

<style scoped lang="scss">

</style>
<template>
  <div ref="dialog"
       id="dialog-outer-wrapper"
       @click="onOutsideComponentClicked"
       class="fixed top-0 left-0 h-screen w-screen z-50 backdrop-blur">
    <div id="dialog-inner-wrapper" @click="onInsideComponentClicked">
      <slot></slot>
    </div>
  </div>
</template>

<script lang="ts">
import {Vue, Component, Ref, Prop, Emit} from 'vue-property-decorator';

@Component({
  name: 'ADialog'
})
export default class ADialog extends Vue {
  @Ref('dialog') readonly dialog!: HTMLDivElement;

  private clickedInsideEvent?: boolean;

  @Emit('close-request')
  onOutsideComponentClicked() {
    if (!this.clickedInsideEvent) {
      return false;
    }
    this.clickedInsideEvent = undefined;
    return true;
  }

  onInsideComponentClicked() {
    this.clickedInsideEvent = true;
  }
}
</script>

<style scoped lang="scss">
.backdrop-blur {
  backdrop-filter: blur(8px);
  background-color: rgba(255, 240, 230, 0.25);
}

#dialog-inner-wrapper {
  height: 100%;
  overflow-y: auto;
}
</style>

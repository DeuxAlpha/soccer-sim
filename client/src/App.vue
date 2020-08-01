<template>
  <div id="app" class="min-h-screen relative flex flex-row">
    <transition @enter="onEnter" @leave="onLeave" :css="false">
      <div v-show="sideBarExpanded" id="nav"
           class="bg-gray-100 flex flex-col min-h-screen border-r border-gray-400 shadow-lg">
        <router-link class="transition duration-100 bg-blue-100 py-2 px-2 text-xl text-gray-800 hover:underline hover:shadow-md"
                     to="/"
                     :exact-active-class="ActiveClass">
          Home
        </router-link>
      </div>
    </transition>
    <button @click="sideBarExpanded = !sideBarExpanded"
            ref="SideBarToggle"
            id="side-bar-toggle"
            class="absolute bottom-0 mb-2 mr-2 text-blue-700 hover:text-blue-600 focus:text-blue-600 active:text-blue-800">
      <AArrowAltSolid size="24px"/>
    </button>
    <router-view/>
  </div>
</template>

<script lang="ts">
import {Vue, Component, Ref} from "vue-property-decorator";
import AArrowAltSolid from "@/components/functionality/icons/AArrowAltSolid.vue";
import GSAP from 'gsap';

@Component({
  components: {AArrowAltSolid}
})
export default class App extends Vue {
  sideBarExpanded = true;

  @Ref('SideBarToggle') readonly SideBarToggle!: HTMLButtonElement;

  get ActiveClass(): string {
    return 'bg-blue-200';
  }

  onEnter(element: HTMLElement, done: Function) {
    const overflow = element.style.overflow;
    element.style.overflow = 'hidden';
    GSAP.to(element, {
      width: '200px',
      duration: 0.25,
      onComplete: () => {
        element.style.overflow = overflow;
        done();
      }
    })
    GSAP.to(this.SideBarToggle, {
      left: 170,
      rotateY: 0,
      duration: 0.25,
    })
  }

  onLeave(element: HTMLElement, done: Function) {
    const overflow = element.style.overflow;
    element.style.overflow = 'hidden';
    GSAP.to(element, {
      width: 0,
      duration: 0.25,
      onComplete: () => {
        element.style.overflow = overflow;
        done();
      }
    })
    GSAP.to(this.SideBarToggle, {
      left: 5,
      rotateY: 180,
      duration: 0.25,
    })
  }
}
</script>

<style lang="scss">
#nav {
  width: 200px;
}

#side-bar-toggle {
  left: 170px;
}
</style>

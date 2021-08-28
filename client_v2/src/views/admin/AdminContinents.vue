<template>
  <Suspense>
    <template #default>
      <ContinentEditor/>
    </template>
    <template #fallback>
      Loading...
    </template>
  </Suspense>
</template>

<script lang="ts">
import {defineComponent} from "vue";
import ContinentEditor from "../../components/content/ContinentEditor.vue";

export default defineComponent({
  name: "AdminContinents",
  components: {ContinentEditor},
  setup(props, context) {

  }
});
</script>

<style scoped lang="ts">

</style>
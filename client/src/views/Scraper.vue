<template>
  <div class="flex flex-col">
    <button class="
    bg-blue-300 hover:bg-blue-400 active:bg-blue-500 focus:bg-blue-500
    text-white py-2 px-4 rounded" @click="onScrapeClicked">
      Scrape
    </button>
  </div>
</template>

<script lang="ts">
import {Vue, Component} from "vue-property-decorator";

@Component({
  name: 'Scraper'
})
export default class Scraper extends Vue {
  loading = false;

  async onScrapeClicked() {
    this.loading = true;
    await this.axios.post('/importers/scrape')
        .then(() => window.location.reload())
        .catch(error => console.dir(error))
        .finally(() => this.loading = false);
  }
}
</script>

<style scoped lang="scss">

</style>

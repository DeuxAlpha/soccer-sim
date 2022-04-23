<template>
  <div class="flex flex-col justify-start items-start w-full">
    <div class="mb-2">
      <router-link class="
      bg-blue-300 hover:bg-blue-400 active:bg-blue-500 focus:bg-blue-500
      text-black
      px-4 py-2 rounded"
                   to="/game/admin/import">
        Import League
      </router-link>
      <router-link class="
      bg-blue-300 hover:bg-blue-400 active:bg-blue-500 focus:bg-blue-500
      text-black px-4 py-2 rounded"
                   to="/game/admin/scrape">Scraper
      </router-link>
    </div>
  </div>
</template>

<script lang="ts">
import {Vue, Component} from "vue-property-decorator";

@Component({
  name: 'GameAdministration',
  components: {}
})
export default class GameAdministration extends Vue {

}
</script>

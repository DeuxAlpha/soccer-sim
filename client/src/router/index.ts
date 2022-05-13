import Vue from 'vue'
import VueRouter, {RouteConfig} from 'vue-router'
import Home from '@/views/Home.vue'
import GameAdministration from "@/views/GameAdministration.vue";
import LeagueImport from "@/views/LeagueImport.vue";
import Scraper from "@/views/Scraper.vue";

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [{
  path: '/',
  name: 'Home',
  component: Home
}, {
  path: '/game/admin',
  name: 'GameAdministration',
  component: GameAdministration
}, {
  path: '/game/admin/import',
  name: 'LeagueImport',
  component: LeagueImport
}, {
  path: '/game/admin/scrape',
  name: 'Scraper',
  component: Scraper
}
]

const router = new VueRouter({
  routes
})

export default router

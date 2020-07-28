import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import Home from '@/views/Home.vue'
import Administration from "@/views/Administration.vue";

Vue.use(VueRouter)

  const routes: Array<RouteConfig> = [{
    path: '/',
    name: 'Home',
    component: Home
  }, {
    path: '/administration',
    name: 'Administration',
    component: Administration
  }
]

const router = new VueRouter({
  routes
})

export default router

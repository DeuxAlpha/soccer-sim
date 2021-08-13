import Home from '../views/Home.vue';
import {createRouter, createWebHistory, RouteRecordRaw} from "vue-router";
import Administration from "../views/Administration.vue";
import Simulation from "../views/Simulation.vue";

const routes: RouteRecordRaw[] = [{
  name: 'home',
  path: '/',
  component: Home
}, {
  name: 'Administration',
  path: '/Administration',
  component: Administration
}, {
  name: 'Simulation',
  path: '/Simulation',
  component: Simulation
}]

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;
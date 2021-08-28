import Home from '../views/Home.vue';
import {createRouter, createWebHistory, RouteRecordRaw} from "vue-router";
import Administration from "../views/admin/Administration.vue";
import Simulation from "../views/Simulation.vue";
import AdminContinents from "../views/admin/AdminContinents.vue";
import AdminCountries from "../views/admin/AdminCountries.vue";
import AdminLeagues from "../views/admin/AdminLeagues.vue";
import AdminTeams from "../views/admin/AdminTeams.vue";

const routes: RouteRecordRaw[] = [{
  name: 'home',
  path: '/',
  component: Home
}, {
  name: 'Administration',
  path: '/Administration',
  component: Administration
}, {
  name: 'AdministrationContinents',
  path: '/Administration/Continents',
  component: AdminContinents
}, {
  name: 'AdministrationCountries',
  path: '/Administration/Countries',
  component: AdminCountries
}, {
  name: 'AdministrationLeagues',
  path: '/Administration/Leagues',
  component: AdminLeagues
}, {
  name: 'AdministrationTeams',
  path: '/Administration/Teams',
  component: AdminTeams
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
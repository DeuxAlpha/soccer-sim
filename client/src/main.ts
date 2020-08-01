import Vue from 'vue'
import Axios from 'axios';
import VueAxios from "vue-axios";
import App from './App.vue'
import router from './router'
import store from './store'
import "@/assets/main.scss";

Vue.config.productionTip = false

Axios.defaults.baseURL = 'https://localhost:5001';

Vue.use(VueAxios, Axios);

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')

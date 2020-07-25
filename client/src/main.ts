import Vue from 'vue'
import Axios from 'axios';
import VueAxios from "vue-axios";
import App from './App.vue'
import router from './router'
import store from './store'

Vue.config.productionTip = false

Vue.use(VueAxios, Axios);

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')

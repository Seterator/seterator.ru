// Точка входа js для страницы Privacy
import Vue from 'vue';
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue';
import PrivacyComponent from '../../../components/Privacy/Privacy.vue';

Vue.use(BootstrapVue);
Vue.use(IconsPlugin);

new Vue({
    el: '#privacy-component',
    render: h => h(PrivacyComponent)
});

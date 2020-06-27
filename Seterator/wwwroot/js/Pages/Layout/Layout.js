// Точка входа js для страницы макета
import Vue from 'vue';
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue';
import FooterComponent from '../../../components/Footer/Footer.vue';

Vue.use(BootstrapVue);
Vue.use(IconsPlugin);

new Vue({
    el: '#footer-component',
    render: h => h(FooterComponent)
});

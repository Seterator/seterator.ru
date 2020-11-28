// Точка входа js для страницы макета
import Vue from 'vue';
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue';
import HeaderComponent from '../../../components/Header/Header.vue';

Vue.use(BootstrapVue);
Vue.use(IconsPlugin);

new Vue({
    el: '#header-component',
    render: h => h(HeaderComponent)
});

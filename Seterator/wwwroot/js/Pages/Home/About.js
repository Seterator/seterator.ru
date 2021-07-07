// Точка входа js для страницы о нас
import Vue from 'vue';
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue';
import AboutComponent from '../../../components/Home/About.vue';
import VueAwesomeSwiper from 'vue-awesome-swiper';
import 'swiper/css/swiper.css';

Vue.use(VueAwesomeSwiper, /* { default options with global component } */);
Vue.use(BootstrapVue);
Vue.use(IconsPlugin);

new Vue({
    el: '#about-component',
    render: h => h(AboutComponent)
});

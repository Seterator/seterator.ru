// Точка входа js для страницы профиля пользователя Profile
import Vue from 'vue';
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue';
import ProfileComponent from '../../../components/Profile/Profile.vue';

Vue.use(BootstrapVue);
Vue.use(IconsPlugin);

new Vue({
    el: '#profile-component',
    render: h => h(ProfileComponent)
});

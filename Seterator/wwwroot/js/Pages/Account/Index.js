// Точка входа js для страницы авторизации/регистрации
import Vue from 'vue';
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue';
import AccountComponent from '../../../components/Account/Account.vue';

Vue.use(BootstrapVue);
Vue.use(IconsPlugin);

new Vue({
    el: '#account-component',
    render: h => h(AccountComponent)
});

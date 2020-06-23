// Точка входа js для страницы макета
import Vue from 'vue';
import AppComponent from '../../../components/App.vue';

new Vue({
    el: '#el',
    render: h => h(AppComponent)
});

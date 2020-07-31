// Точка входа js для главной страницы
import Vue from 'vue';
import Index from '../../../components/Index/Index.vue';

new Vue({
    el: '#index-component',
    render: h => h(Index)
});
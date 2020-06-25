import Vue from 'vue';
import AppComponent from '../components/App.vue';
import IndexComponent from '../components/Pages/Index-page.vue';

let url = new URL(document.location.href);
if (url.pathname == '/')
{
    new Vue({
        el: '#index-page',
        render: h => h(IndexComponent)
    });
}
else
{
    new Vue({
        el: '#el',
        render: h => h(AppComponent)
    });
}

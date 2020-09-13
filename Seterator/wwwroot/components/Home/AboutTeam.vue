<template>
<div class="team">
    <h2 class="team__title">Наша команда</h2>
    <swiper class="team__swiper" ref="mySwiper" :options="swiperOptions">
        <swiper-slide
            v-for="page in splitArr()"
        >
        <div class="team__itemsContainer">
        <team-item 
            v-for="user in page"
            :key="user.username"
            :propIsRoundedAvatar="true"
            :propImgSrc="user.avatarSrc"
        >
            <template slot="status"> {{user.status}} </template>
            <template slot="title"> {{user.username}} </template>
            <template slot="description"> {{user.description}} </template>
        </team-item>
        </div>
        </swiper-slide>
        
        <div class="swiper-pagination" slot="pagination"></div>
    </swiper>

    <h2 class="team__title">Наставники проекта</h2>
    <div class="team__itemsContainer">
        <team-item :propIsRoundedAvatar="false">
            <template slot="status">Главарь банды</template>
            <template slot="title">Александр Новожилов</template>
            <template slot="description">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
            </template>
            <template slot="link">
                Ссылка на внешний ресурс
            </template>
        </team-item>

        <team-item :propIsRoundedAvatar="false">
            <template slot="status">Главарь банды</template>
            <template slot="title">Александр Новожилов</template>
            <template slot="description">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
            </template>
            <template slot="link">
                Ссылка на внешний ресурс
            </template>
        </team-item>

        <team-item :propIsRoundedAvatar="false">
            <template slot="status">Главарь банды</template>
            <template slot="title">Александр Новожилов</template>
            <template slot="description">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
            </template>
            <template slot="link">
                Ссылка на внешний ресурс
            </template>
        </team-item>

        <team-item :propIsRoundedAvatar="false">
            <template slot="status">Главарь банды</template>
            <template slot="title">Александр Новожилов</template>
            <template slot="description">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
            </template>
            <template slot="link">
                Ссылка на внешний ресурс
            </template>
        </team-item>
    </div>
</div>
</template>

<script>
import TeamItemComponent from './TeamItem.vue';

export default {
props: {
    propTeam: Array
},
components: {
    'team-item': TeamItemComponent
},
 data() {
    return {
        swiperOptions: {
            pagination: {
            el: '.swiper-pagination',
            type: 'bullets'
            },
        }
    }
},
computed: {
    swiper() {
        return this.$refs.mySwiper.$swiper
    }
},
mounted() {
    console.log('Current Swiper instance object', this.swiper)
},
methods: {
    splitArr: function() {
        let arr = this.propTeam;        
        let subarray = [];
        let size = 6;

        for (let i = 0; i <Math.ceil(arr.length/size); i++){
            subarray[i] = arr.slice((i*size), (i*size) + size);
        }

        console.log(subarray);
        return subarray;
    }
}
}
</script>

<style>
:root {
  --swiper-theme-color: rgb(255, 82, 25) !important;
}

.team__swiper {
    margin-bottom: 100px;
}

.swiper-pagination {
    bottom: 0 !important;
}

.team__title {
    font-family: 'Montserrat', sans-serif;
    font-size: 18pt;
    font-weight: 600;
    color: rgb(255, 82, 25);
}

.team__itemsContainer {
    margin-top: 30px;
    display: grid;
    grid-template-columns: 1fr 1fr;
    gap: 40px;
}

@media (max-width: 991px) {
    .team__itemsContainer {
        grid-template-columns: 1fr;
    }
}
</style>>


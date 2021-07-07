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
        <team-item 
            v-for="mentor in propMentors"
            :key="mentor.username"
            :propIsRoundedAvatar="false"
            :propImgSrc="mentor.avatarSrc"
            :propIsBackgroundColor="true"
        >
            <template slot="status"> {{mentor.status}} </template>
            <template slot="title"> {{mentor.username}} </template>
            <template slot="description"> {{mentor.description}} </template>
            <template slot="link"> {{mentor.link}} </template>
        </team-item>
    </div>
</div>
</template>

<script>
import TeamItemComponent from './TeamItem.vue';

export default {
props: {
    propTeam: Array,
    propMentors: Array
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
        },
    }
},
computed: {
    swiper() {
        return this.$refs.mySwiper.$swiper
    }
},
methods: {
    splitArr: function() {
        let pageWidth = document.documentElement.scrollWidth;
        let arr = this.propTeam;        
        let subarray = [];
        let size = 6;

        if (pageWidth <= 768) {
            size = 2;
        } 

        for (let i = 0; i < Math.ceil(arr.length/size); i++){
            subarray[i] = arr.slice((i*size), (i*size) + size);
        }
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

@media (max-width: 768px) {
    .team__itemsContainer {
        grid-template-columns: 1fr;
    }
}
</style>>


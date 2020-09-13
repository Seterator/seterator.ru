<template>
<div class="team">
    <h2 class="team__title">Наша команда</h2>
    <swiper class="team__swiper" ref="mySwiper" :options="swiperOptions">
        <swiper-slide>
        <div class="team__itemsConteiner">
        <team-item :propIsRoundedAvatar="true">
            <template slot="status">Главарь банды</template>
            <template slot="title">Александр Новожилов</template>
            <template slot="description">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
            </template>
        </team-item>

        <team-item :propIsRoundedAvatar="true">
            <template slot="status">Главарь банды</template>
            <template slot="title">Александр Новожилов</template>
            <template slot="description">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
            </template>
        </team-item>

        <team-item :propIsRoundedAvatar="true">
            <template slot="status">Главарь банды</template>
            <template slot="title">Александр Новожилов</template>
            <template slot="description">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
            </template>
        </team-item>

        <team-item :propIsRoundedAvatar="true">
            <template slot="status">Главарь банды</template>
            <template slot="title">Александр Новожилов</template>
            <template slot="description">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
            </template>
        </team-item>
    </div>
        </swiper-slide>

        <swiper-slide>
        <div class="team__itemsConteiner">
        <team-item :propIsRoundedAvatar="true">
            <template slot="status">Главарь банды</template>
            <template slot="title">Александр Новожилов</template>
            <template slot="description">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
            </template>
        </team-item>

        <team-item :propIsRoundedAvatar="true">
            <template slot="status">Главарь банды</template>
            <template slot="title">Александр Новожилов</template>
            <template slot="description">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
            </template>
        </team-item>

        <team-item :propIsRoundedAvatar="true">
            <template slot="status">Главарь банды</template>
            <template slot="title">Александр Новожилов</template>
            <template slot="description">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
            </template>
        </team-item>

        <team-item :propIsRoundedAvatar="true">
            <template slot="status">Главарь банды</template>
            <template slot="title">Александр Новожилов</template>
            <template slot="description">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
            </template>
        </team-item>
    </div>
        </swiper-slide>
        <div class="swiper-pagination" slot="pagination"></div>
    </swiper>

    <h2 class="team__title">Наставники проекта</h2>
    <div class="team__itemsConteiner">
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

.team__itemsConteiner {
    margin-top: 30px;
    display: grid;
    grid-template-columns: 1fr 1fr;
    gap: 40px;
}
</style>>


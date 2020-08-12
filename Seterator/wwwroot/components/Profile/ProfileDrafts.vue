// Компонент представляет собой блок,
// содержащий черновики пользователя
// В компонент входят загловок, элементы-черновики и кнопка
// Элементы-черновики вынесены в отдельный компонент, но обернуты в ссылку

<template>
    <div>
        <h5 class="profileDrafts__header">Черновики</h5>
        <a href="#" class="profileDrafts__draft">
            <img-text :img="'/img/Competition/link_1.svg'" :text="'Пример черновика'" :imgColor="'rgb(255, 82,25)'"></img-text>
        </a>

        <div class="profileDrafts__button">
            <a class="profileDrafts__buttonLink" href="#">Все</a>
        </div>
    </div>
</template>

<script>
import ImgText from '../Other/ImgText.vue';

export default {
components: {
    'img-text': ImgText
}
}
</script>

<style scoped>
.profileDrafts__header {
    font-weight: bold;
    margin-bottom: 20px;
}

.profileDrafts__draft {
    display: block;
    margin-top: 10px;
}

.profileDrafts__button {
    display: block;
    width: 100%;
    text-align: center;
    margin-top: 15px;
}

.profileDrafts__buttonLink {
    font-size: 1.1rem;
    font-weight: bold;
    color: rgb(255, 82, 25);
    text-decoration: underline;
}

.profileDrafts__buttonLink:hover {
    opacity: 0.5;
}
</style>

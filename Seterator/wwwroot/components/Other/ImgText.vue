// Компонент представляет собой средство для 
// отображения иконки рядом с текстом
// Параметры:
// img - ссылка на изображение
// text - отображаемый текст
// imgColor - цвет иконки


<template>
  <div class="imgTextq" :style="{ fill: imgColor }">
      <div class="imgTextq__img">
        <img class="imgSvg" :src="img">
      </div>
    <span class="imgTextq__text">{{text}}</span>
  </div>
</template>

<script>
export default {
props: [
    'img',
    'text',
    'imgColor'
]
}
</script>

<style scoped>
.imgTextq {
    display: grid;
    grid-template-columns: 12px 1fr;
}

.imgTextq__img {
    width: 12px;
}

.imgTextq__text {
    margin-left: 5px;
}
</style>

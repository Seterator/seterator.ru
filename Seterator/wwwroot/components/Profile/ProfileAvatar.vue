// Компонент представляет собой аватар пользователя в профиле
// Параметры:
// src - путь к изображению

<template>
    <div class="profileAvatar">
        <img :src="src" alt="Аватар пользователя">
    </div>
</template>

<script>

export default {
    props: {
        src: String
    }
}
</script>

<style>
.profileAvatar {
    max-width: 100%;
}

.profileAvatar img {
    width: 100%;
}
</style>

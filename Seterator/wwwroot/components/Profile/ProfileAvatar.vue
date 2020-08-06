// Компонент представляет собой аватар пользователя в профиле
// Параметры:
// src - путь к изображению

<template>
    <div class="profileAvatar">
        <div class="profileAvatar__organization" v-if="role == 'organization'">
            <img :src="src" alt="Аватар пользователя">
        </div>
        <div v-else>
            <img :src="src" alt="Аватар пользователя">
        </div>
    </div>
</template>

<script>

export default {
    props: {
        src: String,
        role: {
            type: String
        }
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

.profileAvatar__organization {
    width: 150px;
    height: 150px;
    overflow: hidden;
    background: rgb(255, 255, 255);
    border-radius: 50%;
    border: 2px solid rgb(255, 82, 25)
}
</style>

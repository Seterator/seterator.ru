// Компонент, отображающий личные
// данные пользователя в профиле
// Входные параметры:
// personal_data - массив личных данных
// В будущем после разработки соответствующих API доработать 
// валидацию параметров и работу с ними

<template>
    <div class="profilePersonal">
        <div class="profile__title">Личные данные</div>
        <div    class="profilePersonal__items"
                v-if="!propIsEditing"
        >
            <div class="profilePersonal__item">
                <span class="profilePersonal__item_header">Имя фамилия</span>
                <span class="profilePersonal__item_value">{{propPersonalInfo.name}}</span>
            </div>
            <div class="profilePersonal__item">
                <span class="profilePersonal__item_header">Телефон</span>
                <span class="profilePersonal__item_value">{{propPersonalInfo.phone}}</span>
            </div>
            <div class="profilePersonal__item">
                <span class="profilePersonal__item_header">e-mail</span>
                <span class="profilePersonal__item_value">{{propPersonalInfo.email}}</span>
            </div>
            <div class="profilePersonal__item">
                <span class="profilePersonal__item_header">Страна</span>
                <span class="profilePersonal__item_value">{{propPersonalInfo.country}}</span>
            </div>
            <div class="profilePersonal__item">
                <span class="profilePersonal__item_header">Город</span>
                <span class="profilePersonal__item_value">{{propPersonalInfo.city}}</span>
            </div>
        </div>

        <div    v-else
                class="profilePersonal__items_mode_edit"
        >
            <div class="profilePersonal__item">
                <span class="profilePersonal__item_header">*Фамилия Имя Отчество</span>
                <input  class="profilePersonal__item_value profile__inputText"
                        type="text"
                        v-model="personalInfo.name"
                        @change="$emit('change-personalinfo', personalInfo)"
                >
            </div>
            <div class="profilePersonal__item">
                <span class="profilePersonal__item_header">*Телефон</span>
                <input  class="profilePersonal__item_value profile__inputText"
                        type="tel"
                        v-model="personalInfo.phone"
                >
            </div>
            <div class="profilePersonal__item">
                <span class="profilePersonal__item_header">*e-mail</span>
                <input  class="profilePersonal__item_value profile__inputText"
                        type="email"
                        v-model="personalInfo.email"
                >
            </div>
            <div class="profilePersonal__item">
                <span class="profilePersonal__item_header">Страна</span>
                <input  class="profilePersonal__item_value profile__inputText"
                        type="text"
                        v-model="personalInfo.country"
                >
            </div>
            <div class="profilePersonal__item">
                <span class="profilePersonal__item_header">Город</span>
                <input  class="profilePersonal__item_value profile__inputText"
                        type="text"
                        v-model="personalInfo.city"
                >
            </div>
        </div>
    </div>
</template>

<script>
export default {
    props: {
        propPersonalInfo: {
            type: Object,
            
            validation: function(value) {
                if (Array.isArray(value))
                    return true;
                else
                    return false;
            }
        },

        propIsEditing: {
            type: Boolean
        },
    },

    data: function() {
        return {
            personalInfo: this.propPersonalInfo
        }
    },
}
</script>

<style>
.profilePersonal__item {
    display: flex;
    flex-direction: column;
}

.profilePersonal__item_header {
    color: rgb(182, 182, 182);
    font-weight: bold;
    font-size: 0.9rem;
}

.profilePersonal__item_value {
    color: rgb(255, 82, 25);
    font-weight: bold;
}

.profilePersonal__items {
    margin-top: 15px;
    display: grid;
    grid-template-columns: 1fr 1fr 1fr;
    gap: 15px;
    
}

.profilePersonal__items_mode_edit {
    display: flex;
    flex-direction: column;
    gap: 15px;
    margin-top: 15px;
}
</style>

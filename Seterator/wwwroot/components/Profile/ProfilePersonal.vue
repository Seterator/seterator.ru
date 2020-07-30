// Компонент, отображающий личные
// данные пользователя в профиле
// Входные параметры:
// personal_data - массив личных данных
// В будущем после разработки соответствующих API доработать 
// валидацию параметров и работу с ними

<template>
  <div class="profilePersonal">
      <div class="profile__header">Личные данные</div>
      <div class="profilePersonal__items">
        <div class="profilePersonal__item">
            <span class="profilePersonal__item_header">Имя фамилия</span>
            <span class="profilePersonal__item_value">{{personal_data.name}}</span>
        </div>
        <div class="profilePersonal__item">
            <span class="profilePersonal__item_header">Телефон</span>
            <span class="profilePersonal__item_value">{{personal_data.phone}}</span>
        </div>
        <div class="profilePersonal__item">
            <span class="profilePersonal__item_header">e-mail</span>
            <span class="profilePersonal__item_value">{{personal_data.email}}</span>
        </div>
        <div class="profilePersonal__item">
            <span class="profilePersonal__item_header">Страна</span>
            <span class="profilePersonal__item_value">{{personal_data.country}}</span>
        </div>
        <div class="profilePersonal__item">
            <span class="profilePersonal__item_header">Город</span>
            <span class="profilePersonal__item_value">{{personal_data.city}}</span>
        </div>
      </div>
  </div>
</template>

<script>
export default {
props: {
    personal_data: {
        validation: function(value) {
            if (Array.isArray(value))
                return true;
            else
                return false;
        }
    }
}
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
</style>

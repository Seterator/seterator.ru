// Компонент, представляющий отображение статистики
// пользователя в профиле
// Входные пармаетры:
// statistics - массив объектов, содержащих статистические данные
//      объект имеет поля:
//      'name' - название статистической единицы
//      'value' - значение статистической единицы

<template>
    <div class="profileStatistics_wrap">
        <div class="profileStatistics__content container">
            <h5 class="profileStatistics__header">Ваша<br>статистика</h5>
            <ul class="profileStatistics__values">
                <li class="statisticsItem" 
                    v-for="item in statistics" 
                    :key="item.name"
                >
                    <span class="statisticsItem__name">{{ item.name }}</span>
                    <span class="statisticsItem__value">{{ item.value }}</span>
                </li>
            </ul>
        </div>
    </div>
</template>

<script>
export default {
    props: {
        statistics: Array,
        validator: function (statistics) {
            for (item of statistics) {
                if ('name' in item && 'value' in item)
                    return true;
                else
                    return false;
            }
        }
    } 
}
</script>

<style scoped>
.profileStatistics_wrap {
    background-color: rgb(255, 82, 25);
    color: rgb(255, 255, 255);

    margin: 50px 0 50px 0;
}

.profileStatistics__content {
    display: flex;
    flex-wrap: nowrap;
    justify-content: space-between;
    align-items: flex-end;
    padding-top: 30px;
    padding-bottom: 30px;
}

.profileStatistics__header {
    font-family: 'Merriweather', serif;
    font-size: 2rem;
}

.profileStatistics__values {
    list-style: none;
    margin: 0;
    padding: 0;

    display: flex;
    flex-wrap: nowrap;
    flex-direction: column;
    align-items: flex-end;
}

.statisticsItem {
    width: 100%;
    margin: 10px 0;
    display: flex;
    flex-wrap: nowrap;
    justify-content: flex-end;
    gap: 40px;
}

.statisticsItem__value {
    /* margin-left: 20px; */

    font-weight: bold;
}

@media only screen and (max-width: 768px) {
    .profileStatistics__content {
        flex-wrap: wrap;
    }

    .statisticsItem {
        justify-content: space-between;
    }
}

</style>

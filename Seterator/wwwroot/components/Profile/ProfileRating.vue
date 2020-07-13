<template>
    <div class="profileRating">
        <h5 class="profileRating__header">Рейтинг</h5>
        <div v-for="attr in rating" :key="attr.name" class="attr">
            <span class="attr__name">{{attr.name}}:</span>
            <span class="attr__value">{{attr.value}}</span>
        </div>
    </div>
</template>

<script>
export default {
    props: [
        'rating'
    ]
}
</script>

<style scoped>
.attr {
    display: flex;
    justify-content: space-between;
}

.attr__value {
    color: rgb(255, 82, 25);
    font-weight: 600;
}

.profileRating__header {
    font-weight: bold;
}
</style>

// Компонент, отображающий роли пользователя в строке
// Параметры:
// prop_roles - массив строк с доступными ролями

<template>
    <ul class="profileRoles">
        <li class="profileRoles__item" v-for="role of prop_roles" :key="role">{{role}}</li>
    </ul>
</template>

<script>
export default {
props: {
    prop_roles: {
        validator: function(roles) {
            if (Array.isArray(roles)) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
}
</script>

<style scoped>
.profileRoles {
    list-style: none;
    display: flex;
    flex-wrap: nowrap;
    margin: 0;
    padding: 0;
}

.profileRoles__item {
    padding: 0 5px;
    border-right: 1px solid rgb(255, 82, 25);
    opacity: 0.5;

    font-weight: bold;
}

.profileRoles__item:first-child {
    padding: 0 5px 0 0;
}

.profileRoles__item:last-child {
    border: none;
    padding: 0 0 0 5px;
}
</style>

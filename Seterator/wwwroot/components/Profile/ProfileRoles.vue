// Компонент, отображающий роли пользователя в строке
// Параметры:
// prop_roles - массив строк с доступными ролями

<template>
    <ul class="profileRoles">
        <li class="profileRoles__item" 
            v-for="role of prop_roles" 
            :key="role" 
        >
            <span  v-if="isActive(role)"
                class="profileRoles__item_activeRole"
            >{{ role }}</span>
            <a   v-else
                    class="profileRoles__item_inactive"
                    :href="'/?role=' + role"
            >{{ role }}</a>
        </li>
    </ul>
</template>

<script>
export default {
props: {
    active_role: {
        type: String
    },
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
},
methods: {
    isActive: function(role) {
        return (role == this.active_role);
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
    font-weight: bold;
}

.profileRoles__item:first-child {
    padding: 0 5px 0 0;
}

.profileRoles__item:last-child {
    border: none;
    padding: 0 0 0 5px;
}

.profileRoles__item_activeRole {
    color: rgb(204, 66, 20);
}

.profileRoles__item_inactive {
    opacity: 0.5;
}

.profileRoles__item_inactive:hover {
    color:rgb(255, 82, 25);
    cursor: pointer;
}
</style>

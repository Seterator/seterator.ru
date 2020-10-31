<template>
    <form class="reg-form" @submit.prevent="$emit('signup-click', {login, password})">
        <div>
            <input 
                class="reg-form__input_text"
                type="text" 
                placeholder="e-mail или логин" 
                v-model="login"
                required
            />
        </div>
        <div>
            <input
                class="reg-form__input_text"
                type="password" 
                placeholder="Пароль"
                v-model="password"
                required
            />
        </div>
        <div>
            <input 
                class="formButton" 
                type="submit"
                value="Регистрация" 
            />
        </div>
    </form>
</template>

<script>
export default {
data() {
    return {
        login: '',
        password: ''
    }
}
}
</script>

<style scoped>
.reg-form {
    margin-top: 20px;
    display: grid;
    grid-template-columns: 1fr;
    grid-row-gap: 20px;
}

.reg-form__input_text {
    margin: 0;
    padding: 10px;
    width: 100%;

    text-align: center;
    border: 2px solid var(--main-color);
    border-radius: 10px;
}

.reg-form__input_text:focus {
    outline: none;
    border-color: var(--second-color);
}

.formButton {
    margin: 0;
    padding: 15px;
    width: 100%;

    text-align: center;
    background-color: var(--main-color);
    border: none;
    border-radius: 40px;
    color: rgb(255,255,255);
}

.formButton:hover {
    background-color: rgb(204, 66, 20);
    color: rgb(255,255,255);
}

.formButton:active {
    box-shadow: inset 0px 5px 3px 0px rgba(0, 0, 0, 0.2);
}

.formButton:focus {
    outline: none;
}
</style>

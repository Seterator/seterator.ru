<template>
    <form class="auth-form">
        <div>
            <input type="text" asp-for="Login" placeholder="e-mail или логин">
        </div>
        <div>
            <input type="password" placeholder="Пароль">
        </div>
        <div>
            <input class="formButton" type="submit" value="Войти">
        </div>
    </form>
</template>

<script>
export default {

}
</script>

<style scoped>
.auth-form {
    margin-top: 20px;
    display: grid;
    grid-template-columns: 1fr;
    grid-row-gap: 20px;
}

.auth-form input[type=text],
.auth-form input[type=password] {
    margin: 0;
    padding: 10px;
    width: 100%;

    text-align: center;
    border: 2px solid rgb(255, 82, 25);
    border-radius: 10px;
}

.formButton {
    margin: 0;
    padding: 15px;
    width: 100%;

    text-align: center;
    background-color: rgb(255, 82, 25);
    border: none;
    border-radius: 40px;
    color: rgb(255,255,255);
}

.formButton:hover {
    background-color: rgb(204, 66, 20);
    color: rgb(255,255,255);
}
</style>

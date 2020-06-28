<template>
    <form class="reg-form">
        <div>
            <input type="text" placeholder="e-mail">
        </div>
        <div>
            <div>
                <input type="password" placeholder="Пароль">
            </div>
            <!-- <p>На почту придут автоматически сгенерированные логин и пароль.</p> -->
        </div>
        <div>
            <input class="formButton" type="submit" value="Регистрация">
        </div>
    </form>
</template>

<script>
export default {

}
</script>

<style scoped>
.reg-form {
    margin-top: 20px;
    display: grid;
    grid-template-columns: 1fr;
    grid-row-gap: 20px;
}

.reg-form input[type=text],
.reg-form input[type=password] {
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

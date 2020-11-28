<template>
    <footer>
        <b-container>
            <b-row>
                <b-col lg="3" class="f-column">
                    <b-img src="/img/Logo/logo_1-(white).png" class="footer__logo"></b-img>
                </b-col>
                <b-col>
                    <b-row>
                        <b-col cols="6" sm="6" md="4" class="f-column">
                            <div class="list-header">Навигация</div>
                            <div><a href="/">Главная</a></div>
                            <div><a class="disable" href="#">О нас</a></div>
                        </b-col>
                        <b-col cols="6" sm="6" md="4" class="f-column">
                            <div class="list-header">Пользователь</div>
                            <div><a class="disable" href="#">Стать жюри</a></div>
                            <div><a class="disable" href="#">Стать модератором</a></div>
                            <div><a class="disable" href="#">Стать организатором</a></div>
                        </b-col>
                        <b-col cols="6" sm="6" md="4" class="f-column">
                            <div class="list-header">Организаторам</div>
                            <div><a class="disable" href="#">Создать конкурс</a></div>
                            <div><a class="disable" href="#">Узнать больше (pdf)</a></div>
                        </b-col>
                        <b-col cols="6" sm="6" md="4" class="f-column">
                            <div class="list-header">Полезная информация</div>
                            <div><a href="/Home/Privacy">Документы</a></div>
                            <div><a class="disable" href="#">FAQ</a></div>
                        </b-col>
                        <b-col sm="12" md="8" xl="8" class="f-column bank-icons">
                            <img class="tinkoff-icon" src="/img/banks-icons/tinkoff.gif">
                            <img class="bank-icon" src="/img/banks-icons/mastercard.svg">
                            <img class="bank-icon" src="/img/banks-icons/visa.svg">
                        </b-col>
                    </b-row>
                </b-col>
            </b-row>
            <hr>
            <b-row class="last-row">
                <b-col cols="8" sm="8" md="6">
                    <span class="brand">&copy;2020, seterator.ru&trade; | Все права защищены | <a target="_blank" href="https://nginx.org/">Powered&nbsp;by&nbsp;Nginx</a></span>
                </b-col>
                <b-col class="social-icons" cols="4" sm="4" md="6">
                    <a class="social-icon" target="_blank" href="https://vk.com/seterator">
                        <img class="imgSvg" src="/img/Social icons/Orange/vk.svg">
                    </a>
                    <a class="social-icon" target="_blank" href="https://t.me/seterator_updates">
                        <img class="imgSvg" src="/img/Social icons/Orange/telegram.svg">
                    </a>
                </b-col>
            </b-row>
        </b-container>
    </footer>
</template>

<style scoped>
footer {
    background: rgb(17, 17, 17);
    margin: 0;
    padding: 40px 0 30px 0;
    color: white;
}

a {
    color: white;
}
a:hover {
    color: rgb(255, 82, 25);
}

.footer__logo {
    max-width: 200px;
}

.list-header {
    font-weight: 900;
    color: rgb(64, 64, 64);
}

.f-column {
    margin-bottom: 30px;
}

.f-column div {
    margin-bottom: 5px;
}

.f-column div:first-child {
    margin-bottom: 10px;
}

a.disable, a.disable:hover {
    color: rgba(255, 255, 255, 0.5);
    cursor: text;
}

.bank-icons {
    align-self: flex-end;
    display: flex;
    justify-content: flex-end;
}

.bank-icon, .tinkoff-icon {
    align-self: center;
    width: 50px;
    margin: 0 0 0 10px;
}

.tinkoff-icon {
    width: 60px;
}

hr {
    background: rgba(255, 255, 255, 0.2);
}

.last-row {
    align-items: center;
}

.brand {
    font-size: 0.8rem;
}

.social-icons {
    display: flex;
    justify-content: flex-end;
}

.social-icon {
    align-self: center;
    width: 25px;
    margin: 0 0 0 15px;
    fill: white;
}
.social-icon:hover {
    fill: rgb(255, 82, 25);
    cursor: pointer;
}
</style>

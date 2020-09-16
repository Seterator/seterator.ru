<template>
<div class="container account account_background">
    <div 
        v-if="authToggle" 
        class="cheers d-none d-md-block">
            <h2 class="cheers__title">Пиши.</h2>
            <h2 class="cheers__title">и зарабатывай!</h2>
    </div>
    <div 
        v-else 
        class="cheers d-none d-md-block">
            <h2 class="cheers__title">Пиши.</h2>
            <h2 class="cheers__title">Участвуй.</h2>
            <h2 class="cheers__title">Зарабатывай!</h2>
    </div>
    <div class="form-container">
        <button class="switchButton" @click="switchAction">
            <span :class="{ switchButton_active: !authToggle }">Новый участник</span>
            <span :class="{ switchButton_active: authToggle }">Уже сетератор</span>
        </button>
        <authForm-component 
            v-if="authToggle"
            @login-change="login = $event"
            @password-change="password = $event"
            @signin-click="signIn"
        />
        <regForm-component 
            v-else
            @login-change="login = $event"
            @password-change="password = $event"
            @signup-click="signUp"
        />
        <div 
            class="alert alert-warning" 
            v-if="error"
        >
            {{ errorText }}
        </div>
        <p class="auth-agreement">Регистрируясь, Вы соглашаетесь с условиями <a href="/Home/Privacy">Пользовательского соглашения</a>.</p>
    </div>
</div>
</template>

<script>
import AuthFormComponent from './AuthForm.vue';
import RegFormComponent from './RegForm.vue';

export default {
    components: {
        'authForm-component': AuthFormComponent,
        'regForm-component': RegFormComponent
    },
    data: function() {
        return {
            authToggle: true,
            error: false,
            errorText: ''
        }
    },
    methods: {
        switchAction: function() {
            this.authToggle = !this.authToggle;
            this.error = false;
            this.errorText = '';

        },
        signIn: async function(e) {
            if (e.login != '' && e.password != '') {
                let sign = {
                    Username: e.login,
                    Password: e.password
                };
                let response = await fetch('/api/Login', {
                    method: 'POST',
                    headers: {
                        "Content-Type": "text/json; charset=utf-8"
                    }, 
                    body: JSON.stringify(sign)
                });
                let body = await response.json();
                if (await body.status == 0) {
                    document.location.href = '/';
                } else {
                    this.error = true;
                    this.errorText = await body.message;
                }
            }
        },
        signUp: async function(e) {
            if (e.login != '' && e.password != '') {
                let sign = {
                    Username: e.login,
                    Password: e.password
                };
                let response = await fetch('/api/Register', {
                    method: 'POST',
                    headers: {
                        "Content-Type": "text/json; charset=utf-8"
                    }, 
                    body: JSON.stringify(sign)
                });
                let body = await response.json();
                if (await body.status == 0) {
                    document.location.href = '/';
                } else {
                    this.error = true;
                    this.errorText = await body.message;
                }
            }
        }
    }
}
</script>

<style scoped>
.alert {
    margin: 10px;
    text-align: center;
}

.account {
    padding: 0;
    margin-top: 100px;
    margin-bottom: 120px;
    display: grid;
    grid-template-columns: 7fr 4fr;
    gap: 40px;
}

.account_background {
    background: linear-gradient( 90deg, rgba(255,255,255,0.50196) 0%, rgb(255,255,255) 100%), url('/img/Account/bg_login.jpg');
    background-repeat: no-repeat;
    background-position-x: center;
}

.cheers {
    margin-top: 60px;
    justify-self: end;
    white-space: nowrap;
}

.cheers__title {
    font-family: var(--font-serif);
    font-weight: 600;
    font-size: 40pt;
    text-align: right;
}

.cheers__title:nth-child(2) {
    color: var(--main-color);
}

.cheers__title:nth-child(3) {
    color: rgb(204, 66, 20);
}

.form-container {
    padding: 30px 40px;
    margin: 0 100px 0 0;
    border-radius: 10px;
    background: rgb(238, 238, 238);
    box-shadow: 0px 0px 100px 0px rgba(0, 0, 0, 0.2);
}

.switchButton {
    color: rgb(132, 132, 132);
    border: none;
    font-size: 13pt;
    margin: auto;
    white-space: nowrap;
    display: grid;
    grid-gap: 30px;
    grid-template-columns: 1fr 1fr;
}

.switchButton:focus {
    outline: none;
}

.switchButton_active {
    color: var(--main-color);
    box-shadow: 0px 2px 0px 0px var(--main-color);
}

.auth-agreement {
    margin-top: 30px;
    text-align: center;
    font-size: 0.7rem;
}

.auth-agreement a {
    text-decoration: underline;  
}

@media only screen and (max-width: 992px) {
    .cheers__title {
        font-size: 26pt;
    }
}

@media only screen and (max-width: 768px) {
    .account {
        grid-template-columns: 1fr;
        justify-content: center;
    }
    
    .form-container {
        margin: 0;
    }
}
</style>

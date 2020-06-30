<template>
  <div class="container account">
      <div v-if="authToggle" class="cheers d-none d-md-block">
            <h2>Пиши.</h2>
            <h2>и зарабатывай!</h2>
      </div>
      <div v-else class="cheers d-none d-md-block">
            <h2>Пиши.</h2>
            <h2>Участвуй.</h2>
            <h2>Зарабатывай!</h2>
      </div>
      <div class="form-container">
          <div class="switchButton" @click="authToggle = !authToggle">
              <span :class="{ switchButton_active: !authToggle }">Новый участник</span>
              <span :class="{ switchButton_active: authToggle }">Уже сетератор</span>
          </div>
          <authForm-component v-if="authToggle"></authForm-component>
          <regForm-component v-else></regForm-component>
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
            authToggle: true
        }
    }
}
</script>

<style scoped>
.account {
    padding: 0;
    background: linear-gradient( 90deg, rgba(255,255,255,0.50196) 0%, rgb(255,255,255) 100%), url('/img/Account/bg_login.jpg');
    background-repeat: no-repeat;
    background-position-x: center;
    margin-top: 100px;
    margin-bottom: 120px;
    display: grid;
    grid-template-columns: 7fr 4fr;
    gap: 40px;
}

.cheers {
    margin-top: 60px;
    justify-self: end;
    white-space: nowrap;
}

.cheers h2 {
    font-family: 'Merriweather', serif;
    font-weight: 600;
    font-size: 40pt;
    text-align: right;
}

.cheers h2:nth-child(2) {
    color: rgb(255, 82, 25);
}

.cheers h2:nth-child(3) {
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
    font-size: 13pt;
    text-align: center;
    white-space: nowrap;
    display: grid;
    grid-gap: 30px;
    grid-template-columns: 1fr 1fr;
}

.switchButton:hover {
    cursor: pointer;
}

.switchButton_active {
    color: rgb(255, 82, 25);
    box-shadow: 0px 2px 0px 0px rgba(255, 82, 25, 1);
}

.auth-agreement {
    margin-top: 30px;
    text-align: center;
    font-size: 10pt;
}

.auth-agreement a {
    text-decoration: underline;  
}

@media only screen and (max-width: 992px) {
    .cheers h2 {
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

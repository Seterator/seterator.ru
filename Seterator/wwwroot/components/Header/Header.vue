<template>
  <b-container>
    <b-navbar toggleable="lg">
      <b-navbar-brand href="/">
        <b-img src="/img/Logo/logo_1.png" class="logo_vue"></b-img>
      </b-navbar-brand>

      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

      <b-collapse id="nav-collapse" is-nav>
        <b-navbar-nav>
          <b-nav-item link-classes="n_item" href="/">Главная</b-nav-item>

          <b-nav-item
            link-classes="n_item"
            v-if="user.isAuthorized"
            :href="'/' + user.login"
          >Профиль</b-nav-item>
          <b-nav-item link-classes="n_item" v-if="user.isAuthorized" href="/">Выход</b-nav-item>
          <b-nav-item link-classes="n_item" href="/Home/Privacy">Privacy</b-nav-item>
        </b-navbar-nav>

        <b-navbar-nav class="ml-auto">
                    <template v-if="user.isAuthorized">
                        <b-nav-item v-show="false">
                            <b-icon icon="bell"></b-icon>
                        </b-nav-item>
                        <b-nav-item>
                            <b-media class="n_item_last dropdown_menu">
                                <b-img src='/img/icons/avatar.svg' width='15'></b-img>
                                <span class="n_item__user_name">{{ user.login }}</span>
                                <b-icon icon='chevron-down' v-show="true"></b-icon>
                                <div class="dropdown_items">
                                    <a href="/" class="dropdown_item">Редактировать профиль</a>
                                    <a href="/" class="dropdown_item">Конкурсы</a>
                                    <a href="/" class="dropdown_item">Портфолио</a>
                                    <hr class="dropdown_menu_line"></hr>
                                    <a href="/" class="dropdown_item dropdown_item_special">Страница организаторов</a>
                                </div>
                            </b-media>
                        </b-nav-item>
                    </template>
                    <template v-else>
                        <b-nav-item link-classes="n_item" href="/Account/Main">
                            <b-media>
                                    <b-img src='/img/icons/avatar.svg' width='15'></b-img>
                                Авторизация
                            </b-media>
                        </b-nav-item>
                    </template>
                </b-navbar-nav>
      </b-collapse>
    </b-navbar>
  </b-container>
</template>

<script>
// Здесь будет скрипт запроса на данные пользователя
let s_user = {
  isAuthorized: true,
  login: "semen1032",
  roles: ["moderator", "jury"],
};

export default {
  data: function () {
    return {
      user: s_user,
    };
  },
};
</script>

<style scoped>
.logo_vue {
  max-width: 200px;
}

.n_item {
  color: rgba(0, 0, 0, 1) !important;
  font-weight: bold;
}
.n_item:hover {
  color: rgb(255, 82, 25) !important;
  text-decoration: underline;
}
.n_item__user_name {
  color: rgba(0, 0, 0, 1) !important;
  font-weight: bold;
}

.n_item_last:hover .n_item__user_name {
  color: rgb(255, 82, 25) !important;
  text-decoration: underline;
}

.dropdown_menu{
    height: 100%;
    width: 100%;
    margin: 0;
    padding: 20px 50px 0;
    position: relative;
    color: #000;
    display: inline-block;
    overflow: hidden;
    cursor: pointer;
    background-color: #ffffff;
    border: none;
    border-top-left-radius: 15px;
    border-top-right-radius: 15px;
    border-bottom-left-radius: 0;
    border-bottom-right-radius: 0;
}

.dropdown_items{
    position: absolute;
    padding: 0;
    padding: 10px 0;
    left: 0;
    right: 0;
    display: none;
    text-align: center;
    width: auto;
    border: none;
    border-top-left-radius: 0;
    border-top-right-radius: 0;
    border-bottom-left-radius: 15px;
    border-bottom-right-radius: 15px;
}

.dropdown_menu:hover, .dropdown_menu:hover  .dropdown_items{
    overflow: visible;
    display: block;
    background-color: #e7e7e7;
}


.dropdown_item{
 display: block;
 text-size-adjust: none;
 -ms-text-size-adjust: none;
 text-align: center;
 text-shadow: none;
 font-style: normal;
 font-size: 14px;
 font-weight: 300;
 color: #979797;
 margin: 5px 20px;
}

.dropdown_item:hover{
    color: rgb(255, 82, 25) !important;
    text-decoration: underline;
}

.dropdown_menu_line{
    height: 1px;
    width: auto;
    border: #000 1px;
    background-color: #979797;
    
}

.dropdown_item_special{
    color: rgb(255, 82, 25) !important;
}

.dropdown_item_special:hover{
    color: rgb(255, 82, 25) !important;
    text-decoration: underline;
}
</style>

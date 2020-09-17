<template>
  <b-container>
    <b-navbar toggleable="lg" class="navbar">
      <b-navbar-brand href="/">
        <b-img src="/img/Logo/logo_1.png" class="navbar__logo"></b-img>
      </b-navbar-brand>

      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

      <b-collapse id="nav-collapse" is-nav>
        <b-navbar-nav>
          <b-nav-item link-classes="navbar__item" href="/">Главная</b-nav-item>

          <b-nav-item
            link-classes="navbar__item"
            v-if="currentUser.isAuthorized"
            :href="'/' + currentUser.username"
          >Профиль</b-nav-item>
          <b-nav-item link-classes="navbar__item" v-if="currentUser.isAuthorized" @click="signOut">Выход</b-nav-item>
          <b-nav-item link-classes="navbar__item" href="/Home/Privacy">Privacy</b-nav-item>
        </b-navbar-nav>

        <b-navbar-nav class="ml-auto">
            <template v-if="currentUser.isAuthorized">
                <b-nav-item v-show="false">
                    <b-icon icon="bell"></b-icon>
                </b-nav-item>
                <Dropdown 
                    :propUsername="currentUser.username"
                    :propRoles="currentUser.roles"
                />
            </template>
            <template v-else>
                <b-nav-item link-classes="navbar__item" href="/Account/Main">
                    <div class="authorizeButton">
                        <div class="authorize-icon">
                            <img 
                                src='/img/icons/avatar.svg' 
                                class="imgSvg"
                            />
                        </div>
                        Авторизация
                    </div>
                </b-nav-item>
            </template>
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
  </b-container>
</template>

<script>
import Dropdown from "../../components/Header/Dropdown.vue";

export default {
  data: function () {
    return {
      currentUser: this.getCurrentUser(),
    };
  },
  name: "App",
  components: {
    Dropdown
  },
  methods: {
      getCurrentUser: async function() {
          try {
              let response = await fetch('/api/currentuser');
              response = await response;
              this.currentUser = await response.json();
          } catch(e) {
              this.currentUser = null;
              alert(e);
          }
      },
      signOut: async function() {
            let response = await fetch('/api/Logout', {
                method: 'POST',
                headers: {
                    "Content-Type": "text/json; charset=utf-8"
                }
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
};

</script>

<style scoped>
.navbar {
    margin-top: 20px;
}

.authorize-icon {
    width: 15px;
    display: inline-block;
}

.navbar__logo {
  max-width: 200px;
  margin-top: -5px;
}

.navbar__item {
  color: rgb(0, 0, 0) !important;
  font-weight: 600;
}
.navbar__item:hover {
  color: var(--main-color) !important;
  text-decoration: underline;
}

@media (max-width: 991px) {
    .authorize-icon {
        display: none;
    }
}
</style>

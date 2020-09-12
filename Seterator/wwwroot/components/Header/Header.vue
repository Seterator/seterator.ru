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
            v-if="currentUser.isAuthorized"
            :href="'/' + currentUser.username"
          >Профиль</b-nav-item>
          <b-nav-item link-classes="n_item" v-if="currentUser.isAuthorized" href="/">Выход</b-nav-item>
          <b-nav-item link-classes="n_item" href="/Home/Privacy">Privacy</b-nav-item>
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
import Dropdown from "../../components/Header/Dropdown.vue";

// let s_user = {
//     isAuthorized: true,
//     username: 'Семён',
//     roles: ['moderator', 'jury']
// };

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
      }
  }
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

.mid_margin{
  margin: 0 5px 0 5px;
}
</style>

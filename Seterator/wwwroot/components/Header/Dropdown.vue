<template>
  <b-nav-item>
    <b-media class="n_item_last dropdown_menu">
      <b-img class="mid_margin n_item__user_image" src="/img/icons/avatar.svg" width="15"></b-img>
      <span class="n_item__user_name">{{ propUsername }}</span>
      <b-icon class="mid_margin n_item__user_icon" icon="chevron-down" v-show="true"></b-icon>
      <div class="dropdown_items">
        <a href="/" class="dropdown_item">Редактировать профиль</a>
        <a href="/" class="dropdown_item">Конкурсы</a>
        <a href="/" class="dropdown_item">Портфолио</a>
        <hr class="dropdown_menu_line" />

        <a 
            v-for="role in propRoles"
            :key="role"
            href="/" 
            class="dropdown_item dropdown_item_special"
        >
            Страница {{role}}
        </a>

      </div>
    </b-media>
  </b-nav-item>
</template>

<script>
export default {
props: {
    propUsername: String,
    propRoles: Array
},
};
</script>

<style  scoped>
  .dropdown_menu{
    /*border-style: solid;*/
    /*border-color: #000;*/
    /*border-width: 1px;*/
    /*border-radius: 15px;*/
    display: inline-block !important;
    position: relative;
    padding: 0 10px 0 10px;
    /*overflow: hidden;*/

    background-color: #fff;
    border-top-left-radius: 15px;
    border-top-right-radius: 15px;

    transition: all 0.3s ease-in-out;
  }

  .dropdown_menu:focus,
  .dropdown_menu:focus-within,
  .dropdown_menu:hover{
    background-color: rgb(228, 227, 227);
  }

  .n_item__user_image, .n_item__user_name, .n_item__user_icon{
    display: inline-block !important;
  }

  .n_item__user_image{
    width: 15px !important;
    height: 15px !important;
  }

  .n_item__user_icon{
    width: 15px !important;
    height: 15px !important;

  }

  .n_item__user_name{
    text-emphasis: none;
    text-align: center;
    text-decoration: none;
    font-size: 1em;
    font-style: normal;
    font-weight: 500;
    /*background-color: white;*/
    transition-delay: background-color 0.3s ease-in-out;
  }

  .dropdown_items{
    display: block;
    position: absolute;
    visibility: hidden; /* hides sub-menu */
    opacity: 0;
    top: 100%;
    left: 0;
    width: 100%;
    transform: translateY(-1em);
    z-index: -1;
    transition: 
      all 0.3s ease-in-out 0s, 
      visibility 0s linear 0.3s, 
      z-index 0s linear 0.01s;

    background-color: rgb(228, 227, 227);
    border-bottom-left-radius: 15px;
    border-bottom-right-radius: 15px;
  }

  .dropdown_menu:focus .dropdown_items,
  .dropdown_menu:focus-within .dropdown_items,
  .dropdown_menu:hover .dropdown_items {
    visibility: visible; /* shows sub-menu */
    opacity: 1;
    z-index: 1;
    transform: translateY(0%);
    transition-delay: 0s, 0s, 0.3s; /* this removes the transition delay so the menu will be visible while the other styles transition */
  }


  .dropdown_item{
    display: block;
    margin: 10px 10px 10px 10px;
    text-emphasis: none;
    text-align: center;
    font-size: 1em;
    font-style: normal;
    text-decoration: none;
  }
</style>

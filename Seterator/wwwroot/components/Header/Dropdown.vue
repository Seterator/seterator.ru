<template>
  <b-nav-item>
    <b-media class="dropdown_menu dropdown">
      <b-img class="mid_margin dropdown__user-image" src="/img/icons/avatar.svg" width="15" />
      <span class="dropdown__user-name">{{ propUsername }}</span>
      <b-icon class="mid_margin dropdown__chevron-icon" icon="chevron-down" v-show="true" />
      <div class="dropdown__items">
        <a href="/" class="dropdown__item">Редактировать профиль</a>
        <a href="/" class="dropdown__item">Конкурсы</a>
        <a href="/" class="dropdown__item">Портфолио</a>
        <hr class="dropdown_menu_line" />

        <a 
            v-for="role in propRoles"
            :key="role"
            href="/" 
            class="dropdown__item dropdown__item_special"
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
.dropdown{
    min-width: 150px;
    text-align: end;
    position: relative;
    padding: 0 10px;

    background-color: #fff;
    border-top-left-radius: 15px;
    border-top-right-radius: 15px;

    transition: all 0.3s ease-in-out;
}

.dropdown:focus,
.dropdown:focus-within,
.dropdown:hover {
    background-color: rgb(228, 227, 227);
}

.dropdown__user-image,
.dropdown__chevron-icon {
    margin: 0 5px 0 5px;
}

.dropdown .dropdown__user-name:hover {
    color: var(--main-color);
    text-decoration: underline;
}

.dropdown__user-name {
    text-emphasis: none;
    text-align: center;
    text-decoration: none;
    font-size: .9rem;
    font-style: normal;
    font-weight: 600;
    transition-delay: background-color 0.3s ease-in-out;
    color: rgb(0, 0, 0);
}

.dropdown__items{
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

.dropdown:focus .dropdown__items,
.dropdown:focus-within .dropdown__items,
.dropdown:hover .dropdown__items {
    visibility: visible; /* shows sub-menu */
    opacity: 1;
    z-index: 1;
    transform: translateY(0%);
    transition-delay: 0s, 0s, 0.3s; /* this removes the transition delay so the menu will be visible while the other styles transition */
}


.dropdown__item{
    display: block;
    margin: 10px;
    text-emphasis: none;
    text-align: center;
    font-size: 1rem;
    font-style: normal;
    text-decoration: none;
}

.dropdown__item:hover {
    text-decoration: underline;
}

@media (max-width: 991px) {
    .dropdown__user-image {
        display: none;
    }

    .dropdown__user-name {
        font-size: 16px;
        font-weight: 600;
    }

    .dropdown {
        min-width: 100%;
        text-align: start;

        transform: none;
        padding: 10px 0;
        font-size: 1rem;
        font-weight: 600;
        color: rgb(0, 0, 0);
    }   

    .dropdown:hover {
        background: none;
    }

    .dropdown__items {
        visibility: visible; /* shows sub-menu */
        opacity: 1;
        z-index: 1;
        position: relative;
        transition: none;
        transform: none;

        background: none;
    }

    .dropdown__item {
        text-align: left;
        margin-left: 0;
    }
}
</style>

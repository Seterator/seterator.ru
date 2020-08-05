// Компонент описывает отображение профиля пользователя в роли модератора
//
// Требуется внедрить API (пока их не существует)

<template>
  <div>
      <div class="container">
          <div class="profilePersonal__wrap">
              <div class="profilePersonal__leftSide">
                    <profile-avatar class="profile__avatar-wrap" 
                                    src="/img/Profile/ava.png" 
                    />
                    <social-icons   class="profile__socialIcons" 
                                    :socialIcons="propSocialIcons.data" 
                                    :color="propSocialIcons.color" 
                    />
                    <profile-rating class="profile__rating-wrap profile__block" 
                                    :rating="propRating" 
                    />
              </div>
              <div class="profilePersonal__rightSide">
                  <div class="profile__about-wrap profile__block profile__block_bottom_button">
                    <profile-roles  :prop_roles="propRoles" 
                                    :active_role="propActiveRole"
                    />
                    <span class="profile__userName"> {{ name }} </span>
                    <h4 class="profile__title profile__title_topMargin">О себе</h4>
                    <div class="profile__block_margin_top">{{ about }}</div>
                    <seterator-button   class="profile__button" 
                                        :propText="'Модерировать'"
                                        :propHref="'#'"
                                        :propColor="'orangeShadow'"
                    />
                    </div>
                    <profile-personal   class="profile__block" 
                                        :personal_data="propPersonalInfo" 
                    />
              </div>
          </div>
      </div>
  </div>
</template>

<script>
import ProfileAvatar from './ProfileAvatar.vue';
import SocialIcons from '../Other/SocialIcons.vue';
import ProfileRating from './ProfileRating.vue';
import ProfileRoles from './ProfileRoles.vue';
import SeteratorButton from '../Other/SeteratorButton.vue';
import ProfilePersonal from './ProfilePersonal.vue';

export default {
    components: {
        'profile-avatar': ProfileAvatar,
        'social-icons': SocialIcons,
        'profile-rating': ProfileRating,
        'profile-roles': ProfileRoles,
        'seterator-button': SeteratorButton,
        'profile-personal': ProfilePersonal
    },

    props: {
        propSocialIcons: {
            type: Object,
            validator: function(value) {
                if ('data' in value && 'color' in value) {
                    return true;
                }
                else {
                    return false;
                }
            }
        },
        propRating: {
            type: Array
        },
        propRoles: {
            type: Array
        },
        propActiveRole: {
            type: String
        },
        propPersonalInfo: {
            type: Object,
            validator: function(value) {
                if ('name'      in value &&
                    'phone'     in value &&
                    'email'     in value &&
                    'country'   in value &&
                    'city') {
                        return true;
                }
                else {
                    return false;
                }
            }
        }
    },

    data: function() {
        return {
            name: 'Семенов Семён',
            about: 'Я такой человек, мне нужно быть уверенным, что с людьми у меня взаимные чувства. Если я хочу написать — то и человек хочет написать мне, если я люблю — то и меня. Но если я хоть на капельку почувствую, что мне не рады, я перестаю писать, звонить, и даже думать об этом человеке. Мне начинает казаться, что я себя навязываю, и от этой мысли пропадает любое желание контактировать с таким человеком.',
        };
    }

}
</script>

<style>

</style>

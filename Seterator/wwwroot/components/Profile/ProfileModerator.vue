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
                  <div class="profile__about-wrap profile__block">
                    <profile-roles  :prop_roles="propRoles" 
                                    :active_role="propActiveRole"
                    />
                  </div>
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

export default {
    components: {
        'profile-avatar': ProfileAvatar,
        'social-icons': SocialIcons,
        'profile-rating': ProfileRating,
        'profile-roles': ProfileRoles,
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
        }
    },

    data: function() {
        return {
        };
    }

}
</script>

<style>

</style>

// Компонент представляет отображение провиля пользователя в роли жюри

<template>
    <div class="container">
        <div class="profilePersonal__wrap">
            <div class="profilePersonal__leftSide">
                <profile-avatar class="profile__avatar-wrap" 
                                :src="'/img/Profile/ava.png'" 
                                :propIsEditing="propIsEditing"
                />
                <social-icons   class="profile__socialIcons" 
                                :socialIcons="propSocialIcons"   
                                :color="'rgb(255, 82, 25)'" 
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
                    
                    <!-- Имя пользователя -->
                    <span   v-if="!propIsEditing" 
                            class="profile__userName"
                    >
                        {{ propUser.fullName }}
                    </span>
                    <input  v-else
                            class="profile__userName profile__inputText"
                            type="text"
                            :value="propUser.fullName"
                            @change="$emit('change-fullname', $event.target.value)"
                    >

                    <!-- О пользователе -->
                    <h4 class="profile__title profile__title_topMargin">О себе</h4>
                    <div    class="profile__block_margin_top"
                            v-if="!propIsEditing"
                    >
                        {{ propUser.about }}
                    </div>
                    <textarea   v-else
                                class="profile__block_margin_top profile__textarea"
                                :value="propUser.about"
                                @change="$emit('change-about', $event.target.value)"
                    ></textarea>

                    <seterator-button   class="profile__button" 
                                        :propText="'Оценивать'"
                                        :propHref="'#'"
                                        :propColor="'orangeShadow'"
                    />
                    <div    class="profile__editButton" 
                            @click="$emit('change-mode')"
                    >
                        <img-text   :img="'/img/icons/edit.svg'"
                                    :imgColor="'rgb(255, 82, 25)'"
                                    :text="propIsEditing ? 'Сохранить' : 'Редактировать'"
                        />
                    </div>
                </div>
                
                <!-- Персональные данные -->
                <profile-personal   class="profile__block" 
                                    :propPersonalInfo="propPersonalInfo"
                                    :propIsEditing="propIsEditing"
                                    @change-personalinfo="changePersonalInfo"
                />
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
import ImgText from '../Other/ImgText.vue';

export default {
    components: {
        'profile-avatar': ProfileAvatar,
        'social-icons': SocialIcons,
        'profile-rating': ProfileRating,
        'profile-roles': ProfileRoles,
        'seterator-button': SeteratorButton,
        'profile-personal': ProfilePersonal,
        'img-text': ImgText
    },

    props: {
        propUser: {
            type: Object
        },

        propSocialIcons: {
            type: Array,
            // validator: function(value) {
            //     if ('data' in value && 'color' in value) {
            //         return true;
            //     }
            //     else {
            //         return false;
            //     }
            // }
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
        },

        propIsEditing: {
            type: Boolean
        }
    },

    methods: {
        changePersonalInfo: function(e) {
            this.$emit('change-personalinfo', e);
        }
    }
}
</script>

<style>

</style>

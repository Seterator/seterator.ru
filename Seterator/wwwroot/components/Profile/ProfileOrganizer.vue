// Компонент описывает отображение профиля пользователя в роли организатора

<template>
    <div class="profileOrganizer container">
        <div class="profileOrganizer__banner">
            <div class="profileOrganizer__socialIcons">
                <social-icons   class="profile__socialIcons" 
                                :socialIcons="propSocialIcons"   
                                :color="'rgb(255, 255, 255)'" 
                />
            </div>
            <profile-avatar class="profileOrganizer__avatar"
                            :role="propActiveRole"  
                            :src="'/img/Profile/ava.png'" 
                            :propIsEditing="propIsEditing"
            />
        </div>
        <div class="profilePersonal__wrap">
            <div class="profilePersonal__leftSide">
                <profile-rating class="profile__rating-wrap profile__block" 
                                :rating="propRating" 
                />
                <profile-drafts class="profile__drafts-wrap profile__block" 
                />
            </div>
            <div class="profilePersonal__rightSide">
                <div class="profile__about-wrap profile__block">
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
import ProfilePersonal from './ProfilePersonal.vue';
import ProfileDrafts from './ProfileDrafts.vue';
import ImgText from '../Other/ImgText.vue';

export default {
    components: {
        'profile-avatar': ProfileAvatar,
        'social-icons': SocialIcons,
        'profile-rating': ProfileRating,
        'profile-drafts': ProfileDrafts,
        'profile-roles': ProfileRoles,
        'profile-personal': ProfilePersonal,
        'img-text': ImgText
    },

    props: {
        propUser: {
            type: Object
        },

        propSocialIcons: {
            type: Array
        },

        propRating: {
            type: Object
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
.profileOrganizer__banner {
    display: flex;
    align-items: flex-end;
    justify-content: flex-end;
    position: relative;
    width: 100%;
    min-height: 200px;
    color: rgb(238, 238, 238);
    background: linear-gradient(to right, rgba(17, 17, 17, 0.7) 0%, rgba(17, 17, 17, 0.7) 100%), url('/img/Index/bg_1.jpg');
    background-size: cover;
    background-position: 10% 85%;
    background-repeat: no-repeat;

    margin-bottom: 75px;
}

.profileOrganizer__socialIcons {
    min-width: 150px;
    margin-bottom: 10px;
}

.profileOrganizer__avatar {
    position: absolute;
    bottom: 0;
    left: 50px;
    margin-bottom: -75px;
}
</style>

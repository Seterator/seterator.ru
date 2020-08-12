// Компонент описывает отображение профиля пользователя в роли seterator
//
// Требуется внедрить API (пока их не существует)

<template>
    <div>
        <div class="container">
            <div class="profilePersonal__wrap">
                <div class="profilePersonal__leftSide">
                    <profile-avatar class="profile__avatar-wrap" 
                                    :src="propUser.avatar" 
                                    :propIsEditing="propIsEditing"
                                    @change-avatar="$emit('change-avatar', $event)" 
                    />
                    <social-icons   class="profile__socialIcons" 
                                    :socialIcons="propSocialIcons"   
                                    :color="'rgb(255, 82, 25)'" 
                    />
                    <profile-rating class="profile__rating-wrap profile__block" 
                                    :rating="propRating" 
                    />
                    <profile-drafts class="profile__drafts-wrap profile__block" />
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
        <profile-statistics :statistics="statistics_example" />
    </div>
</template>

<script>
import ProfileAvatar from './ProfileAvatar.vue';
import SocialIcons from '../Other/SocialIcons.vue';
import ProfileRating from './ProfileRating.vue';
import ProfileDrafts from './ProfileDrafts.vue';
import ProfileRoles from './ProfileRoles.vue';
import ProfilePersonal from './ProfilePersonal.vue';
import ProfileStatistics from './ProfileStatistic.vue';
import ImgText from '../Other/ImgText.vue';


export default {
    components: {
        'profile-avatar': ProfileAvatar,
        'social-icons': SocialIcons,
        'profile-rating': ProfileRating,
        'profile-drafts': ProfileDrafts,
        'profile-roles': ProfileRoles,
        'profile-personal': ProfilePersonal,
        'profile-statistics': ProfileStatistics,
        'img-text': ImgText
    },

    props: {
        propUser: {
            type: Object
        },

        propSocialIcons: {
            type: Array,
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

    data: function() {
        return {
            
            socialIcons__data: [
                {
                    name: 'vk',
                    href: 'https://vk.com/seterator',
                },
                {
                    name: 'telegram',
                    href: 'tg.com/seterator',
                },
                {
                    name: 'github',
                    href: 'https://github.com'
                }
            ],
            socialIcons__color: 'red',
            rating: [
                {
                    name: 'Автор',
                    value: '100'
                },
                {
                    name: 'Жюри',
                    value: '1000'
                }
            ],
            roles: ['profile-seterator', 'profile-moderator'],
            personal_info: {
                name: 'Семенов Семён',
                phone: '+79253207279',
                email: 'em@ail.com',
                country: 'Russia',
                city: 'Moscow'

            },
            statistics_example: [
                {
                    name: 'h',
                    value: '100'
                },
                {
                    name: 'p',
                    value: '100'
                }
            ]
        }
    },

    methods: {
        changePersonalInfo: function(e) {
            this.$emit('change-personalinfo', e);
        }
    }
}
</script>

<style scoped>

</style>

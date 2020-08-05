// Компонент описывает отображение профиля пользователя в роли seterator
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
                    <profile-drafts class="profile__drafts-wrap profile__block" />
                </div>
                <div class="profilePersonal__rightSide">
                    <div class="profile__about-wrap profile__block">
                        <profile-roles  :prop_roles="propRoles" 
                                        :active_role="propActiveRole"
                        />
                        <span class="profile__userName">{{ name }}</span>
                        <h4 class="profile__title profile__title_topMargin">О себе</h4>
                        <div class="profile__block_margin_top">{{ about }}</div>
                    </div>
                    <profile-personal   class="profile__block" 
                                        :personal_data="propPersonalInfo" 
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

export default {
    components: {
        'profile-avatar': ProfileAvatar,
        'social-icons': SocialIcons,
        'profile-rating': ProfileRating,
        'profile-drafts': ProfileDrafts,
        'profile-roles': ProfileRoles,
        'profile-personal': ProfilePersonal,
        'profile-statistics': ProfileStatistics
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
            name: 'Семенов Семён',
            about: 'Я такой человек, мне нужно быть уверенным, что с людьми у меня взаимные чувства. Если я хочу написать — то и человек хочет написать мне, если я люблю — то и меня. Но если я хоть на капельку почувствую, что мне не рады, я перестаю писать, звонить, и даже думать об этом человеке. Мне начинает казаться, что я себя навязываю, и от этой мысли пропадает любое желание контактировать с таким человеком.',
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
    }
}
</script>

<style scoped>

</style>

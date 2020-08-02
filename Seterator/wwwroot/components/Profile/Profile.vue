// Компонент, описывающий страницу профиля пользователя

<template>
    <div>
        <div class="container">
            <div class="profilePersonal__wrap">
                <div class="profilePersonal__leftSide">
                    <profile-avatar class="profile__avatar-wrap" src="/img/Profile/ava.png"></profile-avatar>
                    <social-icons class="profile__socialIcons" :socialIcons="socialIcons__data" :color="socialIcons__color"></social-icons>
                    <profile-rating class="profile__rating-wrap profile__block" :rating="rating"></profile-rating>
                    <profile-drafts class="profile__drafts-wrap profile__block"></profile-drafts>
                </div>
                <div class="profilePersonal__rightSide">
                    <div class="profile__about-wrap profile__block">
                        <profile-roles :prop_roles="roles"></profile-roles>
                        <span class="profile__name">{{name}}</span>
                        <h4 class="profile__header profile__header_topMargin">О себе</h4>
                        <div class="profile__about">{{about}}</div>
                    </div>
                    <profile-personal class="profile__block" :personal_data="personal_info"></profile-personal>
                </div>
            </div>
        </div>
        <profile-statistics :statistics="statistics_example"></profile-statistics>
    </div>
</template>

<script>
import ProfileAvatar from './ProfileAvatar.vue';
import SocialIcons from '../Other/SocialIcons.vue';
import ProfileRating from './ProfileRating.vue';
import ProfileDrafts from './ProfileDrafts.vue';
import ProfileRoles from './ProfileRoles.vue';
import ProfilePersonal from './ProfilePersonal.vue';
import ProfileStatistics from './ProfileStatistics.vue';

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
            roles: ['Сетератор', 'Модератор'],
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
                    name: 'Количество участий в конкурсе',
                    value: '100'
                },
                {
                    name: 'Количество взятых призовых мест в конкурсе',
                    value: '100'
                },
                {
                    name: 'Количество участий в конкурсе',
                    value: '100'
                },
                {
                    name: 'Количество взятых призовых мест в конкурсе',
                    value: '100'
                }
            ]
        }
    }
}
</script>

<style>
.profile__header {
    font-family: 'Merriweather', serif;
    font-size: 1.3rem;
    font-weight: bold;
}

.profile__header_topMargin {
    margin-top: 35px;
}

.profile__about {
    margin-top: 25px;
}

.profilePersonal__wrap {
    display: grid;
    grid-template-columns: 1fr 3fr;
    gap: 30px;
}

.profilePersonal__leftSide,
.profilePersonal__rightSide {
    display: flex;
    flex-direction: column;
}

.profile__block {
    margin-top: 15px;
    background: rgb(238, 238, 238);
    padding: 30px;
}


.profile__name {
    font-family: 'Merriweather', serif;
    font-size: 2rem;
    font-weight: bold;
    padding: 15px 0;
}
</style>

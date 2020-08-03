// Компонент, описывающий страницу профилей пользователя
// Данный компонент отображает копоненты, соответствующие активной роли пользователя

<template>
    <div>
        <component  :is="activeRole"
                    v-on:swapRole="activeRole = $event"
                    :propActiveRole="activeRole"
                    :propSocialIcons="socialIcons"
                    :propRating="rating"
                    :propRoles="roles"
                    :propPersonalInfo="personalInfo"
        />
    </div>
</template>

<script>
import ProfileSeterator from './ProfileSeterator.vue';
import PrfofileModerator from './ProfileModerator.vue';

export default {
    components: {
        'profile-seterator': ProfileSeterator,
        'profile-moderator': PrfofileModerator
    },

    data: function() {
        return {
            activeRole: '',
            socialIcons: {
                data: [
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
                color: 'red'
            },
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
            personalInfo: {
                name: 'Семенов Семён',
                phone: '+79253207279',
                email: 'em@ail.com',
                country: 'Russia',
                city: 'Moscow'

            }
        }
    },

    mounted: function() {
        let role = new URL(document.URL);
        role = role.searchParams.get('role');

        switch (role) {
            case ('profile-moderator' || 'profile-jury' || 'profile-organization'):
                this.activeRole = role;
                break;
            default:
                this.activeRole = 'profile-seterator';
                break;
        }
    }
}
</script>

<style>
.profile__title {
    font-family: 'Merriweather', serif;
    font-size: 1.3rem;
    font-weight: bold;
}

.profile__title_topMargin {
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

.profile__userName {
    font-family: 'Merriweather', serif;
    font-size: 2rem;
    font-weight: bold;
    padding: 15px 0;
}
</style>

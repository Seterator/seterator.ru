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
import ProfileJury from './ProfileJury.vue';
import ProfileOrganizer from './ProfileOrganizer.vue';

export default {
    components: {
        'profile-seterator': ProfileSeterator,
        'profile-moderator': PrfofileModerator,
        'profile-jury': ProfileJury,
        'profile-organizer': ProfileOrganizer
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
            roles: ['profile-seterator', 'profile-moderator', 'profile-jury', 'profile-organizer'],
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
            case ('profile-moderator'):
                this.activeRole = role;
                break;
            case ('profile-jury'):
                this.activeRole = role;
                break;
            case ('profile-organizer'):
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

.profile__block_margin_top {
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
    margin-top: 30px;
    background: rgb(238, 238, 238);
    padding: 30px;
}

.profile__block_bottom_button {
    position: relative;
    border-bottom: 2px solid transparent;
    border-image:  radial-gradient(ellipse at center, rgba(255,83,25,1) 50%, rgba(255,83,25,0.87) 50%, rgba(255,83,25,0.87) 66%, rgba(255,255,255,0.87) 100%);
    border-image-slice: 1;
}

.profile__userName {
    font-family: 'Merriweather', serif;
    font-size: 2rem;
    font-weight: bold;
    padding: 15px 0;
}

.profile__button {
    position: absolute;
    bottom: 0%;
    left: 50%;
    width: 200px !important;
    height: 50px !important;
    margin-bottom: -25px !important;
    margin-left: -100px !important;
    line-height: 16px;
}
</style>

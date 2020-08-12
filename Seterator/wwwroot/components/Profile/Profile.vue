// Компонент, описывающий страницу профилей пользователя
// Данный компонент отображает копоненты, соответствующие активной роли пользователя

<template>
    <div>
        <component  :is="activeRole"
                    :propUser="user"
                    :propActiveRole="activeRole"
                    :propSocialIcons="user.socialIcons"
                    :propRating="user.rating"
                    :propRoles="user.roles"
                    :propPersonalInfo="user.personalInfo"
                    :propIsEditing="isEditing"
                    @swapRole="activeRole = $event"
                    @change-mode="changeMode"
                    @change-avatar="changeAvatar"
                    @change-fullname="changeFullName"
                    @change-about="changeAbout"
                    @change-personalinfo="changePersonalInfo"
                    class="profile"
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
            user: {
                avatar: '/img/Profile/ava.png',

                socialIcons: [
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
                fullName: 'Семен Семенов',
                about: 'Я такой человек, мне нужно быть уверенным, что с людьми у меня взаимные чувства. Если я хочу написать — то и человек хочет написать мне, если я люблю — то и меня. Но если я хоть на капельку почувствую, что мне не рады, я перестаю писать, звонить, и даже думать об этом человеке. Мне начинает казаться, что я себя навязываю, и от этой мысли пропадает любое желание контактировать с таким человеком.',
                personalInfo: {
                    name: 'Семенов Семён',
                    phone: '+79253207279',
                    email: 'em@ail.com',
                    country: 'Russia',
                    city: 'Moscow'
                }
            },
            isEditing: false,
            activeRole: ''
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
    },

    methods: {
        changeMode: function(e) {
            this.isEditing = !this.isEditing;
        },

        changeAvatar: function(e) {
            this.user.avatar = e; 
        },

        changeFullName: function(e) {
            this.user.fullName = e;
        },

        changeAbout: function(e) {
            this.user.about = e;
        },

        changePersonalInfo: function(e) {
            this.user.personalInfo = e;
        }
    }
}
</script>

<style>
.profile {
    margin-bottom: 800px;
}

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
    position: relative;
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

.profile__editButton {
    position: absolute;
    top: 30px;
    right: 25px;
    color: rgb(255, 82, 25);
    font-weight: bold;
    font-size: .9rem;
    cursor: pointer;
}

.profile__editButton:hover {
    color: red;
}

.profile__inputText {
    background: rgb(230, 230, 230);
    padding: 10px;
    margin-top: 5px;
    border: none;
    width: 100%;
    color: rgb(127, 127, 127);
}

.profile__textarea {
    width: 100%;
    height: 200px;
    background: rgb(230, 230, 230);
    padding: 10px;
    border: none;

    color: rgb(127, 127, 127);
}

</style>

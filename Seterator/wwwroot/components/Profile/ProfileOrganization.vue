<template>
    <div class="profileOrganization container">
        <div class="profileOrganization__banner">
            <div class="profileOrganization__socialIcons">
                <social-icons   :color="'white'"
                                :socialIcons="propSocialIcons.data"
                />
            </div>
            <profile-avatar class="profileOrganization__avatar"
                            :role="'organization'"
                            src="/img/Profile/ava.png" 
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
                    <span class="profile__userName"> {{ name }} </span>
                    <h4 class="profile__title profile__title_topMargin">О себе</h4>
                    <div class="profile__block_margin_top">{{ about }}</div>
                </div>
                <profile-personal   class="profile__block" 
                                    :personal_data="propPersonalInfo" 
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

export default {
    components: {
        'profile-avatar': ProfileAvatar,
        'social-icons': SocialIcons,
        'profile-rating': ProfileRating,
        'profile-drafts': ProfileDrafts,
        'profile-roles': ProfileRoles,
        'profile-personal': ProfilePersonal
    },

    props: {
        propSocialIcons: {
            type: Object
        },

        propRating: {
            type: Object
        },

        propPersonalInfo: {
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
.profileOrganization__banner {
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

.profileOrganization__socialIcons {
    min-width: 150px;
    margin-bottom: 10px;
}

.profileOrganization__avatar {
    position: absolute;
    bottom: 0;
    left: 50px;
    margin-bottom: -75px;
}
</style>

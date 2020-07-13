<template>
  <div class="container">
      <div class="profilePersonal__wrap">
        <div class="profilePersonal__leftSide">
            <profile-avatar class="profile__avatar-wrap" src="/img/Profile/ava.png"></profile-avatar>
            <social-icons class="profile__socialIcons" :socialIcons="socialIcons__data" :color="socialIcons__color"></social-icons>
            <profile-rating class="profile__rating-wrap profile__block" :rating="rating">
            </profile-rating>
            <div class="profile__drafts-wrap">
                <h5>Черновики</h5>
            </div>
        </div>
        <div class="profilePersonal__rightSide">
            <div class="profile__about-wrap">
                <h5>Об авторе</h5>
            </div>
            <div class="profile__achievments-wrap">
                <h5>Достижения</h5>
            </div>
        </div>
    </div>
  </div>
</template>

<script>
import ProfileAvatar from './ProfileAvatar.vue';
import SocialIcons from '../Other/SocialIcons.vue';
import ProfileRating from './ProfileRating.vue';

export default {
    components: {
        'profile-avatar': ProfileAvatar,
        'social-icons': SocialIcons,
        'profile-rating': ProfileRating
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
            ]
        }
    }
}
</script>

<style scoped>
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
    padding: 15px;
}
</style>

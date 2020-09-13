<template>
  <div class="about container">
      <div class="about__header">
          <h2 class="about__title">О нас</h2>
          <div class="about__description">
              На данной странице Вы сможете ознакомиться с нашей командой, наставниками и партнерами проекта.
          </div>
      </div>

    <about-team :propTeam="team">

    </about-team>
      
  </div>
</template>

<script>
import AboutTeamComponent from './AboutTeam.vue';

export default {
components: {
    'about-team': AboutTeamComponent
},
data() {
    return {
        team: [
            {
                avatarSrc: '/img/About/team_lead.png',
                username: 'Александр Новожилов',
                status: 'Team lead',
                description: '',
            },
            {
                avatarSrc: '/img/About/prokazin.jpeg',
                username: 'Михаил Проказин',
                status: 'CTO',
                description: '',
            },
            {
                avatarSrc: '/img/About/designer.jpeg',
                username: 'Василий Птицын',
                status: 'Web-designer',
                description: '',
            },
            {
                avatarSrc: '/img/About/semenov.jpeg',
                username: 'Семён Семенов',
                status: 'Ведущий Frontend-разработчик',
                description: '',
            },
            {
                avatarSrc: '/img/About/kseniya.jpeg',
                username: 'Ксения Платонова',
                status: 'Иллюстратор',
                description: '',
            },
            {
                avatarSrc: '/img/About/belousov.jpeg',
                username: 'Иван Белоусов',
                status: 'Мобильный разработчик',
                description: '',
            },
            {
                avatarSrc: '/img/About/anastasia.jpeg',
                username: 'Анастасия Загинайко',
                status: 'Графический дизайнер',
                description: '',
            },
            {
                avatarSrc: '/img/About/bogdan.jpeg',
                username: 'Богдан Котиков',
                status: 'Программист',
                description: '',
            },
            {
                avatarSrc: '/img/About/max.png',
                username: 'Максим Добряков',
                status: 'Юрист',
                description: '',
            },
        ],
        mentors: [
            {
                avatarSrc: '/img/About/',
                username: '',
                status: '',
                description: '',
            },
            {
                avatarSrc: '/img/About/',
                username: '',
                status: '',
                description: '',
            },
            {
                avatarSrc: '/img/About/',
                username: '',
                status: '',
                description: '',
            },
            {
                avatarSrc: '/img/About/',
                username: '',
                status: '',
                description: '',
            },
            {
                avatarSrc: '/img/About/',
                username: '',
                status: '',
                description: '',
            },
        ]
    }
}
}
</script>

<style scoped>
.about {
    margin-bottom: 50px;
}
.about__header {
    max-width: 400px;
    margin-bottom: 40px;
}

.about__title {
    font-family: 'Merriweather', serif;
    font-weight: 600;
    font-size: 24pt;
}

.about__description {
    margin-top: 20px;
}
</style>

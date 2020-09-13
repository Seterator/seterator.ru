<template>
  <div class="about container">
      <div class="about__header">
          <h2 class="about__title">О нас</h2>
          <div class="about__description">
              На данной странице Вы сможете ознакомиться с нашей командой, наставниками и партнерами проекта.
          </div>
      </div>

    <about-team>

    </about-team>
      
  </div>
</template>

<script>
import AboutTeamComponent from './AboutTeam.vue';

export default {
components: {
    'about-team': AboutTeamComponent
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

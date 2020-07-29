<template>
  <ul class="socialIcons__wrap">
      <li class="socialIcons__icon" v-for="socialIcon in socialIcons" :key="socialIcon.name">
          <a :href="socialIcon.href" target="_blank" :style="{ fill: color }"><img class="aqua imgSvg" :src="pickImage(socialIcon.name)"></a>
      </li>
  </ul>
</template>

<script>
export default {
    props: [
        'socialIcons',
        'color'
    ],
    methods: {
        pickImage(name) {
            switch (name) {
                case 'vk':
                    return '/img/Social icons/Orange/vk.svg';
                    break;
                case 'telegram':
                    return '/img/Social icons/Orange/telegram.svg';
                    break;
                case 'facebook':
                    return '/img/Social icons/Orange/facebook.svg';
                    break;
                case 'twitter':
                    return '/img/Social icons/Orange/twitter.svg';
                    break;
                default:
                    return '/img/icons/web.svg';
                    break;
            }
        }
    }
}
</script>

<style scoped>
.socialIcons__wrap {
    margin: 15px 10px 0 10px;
    padding: 0;
    display: flex;
    flex-wrap: nowrap;
    justify-content: space-evenly;
}

.socialIcons__icon {
    list-style: none;
    width: 20px;
}

.socialIcons__icon:hover {
    opacity: 50%;
}
</style>

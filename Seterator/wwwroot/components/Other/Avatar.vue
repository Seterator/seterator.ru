<template>
  <div class="avatar" :class="{'avatar_style_rounded': propIsRounded}">
  </div>
</template>

<script>
export default {
props: {
    propSrc: String,
    propIsRounded: Boolean
}
}
</script>

<style>
.avatar {
    height: 250px;
    background: url('/img/devka.jpg');
    background-size: cover;
    background-repeat: no-repeat;
    background-position: center;
    
}

.avatar_style_rounded {
    max-width: 100px;
    height: 100px;
    border-radius: 100px;
}

</style>

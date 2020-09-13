<template>
  <div class="teamItem" :class="{'teamItem_avatarStyle_rounded': propIsRoundedAvatar}"> 
      <avatar-component
        class="teamItem__avatar"
        :propSrc="propImgSrc" 
        :propIsRounded="propIsRoundedAvatar"
      />
      <div class="teamItem__right">
        <div class="teamItem__status">
            <slot name="status" />
        </div>
        <h3 class="teamItem__title">
            <slot name="title" />
        </h3>
        <div class="teamItem__description">
            <slot name="description" />
        </div>
        <a  class="teamItem__link"
            href="propHref"
        >
            <slot name="link" />
        </a>
      </div>
  </div>
</template>

<script>
import AvatarComponent from '../Other/Avatar.vue';

export default {
components: {
    'avatar-component': AvatarComponent
},
props: {
    propImgSrc: String,
    propIsRoundedAvatar: {
        type: Boolean,
        default: true
    },
    propHref: String
}
}
</script>

<style>
.teamItem {
    max-width: 600px;
    display: grid;
    grid-template-columns: 170px 3fr;
    gap: 15px;
}

.teamItem_avatarStyle_rounded {
    grid-template-columns: 100px 3fr
}

.teamItem__status {
    font-size: 12pt;
    color: rgb(77, 77, 77);
    font-weight: 600;
}

.teamItem__title {
    font-size: 16pt;
    font-weight: 600;
    margin: 10px 0
}

.teamItem__description {
    font-size: 11pt;
    color: rgb(0,0,0);
}

.teamItem__link {
    font-size: 11pt;
    color: rgb(255, 82, 25);

    margin-top: 20px;
    display: block;
}

.teamItem__link:hover {
    color: rgb(204, 66, 20);
    text-decoration: underline;
}
</style>

<template>
    <a  class="seteratorButton" 
        :href="propHref"
        :class="'seteratorButton_color_' + propColor"
    >
        {{ propText }}
    </a>
</template>

<script>
export default {
    props: {
        propHref: {
            type: String
        },
        propText: {
            type: String
        },
        propColor: {
            type: String
        }
    }
}
</script>

<style scoped>
.seteratorButton {
    display: block;
    margin: 0;
    padding: 15px;
    width: 100%;

    font-weight: 600;
    text-align: center;
    border: 2px solid transparent;
    border-radius: 40px;

    cursor: pointer;
}

.seteratorButton_color_white {
    background-color: rgb(255,255,255);
    color: rgb(0, 0, 0);
    border: 2px solid rgb(0, 0, 0);
    box-sizing: border-box;
}

.seteratorButton_color_white:hover {
    background-color: rgb(0, 0, 0);
    color: rgb(255,255,255) !important;
}

.seteratorButton_color_orange {
    background-color: rgb(255, 82, 25);
    color: rgb(255,255,255) !important;
}

.seteratorButton_color_orange:hover,
.seteratorButton_color_orangeShadow:hover {
    background-color: rgb(204, 66, 20);
    color: rgb(255,255,255);
}

.seteratorButton_color_orangeShadow {
    background-color: rgb(255, 82, 25);
    color: rgb(255,255,255) !important;

    -webkit-box-shadow: 0px 36px 68px -13px rgba(255,82,25,1);
    -moz-box-shadow: 0px 36px 68px -13px rgba(255,82,25,1);
    box-shadow: 0px 36px 68px -13px rgba(255,82,25,1);
}
</style>

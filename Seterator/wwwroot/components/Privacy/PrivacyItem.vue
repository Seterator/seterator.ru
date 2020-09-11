<template>
  <div class="privacyItem">
    <a  class="privacyItem__header" 
        v-b-toggle="propName"
    >
        <slot name="header" />
    </a>
    <b-collapse :id="propName">
        <div class="privacyItem__description">
            <slot name="description" />
        </div>
    </b-collapse>
  </div>
</template>

<script>
export default {
props: {
    propName: String
}
}
</script>

<style scope>
.privacyItem {
    margin: 20px 0;
}

.privacyItem__header {
    font-family: 'Montserrat', sans-serif;
    font-size: 18pt;
    font-weight: 600;
    color: rgb(255, 82, 25) !important;

    text-decoration: none;

}

.privacyItem__header:hover {
    color: rgb(204, 66, 20) !important;
    cursor: pointer;
}

.privacyItem__description {
    font-family: 'Montserrat', sans-serif;
    font-size: 12pt;
    color: rgb(0, 0, 0);

    padding: 20px 0;
}
</style>

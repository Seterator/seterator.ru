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
    font-family: var(--font-sans-serif);
    font-size: 1.1rem;
    font-weight: 600;
    color: rgb(0, 0, 0);

    text-decoration: none;

}

.privacyItem__header:hover {
    color: var(--second-color) !important;
    cursor: pointer;
}

.privacyItem__description {
    font-family: var(--font-sans-serif);
    font-size: .8rem;
    color: rgb(0, 0, 0);

    padding: 20px 0;
}
</style>

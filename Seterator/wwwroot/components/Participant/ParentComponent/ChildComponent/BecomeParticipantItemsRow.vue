<template>
  <div class="participantBecome__itemsRow">
        <h3 class="competitionItem__title competitionItem__title_size_xl">@(ViewData["Competition title"])</h3>
        <becomeImg-text></becomeImg-text>
    </div>
</template>

<script>
import BecomeImgText from 'Seterator/wwwroot/components/Participant/ParentComponent/ChildComponent/BecomeImgText'
export default {
name: 'participantBecome'
}
</script>

<style>

</style>

<template>
    <div>
        <div class="participantBecome container">
            <competitionItem></competitionItem>
            <participantBecome-form></participantBecome-form>
        </div>
        <timer-script></timer-script>
        <become-script></become-script>
    </div>
</template>

<script>
import BecomeCompetitions from 'Seterator/wwwroot/components/Participant/ParentComponent/ChildComponent/BecomeCompetitions';
import ParticipantBecomeForm from 'Seterator/wwwroot/components/Participant/ParentComponent/ChildComponent/ParticipantBecomeForm';
import AddTimer from 'Seterator/wwwroot/components/Participant/ParentComponent/ChildComponent/AddTimer';
import AddBecome from 'Seterator/wwwroot/components/Participant/ParentComponent/ChildComponent/AddBecome';
export default {
name: 'become-index'
}
</script>

<style>

</style>

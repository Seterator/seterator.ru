<template>
    <div>
        <h1>Add</h1>
        <form asp-action="Add" asp-controller="Poem" asp-antiforgery="true">
            <summary-div></summary-div>
            <inner-main></inner-main>
        </form>
    </div>
</template>

<script>
import SummaryModelApp from 'Seterator/wwwroot/components/Poem/ParentComponent/ChildComponent/SummaryModelApp';
import InnerSubmitText from 'Seterator/wwwroot/components/Poem/ParentComponent/ChildComponent/InnerSubmitText';


export default {
name: 'poem-form'
}
</script>

<style>

</style>

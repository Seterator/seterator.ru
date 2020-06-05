<template>
  <div>
        <label asp-for="Text">Текст произведения</label><br />
        <textarea asp-for="Text">

        </textarea>
        <span asp-validation-for="Text" />
    </div>
</template>

<script>
export default {
name: 'innerText'
}
</script>

<style>

</style>

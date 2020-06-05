<template>
    <div>
        <input asp-for="Password" placeholder="Пароль" />
        <span asp-validation-for="Password" />
    </div>
</template>

<script>
export default {
 name: 'password-field',
}
</script>

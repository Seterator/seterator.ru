<template>
    <div>
        <input type="text" asp-for="Login" placeholder="e-mail или логин" />
        <span asp-validation-for="Login" />
    </div>
</template>

<script>
export default {
 name: 'login-field',
}
</script>

<template>
  <div>
    <switch-button></switch-button>
    <login-form></login-form>
    <reg-form></reg-form>
    <auth-soc-icons></auth-soc-icons>
  </div>
</template>

<script>
import LoginForm from 'Seterator/wwwroot/components/Account-Component/Parent-Component/LoginForm';
import RegForm from 'Seterator/wwwroot/components/Account-Component/Parent-Component/RegForm';
import SwitchButton from 'Seterator/wwwroot/components/Account-Component/Parent-Component/Child-Component/SwitchButton';
import AuthSocIcons from 'Seterator/wwwroot/components/Account-Component/Parent-Component/Child-Component/AuthSocIcons';
export default {
name: 'auth-form'
}
</script>

<style>

</style>

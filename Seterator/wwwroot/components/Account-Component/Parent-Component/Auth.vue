<template>
  <div class="container">
      <div id="auth">
          <auth-cheers></auth-cheers>
          <reg-cheers></reg-cheers>
            <div class="auth-form-container">
                <auth-form></auth-form>
                <p class="auth-agreement">Регистрируясь, Вы принимаете условия 
                    <a href="#">Пользовательского соглашения</a>.
                </p>
            </div>
            <success-reg></success-reg>
      </div>
  </div>
</template>

<script>
import AuthForm from 'Seterator/wwwroot/components/Account-Component/Parent-Component/AuthForm';
import SuccessReg from 'Seterator/wwwroot/components/Account-Component/Parent-Component/Child-Component/SuccessReg';
import AuthCheers from 'Seterator/wwwroot/components/Account-Component/Parent-Component/Child-Component/AuthCheers';
import RegCheers from 'Seterator/wwwroot/components/Account-Component/Parent-Component/Child-Component/RegCheers';
export default {
name: 'auth'
}
</script>

<style>

</style>

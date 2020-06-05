<template>
  <div>
    <form asp-action="Register" asp-controller="Account" asp-antiforgery="true">
      <summary-div></summary-div>
      <login-field></login-field>
      <password-field></password-field>
      <form-btn></form-btn>
    </form>
  </div>
</template>

<script>
import SummaryModelApp from "./Login-Child-Component/SummaryModelApp";
import LoginButton from "./Login-Child-Component/LoginButton";
import LoginField from "Seterator/wwwroot/components/Account-Component/Login-Parent-Component/Login-Child-Component/LoginField";
import PasswordField from "Seterator/wwwroot/components/Account-Component/Login-Parent-Component/Login-Child-Component/PasswordField";

export default {
  name: "reg-form",
  components: {
    SummaryModelApp,
    LoginField,
    PasswordField,
    LoginButton
  }
};
</script>

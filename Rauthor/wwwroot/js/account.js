function switchForm() {
    var loginView = document.getElementById("login-form");
    var registerView = document.getElementById("register-form");
    var authButton = document.getElementById("acc-reg-button");
    var registerButton = document.getElementById("acc-auth-button");
    var regCheers = document.getElementById("reg-cheers");
    var authCheers = document.getElementById("auth-cheers");
    if (loginView.style.display != "none") {
        registerView.style.display = "block";
        regCheers.style.display = "block";
        loginView.style.display = "none";
        authCheers.style.display = "none";
        authButton.style.boxShadow = "0px 2px 0px 0px rgba(255, 82, 25, 1)";
        authButton.style.color = "rgb(255, 82, 25)";
        registerButton.style.boxShadow = "none";
        registerButton.style.color = "rgb(132, 132, 132)";
    }
    else {
        loginView.style.display = "block";
        registerView.style.display = "none";
        regCheers.style.display = "none";
        authCheers.style.display = "block";
        registerButton.style.boxShadow = "0px 2px 0px 0px rgba(255, 82, 25, 1)";
        registerButton.style.color = "rgb(255, 82, 25)";
        authButton.style.boxShadow = "none";
        authButton.style.color = "rgb(132, 132, 132)";
    }
}
//# sourceMappingURL=account.js.map
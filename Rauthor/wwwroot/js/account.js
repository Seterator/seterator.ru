function switchForm() {
    var loginView = document.getElementById("login-form");
    var registerView = document.getElementById("register-form");
    var authButton = document.getElementById("account-register-button");
    var registerButton = document.getElementById("account-auth-button");
    if (loginView.style.display == "block") {
        loginView.style.display = "none";
        registerView.style.display = "block";
        authButton.style.background = "rgb(255, 57, 0)";
        registerButton.style.background = "rgb(65, 65, 65)";
    }
    else {
        loginView.style.display = "block";
        registerView.style.display = "none";
        authButton.style.background = "rgb(65, 65, 65)";
        registerButton.style.background = "rgb(255, 57, 0)";
    }
}
//# sourceMappingURL=account.js.map
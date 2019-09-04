function switchForm() {
    var loginView = document.getElementById("login-form");
    var registerView = document.getElementById("register-form");
    if (loginView.style.visibility == "visible") {
        loginView.style.visibility = "hidden";
        registerView.style.visibility = "visible";
    }
    else {
        loginView.style.visibility = "visible";
        registerView.style.visibility = "hidden";
    }
}
//# sourceMappingURL=account.js.map
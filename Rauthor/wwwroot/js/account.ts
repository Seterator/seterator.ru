function switchForm(): void {
    let loginView = document.getElementById("login-form");
    let registerView = document.getElementById("register-form");
    if (loginView.style.visibility == "visible") {
        loginView.style.visibility = "hidden";
        registerView.style.visibility = "visible"
    }
    else {
        loginView.style.visibility = "visible"
        registerView.style.visibility = "hidden";
    }
}
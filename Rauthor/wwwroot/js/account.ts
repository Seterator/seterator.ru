function switchForm(): void {
    let loginView = document.getElementById("login-form");
    let registerView = document.getElementById("register-form");
    if (loginView.style.display == "block") {
        loginView.style.display = "none";
        registerView.style.display = "block"
    }
    else {
        loginView.style.display = "block"
        registerView.style.display = "none";
    }
}
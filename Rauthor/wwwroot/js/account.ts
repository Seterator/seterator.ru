function switchForm(): void {
    let loginView = document.getElementById("login-form");
    let registerView = document.getElementById("register-form");
    let authButton = document.getElementById("account-register-button");
    let registerButton = document.getElementById("account-auth-button");
    if (loginView.style.display == "block") {
        loginView.style.display = "none";
        registerView.style.display = "block"
        authButton.style.background = "rgb(255, 57, 0)"
        registerButton.style.background = "rgb(65, 65, 65)"
    }
    else {
        loginView.style.display = "block"
        registerView.style.display = "none";
        authButton.style.background = "rgb(65, 65, 65)"
        registerButton.style.background = "rgb(255, 57, 0)"
    }
}
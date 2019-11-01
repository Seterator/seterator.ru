function switchForm(): void {
    let loginView = document.getElementById("login-form");
    let registerView = document.getElementById("register-form");
    let authButton = document.getElementById("acc-reg-button");
    let registerButton = document.getElementById("acc-auth-button");
    let regCheers = document.getElementById("reg-cheers");
    let authCheers = document.getElementById("auth-cheers");

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

function successReg(): void {
    let authContainer = document.getElementById("auth");
    let sucView = document.getElementById("successReg");
    let authCheersView = document.getElementById("auth-cheers");
    let regCheersView = document.getElementById("reg-cheers");
    let authFormContainerView = document.getElementById("auth-form-container");
    
    let regView = document.getElementById("register-form");

    authContainer.style.gridTemplateColumns = "0.33fr";
    authContainer.style.alignContent = "center";
    authContainer.style.justifyContent = "center";

    regView.style.display = "none";
    authCheersView.style.display = "none";
    regCheersView.style.display = "none";
    authFormContainerView.style.display = "none";
    


    sucView.style.display = "flex";
}


async function login(username: string, password: string) {
    let model: string = JSON.stringify({ "Username": username, "Password": password });
    let response = fetch("api/account",
        {
            body: model,
            method: "post"
        });
    console.log(await response);
}
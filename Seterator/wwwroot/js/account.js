async function login(username, password) {
    let model = JSON.stringify({ "Username": username, "Password": password });
    let response = fetch("api/account", {
        body: model,
        method: "post"
    });
    console.log(await response);
}

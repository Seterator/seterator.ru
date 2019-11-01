async function removeButtonClick(sender) {
    let guid = window.location.pathname.split(new RegExp("/|\\?"))[3];
    await fetch(`/api/competition/${guid}`, {
        method: "delete"
    });
}
//# sourceMappingURL=competition.js.map
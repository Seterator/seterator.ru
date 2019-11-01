document.addEventListener("readystatechange", () => {
    let form = document.getElementById("main-form");
    form.addEventListener("submit", create);
});
class Competition {
    constructor(title, startDate, endDate, description, prizes) {
        this.Title = title;
        this.StartDate = startDate;
        this.EndDate = endDate;
        this.Description = description;
        this.Prizes = prizes;
    }
}
async function removeButtonClick(sender) {
    let guid = window.location.pathname.split(new RegExp("/|\\?"))[3];
    await fetch(`/api/competition/${guid}`, {
        method: "delete"
    });
}
async function create(event) {
    //let form = document.getElementById("main-form") as any;
    event.preventDefault();
    let competition = new Competition(this.title.value, this.startDate.value, this.endDate.value, this.description.value, this.prizes.value);
    await fetch('/api/competition', {
        body: JSON.stringify(competition),
        method: "POST",
        headers: [
            ["Content-Type", "application/json"]
        ]
    });
    return false;
}
//# sourceMappingURL=competition.js.map
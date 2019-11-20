/// <reference path="../Core/models.ts" />
namespace Competition.Update {
    document.addEventListener("readystatechange", () => {
        let form = document.getElementById("main-form") as HTMLFormElement;
        form.addEventListener("submit", update)
    });

    async function update(event: Event) {
        event.preventDefault();
        let guid = Core.Utils.getCurrentGuid();
        let competition = new Core.Models.Competition(
            this.title.value,
            this.startDate.value,
            this.endDate.value,
            this.description.value,
            this.prizes.value,
        );
        await fetch(`/api/competition/${guid}`, {
            body: JSON.stringify(competition),
            method: "PUT",
            headers: [
                ["Content-Type", "application/json"]
            ]
        });
        alert("Success")
        return false;
    }
}
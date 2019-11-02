/// <reference path="../Core/models.ts" />
namespace Competition.Create {
    document.addEventListener("readystatechange", () => {
        let form = document.getElementById("main-form") as HTMLFormElement;
        form.addEventListener("submit", create)
    });

    async function create(event: Event) {
        event.preventDefault();
        let competition = new Core.Models.Competition(
            this.title.value,
            this.startDate.value,
            this.endDate.value,
            this.description.value,
            this.prizes.value,
        );
        await fetch('/api/competition', {
            body: JSON.stringify(competition),
            method: "POST",
            headers: [
                ["Content-Type", "application/json"]
            ]
        });
        return false;
    }
}
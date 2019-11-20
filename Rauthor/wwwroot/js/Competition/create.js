/// <reference path="../Core/models.ts" />
var Competition;
(function (Competition) {
    var Create;
    (function (Create) {
        document.addEventListener("readystatechange", () => {
            let form = document.getElementById("main-form");
            form.addEventListener("submit", create);
        });
        async function create(event) {
            event.preventDefault();
            let competition = new Core.Models.Competition(this.title.value, this.startDate.value, this.endDate.value, this.description.value, this.prizes.value);
            await fetch('/api/competition', {
                body: JSON.stringify(competition),
                method: "POST",
                headers: [
                    ["Content-Type", "application/json"]
                ]
            });
            return false;
        }
    })(Create = Competition.Create || (Competition.Create = {}));
})(Competition || (Competition = {}));
//# sourceMappingURL=create.js.map
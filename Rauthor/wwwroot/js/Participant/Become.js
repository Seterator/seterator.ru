var guid = window.location.pathname.split(new RegExp("/|\\?"))[3];
fetch(`/api/Competition/${guid}`, {
    method: 'GET'
}).then(response => response.json()).then(competition => LoadCompetition(competition));

function LoadCompetition(competition) {
    LoadTimer();
    LoadCompetitionDetails();

    function LoadTimer() {
        setInterval(() => {
            document.querySelector(".competitionItem__timer").textContent = ReturnTime(competition.endDate);
        }, 1000);
    }

    function LoadCompetitionDetails() {
        document.querySelector(".competitionItem__title").textContent = competition.title;
        document.querySelector(".competitionItem__description").textContent = competition.description;
    }
}
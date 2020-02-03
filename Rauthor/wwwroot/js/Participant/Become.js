var guid = window.location.pathname.split(new RegExp("/|\\?"))[3];
fetch(`/api/Competition/${guid}`, {
    method: 'GET'
}).then(response => response.json()).then(competition => LoadCompetition(competition));

let participantForm = document.forms[0];
participantForm.addEventListener("submit", SendForm);

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

function SendForm() {
    event.preventDefault();
    let participantForm = document.forms[0];

    let application = {
        title: participantForm.title.value,
        nickname: participantForm.nickname.value,
        poem: participantForm.poem.value
    }

    fetch("/api/Participant", {
        method: 'POST',
        headers: {
            "Content-Type": "text/json; charset=utf-8"
        },
        body: JSON.stringify(application)
    }).then(response => {
        if (response.status == 200)
            document.location.href = "/";
        else
            alert(`Ошибка: ${response.status}`);
    });
}
// Создание конкурса
let competitionForm = document.forms[0];
competitionForm.addEventListener("submit", CreateCompetition);

function CreateCompetition() {
    event.preventDefault();
    let competitionForm = document.forms[0];
    let competition = {
        "ManagerPhoneNumber": competitionForm.phoneNumber.value,
        "ManagerEmail": competitionForm.email.value,
        "ManagerSocialLinks": [],
        "Categories": [],
        "Title": competitionForm.title.value,
        "ShortDescription": competitionForm.shortDescription.value,
        "Description": competitionForm.description.value,
        "Constraints": [
            {
                "CheckedValue": "Age",
                "Min": parseInt(competitionForm.ageStart.value, 10),
                "Max": parseInt(competitionForm.ageEnd.value, 10)
            },
            {
                "CheckedValue": "Country",
                "Value": competitionForm.countries.valuet
            }
        ],
        "Prizes": [],
        "JuryGuids": [],
        "PublicationDate": competitionForm.publicationDate.value,
        "StartDate": competitionForm.startDate.value,
        "EndDate": competitionForm.endDate.value
    }    

    fetch("/api/Competition", {
        method: 'POST', 
        headers: {
            "Content-Type": "text/json; charset=utf-8"
        }, 
        body: JSON.stringify(competition)
    }).then(response => {
        if (response.status == 200) {
            document.location.href = "/";
        }
        else {
            alert(`Ошибка: ${response.status}`);
        }
    });
}

// Получение текущего конкурса
var guid = window.location.pathname.split(new RegExp("/|\\?"))[3];
fetch(`/api/Competition/${guid}`, {
    method: 'GET'
}).then(response => response.json()).then(competition => LoadCompetition(competition));

// Обновление конкурса
var Competition;
(function (Competition) {
    var Update;
    (function (Update) {
        document.addEventListener("readystatechange", () => {
            let form = document.getElementById("main-form");
            form.addEventListener("submit", update);
        });
        async function update(event) {
            event.preventDefault();
            let guid = Core.Utils.getCurrentGuid();
            let competition = new Core.Models.Competition(this.title.value, this.startDate.value, this.endDate.value, this.description.value, this.prizes.value);
            await fetch(`/api/competition/${guid}`, {
                body: JSON.stringify(competition),
                method: "PUT",
                headers: [
                    ["Content-Type", "application/json"]
                ]
            });
            alert("Success");
            return false;
        }
    })(Update = Competition.Update || (Competition.Update = {}));
})(Competition || (Competition = {}));

// Отправка заявки на конкурс
function SendForm() {
    event.preventDefault();
    let participantForm = document.forms[0];

    let application = {
        guid: window.location.href.split("/")[5], 
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

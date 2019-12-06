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
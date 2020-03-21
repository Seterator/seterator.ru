fetch('/api/Competition', {
    method: 'GET'
}).then(response => response.json()).then(competitions => OutputCompetitions(competitions));

function OutputCompetitions(competitions) {
    competitions.forEach(competition => {
        if (new Date(competition.endDate) > new Date(Date.now())) {
            document.querySelector(".index__eventsList").prepend(CreateCompetitionItem(competition));
        }
    });

    setInterval(IndexTimer, 1000);

    function IndexTimer() {
        competitionsTimersDOM = document.querySelectorAll(".competitionItem__timer_column");
        competitionsTimersDOM.forEach(timer => timer.textContent = ReturnTime(timer.dataset.enddate));
    }
}

function CreateCompetitionItem(competition) {
    var competitionItemHref = document.createElement("a");
    competitionItemHref.classList.add("index__competitionItemHref");
    competitionItemHref.href = `Competition/Details/${competition.guid}`;

    var competitionItemDiv = document.createElement("div");
    competitionItemDiv.classList.add("index__competitionItem", "competitionItem", "competitionItem_direction_column");
    
    var competitionItemTimer = document.createElement("span");
    competitionItemTimer.classList.add("competitionItem__timer_column");
    competitionItemTimer.setAttribute("data-endDate", competition.endDate)
    competitionItemTimer.textContent = ReturnTime(competition.endDate);
    
    var competitionItemCategory = document.createElement("span");
    competitionItemCategory.classList.add("competitionItem__category");
    competitionItemCategory.textContent = "Ежедневный конкурс";
    
    var competitionItemTitle = document.createElement("h4");
    competitionItemTitle.classList.add("competitionItem__title");
    competitionItemTitle.textContent = competition.title;
    
    var competitionItemShortDescription = document.createElement("p");
    competitionItemShortDescription.classList.add("competitionItem__shortDescription");
    competitionItemShortDescription.textContent = competition.description;

    competitionItemDiv.append(competitionItemTimer, competitionItemCategory, competitionItemTitle, competitionItemShortDescription);
    competitionItemHref.append(competitionItemDiv);

    return competitionItemHref;
}
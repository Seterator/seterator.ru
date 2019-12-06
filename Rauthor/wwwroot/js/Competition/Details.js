HideElems();

var guid = window.location.pathname.split(new RegExp("/|\\?"))[3];
fetch(`/api/Competition/${guid}`, {
    method: 'GET'
}).then(response => response.json()).then(competition => LoadCompetition(competition));

function LoadCompetition(competition) {
    UnhideElems();
    LoadCompetitionBanner();
    LoadCompetitionPrizes();
    LoadCompetitionJury();

    function LoadCompetitionBanner() {
        LoadOrganizerInfo();
        LoadCompetitionBannerInfo();
        
        function LoadOrganizerInfo(competition) {
            document.querySelector(".parsonalInfo__name").textContent = "Не указано";
            document.querySelector(".personalInfo__phone").textContent = "Не указано";
            document.querySelector(".personalInfo__email").textContent = "Не указано";

        }
        function LoadCompetitionBannerInfo() {
            document.querySelector(".competitionItem__category").textContent = "Ежедневный конкурс";
            document.querySelector(".competitionItem__title").textContent = competition.title;
            document.querySelector(".competitionItem__shortDescription").textContent = competition.shortDesctiption;
            setInterval(() => {
                document.querySelector(".competitionItem__timer").textContent = ReturnTime(competition.endDate);
            }, 1000);

        }
    }
    function LoadCompetitionConditions() {
        
    }
    function LoadCompetitionPrizes() {
        LoadCompetitionPrizesLit();

        function LoadCompetitionPrizesLit() {
            competition.prizes.forEach(prize => document.querySelector(".competitionPrizes").append(CreateCompetitionPrize(prize)));
        }
        function CreateCompetitionPrize(prize) {
            var prizeItem = document.createElement("li");
            prizeItem.classList.add("competitionPrizes__item");

            var prizeItemPlace = document.createElement("span");
            prizeItemPlace.classList.add("competitionPrizes__name");
            prizeItemPlace.textContent = `${prize.begin_place} - ${prize.end_place} место: `;

            var prizeItemValue = document.createElement("span");
            prizeItemValue.classList.add("competitionPrizes__value");
            prizeItemValue.textContent = prize.value;

            prizeItem.append(prizeItemPlace, prizeItemValue);
            return prizeItem;
        }
    }
    function LoadCompetitionJury() {
        LoadJuryCount();
        CreateJuryList();

        function LoadJuryCount() {
            document.querySelector(".jury__count").textContent = `(${competition.jury.length})`;
        }
        function CreateJuryList() {
            if (competition.jury.length != 0) {
                document.querySelector(".jury__showAllBtn").style.removeProperty("display");
                competition.jury.forEach(juryItem => {
                    document.querySelector(".jury__lst").append(CreateJuryItem(juryItem))
                });
            }
            function CreateJuryItem(juryJSON) {
                var juryItemLi = document.createElement("li");
                juryItemLi.classList.add("userItem");

                var imgText = document.createElement("div");
                imgText.classList.add("imgText");

                var avatar = document.createElement("div");
                avatar.classList.add("avatar", "avatar_shape_circle", "avatar_theme_dark", "avatar_size_m");

                var juryName = document.createElement("span");
                juryName.classList.add("userItem__name");
                juryName.textContent = "Имя жюри"; //juryJSON.nickname

                var juryDescription = document.createElement("p");
                juryDescription.classList.add("userItem__description");
                juryDescription.textContent = "Описание жюри"; //juryJSON.description

                imgText.append(avatar, juryName);
                juryItemLi.append(imgText, juryDescription);

                return juryItemLi;
            }
        }
    }
    function LoadCompetitionParticipants() {
        
    }

}

function HideElems() {
    // Информация об организаторе
    document.querySelector(".personalInfo__avatar").style.display = "none";
    document.querySelector(".personalInfo__phone").parentElement.style.display = "none";
    document.querySelector(".personalInfo__email").parentElement.style.display = "none";    
    document.querySelector(".jury__showAllBtn").style.display = "none";    
}

function UnhideElems() {
    document.querySelector(".personalInfo__avatar").style.removeProperty("display");
    document.querySelector(".personalInfo__phone").parentElement.style.removeProperty("display");
    document.querySelector(".personalInfo__email").parentElement.style.removeProperty("display");
}
HideElems();

fetch('/api/Competition/143481f8-fb2b-42b5-bd26-21ee985b3dc1', {
    method: 'GET'
}).then(response => response.json()).then(competition => LoadCompetition(competition));

function LoadCompetition(competition) {
    UnhideElems();
    LoadCompetitionBanner();


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

}

function HideElems() {
    // Информация об организаторе
    document.querySelector(".personalInfo__avatar").style.display = "none";
    document.querySelector(".personalInfo__phone").parentElement.style.display = "none";
    document.querySelector(".personalInfo__email").parentElement.style.display = "none";

    // Информация о конкурсе в баннере
    
}

function UnhideElems() {
    document.querySelector(".personalInfo__avatar").style.removeProperty("display");
    document.querySelector(".personalInfo__phone").parentElement.style.removeProperty("display");
    document.querySelector(".personalInfo__email").parentElement.style.removeProperty("display");
}

// function CreateBannerDataDOM {
//     var personalInfo__avatar = document.createElement("div");
//     personalInfo__avatar.classList.add("personalInfo__avatar", "imgText");

//     var avatar = document.createElement("div");
//     avatar.classList.add("avatar", "avatar_theme_light", "avatar_shape_circle", "avatar_size_s");

//     var parsonalInfo__name = document.createElement("div");
//     parsonalInfo__name.classList.add("parsonalInfo__name", "imgText__text_margin_left");
//     parsonalInfo__name.textContent("Имя организатора");

//     var organizerEmailDiv = document.createElement("div");
//     organizerEmailDiv.classList.add("personalInfo__item_margin_bottom", "imgText");

//     var organizerEmailImg = 
// }
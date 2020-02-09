document.addEventListener('DOMContentLoaded', function(){
    
    const BannerComponent = {
        props: [
            'competition'
        ],
        template: `
            <div class="banner banner_padding_small banner_theme_common banner_partition_two"
                    v-show="competition">
                <div class="banner__personalInfo personalInfo personalInfo_font_small">
                    <div class="personalInfo__avatar imgText">
                        <div class="avatar avatar_theme_light avatar_shape_circle avatar_size_s">

                        </div>
                        <div class="parsonalInfo__name imgText__text_margin_left">
                            {{competition.creator ? competition.creator.login : noData}}
                        </div>
                    </div>
                    <div class="personalInfo__item_margin_bottom imgText">
                    <img class="imgText__img imgSvg imgSvg_color_white" src="/img/Competition/telephone.svg">
                        <span class="personalInfo__phone imgText__text_margin_left">
                            {{competition.managerPhoneNumbmer || noData}}
                        </span>
                    </div>
                    <div class="personalInfo__item_margin_bottom imgText">
                        <img class="imgText__img imgSvg imgSvg_color_white" src="/img/Competition/email.svg">
                        <span class="personalInfo__email imgText__text_margin_left">
                            {{competition.managerEmail || noData}}
                        </span>
                    </div>
                    <div v-show="false" class="personalInfo__item_margin_bottom socialIcons socialIcons_align_bySides">
                        <a class="socialIcons__item socialIcons__item_size_s" href="#"><img class="imgSvg imgSvg_color_white imgSvg_hovered_color_orange" src="/img/Social icons/Orange/google.svg" /></a>
                        <a class="socialIcons__item socialIcons__item_size_s" href="#"><img class="imgSvg imgSvg_color_white imgSvg_hovered_color_orange" src="/img/Social icons/Orange/twitter.svg" /></a>
                        <a class="socialIcons__item socialIcons__item_size_s" href="#"><img class="imgSvg imgSvg_color_white imgSvg_hovered_color_orange" src="/img/Social icons/Orange/facebook.svg" /></a>
                        <a class="socialIcons__item socialIcons__item_size_s" href="#"><img class="imgSvg imgSvg_color_white imgSvg_hovered_color_orange" src="/img/Social icons/Orange/vk.svg" /></a>
                    </div>
                </div>
                <div class="banner__competitionItem competitionItem_direction_column">
                    <span class="competitionItem__category"></span>
                    <h4 class="competitionItem__title">
                        {{competition.title}}
                    </h4>
                    <p class="competitionItem__shortDescription competitionItem__shortDescription_width_allLine">
                        {{competition.shortDescription}}
                    </p>
                    <div class="competitionItem__division competitionItem__division_align_bySides">
                        <div class="imgText">
                            <img class="imgText__img imgSvg imgSvg_color_gray imgText__img_size_s" src="/img/Competition/share.svg">
                            <span class="competitionItem__share">Поделиться</span>
                        </div>
                        <a class="competitionItem__button btn btn_decoration_orangeShadow btn_color_orange" asp-action="Become"
                                asp-controller="Participant"
                                asp-route-guid="@Model.Guid">
                            <div class="imgText">
                                <img class="imgText__img imgSvg imgSvg_color_white" src="/img/Competition/time.svg">
                                <span class="imgText__text competitionItem__timer">{{timer}}</span>
                            </div>
                            <span class="formButton__item">Участвовать</span>
                        </a>
                    </div>
                </div>
            </div>
        `,
        data() {
            return {
                noData: 'Не указано',
                timer: ''
            };
        }
    };

    const ElementOfConstraintsComponent = {
        props: [
            'constraintElement'
        ],
        template: `
            <li>
                <div class="competitionConditions__item competitionConditions__item_marker_orangeDot"
                    v-if="constraintElement.type == 'basic'"> 
                    <span class="competitionConditions__name">
                        {{constraintElement.name}}
                    </span> 
                    <span class="competitionConditions__value">
                        {{constraintElement.value}}
                    </span>
                </div>
                <div class="competitionConditions__item competitionConditions__item_marker_orangeDot"
                    v-else-if="constraintElement.type == 'line'"> 
                    <span class="competitionConditions__name">
                        {{constraintElement.name}}
                    </span>
                </div>
                <div class="competitionConditions__item competitionConditions__item_type_file"
                    v-else-if="constraintElement.type == 'file'">
                    <div class="imgText">
                        <img class="imgText__img imgSvg imgSvg_color_orange" src="/img/Competition/link_1.svg"
                            v-if="constraintElement.name == 'Условия конкурса'">
                        <img class="imgText__img imgSvg imgSvg_color_orange" src="/img/Competition/document.svg"
                            v-else>
                        <span class="competitionConditions__fileName">{{constraintElement.name}}</span>
                    </div>
                </div>
            </li>
        `
    };

    const ConstraintsComponent = {
        props: [
            'constraints'
        ],
        template: `
            <div>
                <div class="competitionDetails__competitionConditions">
                    <h3 class="competitionDetails__header">
                        {{title}}
                    </h3>
                    <ul class="competitionConditions">
                        <element-of-constraints-component :constraintElement="constraintElement" :key="constraintElement.name" v-for="constraintElement of this.constraints"></element-of-constraints-component>
                    </ul>
                </div>
            </div>
        `,
        data() {
            return {
                title: 'Условия конкурса'
            };
        },
        components: {
            'element-of-constraints-component': ElementOfConstraintsComponent
        }
    };
    
    let vm = new Vue({
        el: '.app',
        components: {
            'banner-component': BannerComponent,
            'constraints-component': ConstraintsComponent,
        },
        data: {
            competition: {}
        },
        created: function(){
                let guid = window.location.pathname.split("/")[3];
                fetch(`/api/Competition/${guid}`, {
                    method: 'GET',
                }).then(response => response.json()).then(competition => {this.competition = competition; loadTimer(competition)});
        }
    });

    function loadTimer(competition) {
        setInterval(() => {
                    document.querySelector(".competitionItem__timer").textContent = ReturnTime(competition.endDate);
                }, 1000);
    }

});



// HideElems();

// var guid = window.location.pathname.split(new RegExp("/|\\?"))[3];
// fetch(`/api/Competition/${guid}`, {
//     method: 'GET'
// }).then(response => response.json()).then(competition => LoadCompetition(competition));

// function LoadCompetition(competition) {
//     UnhideElems();
//     LoadCompetitionBanner();
//     LoadCompetitionDescription();
//     LoadCompetitionConditions();
//     LoadCompetitionPrizes();
//     LoadCompetitionJury();
//     LoadCompetitionParticipants();

//     function LoadCompetitionBanner() {
//         LoadOrganizerInfo();
//         LoadCompetitionBannerInfo();
        
//         function LoadOrganizerInfo(competition) {
//             document.querySelector(".parsonalInfo__name").textContent = "Не указано";
//             document.querySelector(".personalInfo__phone").textContent = "Не указано";
//             document.querySelector(".personalInfo__email").textContent = "Не указано";

//         }
//         function LoadCompetitionBannerInfo() {
//             document.querySelector(".competitionItem__category").textContent = "Ежедневный конкурс";
//             document.querySelector(".competitionItem__title").textContent = competition.title;
//             document.querySelector(".competitionItem__shortDescription").textContent = competition.shortDesctiption;
//             setInterval(() => {
//                 document.querySelector(".competitionItem__timer").textContent = ReturnTime(competition.endDate);
//             }, 1000);

//         }
//     }
//     function LoadCompetitionDescription() {
//         document.querySelector(".competitionItem__fullDescription").textContent = competition.description;
//     }
//     function LoadCompetitionConditions() {
//         document.querySelector(".competitionConditions").textContent = "Временно недоступно. В разработке.";
//     }
//     function LoadCompetitionPrizes() {
//         LoadCompetitionPrizesLit();

//         function LoadCompetitionPrizesLit() {
//             competition.prizes.forEach(prize => document.querySelector(".competitionPrizes").append(CreateCompetitionPrize(prize)));
//         }
//         function CreateCompetitionPrize(prize) {
//             var prizeItem = document.createElement("li");
//             prizeItem.classList.add("competitionPrizes__item");

//             var prizeItemPlace = document.createElement("span");
//             prizeItemPlace.classList.add("competitionPrizes__name");
//             prizeItemPlace.textContent = `${prize.begin_place} - ${prize.end_place} место: `;

//             var prizeItemValue = document.createElement("span");
//             prizeItemValue.classList.add("competitionPrizes__value");
//             prizeItemValue.textContent = prize.value;

//             prizeItem.append(prizeItemPlace, prizeItemValue);
//             return prizeItem;
//         }
//     }
//     function LoadCompetitionJury() {
//         LoadJuryCount();
//         CreateJuryList();

//         function LoadJuryCount() {
//             document.querySelector(".jury__count").textContent = `(${competition.jury.length})`;
//         }
//         function CreateJuryList() {
//             if (competition.jury.length != 0) {
//                 document.querySelector(".jury__showAllBtn").style.removeProperty("display");
//                 competition.jury.forEach(juryItem => {
//                     document.querySelector(".jury__lst").append(CreateJuryItem(juryItem))
//                 });
//             }
//             function CreateJuryItem(juryJSON) {
//                 var juryItemLi = document.createElement("li");
//                 juryItemLi.classList.add("userItem");

//                 var imgText = document.createElement("div");
//                 imgText.classList.add("imgText");

//                 var avatar = document.createElement("div");
//                 avatar.classList.add("avatar", "avatar_shape_circle", "avatar_theme_dark", "avatar_size_m");

//                 var juryName = document.createElement("span");
//                 juryName.classList.add("userItem__name");
//                 juryName.textContent = "Имя жюри"; //juryJSON.nickname

//                 var juryDescription = document.createElement("p");
//                 juryDescription.classList.add("userItem__description");
//                 juryDescription.textContent = "Описание жюри"; //juryJSON.description

//                 imgText.append(avatar, juryName);
//                 juryItemLi.append(imgText, juryDescription);

//                 return juryItemLi;
//             }
//         }
//     }
//     function LoadCompetitionParticipants() {
//         LoadCompetitionParticipantsCount();
//         LoadCompetitionParticipantsList();

//         function LoadCompetitionParticipantsCount() {
//             document.querySelector(".participants__count").textContent = `(${competition.participants.length})`;
//         }
//         function LoadCompetitionParticipantsList() {
//             competition.participants.forEach(participant => document.querySelector(".participants__lst").append(CreateCompetitionParticipant(participant)));

//             function CreateCompetitionParticipant(participant) {
//                 var participantItem = document.createElement("li");
//                 participantItem.classList.add("participantItem");

//                 var poemTitle = document.createElement("span");
//                 poemTitle.classList.add("participantItem__poemTitle");
//                 poemTitle.textContent = participant.title;
                
//                 var nickname = document.createElement("span");
//                 nickname.classList.add("participantItem__nickname");
//                 nickname.textContent = participant.nickname;

//                 participantItem.append(poemTitle, nickname);
//                 return participantItem;
//             }
//         }
//         function ShowCompetitionParticipantsBtn() {
//             if (competition.participants.length != 0) {
//                 document.querySelector(".participants__showAllBtn").style.removeProperty("display");   
//             }
//         }
//     }

// }

// function HideElems() {
//     // Информация об организаторе
//     document.querySelector(".personalInfo__avatar").style.display = "none";
//     document.querySelector(".personalInfo__phone").parentElement.style.display = "none";
//     document.querySelector(".personalInfo__email").parentElement.style.display = "none";    
//     document.querySelector(".jury__showAllBtn").style.display = "none";    
//     document.querySelector(".participants__showAllBtn").style.display = "none";   
//     document.querySelectorAll(".competitionConditions__item").forEach(condition => condition.style.display = "none");
    
// }

// function UnhideElems() {
//     document.querySelector(".personalInfo__avatar").style.removeProperty("display");
//     document.querySelector(".personalInfo__phone").parentElement.style.removeProperty("display");
//     document.querySelector(".personalInfo__email").parentElement.style.removeProperty("display");
// }
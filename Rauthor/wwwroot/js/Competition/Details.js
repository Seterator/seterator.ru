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

    const PrizesComponent = {
        props: [
            'prizes'
        ],
        template: `
        <div>
            <div class="competitionDetails__competitionPrizes">
                <h3 class="competitionDetails__header">
                    {{title}}
                </h3>
                <ul class="competitionPrizes">
                    <li class="competitionPrizes__item"
                        v-for="prize in prizes" :key="prize.value">
                        <span   class="competitionPrizes__name"
                                v-for="(range, i) in prize.range"
                        >
                            {{ renderPrizePlaces(range) }}
                            {{ i < (prize.range.length - 1) ? ", " : "" }}
                            {{ i == (prize.range.length - 1) ? renderPlacesLabel(prize) : "" }}
                        </span>
                        <span class="competitionPrizes__value">
                             - {{ prize.value }}
                        </span>
                    </li>
                </ul>
            </div>
        </div>
        `,
        data() {
            return {
                title: 'Призы',
            };
        },
        methods: {
            renderPrizePlaces(range) {
                if (range.length == 2) {
                    return range[0] + ' - ' + range[1];
                }
                else {
                    return range[0];
                }
            },
            renderPlacesLabel(prize) {
                if (prize.range.length > 1)
                    return " места";
                else if (prize.range[0].length > 1)
                    return " места";
                else
                    return " место";
            }
        }
    };

    const JuryComponent = {
        props: [
            'juryList'
        ],
        template: `
        <div>
            <div class="competitionDetails__jury jury">
                <h3 class="competitionDetails__header">{{title}} <span class="jury__count">({{juryList.length}})</span></h3>
                <ul class="jury__lst">
                    <li class="userItem"
                        v-for="jury in juryList.slice(0, showedItems)"
                    >
                        <div class="imgText">
                            <div class="avatar avatar_shape_circle avatar_theme_dark avatar_size_m">
                            </div>
                            <span class="userItem__name">
                                {{jury.name}}
                            </span>
                        </div>
                        <p class="userItem__description">
                            {{jury.description}}
                        </p>
                    </li>
                </ul>
                <div    class="jury__showAllBtn btn btn_color_white"
                        v-show="isShowButton"
                        v-on:click="showedItems = juryList.length; isShowButton = false"
                >
                    Смотреть всех
                </div>
            </div>
        </div>
        `,
        data() {
            return {
                title: 'Жюри',
                showedItems: 3,
                isShowButton: true,
            };
        }
    };
    
    let vm = new Vue({
        el: '.app',
        components: {
            'banner-component': BannerComponent,
            'constraints-component': ConstraintsComponent,
            'prizes-component': PrizesComponent,
            'jury-component': JuryComponent
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

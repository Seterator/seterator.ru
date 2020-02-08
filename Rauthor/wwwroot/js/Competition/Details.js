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
    
    let vm = new Vue({
        el: '.app',
        components: {
            'banner-component': BannerComponent,
            'constraints-component': ConstraintsComponent
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

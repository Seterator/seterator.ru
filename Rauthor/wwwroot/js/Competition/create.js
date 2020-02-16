document.addEventListener('DOMContentLoaded', function() {
    const PreBannerComponent = {
        props: [
            'competition'
        ],
        template: `
        <div>
            <h2 class="createCompetition__header">Личная информация</h2>
            <div class="createCompetition__personalInfo personalInfo personalInfo_theme_light">
                <div class="personalInfo__socialIcons socialIcons">
                    <a class="socialIcons__item socialIcons__item_size_m" href="#"><img class="imgSvg imgSvg_color_white imgSvg_hovered_color_orange" src="/img/Social icons/Orange/google.svg" /></a>
                    <a class="socialIcons__item socialIcons__item_size_m" href="#"><img class="imgSvg imgSvg_color_white imgSvg_hovered_color_orange" src="/img/Social icons/Orange/twitter.svg" /></a>
                    <a class="socialIcons__item socialIcons__item_size_m" href="#"><img class="imgSvg imgSvg_color_white imgSvg_hovered_color_orange" src="/img/Social icons/Orange/facebook.svg" /></a>
                    <a class="socialIcons__item socialIcons__item_size_m" href="#"><img class="imgSvg imgSvg_color_white imgSvg_hovered_color_orange" src="/img/Social icons/Orange/vk.svg" /></a>
                </div>
                <div class="personalInfo__phoneAndEmail">
                    <div class="imgText">
                        <img class="imgText__img imgSvg imgSvg_color_white" src="/img/Competition/telephone.svg">
                        <input class="createCompetition__textbox createCompetition__textbox_theme_light imgText__text" name="phoneNumber" type="tel" placeholder="Введите номер"
                                v-model.number="competition.managerPhoneNumber">
                    </div>
                    <div class="imgText">
                        <img class="imgText__img imgSvg imgSvg_color_white" src="/img/Competition/email.svg">
                        <input class="createCompetition__textbox createCompetition__textbox_theme_light imgText__text" name="email" type="email" placeholder="Введите почту"
                                v-model="competition.managerEmail">
                    </div>
                </div>
            </div>
        </div>
        `
    };

    const BannerComponent = {
        props: [
            'competition'
        ],
        template: `
        <div>
            <div class="createCompetition__banner banner banner_theme_none banner_padding_small">
                <label class="createCompetition__label createCompetition__label_theme_dark">Ежедневный конкурс</label>
                <input class="createCompetition__textbox createCompetition__textbox_font_header createCompetition__textbox_theme_dark" name="title" type="text" placeholder="Введите название конкурса" required
                        v-model="competition.title">
                <label class="createCompetition__label createCompetition__label_theme_dark">Описание идеи конкурса</label>
                <textarea class="createCompetition__shortDescription createCompetition__textarea createCompetition__textarea_theme_dark" name="shortDescription" rows="5" placeholder="Начните вводить текст..."
                            v-model="competition.shortDescription"></textarea>
                <a class="createCompetition__uploadBackgroundImg" href="#">
                    <div class="imgText">
                        <img class="imgText__img imgSvg imgSvg_color_white" src="/img/Competition/picture.svg">
                        <div class="imgText__text">
                            Загрузить изображение на фон
                        </div>
                    </div>
                </a>
            </div>
        </div>
        `
    };
    

    const ConstraintElementComponent = {
        props: [
            'constraints',
            'type',
            'name',
            'description',
            'inpType',
            'options'
        ],
        template: `
        <div>
            <div v-if="type == 'line' || inpType == 'URL'">
                <label class="createCompetition__label" :for="name">*{{description[0]}}</label>
                <input class="createCompetition__textbox createCompetition__textbox_theme_light createCompetition__textbox_type_nomralText" 
                        :id="name" :type="inpType" :placeholder="description[1] ? description[1] : description[0]"
                        v-model.lazy="value[0]">
            </div>
            <div v-else-if="type == 'dict'">
                <div v-if="inpType == 'select'">
                    <label class="createCompetition__label">*{{description[0]}}</label>
                    <select class="createCompetition__select createCompetition__select_theme_light createCompetition__startRange"
                            v-model="value[0]">
                        <option v-for="option in options">{{ option }}</option>
                    </select>
                </div>
                <div v-else-if="inpType == 'checkbox'">
                    <br>
                    <input :type="inpType" :id="name" v-model="value[0]">
                    <label :for="name">{{description[1] ? description[1] : description[0]}}</label>
                </div>
                <div v-else-if="description.length == 3">
                    <label class="createCompetition__label" :for="name">*{{description[0]}}</label>
                    <input class="createCompetition__textbox createCompetition__textbox_theme_light createCompetition__textbox_type_range" :id="name" :type="inpType" :placeholder="description[1]"
                            v-model.number.lazy="value[0]">
                    <input class="createCompetition__textbox createCompetition__textbox_theme_light createCompetition__textbox_type_range" :id="name" :type="inpType" :placeholder="description[2]"
                            v-model.number.lazy="value[1]">
                </div>
                <div v-else>
                    <label class="createCompetition__label" :for="name">*{{description[0]}}</label>
                    <input class="createCompetition__textbox createCompetition__textbox_theme_light createCompetition__textbox_type_nomralText" :id="name" :type="inpType" :placeholder="description[1]"
                            v-model.number.lazy="value[0]">
                </div>
            </div>
            <div v-else-if="type == 'file'">
                <input class="createCompetition__uploadDocument createCompetition__uploadDocument_view_disable" :type="inpType" :id="name"
                        v-model="value[0]">
                    <label class="createCompetition__upload" :for="name">    
                        <div class="imgText">
                            <img class="imgText__img imgSvg imgSvg_color_orange" src="/img/Competition/plus.svg">
                            <span>{{description[1] ? description[1] : description[0]}}</span>
                        </div>
                    </label>
            </div>
        </div>
        `,
        data() {
            return {
                value: []
            }
        },
        computed: {
            appendConstraint() {
                let isExist = false;
                if (this.type == 'line') {
                    this.constraints.forEach(constraint => {
                        if (constraint.name == this.description[0]) {
                            isExist = true;
                            constraint.value[0] = this.value[0];
                        }
                    });
    
                    if (!isExist)
                        this.constraints.push({
                            type: this.type,
                            name: this.description[0],
                            value: this.value
                        });
                }
                else if (this.type == 'dict') {
                    this.constraints.forEach(constraint => {
                        if (constraint.name == this.description[0]) {
                            isExist = true;
                            constraint.value[0] = this.value[0];
                            constraint.value[1] = this.value[1];
                        }
                    });
    
                    if (!isExist)
                        this.constraints.push({
                            type: this.type,
                            name: this.description[0],
                            value: this.value
                        });
                }
                else if (this.inpType == 'URL') {
                    this.constraints.forEach(constraint => {
                        if (constraint.name == this.description[0]) {
                            isExist = true;
                            constraint.value[0] = '';
                            constraint.value[1] = this.value[0];
                        }
                    });
    
                    if (!isExist)
                        this.constraints.push({
                            type: this.type,
                            name: this.description[0],
                            value: [ '', this.value ]
                        });
                }
                else {
                    this.constraints.forEach(constraint => {
                        if (constraint.name == this.description[0]) {
                            isExist = true;
                            constraint.value[0] = this.value[0];
                            constraint.value[1] = this.value[1];
                        }
                    });
    
                    if (!isExist)
                        this.constraints.push({
                            type: this.type,
                            name: this.description[0],
                            value: this.value
                        });
                }
            }
        }
    };
    
    const ConstraintsComponent = {
        props: [
            'competition'
        ],
        template: `
        <div>
            <div class="createCompetition__conditions">
                <h2 class="createCompetition__header">Задайте условия конкурса</h2>
                <constraintElement-component    :constraints="competition.constraints" :name="'maxParticipants'" :type="'line'" 
                                                :description="['Максимальное количество учаcтников']" :inpType="'text'"></constraintElement-component>
                <constraintElement-component    :constraints="competition.constraints" :name="'age'" :type="'dict'" 
                                                :description="['Возраст учаcтников', 'От', 'До']" :inpType="'number'"></constraintElement-component>
                <constraintElement-component    :constraints="competition.constraints" :name="'countries'" :type="'line'" 
                                                :description="['Страны учаcтников', '#Все']"></constraintElement-component>
                <constraintElement-component    :constraints="competition.constraints" :name="'cities'" :type="'line'" 
                                                :description="['Города учаcтников', '#Все']" :inpType="'text'"></constraintElement-component>
                <constraintElement-component    :constraints="competition.constraints" :name="'link'" :type="'file'" 
                                                :description="['Ссылка на подробные условия конкурса', 'Вставьте ссылку на подробные условия конкурса']"" :inpType="'URL'"></constraintElement-component>
                <constraintElement-component    :constraints="competition.constraints" :name="'price'" :type="'dict'" 
                                                :description="['Стоимость конкурса (руб)', 'Установите стоимость конкурса в рублях']"" :inpType="'number'"></constraintElement-component>
                <constraintElement-component    :constraints="competition.constraints" :name="'extra'" :type="'line'" 
                                                :description="['Свое условие конкурса', 'Впишите свободное условие конкурса']"" :inpType="'text'"></constraintElement-component>

                <constraintElement-component    :constraints="competition.constraints" :name="'badwords'" :type="'dict'" 
                                                :description="['Мат', 'Разрешить мат (после публикации нельзя изменить)']"" :inpType="'checkbox'"></constraintElement-component>

                <constraintElement-component    :constraints="competition.constraints" :name="'ageConstraint'" :type="'dict'" 
                                                :description="['Возрастное ограничение']" :inpType="'select'" :options="['0+', '6+', '12+', '16+', '18+']"></constraintElement-component>
                                                
                <div class="createCompetition__documents">
                    <constraintElement-component    :constraints="competition.constraints" :name="'constraintsDocument'" :type="'file'" 
                                                    :description="['Условия', 'Загрузить условия']"" :inpType="'file'"></constraintElement-component>

                    <constraintElement-component    :constraints="competition.constraints" :name="'politicsDocument'" :type="'file'" 
                                                    :description="['Политика конфиденциальности', 'Загрузить политику конфиденциальности']"" :inpType="'file'"></constraintElement-component>
                                                    
                    <constraintElement-component    :constraints="competition.constraints" :name="'agreementDocument'" :type="'file'" 
                                                    :description="['Соглашение', 'Загрузить соглашение']"" :inpType="'file'"></constraintElement-component>

                    <constraintElement-component    :constraints="competition.constraints" :name="'extraDocument'" :type="'file'" 
                                                    :description="['Доп. документ', 'Загрузить доп. документ']"" :inpType="'file'"></constraintElement-component>
                </div>
            </div>
        </div>
        `,
        components: {
            'constraintElement-component': ConstraintElementComponent
        }
    };

    let vm = new Vue({
        el: '.app',
        components: {
            'prebanner-component': PreBannerComponent,
            'banner-component': BannerComponent,
            'constraints-component': ConstraintsComponent
        },
        data: {
            competition: {
                managerPhoneNumber: null,
                managerEmail: null,
                managerSocialLinks: [],
                categories: [],
                title: null,
                description: null,
                shortDescription: null,
                maxParticipants: null,
                constraints: [],
                prizes: [],
                jury: []
            }
        },
        methods: {
            appendConstraint(inp_type, inp_name, inp_value) {
                this.competition.constraints.push({
                    type: inp_type,
                    name: inp_name,
                    value: inp_value
                });
            }
        }
    });

});





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
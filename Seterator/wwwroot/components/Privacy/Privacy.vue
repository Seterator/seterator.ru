<template>
  <div class="privacy container">
        <h1 class="privacy__header">Документы</h1>
        <privacy-item  
            :propName="'user-license'"
        >
            <template v-slot:header>
                Пользовательское соглашение
            </template>
            <template v-slot:description>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
            </template>
        </privacy-item>

        <privacy-item  
            :propName="'confidential-policy'"
        >
            <template v-slot:header>
                Конфидециальная политика
            </template>
            <template v-slot:description>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
            </template>
        </privacy-item>

        <privacy-item  
            :propName="'term-of-use'"
        >
            <template v-slot:header>
                Правила пользования
            </template>
            <template v-slot:description>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
            </template>
        </privacy-item>

        <privacy-item  
            :propName="'for-organizers'"
        >
            <template v-slot:header>
                Для организаторов
            </template>
            <template v-slot:description>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
            </template>
        </privacy-item>

        <privacy-item  
            :propName="'agency-agreement-with-a-legal-entity'"
        >
            <template v-slot:header>
                Агентский договор с юридическим лицом
            </template>
            <template v-slot:description>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
            </template>
        </privacy-item>

        <privacy-item  
            :propName="'agency-agreement-with-ani-ndividual'"
        >
            <template v-slot:header>
                Агентский договор с физическим лицом
            </template>
            <template v-slot:description>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
            </template>
        </privacy-item>

        <privacy-item  
            :propName="'for-moderators-and-jury'"
        >
            <template v-slot:header>
                Для модераторов и жюри
            </template>
            <template v-slot:description>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
            </template>
        </privacy-item>

        <privacy-item  
            :propName="'rules-for-checking-works'"
        >
            <template v-slot:header>
                Регламент проверки произведений
            </template>
            <template v-slot:description>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
            </template>
        </privacy-item>

        <privacy-item  
            :propName="'regulations-on-the-work-of-moderators'"
        >
            <template v-slot:header>
                Положение о работе модераторов
            </template>
            <template v-slot:description>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
            </template>
        </privacy-item>

        <privacy-item  
            :propName="'regulations-for-the-evaluation-of-works'"
        >
            <template v-slot:header>
                Регламент оценки произведений
            </template>
            <template v-slot:description>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
            </template>
        </privacy-item>

        <privacy-item  
            :propName="'regulations-on-the-work-of-the-jury'"
        >
            <template v-slot:header>
                Положение о работе жюри
            </template>
            <template v-slot:description>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
            </template>
        </privacy-item>
  </div>
</template>

<script>
import PrivacyItemComponent from './PrivacyItem.vue'

export default {
    components: {
        'privacy-item': PrivacyItemComponent
    }
}
</script>

<style>
.privacy__header {
    font-family: 'Merriweather', serif;
    font-size: 24pt;
    font-weight: 600;

    padding-bottom: 30px;
}
</style>

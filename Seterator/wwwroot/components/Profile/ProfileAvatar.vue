// Компонент представляет собой аватар пользователя в профиле
// Параметры:
// src - путь к изображению

<template>
    <div class="profileAvatar" :class="[role!='profile-organizer' ? 'profileAvatar_role_user' : null]">

        <!-- Аватар профиля организации -->
        <div    v-if="role == 'profile-organizer'"
                class="profileAvatar__organization"
        >
            <img    alt="Аватар пользователя"
                    :src="image"
            />
            <div    class="editing"
                    v-if="propIsEditing"
            >
                <label  class="editing__label_role_user"
                        for="file-input"
                >
                    <span>Загрузить</span>
                </label>
                <input  type="file" 
                        id="file-input" 
                        class="editing__input_role_user"
                        @change="onFileChange">
            </div>
        </div>

        <!-- Аватар профиля не организации -->
        <div v-else>
            <img    alt="Аватар пользователя"
                    :src="image" 
            />

            <!-- Редактирование профиля -->
            <div    class="editing"
                    v-if="propIsEditing"
            >
                <label  class="editing__label_role_user"
                        for="file-input"
                >
                    <span>Загрузить</span>
                </label>
                <input  type="file" 
                        id="file-input" 
                        class="editing__input_role_user"
                        @change="onFileChange">
            </div>
        </div>
    </div>
</template>

<script>

export default {
    props: {
        src: {
            type: String
        },
        
        role: {
            type: String
        },
        
        propIsEditing: {
            type: Boolean
        }
    },
    
    data() {
        return {
            image: this.src
        }
    },

    methods: {
        onFileChange(e) {
            let files = e.target.files || e.dataTransfer.files;
            if (!files.length)
                return;
            this.createImage(files[0]);
        },

        createImage(file) {
            let image = new Image();
            let reader = new FileReader();
            let vm = this;

            // this.$emit('change-avatar', file);
            
            reader.onload = (e) => {
                vm.image = e.target.result;
            };
            reader.readAsDataURL(file);
        },

        removeImage: function(e) {
            this.image = '';
        }
    }
}
</script>

<style scoped>
.profileAvatar {
    max-width: 100%;
}

.profileAvatar_role_user {
    position: relative;
}

.profileAvatar img {
    width: 100%;
}

.profileAvatar__organization {
    width: 150px;
    height: 150px;
    overflow: hidden;
    background: rgb(255, 255, 255);
    border-radius: 50%;
    border: 2px solid rgb(255, 82, 25)
}

.editing {
    position: absolute;
    width: 100%;
    bottom: 0;
}

.editing__label_role_user {
    width: 100%;
    margin: 0;
    padding: 10px;
    text-align: center;
    background: rgb(255, 255, 255);
    opacity: 0.8;

    color: rgb(255, 82, 25);
    font-weight: bold;
}

.editing__label_role_user:hover {
    opacity: 0.9;
    cursor: pointer;

    text-decoration: underline;
}

.editing__input_role_user {
    width: 0.1px;
     height: 0.1px;
     opacity: 0;
     position: absolute;
     z-index: -10;
}
</style>

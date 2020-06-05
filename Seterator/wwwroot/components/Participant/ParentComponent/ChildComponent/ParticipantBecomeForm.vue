<template>
  <div>
      <form class="participantBecome__form form">
        <input class="form__textbox form__textbox_type_nomralText form__textbox_theme_light" name="title" type="text" placeholder="Название произведения" />
        <input class="form__textbox form__textbox_type_nomralText form__textbox_theme_light" name="nickname" type="text" placeholder="Псевдоним" />
        <textarea class="form__textarea form__textarea_theme_light" name="poem" placeholder="Забил снаряд я в пушку..." rows="10"></textarea>
        <input class="btn btn_color_orange" type="submit" value="Отправить" />
        <p class="form__authAgreement form__authAgreement_size_m">Регистрируясь, Вы принимаете условия <a href="#">Пользовательского соглашения</a>.</p>
    </form>
  </div>
</template>

<script>
export default {
name: 'participantBecome-form'
}
</script>

<style>

</style>

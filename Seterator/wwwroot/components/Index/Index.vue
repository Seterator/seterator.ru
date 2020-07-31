<template>
  <div class="container">
    <div class="banner banner_theme_common banner_padding_medium">
      <!-- Блок для затемнения -->
      <div class="banner_block">
        <h2 class="banner_title">Поэтические конкурсы каждый день!</h2>
        <p class="banner_description">
          Устал от конкурсов с результатами через год?
          <br />Отправь заявку сегодня и завтра узнай результат!
        </p>
      </div>
    </div>
    <div class="row event_list">
      <div class="col-md-12 col-xl-4">
        <span class="line"></span>
        <!-- Выдает актуальное время, но должен выдавать время до окончания конкурса -->
        <p style="display: inline;">{{timestamp}}</p>
        <span class="line"></span>

        <div class="competition_block">
          <p class="competition_headline thin">
            <!-- Место времени (таймстемп) надо вставить тип конкурса: Ежедневный конкурс-->
            {{timestamp}}
            <img src alt="Paid-Symbol" />
          </p>
          <h2 class="competition_title">Lorem ipsum dolor</h2>
          <p class="competition_description">Lorem ipsum dolor sit amet consectetur adipisicing</p>
        </div>
      </div>
      <div class="col-md-12 col-xl-4">
        <span class="line"></span>
        <!-- Выдает актуальное время, но должен выдавать время до окончания конкурса -->
        <p style="display: inline;">{{timestamp}}</p>
        <span class="line"></span>

        <div class="competition_block">
          <p class="competition_headline thin">
            <!-- Место времени (таймстемп) надо вставить тип конкурса: Ежедневный конкурс-->
            {{timestamp}}
            <img src alt="Paid-Symbol" />
          </p>
          <h2 class="competition_title">Lorem ipsum dolor</h2>
          <p class="competition_description">Lorem ipsum dolor sit amet consectetur adipisicing</p>
        </div>
      </div>
      <div class="col-md-12 col-xl-4">
        <span class="line"></span>
        <!-- Выдает актуальное время, но должен выдавать время до окончания конкурса -->
        <p style="display: inline;">{{timestamp}}</p>
        <span class="line"></span>

        <div class="competition_block">
          <p class="competition_headline thin">
            <!-- Место времени (таймстемп) надо вставить тип конкурса: Ежедневный конкурс-->
            {{timestamp}}
            <img src alt="Paid-Symbol" />
          </p>
          <h2 class="competition_title">Lorem ipsum dolor</h2>
          <p class="competition_description">Lorem ipsum dolor sit amet consectetur adipisicing</p>
        </div>
      </div>
      <!-- 3 блока в ряд и 1 блок на маленьких экранах -->
      <!--
        <div class="col-md-12 col-xl-4">
            
        </div>
        <div class="col-md-12 col-xl-4">
            
        </div>
      -->
    </div>
  </div>
</template>

<script>
export default {
  data: function () {
    return {
      timestamp: "",
    };
  },
  created() {
    setInterval(this.getNow, 1000);
  },
  methods: {
    getNow: function () {
      const today = new Date();
      const date =
        today.getFullYear() +
        "-" +
        (today.getMonth() + 1) +
        "-" +
        today.getDate();
      const time =
        today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
      const dateTime = date + " " + time;
      this.timestamp = dateTime;
    },
  },
};
</script>
<!--
<script type = "text/javascript">
I
var vue_det = new Vue({
  el: "#intro",

});
</script>
-->

<style scoped>
</style>
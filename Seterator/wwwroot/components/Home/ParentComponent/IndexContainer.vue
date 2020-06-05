<template>
  <div>
      <div class="container">
          <index-container></index-container>
      </div>
      <timer-script></timer-script>
      <index-script></index-script>
  </div>
</template>

<script>
import Index from 'Seterator/Views/Home/Index';
import AddTimer from 'Seterator/wwwroot/components/Home/ParentComponent/ChildComponent/AddTimer';
import AddIndex from 'Seterator/wwwroot/components/Home/ParentComponent/ChildComponent/AddIndex';
export default {
name: 'index-container'
}
</script>

<style>

</style>

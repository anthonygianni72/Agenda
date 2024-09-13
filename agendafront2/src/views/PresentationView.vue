<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/Programmer2.png">
    <HelloWorld />
  </div>
</template>

<script>
// @ is an alias to /src
import HelloWorld from '@/components/HelloWorld.vue'

export default {
  name: 'PresentationView',
  components: {
    HelloWorld
  }
}
</script>
<style scoped>

.home img {
    max-width:300px;
    max-height:250px;
    width: auto;
    height: auto;
}</style>

<template>
  <!-- <img alt="Vue logo" src="./assets/logo.png"> -->
  <FilterModule msg="Welcome to Your Vue.js App"/>
  <GridModule/>
</template>

<script>
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap";
import FilterModule from './components/Filter.vue'
import GridModule from './components/Grid.vue'

export default {
  name: 'App',
  components: {
    FilterModule,
    GridModule
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>

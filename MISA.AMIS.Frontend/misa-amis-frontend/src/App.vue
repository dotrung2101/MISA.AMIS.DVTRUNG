<template>
  <div id="app">
    <my-navbar></my-navbar>
    <div class="main">
      <my-header></my-header>
      <my-content></my-content>
    </div>
  </div>
</template>

<script>
import MyHeader from './components/layout/header.vue';
import MyContent from './components/layout/content.vue';
import MyNavbar from './components/layout/navbar';

export default {
  name: 'App',
  components: {
    MyHeader,
    MyContent,
    MyNavbar,
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
  display: flex;
  width: 100%;
  height: 100vh;
  box-sizing: border-box;
}

.main{
  flex: 1;
  height: 100%;
  display: flex;
  flex-direction: column;
}
</style>

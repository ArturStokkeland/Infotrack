<script setup lang="ts">
import { RouterLink, RouterView } from "vue-router";
import HelloWorld from "./components/HelloWorld.vue";
</script>

<template>
  <nav>
    <div>
      <RouterLink to="/">Search</RouterLink>
      <RouterLink to="/history">History</RouterLink>
    </div>
  </nav>

  <RouterView />
</template>

<style scoped>
nav {
  display: fixed;
  background-color: #292524;
  padding: 10px;
}

nav > div {
  align-items: space-between;
  display: flex;
  width: 100%;
  justify-content: space-evenly;
  gap: 50px;
}

a {
  background-color: #0891b2;
  border-bottom: 4px solid #155e75;
  border-radius: 10px;
  font-size: 2rem;
  text-decoration: none;
  color: #e7e5e4;
  padding: 10px 20px;
}

a:hover {
  background-color: #06b6d4;
}
</style>

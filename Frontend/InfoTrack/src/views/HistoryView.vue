<script setup lang="ts">
import axios from "axios";
import { ref, onMounted } from "vue";

interface searchResult {
  query: string;
  engine: string;
  ranking: string;
  date: string;
}

const loading = ref(true);
let history = ref();

onMounted(() => {
  var config = {
    method: "get",
    url: "https://localhost:7273/history",
    headers: {},
  };

  axios(config)
    .then(function (response) {
      console.log(response.data);
      let loadedHistory: Array<searchResult> = [];
      response.data.forEach((result) => {
        let newResult = {
          query: result.searchTerm,
          engine: result.searchEngine,
          ranking: result.result,
          date: result.searchDate,
        };
        loadedHistory.push(newResult);
      });
      history.value = loadedHistory;
      loading.value = false;
    })
    .catch(function (error) {
      console.log(error);
    });
});
</script>

<template>
  <div id="container">
    <div class="tab">
      <h1>History</h1>
      <div id="loading" v-if="loading"><p>Loading data...</p></div>
      <div v-if="!loading">
        <div class="grid-header">
          <p class="grid-header-item">Query</p>
          <p class="grid-header-item">Engine</p>
          <p class="grid-header-item">Rankings</p>
          <p class="grid-header-item">Search Date</p>
        </div>
        <div v-for="result in history" class="grid-body">
          <p class="grid-body-item">{{ result.query }}</p>
          <p class="grid-body-item">{{ result.engine }}</p>
          <p class="grid-body-item">{{ result.ranking }}</p>
          <p class="grid-body-item">{{ result.date }}</p>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
#container {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.tab {
  background-color: #292524;
  border-radius: 20px;
  margin-top: 20px;
  padding: 20px 30px;
  width: 80%;
}

.tab > h1 {
  color: #e7e5e4;
  text-align: center;
  margin: 0;
  margin-bottom: 20px;
}

#loading > p {
  color: #e7e5e4;
  text-align: center;
  margin: 0;
}

.grid-header {
  width: 100%;
  display: grid;
  grid-template-columns: repeat(4, minmax(0, 1fr));
  gap: 1rem;
}

.grid-header-item {
  color: #e7e5e4;
  font-size: 1.25rem;
  font-weight: bold;
  text-align: center;
}

.grid-body {
  width: 100%;
  display: grid;
  grid-template-columns: repeat(4, minmax(0, 1fr));
  gap: 1rem;
  margin-bottom: 10px;
  background-color: #404040;
  border-radius: 20px;
}

.grid-body:hover {
  background-color: #525252;
}

.grid-body-item {
  color: #e7e5e4;
  font-size: 1.25rem;
  text-align: center;
}
</style>

<script setup lang="ts">
import axios from "axios";
import { ref } from "vue";

const result = ref();
const loading = ref(false);
const query = ref("");
const engine = ref("google");

function test() {
  loading.value = true;

  var config = {
    method: "post",
    url:
      "https://localhost:7273/scrape/" +
      encodeURIComponent(engine.value) +
      "/" +
      encodeURIComponent(query.value),
    headers: {},
  };

  axios(config)
    .then(function (response) {
      result.value = response.data;
      result.value = {
        query: response.data.searchTerm,
        engine: response.data.searchEngine,
        ranking: response.data.result,
        date: response.data.searchDate,
      };
      console.log(JSON.stringify(response.data));
      loading.value = false;
    })
    .catch(function (error) {
      console.log(error);
    });
}
</script>

<template>
  <div id="container">
    <div class="tab">
      <h1>Search</h1>
      <div class="searchContainer">
        <div class="inputContainer">
          <p>Search Query:</p>
          <input
            type="text"
            placeholder="Enter a search query"
            v-model="query"
          />
        </div>
        <div class="inputContainer">
          <p>Search Engine:</p>
          <div id="radios">
            <div>
              <input
                type="radio"
                id="google"
                name="fav_language"
                value="google"
                v-model="engine"
                checked
              />
              <label for="google">Google</label><br />
            </div>
            <div>
              <input
                type="radio"
                id="bing"
                name="fav_language"
                value="bing"
                v-model="engine"
              />
              <label for="bing">Bing</label><br />
            </div>
          </div>
        </div>
      </div>
      <div id="buttonContainer">
        <button @click="test()">Find Results</button>
      </div>
    </div>
    <div class="tab">
      <h1>Result</h1>
      <div v-if="!result && !loading" class="status">
        No results yet, try searching
      </div>
      <div v-if="loading" class="status">Fetching Results</div>
      <div v-if="result && !loading">
        <div class="grid-header">
          <p class="grid-header-item">Query</p>
          <p class="grid-header-item">Engine</p>
          <p class="grid-header-item">Rankings</p>
          <p class="grid-header-item">Search Date</p>
        </div>
        <div class="grid-body">
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
p {
  color: #e7e5e4;
  font-size: 1.5rem;
}

label {
  color: #e7e5e4;
  font-size: 1.5rem;
  padding-left: 10px;
}

input {
  font-size: 1.5rem;
  box-sizing: border-box;
  border-radius: 10px;
}

input[type="text"] {
  padding: 10px;
  width: 100%;
}

input[type="radio"] {
  width: 15px;
  height: 15px;
}

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
}

.searchContainer {
  display: flex;
  flex-direction: column;
  gap: 20px;
  margin: 20px 0;
}

.inputContainer {
  display: flex;
  background-color: #404040;
  border-radius: 20px;
  padding: 30px;
  flex-direction: column;
  gap: 10px;
}

.inputContainer > p {
  margin: 0;
}

#radios {
  display: flex;
  justify-content: space-around;
}

#buttonContainer {
  display: flex;
  justify-content: center;
  margin: 0;
}

button {
  background-color: #0891b2;
  border-top: none;
  border-right: none;
  border-left: none;
  border-bottom: 4px solid #155e75;
  color: #e7e5e4;
  border-radius: 10px;
  font-size: 1.5rem;
  padding: 10px 40px;
}

button:hover {
  background-color: #06b6d4;
  cursor: pointer;
}

.status {
  color: #e7e5e4;
  text-align: center;
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

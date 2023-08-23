import { createRouter, createWebHistory } from "vue-router";
import SearchView from "../views/SearchView.vue";
import HistoryView from "../views/HistoryView.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/",
      name: "Search",
      component: SearchView,
    },
    {
      path: "/history",
      name: "history",
      component: HistoryView,
    },
  ],
});

export default router;

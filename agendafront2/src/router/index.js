import { createRouter, createWebHistory } from 'vue-router'
import PresentationView from '../views/PresentationView.vue'

const routes = [
  {
    path: '/',
    name: 'presentation',
    component: PresentationView
  },
  {
    path: '/requirements',
    name: 'requirements',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/RequirementsView.vue')
  }
  ,
  {
    path: '/schedule',
    name: 'schedule',
    component: () => import(/* webpackChunkName: "about" */ '../views/ScheduleView.vue')
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router

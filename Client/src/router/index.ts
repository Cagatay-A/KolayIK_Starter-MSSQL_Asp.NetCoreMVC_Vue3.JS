import { createWebHistory, createRouter } from 'vue-router';
//import { RouteRecordRaw } from "vue-router";
import ModalPage from '../components/ModalPage.vue';
import PermissionPage from '../components/PermissionPage.vue';
import NotFoundPage from '../components/NotFoundPage.vue';
import TimePicker from '../components/TimePicker.vue';//DEPRECATED
import AlertPage from '../components/AlertPage.vue';


const routes = [

  {
    path: '/',
    name: "PermissionPage",
    component: PermissionPage,
  },
  {
    path: '/modalPage',
    name: 'ModalPage',
    component: ModalPage,
  },
  {//DEPRECATED
    path: '/TimePicker',
    name: 'TimePicker',
    component: TimePicker,
  },
  {
    path: '/AlertPage',
    name: 'AlertPage',
    component: AlertPage,
  },
  { 
    path: '/:pathMatch(.*)*', 
    component: NotFoundPage 
  },
  ];

  const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes,
  });
  
  
  export default router;
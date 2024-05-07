import './assets/main.css'

import { createApp } from 'vue'
import { createRouter, createWebHistory } from 'vue-router'
import { autoAnimatePlugin } from '@formkit/auto-animate/vue'
import App from './App.vue'

import Home from './pages/Home.vue'
import Good from './pages/Good.vue'
import Orders from './pages/Orders.vue'
import LogIn from './pages/Auth/LogIn.vue'
import SignUp from './pages/Auth/SignUp.vue'
import Settings from './pages/Settings.vue'
import Work from './pages/Work.vue'

const app = createApp(App)

const routes = [
    { path: '/', name: 'Home', component: Home },
    { path: '/good/:id', name: 'Good', component: Good },
    { path: '/orders', name: 'Orders', component: Orders },
    { path: '/login', name: 'LogIn', component: LogIn },
    { path: '/signup', name: 'SignUp', component: SignUp },
    { path: '/settings', name: 'Settings', component: Settings },
    { path: '/work', name: 'Work', component: Work }
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

app.use(router)
app.use(autoAnimatePlugin)

app.mount('#app')
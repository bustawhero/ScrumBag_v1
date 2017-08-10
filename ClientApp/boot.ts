import Vue from 'vue';
import VueRouter from 'vue-router';
Vue.use(VueRouter);

const routes = [
    { path: '/', component: require('./components/home/home.vue.html'),meta:{ noAuth: true} },
    { path: '/counter', component: require('./components/counter/counter.vue.html'),meta:{ noAuth: false} },
    { path: '/fetchdata', component: require('./components/fetchdata/fetchdata.vue.html'),meta:{ noAuth: false} },
    { path: '/register', component: require('./components/register/register.vue.html'),meta:{ noAuth: true} },
    { path: '/login', component: require('./components/login/login.vue.html'),meta:{ noAuth: true} },
    { path: '/company', component: require('./components/company/company.vue.html'),meta:{ noAuth: true} },
    { path: '/client/:id', component: require('./components/clients/client.vue.html'),meta:{ noAuth: true} },
    { path: '/project/:id', component: require('./components/projects/project.vue.html'),meta:{ noAuth: true} },
    { path: '/client', component: require('./components/company/clientitem.vue.html'),meta:{ noAuth: false} },
    { path: '/bug/:id', component: require('./components/bugs/bugs.vue.html'),meta:{ noAuth: false} },
    { path: '/projtask', component: require('./components/bugs/projtask.vue.html'),meta:{ noAuth: false} }
];

const myRouter = new VueRouter({ mode: 'history', routes: routes });

 let count = 0;

myRouter.beforeEach((to, from, next)=>{
   
    if(to.matched.some(record => record.meta.noAuth))
    {
        //this.next()s
        console.log("No Auth Site" + count++);
        next();

        //this.next({path: '/'})
    }
    else {
        console.log("Auth Site")
        let token  = localStorage.getItem('token');
        if(token)
        {
            next();
        }
        else
        {
            next({path: '/login'})
            //next();
        }   
    }
})


new Vue({
    el: '#app-root',
    router: myRouter,
    render: h => h(require('./components/app/app.vue.html'))
});

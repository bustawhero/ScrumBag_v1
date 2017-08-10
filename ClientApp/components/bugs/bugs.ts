import Vue from 'vue';
import axios from 'axios';
import { Component, Lifecycle } from 'av-ts';
import { Bug } from '../../interfaces/ibug';
import projtask from './projtask';

@Component({
    components:{
        'projtask': projtask
    }
})
export default class BugComponent extends Vue{

test:string = "just a test Wheroo Style!!";
bugid: string = "no id";
bug: Bug = null;

@Lifecycle created(){

    this.bugid =  this.$route.params.id;

    let url = '/api/Company/GetBugData' + '/?bugid=' + this.bugid;

    this.test = "testing " +  this.bugid;

     fetch(url, {
      credentials: 'same-origin'
    })
    .then(response => response.json() as Promise<Bug>)
    .then(data => {
        console.log(data);
        this.bug = data;
    }).catch( r=> console.log(r) );
}



}
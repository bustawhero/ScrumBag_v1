import Vue from 'vue';
import axios from 'axios';
import { Component, Lifecycle, Prop, p} from 'av-ts';
import { ProjTask } from '../../interfaces/ibug';

@Component
export default class ProjTaskComponent extends Vue{

projtasks:ProjTask[] = [];

checked:boolean = false;
test: string = "hello world";

  @Prop bugid = p({
    type: String,
    required: true
  })

@Lifecycle created(){

let url = '/api/Company/GetBugTasks' + '/?bugid=' + this.bugid;

this.test = "Hello Bug:" + this.bugid;

    fetch(url, {
      credentials: 'same-origin'
    })
    .then(response => response.json() as Promise<ProjTask[]>)
    .then(data => {
        console.log("task success");
        this.projtasks = data;
    }).catch( r=> console.log(r) );
}


}
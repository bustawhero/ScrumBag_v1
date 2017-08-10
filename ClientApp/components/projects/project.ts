import Vue from 'vue';
import { Lifecycle, Component } from 'av-ts';
import axios from 'axios'

interface bug{
    id: number,
    name: string,
    bugStatus: string,
    prTojType: string,
    backLog: boolean,
    openTaskCount: number
}

@Component
export default class ProjectComponent extends Vue{
test:string = "is this working?";
projectid:string = "just a test";
bugs: bug[] =[];


@Lifecycle created(){

    this.projectid =  this.$route.params.id;

let url = '/api/Company/GetBugList' + '/?projid=' + this.projectid;

 fetch(url, {
      credentials: 'same-origin'
    })
            .then(response => response.json() as Promise<bug[]>)
            .then(data => {
               console.log(data);
                this.bugs = data;
            }).catch( r=> console.log(r) );
}


}

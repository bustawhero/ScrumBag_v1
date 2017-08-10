import Vue from 'vue';
import axios from 'axios';
import { Component, Lifecycle} from 'av-ts';



interface projs {
    id: number,
    name: string,
    descr: string,
    clientID: number,
    createDate: Date,
    bugCount: number
}

interface iproject {
    id: number,
    name: string,
    descr: string,
    clientID: number,
    createDate: Date
    bugs:bug[]
}

interface bug{
    id: number,
    name: string,
    bugStatus: string,
    prTojType: string,
    backLog: boolean
}

interface proj {
    id: number,
    bugs: number[]
}

@Component
export default class ClientComponent extends Vue{
clientid: string = "no value"
projects: projs[] = [];
fakebugs: number[] = [];
proj: proj[] = [];



@Lifecycle created(){

this.clientid =  this.$route.params.id;

let url = '/api/Company/GetProjData' + '/?clientid=' + this.clientid;

 fetch(url, {
      credentials: 'same-origin'
    })
            .then(response => response.json() as Promise<projs[]>)
            .then(data => {
               console.log(data);
                this.projects = data;
            }).catch( r=> console.log(r) );
}

setid(){

this.clientid = this.$route.params.id;

}

addBug()
{

    let num:number = this.fakebugs.length + 1;
    this.fakebugs.push(num);

}

addProj(){
    let num:number = this.proj.length + 1;

    let n_proj:proj = {id: num, bugs: this.fakebugs};

    this.proj.push(n_proj);

}

    
}
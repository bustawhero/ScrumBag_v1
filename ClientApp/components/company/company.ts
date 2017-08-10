import Vue from 'vue';
import { Component, Lifecycle, Watch } from 'av-ts';
import axios from 'axios';
import { Client } from '../../interfaces/iclient';
import clientitem from './clientitem';
import Dictionary from './dictionary';

interface idict{
    key:number,
    name: string
}


interface Company{
    id: number,
    name: string,
    logolink: string,
    client: Client[]
}

interface DueTasks{
    id:number,
    bugId:number,
    taskType:string,
    descr: string,
    assignedTo: number,
    createDate: Date,
    complete: boolean,
    completeDate: Date,
    dueDate: Date
}


@Component({
    components:{
        'clientitem': clientitem 
    }
})
export default class CompanyComponent extends Vue{

clients: Client[] = [];
testData: string = "Warren Wrate"
company: Company = {id: 1, name:"", logolink:'./logo.png', client: null};
checked: boolean = false;
mname: string = "none";
_dictionary = new Dictionary();  


  myWatchee = 'watch me!'
  @Watch('company')
  handler(newVal, oldVal) {
    console.log(this.company + 'changed!');
    this.company.client = this.clients;
  }

@Lifecycle created(){

        let user1:idict = { key: 1, name: "Warren" };
        let user2:idict = { key: 2, name: "Addison" };

        this._dictionary = new Dictionary();  

        this._dictionary.Add(user1);
        this._dictionary.Add(user2);

        this.mname = this._dictionary.Get(1);

 fetch('/api/Company/GetCompanyData', {
      credentials: 'same-origin'
    })
            .then(response => response.json() as Promise<Company>)
            .then(data => {
               console.log(data);
                this.company = data;
            }).catch( r=> console.log(r) );

//GetClientData

 fetch('/api/Company/GetClientData', {
      credentials: 'same-origin'
    })
            .then(response => response.json() as Promise<Client[]>)
            .then(data => {
               console.log(data);
                this.clients = data;
            }).catch( r=> console.log(r) );
        
    this.testData = "Created Works!!";

    try{
        this.add();
        this.company.client = this.clients;
    }
    catch(e){
        console.log(e);
    }

    console.log(this.company);

}

updateData(){

        var self = this;

        self.company.client = this.clients

        axios.post('api/Company/UpdateCompany/', self.company).then((data)=> { console.log("Success")
        } ).catch((error)=>{console.log("error occurred.")});
}

chkclk(){

    alert(this.checked);
    
}


 

add(){
    this.company.client = this.clients;

    console.log(this.company);
}


}


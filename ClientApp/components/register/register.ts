import Vue from 'vue';
import { Component, Lifecycle } from 'av-ts';
import axios from "axios";
import counter from "../counter/counter";

interface RegisterViewModel {
        Email: string,
        FName: string,
        LName: string,
        MI: string,
        Alias: string,
        UserTypr: string,
        CompanyID: number,
        Password: string,
        ConfirmPassword: string
}

@Component({
    filters:{},
    name: 'register',
    components:{
        'counter': counter 
    }
})
export default class RegisterComponent extends Vue {
    currentcount: number = 0;
    UserTypes: string[] = ["Admin", "Developer", "Tester","Analyst","Systems Analyst"];
    Email: string = "default@non.com";
    Password: string = "";
    ConfirmPassword: string = "transformersJustCameOut";
    MyName: string = "Warren Wrate";
    SelectedUserType: string = "Analyst";
    FName: string = "";
    LName: string = "";
    MI: string = "";
    CompanyID: number = 1;
    Alias: string = "";
    Pic: string = "./default.png"
    FakeToken: string = "";

getNameAndToken(){
    this.FakeToken = localStorage.getItem('token');
    this.MyName = localStorage.getItem('Name');
    console.log(this.FakeToken);
}


       registerUser(){

        this.currentcount = 15;

        if(this.Password != this.ConfirmPassword){
            console.log("password and confirm do not match");
            return;
        }

        //axios.get('api/Account/MyTest').then((data)=> this.MyName = data.data);

        //** the above and below work */

        // axios.get('/api/Account/RegisterT', { params: {
        //     //model: this.rvm
        //     Email: "warrenwrate@testing.com",
        //     FName: "Warren",
        //     LName: "Wrate",
        //     MI: "H",
        //     Alias: "wwrat",
        //     UserType: "Developer",
        //     CompanyID: 1,
        //     Password: "14Butters!",
        //     ConfirmPassword: "14Butters!",
        //     Pic: './images/warren.jpg'
        //     }})
        //  .then((res) => {
        //    console.log(res);
        //  })
        //  .catch((ex) => console.log(ex));

         let _user = {
            Email: this.Email,
            FName: this.FName,
            LName: this.LName,
            MI: this.MI,
            Alias: this.Alias,
            UserType: this.SelectedUserType,
            CompanyID: this.CompanyID,
            Password: this.Password,
            ConfirmPassword: this.ConfirmPassword,
            Pic: './images/warren.jpg'
        }

        axios.post('/api/Account/',_user)
        .then(function (response) {
            //console.log(response.data);
            localStorage.setItem('token','whatan@w3s0m3m@d3upT0k3n' );
            // if(this.FName)
            // {
            // localStorage.setItem('Name', this.FName);
            // }
            console.log(this.FName);
            console.log("success");
        })
        .catch(function (error) {
            console.log(error);
        });

 
  }
     


    findMyName() {
        this.MyName = "Warren The Awesome Wrate";
    }
}
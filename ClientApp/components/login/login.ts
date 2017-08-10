import Vue from 'Vue';
import { Component, Lifecycle } from 'av-ts';
import axios from "axios";


interface LoginModel {
        Email: string,
        Password: string
}

@Component
export default class LoginComponent extends Vue{

playdata: string = "What up.  Better login to view this cool Website"
Password: string = "";
UserName: string = "";


login()
{
   var self = this;

   var _user ={ Email: self.UserName, Password: self.Password, RememberMe: false } 

   console.log("remember the " + _user.Email);

   console.log(this.UserName);


   axios.get('/api/Account/Login', { params: { Email: self.UserName, Password: self.Password, RememberMe: false }})
   .then((res) => {
           console.log(res);
           localStorage.setItem('token','whatan@w3s0m3m@d3upT0k3n' );
           window.location.href = '/';
         })
         .catch((ex) => console.log(ex));
}

}


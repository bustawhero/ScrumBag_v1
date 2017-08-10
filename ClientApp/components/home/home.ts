import Vue from 'vue';
import { Lifecycle, Component } from 'av-ts';

interface idict{
    key:number,
    name: string
}

@Component
export default class HomeComponent extends Vue{

    //_dictionary: Dictionary = new Dictionary();
    mname:string= "None";

    @Lifecycle created(){

        let user1:idict = { key: 1, name: "Warren" };
        let user2:idict = { key: 2, name: "Addison" };

        // this._dictionary.Add(user1);
        // this._dictionary.Add(user2);
    }

}

// class Dictionary{

//     _arr:boolean[] = Array(20);
//     dictionary: idict[];

//     public Add(item:idict)
//     {
//         if(this.check(item))
//             {
//                 this.dictionary.push(item);
//                 console.log("added item to list");
//             }
//         else{
//             console.log("already has a item with that key");
//         } 
//     }

//     public Contains(key:number):boolean
//     {
//         return this._arr[key];
//     }

//     public Get(key:number):string
//     {
//         let d:idict[] = this.dictionary.filter(x=> x.key === key);

//         return d[0].name;
//     }

//     private check(c:idict):boolean
//     {
//         if(this._arr[c.key] == false){

//             return true;
//         }
//         return false;
//     }

// }
import Vue from 'vue';
import { Component, Lifecycle } from 'av-ts';
import axios from 'axios';

interface WeatherForecast {
    dateFormatted: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}

interface ProjTasks {
    id: string;
    bugid: number;
    taskType: string;
    descr: string;
    assignedTo: number;
    createDate: Date;
    complete: boolean;
    dueDate: Date;
}

@Component
export default class FetchDataComponent extends Vue {
    forecasts: WeatherForecast[] = [];
    myTasks: ProjTasks[] = [];

    @Lifecycle mounted() {
        fetch('/api/SampleData/WeatherForecasts', {
      credentials: 'same-origin'

    })
            .then(response => response.json() as Promise<WeatherForecast[]>)
            .then(data => {
               console.log(data);
                this.forecasts = data;
            }).catch( r=> console.log(r) );
    }

    getTasksa()
    {
        var self = this;

        axios.get('api/SampleData/GetTasksbyClient').then((data)=> {self.myTasks = data.data
        console.log(data)
        } );

       console.log(self.myTasks);
    }
    
    // not sure why but it needs a var self to get both methods to work.
       getTasks() {
        
        var self = this;

        fetch('api/SampleData/GetTasksbyClient',
        {
            credentials: 'same-origin'
        })
            .then(response => response.json() as Promise<ProjTasks[]>)
            .then(data => {
                self.myTasks = data;
            });

            console.log("The fetch works");
    }
}

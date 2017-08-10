import Vue from 'vue';
import { Component, Prop, p } from 'av-ts';
import { Client } from '../../interfaces/iclient';


@Component
export default class ClientitemComponent extends Vue{

checked:boolean = false;
testci: string = "hello world";

  @Prop client = p({
    type: Object,
    required: true
  })

}
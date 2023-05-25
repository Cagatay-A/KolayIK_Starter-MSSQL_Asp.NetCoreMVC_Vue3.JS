<!--DEPRECATED-->

<template>
 

 <div class="dropdown">

  <button @click="Drop()" class="dropbtn">

<div class="row" style="margin-right:0.2em">
<div class="col">
<h6 style="margin-left:0.5em">--:--</h6>
</div>
<div class="col">
  <i style="font-weight:border;font-size:20px" class="bi bi-clock d-flex justify-content-end"></i>
</div>
</div>

  </button>

<div id="myDropdown" class="dropdown-content">
<div style="margin-left:-20em" class="hstack gap-1">

<div class="bg-light border ms-auto col-2">
<div class="panel" id="result_panel">
<div class="panel-body ">

    <ul class="timepicker" >
<div v-for="(items,index) in 24" :key="items">

<div @click="ClickHourPicker(1,index)" v-if="items===this.SelectedStartHour">
  <li style="border: none; padding: 6px;" class="list-group-item disabled" >
          {{ items }}
        </li>
</div>

<div v-else>
  <li @click="ClickHourPicker(1,index)" style="border: none; padding: 6px;" class="list-group-item " >
          {{ items }}
        </li>
</div>

</div>
    </ul>

</div>
</div>
</div>

<div class="bg-light border col-2">
<div class="panel" id="result_panel">
<div class="panel-body">

    <ul class="timepicker">
      <li  style="border: none; padding: 6px;" class="list-group-item " v-for="item in 60" :key="item">
          {{ item }}
        </li>
    </ul>

</div>
</div>
</div>


</div>
</div>
</div>

 </template>

<script  lang="ts" >
import ModalService from "@/services/ModalService";

import { onMounted, onUnmounted } from "vue";
import { defineComponent } from "vue";

import User from "@/models/User";
import Company from "@/models/Company";
import PermissionRequest from "@/models/PermissionRequest";
import IPermissionRequest from "@/models/PermissionRequest";
import Permission from "../models/Permission";


export default defineComponent({
  name: "TimePicker",

  props: {
    open: {
      type: Boolean,
      required: true,
    },
  },
    data() {
   
    return {
      DateChangeCounter: 0,
      selectedOrders: [],
      orderCount: 1,
      currentIndex: -1,
      active: false,
      selected: null,
      permissionCounter: 0,
   

      Request: {} as PermissionRequest,
      IRequest: {} as IPermissionRequest[],
      User: [] as User[],
      Permission: [] as Permission[],
      Company: {} as Company,
      Male:  [] as Permission[],
      Female:  [] as Permission[],

      timespan: {
          ticks: "0",
          days: 0,
          hours: 0,
          milliseconds: 0,
          minutes: 0,
          seconds: 0,
          totalDays: 0,
          totalHours: 0,
          totalMilliseconds: 0,
          totalMinutes: 0,
          totalSeconds: 0,
            },

    } //return
    }, //data
    methods: {

Drop() {
  document.getElementById("myDropdown").classList.toggle("show");
},


ClickHourPicker(id:any,indis:any){

if(id==1) //Start
{
  this.SelectedStartHour=indis+1;
  this.SelectedStartTime=indis+1;
}
if(id==2) //Stop
{
  this.SelectedStopHour=indis+1;
  this.SelectedStopTime=indis+1;

}
if(id==3) //Return
{
  this.SelectedReturnHour=indis+1;
  this.SelectedReturnTime=indis+1;
}
},

TimeToSpan(data){
var date1 = new Date('2023-04-13T'+data+':00Z');
var time = date1.getTime();

var days = Math.floor(time / (1000 * 60 * 60 * 24));
time -=  days * (1000 * 60 * 60 * 24);

var hours = Math.floor(time / (1000 * 60 * 60));
time -= hours * (1000 * 60 * 60);

var mins = Math.floor(time / (1000 * 60));
time -= mins * (1000 * 60);

var seconds = Math.floor(time / (1000));
time -= seconds * (1000);

var totalDays = (hours/24)+((mins/60)/24);
var totalHours = hours+(mins/60);
var totalMinutes = totalHours*60;
var totalSeconds = totalMinutes*60;
var totalMilliseconds = totalSeconds*1000;

this.timespan.ticks=totalMilliseconds+"0000";
this.timespan.days=0;
this.timespan.hours=hours;
this.timespan.milliseconds=0;
this.timespan.minutes=mins;
this.timespan.seconds=0;

this.timespan.totalDays=totalDays;
this.timespan.totalHours=hours;
this.timespan.totalMilliseconds=totalMilliseconds;
this.timespan.totalMinutes=totalMinutes;
this.timespan.totalSeconds=totalSeconds;

return(this.timespan);
},

GetPermisions() {
  ModalService.GetMalePermision().then(response=>{  
    this.Male =response.data;
    }).catch((e) => {
          console.log(e);
        });

        ModalService.GetFemalePermision().then(response=>{  
    this.Female =response.data;
    }).catch((e) => {
          console.log(e);
        });
},

GetCurrentUser() {
   ModalService.getCurrentUser().then(response=>{  
    this.User =response.data;
this.GetUserCompany(this.User.userCompanyId);
    }).catch((e) => {
          console.log(e);
        });
},

GetUserCompany(id:any) {
   ModalService.GetUserCompany(id).then(response=>{  
    this.Company =JSON.parse(JSON.stringify(response.data));
    this.TicksToTime(
    this.Company.companyStartWorkingTime,
    this.Company.companyStopWorkingTime,
    this.Company.companyStartLunchTime,
    this.Company.companyStopLunchTime
    );
    }).catch((e) => {
          console.log(e);
        });
},

TicksToTime(WStartTime:any,WStopTime:any,LStartTime:any,LStopTime:any){

var wstartlength=String(WStartTime.ticks).length-4
var wstartmilliseconds=String(WStartTime.ticks).slice(0,wstartlength);
this.companyinfo.WStartHour=Math.trunc((Number(wstartmilliseconds)/(1000*60*60)));// MesaiBaşlangıcı
this.companyinfo.WStartMin=(((Number(wstartmilliseconds)/(1000*60*60))-this.companyinfo.WStartHour)*60);

var wstoplength=String(WStopTime.ticks).length-4
var wstopmilliseconds=String(WStopTime.ticks).slice(0,wstoplength);
this.companyinfo.WStopHour=Math.trunc((Number(wstopmilliseconds)/(1000*60*60)));// MesaiBitişi
this.companyinfo.WStopMin=(((Number(wstopmilliseconds)/(1000*60*60))-this.companyinfo.WStopHour)*60);

var lstartlength=String(LStartTime.ticks).length-4
var lstartmilliseconds=String(LStartTime.ticks).slice(0,lstartlength);
this.companyinfo.LStartHour= (Number(lstartmilliseconds)/(1000*60*60));// ÖğleYemeğiBaşlangıcı
this.companyinfo.LStartMin=(((Number(lstartmilliseconds)/(1000*60*60))-this.companyinfo.LStartHour)*60);

var lstoplength=String(LStopTime.ticks).length-4
var lstopmilliseconds=String(LStopTime.ticks).slice(0,lstoplength);
this.companyinfo.LStopHour= (Number(lstopmilliseconds)/(1000*60*60));// ÖğleYemeğiBitişi
this.companyinfo.LStopMin=(((Number(lstopmilliseconds)/(1000*60*60))-this.companyinfo.LStopHour)*60);

},


onChangePermission(permissionid) 
{
this.IRequest.permissionId=permissionid.target.selectedIndex+1;
console.log("id -  "+this.IRequest.permissionId);
},

  }, //methods

setup(_, { emit }) {
    const close = () => {
      emit("close");
    };

    const handleKeyup = (event) => {
      if (event.keyCode === 27) {
        close();
      }
    };

    onMounted(() => document.addEventListener("keyup", handleKeyup));
    onUnmounted(() => document.removeEventListener("keyup", handleKeyup));

    return { close };
},

});
</script>


<style scoped>
*,
::before,
::after {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

.vue-modal {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  overflow-x: hidden;
  overflow-y: auto;
  background-color: rgba(0, 0, 0, 0.4);
  z-index: 1;
}

.vue-modal-inner {
  max-width: 500px;
  margin: 2rem auto;
}

.vue-modal-content {
  position: relative;
  background-color: #fff;
  border: 1px solid rgba(0, 0, 0, 0.3);
  background-clip: padding-box;
  border-radius: 0.3rem;
  padding: 1rem;
}

.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.5s;
}

.fade-enter-from,
.fade-leave-to {
  opacity: 0;
}

.drop-in-enter-active,
.drop-in-leave-active {
  transition: all 0.3s ease-out;
}

.drop-in-enter-from,
.drop-in-leave-to {
  opacity: 0;
  transform: translateY(-50px);
}
/*---------------*/

li{
  background-color: #ffffff; /*free*/
}
li:hover {
  background-color: #e5e5e5; /*Hover*/
}
li:active {
  background-color: #cecece; /*when selected*/
  font-weight: bold;
}



.timepicker {
  width: 80px;
  height: 150px;
  overflow-y: scroll;
}

.timepicker::-webkit-scrollbar {
    display: none;
}
/*------------*/

.dropbtn {
  background-color:white;
  color: black;
  font-size: 16px;
  border: 1px solid #cecece;
  cursor: pointer;
  width:80px;
  height:32px;
  text-align:left;
padding-left:1px;
border-radius:3px;
}



.dropdown {
  position: relative;
  display: inline-block;
}


.dropdown-content {
  display: none;
  position: absolute;
  background-color: #f1f1f1;
  min-width: 160px;
  box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
  z-index: 1;
}
.show {display:block;}


</style>
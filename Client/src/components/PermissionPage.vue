<template>

<div class="position-absolute top-0">
<transition name="fade" >
    <div v-if="this.showAlert===1">
      <AlertPage :AlertType="this.AlertType"></AlertPage>
    </div>
</transition>
</div>

<div class="container">

<!--1.ROW-->
<div class="row d-flex justify-content-center" style="margin-top:5em">
    <div class="d-flex justify-content-start col-xs-12">
     <h1>İzin Talep Listesi</h1>


     <div class="col-1 d-flex justify-content-center" style="">
     <button style="border-width: 1px;height:3em;" @click="GETDataTable" type="button" class="btn btn-ligth" >
      <i style="font-weight:bold ;font-size: 24px;" class="bi bi-arrow-clockwise"></i>
    </button>
  </div>

 </div>
  </div>
<!--1.ROW-->

<!--2.ROW-->
<div class="row d-flex justify-content-center"  style="margin-bottom:2em;margin-top:2em;">
  
  <div class="col">

<div class="row" >

<div class="col-11">
<input v-model="search.key" autocomplete='search.key' @keyup.enter="OnPressEnter(search)" 
type="text" class="form-control rounded-2" placeholder="İzin taleplerinde ara"
id="search-input">
</div>
<div class="col">
<button @click="OnPressEnter(search)" style="margin-left:-7em" type="button" class="btn btn-ligth copy" >
<svg xmlns="http://www.w3.org/2000/svg" class="icon icon-tabler icon-tabler-search" width="24" height="24" viewBox="0 0 24 24" stroke-width="2" stroke="currentColor" fill="none" stroke-linecap="round" stroke-linejoin="round">
<path stroke="none" d="M0 0h24v24H0z" fill="none"></path>
<path d="M10 10m-7 0a7 7 0 1 0 14 0a7 7 0 1 0 -14 0"></path>
<path d="M21 21l-6 -6"></path>
</svg>
</button>


</div>

</div>

</div>


<div class="col">
<!--MODAL-->

     <div class="d-flex justify-content-end" >
 <button @click="isOpen = true" type="button" class="btn btn-primary col-4">Yeni İzin</button>
     </div>
<Modal :open="isOpen" @close="isOpen = !isOpen">
  
</Modal>
<!--MODAL-->
</div>

</div>
<!--2.ROW-->

<!--3.ROW-->
<div class="row d-flex justify-content-center" style="margin-top:-1em">
    <div class="col-xs-11">

     <table class="table table-bordered " style="overflow:hidden;border-radius: 3px;border: 1px solid white;">
  <thead class="text-bg-primary align-text-bottom " style="font-size:14px;">
     <tr >
      <th scope="col" >Kullanıcı</th>
      <th scope="col">İzin Türü</th>
      <th scope="col">
      Kullanılan<br/>İzinli Gün<br/>Sayısı
      </th>
      <th scope="col">Kalan İzinli<br/>Gün Sayısı</th>


      <th style="text-align:center" v-on:dblclick="clickcounter += 1, OnPressVisiblity()" scope="col">

        <div  v-if="this.CurrentUser.userType=='Administrator'">       
 <div  v-if="this.visiblity">
      Durum
 </div>

 <div  v-else>
  
      Durum<br>
      <span style="font-size:12px;font-weight:bolder;color:yellow;font-style: italic;">Edit</span>
   
</div>
</div>
<div  v-else>
  
  Durum<br>


</div>
</th>






      <th scope="col">Oluşturan<br/>Kullanıcı</th>
      <th scope="col">Oluşturulma<br/>Tarihi</th>
    </tr>
  </thead>
  <tbody style="background-color:#cfdde3;">

     <tr v-for="(request, index) in visiblePages" :key="request.id">

      <td>  {{request.permissionsRequestId}}</td>
      <td>{{request.permissionId}}</td>

<!----------------------------->
<td>
<div v-if="this.issearched===1" ><!---Searched-->
  <div v-if="this.NullSearched===0"><!---SuccessSearched-->
    <tr  class="row d-flex justify-content-center"> {{visiblePages2[0].userUsedBalanceDays}} </tr>
</div>

<div v-else><!---NOTSuccessSearched-->
    <tr  class="row d-flex justify-content-center"> {{visiblePages2[index].userUsedBalanceDays}} </tr>
</div>

</div>
<div v-else><!---NotSearched-->
    <tr  class="row d-flex justify-content-center"> {{visiblePages2[index].userUsedBalanceDays}} </tr>
</div>
</td>

<td>
<div v-if="this.issearched===1" ><!---Searched-->
  <div v-if="this.NullSearched===0"><!---SuccessSearched-->
    <tr  class="row d-flex justify-content-center"> {{visiblePages2[0].userBalanceDays}} </tr>
</div>

<div v-else><!---NOTSuccessSearched-->
    <tr  class="row d-flex justify-content-center"> {{visiblePages2[index].userBalanceDays}} </tr>
</div>

</div>
<div v-else><!---NotSearched-->
    <tr  class="row d-flex justify-content-center"> {{visiblePages2[index].userBalanceDays}} </tr>
</div>
</td>
<!----------------------------->

      <!--<td>{{user.userStatus}}</td>-->

<!---------------------->
<div  v-if="this.CurrentUser.userType=='Administrator'">       
      <div v-if="this.visiblity" class="row d-flex justify-content-center">
<td>{{request.requestAdminConfirm}}</td>
</div>

 <div v-else >
<td class="row d-flex justify-content-center">

 <div class="w-auto p-0"  v-if="request.requestAdminConfirm === 'False'">
<select  class="form-select" @change="AdminConfirm(request.permissionsRequestId,$event)">
  <option selected value="False">False</option>
   <option value="True">True</option>
</select>
</div>



 <div class="w-auto p-0" v-else-if="request.requestAdminConfirm === 'True'">

<select class="form-select" @change="AdminConfirm(request.permissionsRequestId,$event)">
  <option  value="True" selected>True</option>
  <option value="False">False</option>
</select>

</div>


</td>
</div>
</div>
<div v-else >

  <div class="row d-flex justify-content-center">
<td>{{request.requestAdminConfirm}}</td>
</div>

</div>
<!---------------------->


<td>
<div v-if="this.issearched===1" ><!---Searched-->

  <div v-if="this.NullSearched===0"><!---SuccessSearched-->
  <td class="row d-flex justify-content-center" >
{{visiblePages2[0].userName}} <br>
    {{visiblePages2[0].userSurname}}
</td>
</div>

<div v-else><!---NOTSuccessSearched-->
  <td class="row d-flex justify-content-center">
{{visiblePages2[index].userName}} <br>
    {{visiblePages2[index].userSurname}}
</td>
</div>

</div>
<div v-else><!---NotSearched-->
  <td class="row d-flex justify-content-center">
{{visiblePages2[index].userName}} <br>
    {{visiblePages2[index].userSurname}}
</td>
</div>
</td>



 <td class="col-2">

  <div class="row d-flex justify-content-center">
<div class="col">
{{request.requestCreatedDate}}
</div>
 </div>

 <div class="row d-flex justify-content-center">
<div class="col">
  {{request.requestCreatedtime}}
</div>
</div>

</td>

    </tr>
    <tr>
    </tr>


  </tbody>
</table>


    </div>
  </div>
 <!--3.ROW--> 

<!--4.ROW-->
<div class="row" style="margin-top:0.5em">
    <div class="d-flex justify-content-end">

<div class="btn-group" role="group">

  <button @click="Previous"  type="button" class="btn btn-secondary" 
  style="background-color:#d0c9da;
  border-radius:8px;
  width:3em;
   height:2.2em;
  text-align:center">
<svg
style="
margin-top:-0.4em;
margin-left:-0.2em"
 color="blue" width="30" height="30" fill="currentColor" class="bi bi-arrow-left" viewBox="0 0 16 16">
  <path fill-rule="evenodd" d="M15 8a.5.5 0 0 0-.5-.5H2.707l3.147-3.146a.5.5 0 1 0-.708-.708l-4 4a.5.5 0 0 0 0 .708l4 4a.5.5 0 0 0 .708-.708L2.707 8.5H14.5A.5.5 0 0 0 15 8z"/>
</svg>
  </button>

  <button type="button" class="btn btn-secondary" 
 style="
  background-color:#d0c9da;
  border-radius:8px;
  width:3em;
  height:2.2em;">
<h6   
style="
  text-align:center;
  color:black;
  font-weight:bold;">


{{ this.startpage }}
</h6>
  </button>
  
  <button   @click="Next"  type="button" class="btn btn-secondary" 
  style="background-color:#d0c9da;
  border-radius:8px;
  border-radius:8px;
  width:3em;
  height:2.2em;
  text-align:center">
  <svg 
  style="
margin-top:-0.4em;
margin-left:-0.2em"
  color="blue" width="30" height="30" fill="currentColor" class="bi bi-arrow-right" viewBox="0 0 16 16">
  <path fill-rule="evenodd" d="M1 8a.5.5 0 0 1 .5-.5h11.793l-3.147-3.146a.5.5 0 0 1 .708-.708l4 4a.5.5 0 0 1 0 .708l-4 4a.5.5 0 0 1-.708-.708L13.293 8.5H1.5A.5.5 0 0 1 1 8z"/>
</svg>
  </button>

</div>
    </div>
     <div class="col-12" style="height:6em">
  </div>
  </div>
<!--4.ROW-->

</div> <!--Container-->


</template>


<script lang="ts">
import { ref } from "vue";
import Modal from "../components/ModalPage.vue";
import PermissionService from "@/services/PermissionService";
import User from "@/models/User";
import PermissionRequest from "@/models/PermissionRequest";
import Permission from "../models/Permission";
import { environment } from "@/environments/environment";
import AlertPage from "../components/AlertPage.vue";

export default {
  name: 'PermissionPage',

  created(){
    this.GETDataTable();
    this.UpdateUserStatus();
    this.GetCurrentUser();

    this.Perpage=JSON.parse(JSON.stringify(environment)).PaginationPerPage;
  },

      components: { 
    Modal,
    AlertPage,
     },

       setup() {
    const isOpen = ref(false);

    return { isOpen };
  },

  props: {
    msg: String
  },

  data() {
    return {
//--------------------------
showAlert:0,
requests: [] as PermissionRequest[],
tablerequests: [] as PermissionRequest[],
permissions: [] as Permission[],
User: [] as User[],
tableUser: [] as User[],
CurrentUser: [] as User[],

sec:"",
min:"",
hour:"",

    AlertType:"",
    startpage: 1,
    Perpage:0,

    clickcounter: 0,
    visiblity: true,
    search: {key:""},
    issearched:0,
    NullSearched:0,

    active: false,
    selected: null,
    }
    },
    computed: {
    visiblePages () {
      return this.requests.slice((this.startpage -1)* this.Perpage, this.startpage* this.Perpage)
    },
    visiblePages2 () {
      return this.User.slice((this.startpage - 1)* this.Perpage, this.startpage* this.Perpage)
    }
  },
  methods: {

TicksToTime(datatick:any){
/*
var startlength=String(datatick).length-4
var startmilliseconds=String(datatick).slice(0,startlength);
*/
/*
var StartHour=Math.trunc((Number(startmilliseconds)/(1000*60*60)));
var StartMin=(((Number(startmilliseconds)/(1000*60*60))-StartHour)*60);
var StartSec=(((Number(startmilliseconds)/(1000))-((StartHour*60*60)+(StartMin*60))));
*/
//1324339212260 12:47:13
//468650000000  13:01:05
/*
var date = new Date(1324339212260);
console.log(new Date('May 04, 2025'+ date));
*/


if(datatick.hours<10){
  var hour='0'+datatick.hours
}else{
  hour=datatick.hours
}

if(datatick.minutes<10){
  var minute='0'+datatick.minutes
}else{
  minute=datatick.minutes
}

if(datatick.seconds<10){
  var second='0'+datatick.seconds
}else{
  second=datatick.seconds
}

var time= hour+":"+minute+":"+second;


return(time);
},

Next(){ 
var pagelength=(((this.requests.length-Math.trunc(((this.requests.length)%environment.PaginationPerPage)))/environment.PaginationPerPage));

if(((this.requests.length)%environment.PaginationPerPage)>0){  //Artan Varsa
pagelength++; //artık page ekle
}
else{/* */}

  if(this.startpage!=pagelength){
    this.startpage++;
    }

    },

Previous(){
  if(this.startpage!=1){
    this.startpage--;
    }
    },

OnPressVisiblity() {
if(this.visiblity==false)
{
this.visiblity=true;
}
else{
this.visiblity=false;
}
},

OnPressEnter(key) {
var simplifykey = JSON.parse(JSON.stringify(key)).key;
var splitarray =simplifykey.split(" ");
var result;
this.issearched=1;
//===========TextFormatted=============
for(var j=0; j<=splitarray.length-1;j++){
if(splitarray[j]==""){
  console.log("");//satır boş olduğundan hata veriyor.
}else{
  if(result==null){
    result=splitarray[j];
}else{
  result=result+" "+splitarray[j];
}
}
}
//===========TextFormatted=============

PermissionService.getSearch(result).then(response=>{  
this.requests ="";
this.User ="";
this.requests =response.data.permissionsRequests;
this.User =response.data.users;
this.search.key=result;
result="";
this.NullSearched=0;
}).catch((e) => {
  this.NullSearched=1;
this.AlertTrigger("\""+this.search.key+"\""+ " Diye Bir Kullanıcı Bulunmadı.","General.Info");
      console.log(e);
    });

}, //OnPressEnter

AlertTrigger(message:any,Alertid:any){
this.AlertType=Alertid;
if(this.showAlert==0){
  this.showAlert=1;
  environment.alertmessage=message;
setTimeout(() => 
this.showAlert=0,
2500
);
}
},

GETDataTable() {
this.registryquantity=0;
this.currentpage=1;

//-----------------
this.issearched=0;
this.requests ="";
this.User ="";
PermissionService.getDataTable().then(response=>{  

this.requests =response.data[0].permissionsRequests;
this.User =response.data[0].users;

console.log(this.requests);

for(var i=0;i<=this.requests.length-1;i++){
//var step1 = this.TicksToTime( JSON.parse(JSON.stringify(this.requests[i].requestCreatedTime)).ticks) ;
var step1 = this.TicksToTime(JSON.parse(JSON.stringify(this.requests[i].requestCreatedTime)));
this.requests[i].requestCreatedtime=step1;

 var datasplittime =this.requests[i].requestCreatedDate.replace('-', '/').replace('-', '/').split('T');
  this.requests[i].requestCreatedDate=datasplittime[0];
}

this.tablerequests=this.requests.slice(this.startpaging,this.stoppaging);
this.tableUser=this.User.slice(this.startpaging,this.stoppaging);

}).catch((e) => {
      console.log(e);
    });
//-----------------
},

AdminConfirm(permissionsRequestId:any,event:any) {

PermissionService.putPermission(permissionsRequestId,event.target.value).then(response=>{ 
  console.log(response); 
this.GETDataTable();
}).catch((e) => {
      console.log(e);
    });

},

GetCurrentUser() {
   PermissionService.getCurrentUser().then(response=>{  
    this.CurrentUser =response.data;
    console.log(this.CurrentUser.userType);
if(this.CurrentUser.userType=="Administrator"){
    this.UpdateHoliday();
  }
    }).catch((e) => {
          console.log(e);
        });
},

UpdateHoliday() {
   PermissionService.updateholidays().then()
   .catch((e) => {
          console.log(e);
        });
},

UpdateUserStatus(){
  PermissionService.UpdateUserStatus().then(response=>{  
  console.log(response.data);
}).catch((e) => {
      console.log(e);
    });
},



},//Methods
}//export

</script>



<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}

</style>

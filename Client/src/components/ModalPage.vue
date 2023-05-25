<template>

  <transition name="fade">
     <div class="vue-modal" v-show="open">
       <transition name="drop-in">

         <div class="vue-modal-inner" v-show="open">
           <div class="vue-modal-content" >
           
       <div class="modal-header">

<svg version="1.1" id="Layer_1" 
x="0px" y="0px" width="16" height="16" fill="currentColor" class="bi bi-airplane-fill"
viewBox="0 0 16 16" enable-background="new 0 0 24 24"
xml:space="preserve">  <image id="image0" width="24" height="24" x="-4" y="-4"
    href="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABgAAAAYEAAAAACVjL5nAAAABGdBTUEAALGPC/xhBQAAACBjSFJN
AAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAAAmJLR0T//xSrMc0AAAAJcEhZ
cwAAAGAAAABgAPBrQs8AAAAHdElNRQfnAxYPJCFDmkXMAAAAEGNhTnYAAAAYAAAAGP////z////8
MOWZbQAAAVxJREFUOMtj/P+fgSTARJryoajhOcd91l+bUYT+4wFrf9mYKHZ4vfl5AiEG1/C7c3f+
w5AfdxBSy4oZGBg2MTAoSd+TwtDwY4aNo1iluEDO4lm1D/d83/n//4pAqBM22Og8Y8LQMJkdIsv4
koHB/EVQTvsHhKPX/kJ2JlTDeanmCyw92Ly9rBjVX3A/vGfdaSByml0WVfmKQPSAQAmlC7uD5flz
EMo7JDFDDi1YF2/h0mbgg2nwTv76G6eGvxJP3xye5v2DTZmBAaZF7+atPpwamqXUO0XW879iYGBT
5tKGOWzyNZwafshYHmFgYGDgf+nDvXhLsDy7LAMDo128/Fd3nH7488CSjYFB6PWhb///X9gtcpqB
gYFB7Mr93Xg8/eeB5QvV/kdz/////3+nAUsPA4NY3+5JeEPph0yz3V9ZSLw0X2BgsHH83YlXAzI4
LzWZ/ccMdFHGwVcIAACmufyM1+ShNwAAACV0RVh0ZGF0ZTpjcmVhdGUAMjAyMy0wMy0yMlQxNToz
NjozMyswMDowMG6VoeIAAAAldEVYdGRhdGU6bW9kaWZ5ADIwMjMtMDMtMjJUMTU6MzY6MzMrMDA6
MDAfyBleAAAAKHRFWHRkYXRlOnRpbWVzdGFtcAAyMDIzLTAzLTIyVDE1OjM2OjMzKzAwOjAwSN04
gQAAAABJRU5ErkJggg==" />
</svg>


         <h5 style="margin-left:-15em" class="modal-title">İzin Talep Et </h5>
         <button @click="close" type="button" class="btn-close" aria-label="Close"></button>
       </div>
  
<!--BODYSTART-->

<transition name="fade">
    <div style="margin-top: 0.3em;" v-if="this.showAlert===1">
      <AlertPage :AlertType="this.AlertType"></AlertPage>
    </div>
</transition>
 <hr style="margin-top:0.6em; width:auto;">
 
 <form style="margin-top:1em" class="row g-5 needs-validation d-flex justify-content-center" novalidate>
  <!--1.FormRow--> 
    <div class="row">
 
   <div class="col-5">
   <label style="margin-left:-0.1em;font-size:12px;font-weight: bold;" for="input" class="d-flex justify-content-start">İzin Türü</label>


 <!-----------------MALE---------------------->
<div class="dropdown" v-if="this.User.userGender === 'Male'" style=" margin-left:-0.09em;">

        <button 
        @click="(this.OnClickDropdownMenu=!this.OnClickDropdownMenu)"
        style="background-color: #f1f2f7; color:black; width: 20em;height: 2.2em; border-color: transparent;"
        class="btn btn-primary" type="button" 
        data-bs-toggle="dropdown" >  

        <span style="height: 2.2em; font-size: 12px; opacity:0.6;" class=" d-flex align-items-center col-12" v-if="SelectedOption_Name===''">

  <span class="col-7" style="padding: 1em;">
   <span class="d-flex justify-content-start"> Permissions</span>
  </span> 

  <span class="col-4" style="padding: 1em;"></span> 

  <div v-if="this.OnClickDropdownMenu===false">
<span @click="(this.OnClickDropdownMenu=!this.OnClickDropdownMenu)" class="bi bi-chevron-down" ></span>
  </div>
  <div v-else>
    <span @click="(this.OnClickDropdownMenu=!this.OnClickDropdownMenu)" class="bi bi-chevron-up" ></span>
  </div>

         </span>

         <span style="height: 2.2em; font-size: 12px; opacity:0.6;" class=" d-flex align-items-center col-12" v-else>     

  <span class="col-7" style="padding: 1em;">
   <span class="d-flex justify-content-start"> {{this.SelectedOption_Name}}</span>
  </span> 

  <span class="col-4" style="padding: 1em;">
    <span class="d-flex justify-content-end"> Kalan: {{ this.SelectedOption_Remaining }} {{ this.SelectedOption_permissionCycleType }}</span>
  </span> 

  <div v-if="this.OnClickDropdownMenu===false">
<span @click="(this.OnClickDropdownMenu=!this.OnClickDropdownMenu)" class="bi bi-chevron-up" ></span>
  </div>
  <div v-else>
    <span @click="(this.OnClickDropdownMenu=!this.OnClickDropdownMenu)" class="bi bi-chevron-down" ></span>
  </div>
    </span>
    
      </button>
<!----------------------------------------------->
<ul class="dropdown-menu">
<li @click="onChangePermission(index)"  style=" font-size: 13px; width: 23em;" class="dropdown-item" v-for="(male,index) in this.Male" :key="male.id">             
<!-------------------------------------->
<!--iusertopermission'da Onaylanmış izini varsa-->
<div class="row" v-if="(this.UserDataLength===1)">
<!---->
<div v-if="index<=this.IUserLength">
<div class="row" v-if="male.permissionId===this.IUser[index].permissionId">

  <div class="row  py-1 px-2">
    <div class="col-7">
   <span class="" style=" font-size: 13px;"> {{male.permissionName}} </span> 
    </div>
    <div class="col d-flex justify-content-start">
      <span class="col-5"  style=" font-size: 13px;">Kalan: {{ this.IUser[index].permissionBalanceQuentity  }} {{male.permissionCycleType}}</span> 
    </div>
    <div  class="col" >
      <span class="col-11 d-flex justify-content-end">
        <span data-bs-toggle="tooltip" data-bs-placement="top" title=""
        @mouseover="Tooltip(index)" :name="'info' + index" class="bi bi-exclamation-circle" style="transform: rotate(180deg);font-size: 1.2em; color: black;opacity: 80%;">
        </span>
      </span> 
    </div>
  </div>

</div>
</div>

<div v-else>

  <div v-if="(male.permissionName)==='Yıllık İzin'" class="col-12">

    <div class="row  py-1 px-2">
    <div class="col-7">
   <span class="" style=" font-size: 13px;"> {{male.permissionName}} </span> 
    </div>
    <div class="col d-flex justify-content-start">
      <span class="col-5"  style=" font-size: 13px;">Kalan: {{ this.User.userBalanceDays  }} {{male.permissionCycleType}}</span> 
    </div>
    <div  class="col" >
      <span class="col-11 d-flex justify-content-end">
        <span data-bs-toggle="tooltip" data-bs-placement="top" title=""
        @mouseover="Tooltip(index)" :name="'info' + index" class="bi bi-exclamation-circle" style="transform: rotate(180deg);font-size: 1.2em; color: black;opacity: 80%;">
        </span>
      </span> 
    </div>
  </div>

</div>

<div v-else>

  <div class="row  py-1 px-2">
    <div class="col-7">
   <span class="" style=" font-size: 13px;"> {{male.permissionName}} </span> 
    </div>
    <div class="col d-flex justify-content-start">
      <span class="col-5"  style=" font-size: 13px;">Kalan: {{ male.permissionTotalLimit  }} {{male.permissionCycleType}}</span> 
    </div>
    <div  class="col" >
      <span class="col-11 d-flex justify-content-end">
        <span data-bs-toggle="tooltip" data-bs-placement="top" title=""
        @mouseover="Tooltip(index)" :name="'info' + index" class="bi bi-exclamation-circle" style="transform: rotate(180deg);font-size: 1.2em; color: black;opacity: 80%;">
        </span>
      </span> 
    </div>
  </div>

</div>

</div>
<!----->
</div>


<!--iusertopermission'da Onaylanmış izini yoksa-->
<div class="row" v-else>
<!---->
  <div v-if="(male.permissionName)==='Yıllık İzin'" class="col-12">

    <div class="row  py-1 px-2">
    <div class="col-7">
   <span class="" style=" font-size: 13px;"> {{male.permissionName}} </span> 
    </div>
    <div class="col d-flex justify-content-start">
      <span class="col-5"  style=" font-size: 13px;">Kalan: {{ this.User.userBalanceDays  }} {{male.permissionCycleType}}</span> 
    </div>
    <div  class="col">
      <span class="col-11 d-flex justify-content-end">
        <span data-bs-toggle="tooltip" data-bs-placement="top" title=""
        @mouseover="Tooltip(index)" :name="'info' + index" class="bi bi-exclamation-circle" style="transform: rotate(180deg);font-size: 1.2em; color: black;opacity: 80%;">
        </span>
      </span> 
    </div>
  </div>

</div>
<div v-else>

  <div class="row  py-1 px-2">
    <div class="col-7">
   <span class="" style=" font-size: 13px;"> {{male.permissionName}} </span> 
    </div>
    <div class="col d-flex justify-content-start">
      <span class="col-5"  style=" font-size: 13px;">Kalan: {{ male.permissionTotalLimit  }} {{male.permissionCycleType}}</span> 
    </div>
    <div  class="col" >
      <span class="col-11 d-flex justify-content-end">
        <span id="boot-icon" class="bi bi-exclamation-circle" style="transform: rotate(180deg);font-size: 1.2em; color: black;opacity: 80%;"></span>
      </span> 
    </div>
  </div>

</div>
<!----->

</div>
<!-------------------------------------->
</li>
</ul>

</div>
 <!-----------------MALE---------------------->



 <!-----------------FEMALE---------------------->
<div class="dropdown"  v-if="this.User.userGender === 'Female'">

  <button 
        @click="(this.OnClickDropdownMenu=!this.OnClickDropdownMenu)"
        style="background-color: #f1f2f7; color:black; width: 20em;height: 2.2em; border-color: transparent;"
        class="btn btn-primary" type="button" 
        data-bs-toggle="dropdown" >  

        <span style="height: 2.2em; font-size: 12px; opacity:0.6;" class=" d-flex align-items-center col-12" v-if="SelectedOption_Name===''">

  <span class="col-7" style="padding: 1em;">
   <span class="d-flex justify-content-start"> Permissions</span>
  </span> 

  <span class="col-4" style="padding: 1em;"></span> 

  <div v-if="this.OnClickDropdownMenu===false">
<span @click="(this.OnClickDropdownMenu=!this.OnClickDropdownMenu)" class="bi bi-chevron-down" ></span>
  </div>
  <div v-else>
    <span @click="(this.OnClickDropdownMenu=!this.OnClickDropdownMenu)" class="bi bi-chevron-up" ></span>
  </div>

         </span>

         <span style="height: 2.2em; font-size: 12px; opacity:0.6;" class=" d-flex align-items-center col-12" v-else>     

  <span class="col-7" style="padding: 1em;">
   <span class="d-flex justify-content-start"> {{this.SelectedOption_Name}}</span>
  </span> 

  <span class="col-4" style="padding: 1em;">
    <span class="d-flex justify-content-end"> Kalan: {{ this.SelectedOption_Remaining }} {{ this.SelectedOption_permissionCycleType }}</span>
  </span> 

  <div v-if="this.OnClickDropdownMenu===false">
<span @click="(this.OnClickDropdownMenu=!this.OnClickDropdownMenu)" class="bi bi-chevron-up" ></span>
  </div>
  <div v-else>
    <span @click="(this.OnClickDropdownMenu=!this.OnClickDropdownMenu)" class="bi bi-chevron-down" ></span>
  </div>
    </span>

      </button>

      <ul class="dropdown-menu">
          <li @click="onChangePermission(index)"  style=" font-size: 13px; width: 23em;" class="dropdown-item" v-for="(female,index) in this.Female" :key="female.id">
<!-------------------------------------->
<!--iusertopermission'da Onaylanmış izini varsa-->
<div class="row" v-if="(this.UserDataLength===1)">
<!---->
<div v-if="index<=this.IUserLength">
<div class="row" v-if="female.permissionId===this.IUser[index].permissionId">

  <div class="row  py-1 px-2">
    <div class="col-7">
   <span class="" style=" font-size: 13px;"> {{female.permissionName}} </span> 
    </div>
    <div class="col d-flex justify-content-start">
      <span class="col-5"  style=" font-size: 13px;">Kalan: {{ this.IUser[index].permissionBalanceQuentity  }} {{female.permissionCycleType}}</span> 
    </div>
    <div  class="col" >
      <span class="col-11 d-flex justify-content-end">
        <span data-bs-toggle="tooltip" data-bs-placement="top" title=""
        @mouseover="Tooltip(index)" :name="'info' + index" class="bi bi-exclamation-circle" style="transform: rotate(180deg);font-size: 1.2em; color: black;opacity: 80%;">
        </span>
      </span> 
    </div>
  </div>

</div>
</div>

<div v-else>

  <div v-if="(female.permissionName)==='Yıllık İzin'" class="col-12">

    <div class="row  py-1 px-2">
    <div class="col-7">
   <span class="" style=" font-size: 13px;"> {{female.permissionName}} </span> 
    </div>
    <div class="col d-flex justify-content-start">
      <span class="col-5"  style=" font-size: 13px;">Kalan: {{ this.User.userBalanceDays  }} {{female.permissionCycleType}}</span> 
    </div>
    <div  class="col" >
      <span class="col-11 d-flex justify-content-end">
        <span data-bs-toggle="tooltip" data-bs-placement="top" title=""
        @mouseover="Tooltip(index)" :name="'info' + index" class="bi bi-exclamation-circle" style="transform: rotate(180deg);font-size: 1.2em; color: black;opacity: 80%;">
        </span>
      </span> 
    </div>
  </div>

</div>

<div v-else>

  <div class="row  py-1 px-2">
    <div class="col-7">
   <span class="" style=" font-size: 13px;"> {{female.permissionName}} </span> 
    </div>
    <div class="col d-flex justify-content-start">
      <span class="col-5"  style=" font-size: 13px;">Kalan: {{ female.permissionTotalLimit  }} {{female.permissionCycleType}}</span> 
    </div>
    <div  class="col" >
      <span class="col-11 d-flex justify-content-end">
        <span data-bs-toggle="tooltip" data-bs-placement="top" title=""
        @mouseover="Tooltip(index)" :name="'info' + index" class="bi bi-exclamation-circle" style="transform: rotate(180deg);font-size: 1.2em; color: black;opacity: 80%;">
        </span>
      </span> 
    </div>
  </div>

</div>

</div>
<!----->
</div>


<!--iusertopermission'da Onaylanmış izini yoksa-->
<div class="row" v-else>
<!---->
  <div v-if="(female.permissionName)==='Yıllık İzin'" class="col-12">

    <div class="row  py-1 px-2">
    <div class="col-7">
   <span class="" style=" font-size: 13px;"> {{female.permissionName}} </span> 
    </div>
    <div class="col d-flex justify-content-start">
      <span class="col-5"  style=" font-size: 13px;">Kalan: {{ this.User.userBalanceDays  }} {{female.permissionCycleType}}</span> 
    </div>
    <div  class="col">
      <span class="col-11 d-flex justify-content-end">
        <span data-bs-toggle="tooltip" data-bs-placement="top" title=""
        @mouseover="Tooltip(index)" :name="'info' + index" class="bi bi-exclamation-circle" style="transform: rotate(180deg);font-size: 1.2em; color: black;opacity: 80%;">
        </span>
      </span> 
    </div>
  </div>

</div>
<div v-else>

  <div class="row  py-1 px-2">
    <div class="col-7">
   <span class="" style=" font-size: 13px;"> {{female.permissionName}} </span> 
    </div>
    <div class="col d-flex justify-content-start">
      <span class="col-5"  style=" font-size: 13px;">Kalan: {{ female.permissionTotalLimit  }} {{female.permissionCycleType}}</span> 
    </div>
    <div  class="col" >
      <span class="col-11 d-flex justify-content-end">
        <span id="boot-icon" class="bi bi-exclamation-circle" style="transform: rotate(180deg);font-size: 1.2em; color: black;opacity: 80%;"></span>
      </span> 
    </div>
  </div>

</div>
<!----->
</div>

</li>
</ul>

</div>
 <!-----------------FEMALE---------------------->


   </div>
      <div class="col-4 ">
   
   </div>
      <div class="col-3 ">
   <label style="margin-left:0em;font-size:12px;font-weight: bold;" for="input" class="d-flex justify-content-start">Toplam</label>
     <input disabled placeholder="Gün" style="text-align:center;height:2.1em;"  v-model="this.IRequest.requestNetDays" autocomplete='IRequest.requestNetDays' type="text" class="form-control" id="validationTooltip05" required>
  
   </div>
 
  </div>
   <!--1.FormRow-->
  <!--2.FormRow--> 
 
    <div class="row" style="margin-top:1em">
 
    
     <div class="col-3">
 <div>
  <label style="margin-left:-0.15em;font-size:12px;font-weight: bold;" for="input" class="d-flex justify-content-start">Başlangıç Tarihi</label>
 <input @click="calendar" @change="onChangeDateOrTime()" v-model="this.IRequest.requestStartDate" autocomplete='IRequest.requestStartDate' style="
 height:2.1em;
 width:7em;
 margin-left:-0.4em;
 border-width:0.12em;
 border-color:#ced4da;
 border-radius:3px;
 text-align:center
 "  type="date" name="perstartdate" id="perstartdate"/>
 
 </div>
  </div>
 
 
     <div class="col-2">
 <div>
<!--
DEPRECATED
<TimePicker @click="TimepickerParams(1)"></TimePicker>
 -->

 <input @change="onChangeDateOrTime()" v-model="this.IRequest.requestStartTime" autocomplete='IRequest.requestStartTime' style="
 height:2.1em;
 width:5em;
 border-width:0.12em;
 border-color:#ced4da;
 border-radius:3px;
 margin-top:1.12em;
 margin-left:0.8em;
 text-align:center
 " type="time" name="perstarttime" id="perstarttime"/>

 </div>
  </div>
 
 
     <div  style="margin-left:0.1em" class="col-4">
 <div>
  <label style="margin-left:4.9em;font-size:12px;font-weight: bold;" for="input" class="d-flex justify-content-start">Bitiş Tarihi</label>
 
 <input @click="calendar" @change="onChangeDateOrTime()" v-model="this.IRequest.requestStopDate" autocomplete='IRequest.requestStopDate' style="
 height:2.1em;
 width:7em;
 border-width:0.12em;
 border-color:#ced4da;
 border-radius:3px;
 margin-left:3.7em;
 text-align:center
 " type="date" name="perstopdate" id="perstopdate"/>
 
 </div>
  </div>
 
     <div  style=""  class="col-1 position-relative">
 <div>
  <!--
    DEPRECATED
  <TimePicker @click="TimepickerParams(2)"></TimePicker>
 -->
 <input @change="onChangeDateOrTime()" v-model="this.IRequest.requestStopTime" autocomplete='IRequest.requestStopTime' 
 style="
 height:2.1em;
 width:5em;
 border-width:0.12em;
 border-color:#ced4da;
 border-radius:3px;
 margin-top:1.12em;
 margin-left:2.2em;
 text-align:center
 " type="time" name="perstoptime" id="perstoptime"/>
 
 </div>
 
 </div>
  </div>
 
  <!--2.FormRow--> 
  <!--3.FormRow-->
   <div class="row" style="margin-top:1em">
 
 <div class="col-md-12 position-relative">
 
 <div class="form-group">
         <label style="margin-left:0em;font-size:12px;font-weight: bold;" for="input" class="d-flex justify-content-start">
         Açıklama</label>
        <div class="col-12">  
 
<div class="row">
 <textarea @keypress="CommentArea" @change="CommentArea" v-model="this.IRequest.requestComment" autocomplete='IRequest.requestComment'
 name="user-message" id="Textarea"  rows="4" class="form-control" placeholder="Mesaj Ekleyin"></textarea>
</div>

<transition name="fade">
    <div style="margin-top: 0.3em;" v-if="this.CommentLengthCounter>0">
      <div class="row">
        <span style="margin-top:0.4em;color: green;font-size: 14px;" class="col-11 d-flex justify-content-start">{{ this.CommentLengthCounter }} / 1000 karakter kaldı</span>
      </div>
    </div>
</transition>


  </div><!--end col 12-->
 
      </div>
  </div>
 
   </div>
  <!--3.FormRow-->
  <!--4.FormRow-->
 <div class="row" style="margin-top:1em" >
 
   </div>
 
    <div class="row">
     <div class="col" style="margin-left:-0.25em;">
   <label style="margin-left:0.3em;font-size:12px;font-weight: bold;" for="input" class="d-flex justify-content-start">Dönüş Tarihi</label>
 
 <div >



  <!--DEPRECATED
    <input v-model="this.IRequest.requestPartnerStopDate" autocomplete='IRequest.requestPartnerStopDate' -->
 <input disabled  v-model="this.IRequest.requestReturnStopDate" autocomplete='this.IRequest.requestReturnStopDate' 
 style="border-width:0.12em;
 border-color:#ced4da;
 border-radius:3px;
 height:2.1em;
 width:7em;
 margin-left:-3.5em;
 text-align:center"  type="date" name="perreturndate" id="perreturndate"/>
 
 </div>
  </div>
 
     <div class="col">
 <div>
 <!--DEPRECATED
  <TimePicker @click="TimepickerParams('3')"></TimePicker>
  -->
 <!--DEPRECATED
  <input  v-model="this.IRequest.requestPartnerStopTime" autocomplete='IRequest.requestPartnerStopTime' 
-->

 <input disabled v-model="this.IRequest.requestReturnStopTime" autocomplete='this.IRequest.requestReturnStopTime' 
 style="
 border-width:0.12em;
 border-color:#ced4da;
 border-radius:3px;
 height:2.1em;
 width:5em;
 margin-left:-11.3em;
 margin-top:1.12em;
text-align: center;"
placeholder="--:--" name="perreturntime" id="perreturntime" />
<!--type="time" Clock iconundan dolayı ortalanmıyor.-->
<!--Shadow için style="image.png..."-->
 </div>
 
  </div>
 
 
 
      <div class="col-3 ">
   <label style="margin-left:0em;font-size:12px;font-weight: bold;" for="input" class="d-flex justify-content-start">Kalan Gün Sayısı</label>
   <input disabled placeholder="Gün" style="text-align:center;height:2.1em;" type="text" class="form-control" id="validationTooltip05" v-model="this.User.userBalanceDays" required>
   </div>
  </div><!--ROW-->
  <!--4.FormRow-->
  <!--5.FormRow-->
  <div class="row g-1" style="margin-top:1.8em">
 
 </div>
  <!--5.FormRow-->
 
 </form>    
           <!--BODYSTOP-->
 
  <!--6.Row-->
          <div class="row" style="margin-top:0.5em;">
   <div class="col-12">
    <div class="span8 btn-block">
     <hr style=" width:auto;">
 </div>
   </div>
   </div>
  <!--6.Row-->
   <!--7.Row-->
          <div class="row g-1" style="margin-top:1em;">
 
   <div class="col">
 
     <button class="btn btn-large btn-block btn-secondary w-100" style="height:2.1em;" @click="close"  type="button">İptal</button>
 
   </div>
 
   <div  style="width:1em">
 
   </div>
   
   <div class="col">
 
     <button class="btn btn-primary w-100" style="height:2.1em;" @click="AddPermission()"  type="submit">Talep Gönder</button>
   </div>
 
   </div>
     <!--7.Row-->
       </div> <!--Content-->
         </div>
       </transition>
     </div>
   </transition>
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
import { environment } from "@/environments/environment";
import IUsersToPermission from "@/models/IuserToPermission";
//import TimePicker from "../components/TimePicker.vue";
import AlertPage from "../components/AlertPage.vue";


export default defineComponent({
  name: "ModalPage",

    created(){
    this.GetCurrentUser(); //Trigger(GetUserCompany  GetRemainingPermissions)
    this.GetPermisions();
  },
components: {
//TimePicker,
AlertPage,
 },
  props: {
    open: {
      type: Boolean,
      required: true,
    },
  },
    data() {
   
    return {
      IUserLength:0,
      yıllıkindisi:0,
      AlertType:"",
      showAlert:0,
      date:"",
      DateChangeCounter: 0,
      selectedOrders: [],
      orderCount: 1,
      currentIndex: -1,
      active: false,
      selected: null,
      permissionCounter: 0, 
      UserDataLength:0,
      CommentLengthCounter:0,
      OnClickDropdownMenu:false,

      SelectedOption_Name:"",
      SelectedOption_Remaining:"",
      SelectedOption_permissionCycleType:"",
      
      IUser: {} as IUsersToPermission[],
      Request: {} as PermissionRequest,
      IRequest: {} as IPermissionRequest[],
      User: [] as User[],
      Permission: [] as Permission[],
      Company: {} as Company,
      Male:  [] as Permission[],
      Female:  [] as Permission[],
      
      companyinfo: {
        WStartHour: 0,
        WStartMin: 0,

        WStopHour: 0,
        WStopMin: 0,

        LStartHour: 0,
        LStartMin: 0,

        LStopHour: 0,
        LStopMin: 0,
            },

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


CommentArea(){
  if(this.IRequest.requestComment!=null){
    this.CommentLengthCounter=this.IRequest.requestComment.length;
  }else {
   this.CommentLengthCounter=0;
  }
},

Tooltip(id:any){
  let fullid="info"+id;

  if(this.User.userGender=="Male"){

    if(this.Male[id].permissionName=="Yıllık İzin"){
      document.getElementsByName(fullid)[0].setAttribute('title', 'Total İzin: '+ this.User.userTotalBalanceDays);
    }else{
      document.getElementsByName(fullid)[0].setAttribute('title', 'Total İzin: '+ this.Male[id].permissionTotalLimit);
    }
  
  }else{

    if(this.Male[id].permissionName=="Yıllık İzin"){
      document.getElementsByName(fullid)[0].setAttribute('title', 'Total İzin: '+ this.User.userTotalBalanceDays);
    }else{
      document.getElementsByName(fullid)[0].setAttribute('title', 'Total İzin: '+ this.Female[id].permissionTotalLimit);
    }

  }
},

onChangeDateOrTime()
{     
if(this.IRequest.requestStartDate!=null && this.IRequest.requestStopDate!=null&&this.IRequest.requestStartTime!=null && this.IRequest.requestStopTime!=null)
{
if(this.IRequest.requestStartDate==this.IRequest.requestStopDate&&this.IRequest.requestStopTime<this.IRequest.requestStartTime)
{
  this.AlertTrigger("Einstein'ın Külleri Ters Döndü!","Modal.Danger");
}
}

var CompanyWStart = new Date("01/01/2007 " + (this.companyinfo.WStartHour+":"+this.companyinfo.WStartMin)).getTime();
var CompanyWStop = new Date("01/01/2007 " + (this.companyinfo.WStopHour+":"+this.companyinfo.WStopMin)).getTime();
var CompanyLStart = new Date("01/01/2007 " + (this.companyinfo.LStartHour+":"+this.companyinfo.LStartMin)).getTime();
var CompanyLStop = new Date("01/01/2007 " + (this.companyinfo.LStopHour+":"+this.companyinfo.LStopMin)).getTime();


if(this.IRequest.requestStartTime!=null && this.IRequest.requestStopTime!=null){

var starttime=this.IRequest.requestStartTime.split(':');
var SelectedStartTime = new Date("01/01/2007 " + (starttime[0]+":"+starttime[1])).getTime();

if( (SelectedStartTime-CompanyWStart)>=0 &&(SelectedStartTime-CompanyWStop)<0)
  {
    if((SelectedStartTime-CompanyLStart)<0||(SelectedStartTime-CompanyLStop)>=0)
  {
  //mesaide ve yemek saatleriyle çakışmıyor.
  this.CalcNetDays();
  }else{
   this.AlertTrigger("İzin Başlangıcı Yemek Saatleri İle Çakışamaz.","Modal.Info");
  }
  //mesaide.
  }else{
   this.AlertTrigger("İzin Başlangıcı Mesai Saatleri İçerisinde Olmalı.","Modal.Info");
  }

}

},

CalcNetDays(){
  if(this.IRequest.requestStartDate!=null && this.IRequest.requestStopDate!=null&&this.IRequest.requestStartTime!=null && this.IRequest.requestStopTime!=null)
{
  var datestart=this.IRequest.requestStartDate;
  var datestop=this.IRequest.requestStopDate;
  var userid = environment.currentuserid;

  var timestart =JSON.parse(JSON.stringify(this.TimeToSpan(this.IRequest.requestStartTime))).ticks;
  var timestop =JSON.parse(JSON.stringify(this.TimeToSpan(this.IRequest.requestStopTime))).ticks;

ModalService.CalcNetDay(datestart,datestop,userid,timestart,timestop).then(response=>{
var resultdays =(response.data).split(",");

this.IRequest.requestBrutDays=resultdays[0];
this.IRequest.requestNetDays=resultdays[1];
var splited = resultdays[2].split('.');
this.IRequest.requestReturnStopDate=splited[0]+"/"+splited[1]+"/"+splited[2];
this.IRequest.requestReturnStopTime=resultdays[3];

var SelectedReturnTime = new Date(this.IRequest.requestReturnStopDate +" 12:00");
this.IRequest.requestReturnStopDate=SelectedReturnTime.toISOString().substring(0, 10);
        }).catch((e) => {
         this.AlertTrigger("Dönüş Tarihiniz Hesaplanamadı, Lütfen Tekrar Deneyin.","Modal.Danger");
              console.log(e);
            });
}
},

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
   
calendar(){
var today = new Date().toISOString().split('T')[0];
document.getElementsByName("perstartdate")[0].setAttribute('min', today);
document.getElementsByName("perstopdate")[0].setAttribute('min', this.IRequest.requestStartDate);
document.getElementsByName("perreturndate")[0].setAttribute('min', this.IRequest.requestStopDate); 
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
      this.GetRemainingPermissions();
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

this.SelectedOption_Name="";
this.SelectedOption_Remaining="";
this.SelectedOption_permissionCycleType="";
this.IRequest.permissionId="";

this.IRequest.permissionId=permissionid+1; //db de veriler 1 den başlıyor.

if(this.User.userGender=="Male"){
  this.SelectedOption_Name=this.Male[permissionid].permissionName;

  for(var o =0; o<=this.Male.length-1;o++)
{
  if(this.Male[o].permissionName=="Yıllık İzin"){
    this.SelectedOption_permissionCycleType=this.Male[o].permissionCycleType;
  }
}

  if(this.SelectedOption_Name=="Yıllık İzin"){
// Yıllık İzinse
this.SelectedOption_Remaining=this.User.userBalanceDays
  }

else{
// iusertopermission tablosunda onaylanmışsa
  for(var j =0; j<= this.IUserLength;j++){
  if(this.IUser[j].permissionId==this.Male[permissionid].permissionId){
this.SelectedOption_Remaining=JSON.parse(JSON.stringify(this.IUser[j])).permissionBalanceQuentity;
  }
}

if(this.SelectedOption_Remaining==""){
// Yıllık izin değilse ve iusertopermission tablosunda yoksa

  for(var k =0; k<= this.Male.length-1;k++){
  if(this.Male[k].permissionName==this.SelectedOption_Name){
this.SelectedOption_Remaining=this.Male[k].permissionTotalLimit;
  }
}

}
}
}

if(this.User.userGender=="Female"){
  this.SelectedOption_Name=this.Female[permissionid].permissionName;

  for(var p =0; p<=this.Female.length-1;p++)
{
  if(this.Female[p].permissionName=="Yıllık İzin"){
    this.SelectedOption_permissionCycleType=this.Female[p].permissionCycleType;
  }
}

  if(this.SelectedOption_Name=="Yıllık İzin"){
// Yıllık İzinse
this.SelectedOption_Remaining=this.User.userBalanceDays;
  }
else{
// iusertopermission tablosunda onaylanmışsa
  for(var m =0; m<= this.IUserLength;m++){
  if(this.IUser[m].permissionId==this.Female[permissionid].permissionId){
this.SelectedOption_Remaining=JSON.parse(JSON.stringify(this.IUser[m])).permissionBalanceQuentity;
  }
}


if(this.SelectedOption_Remaining==""){
// Yıllık izin değilse ve iusertopermission tablosunda yoksa
  for(var n =0; n<=this.Female.length-1;n++){
  if(this.Female[n].permissionName==this.SelectedOption_Name){
this.SelectedOption_Remaining=this.Female[n].permissionTotalLimit;
  }
}
}

}
}

},


AddPermission() 
{
   if(this.IRequest.requestNetDays!=null&&this.User.userBalanceDays!=null&&this.User.userBalanceDays>this.IRequest.requestNetDays){

    this.IRequest.requestReturnStopTime=this.IRequest.requestReturnStopTime.substring(0,5);
  

    this.IRequest.Create=JSON.parse(JSON.stringify(this.TimeToSpan(this.IRequest.requestStartTime))).ticks;
    this.IRequest.requestStartTime=JSON.parse(JSON.stringify(this.TimeToSpan(this.IRequest.requestStartTime))).ticks;
    this.IRequest.requestStopTime=JSON.parse(JSON.stringify(this.TimeToSpan(this.IRequest.requestStopTime))).ticks;
    this.IRequest.requestReturnStopTime=JSON.parse(JSON.stringify(this.TimeToSpan(this.IRequest.requestReturnStopTime))).ticks;
    //this.IRequest.requestPartnerStopTime=JSON.parse(JSON.stringify(this.TimeToSpan(this.IRequest.requestPartnerStopTime))).ticks;
    this.IRequest.requestCreatedByUserId=environment.currentuserid;  
    this.IRequest.requestAdminConfirm="False";

          ModalService.AddPermission(this.IRequest).then(response=>{
            this.requests =response.data;
            this.AlertTrigger("İşlem Başarılı","Modal.Success");
        }).catch((e) => {
              console.log(e);
            });

}else {
   this.AlertTrigger("Alacağınız İzin"+"("+this.IRequest.requestNetDays+")," + " Bakiyenizden("+this.User.userBalanceDays+")"+ " Daha Fazla Olamaz.","Modal.Info");
}

},

GetRemainingPermissions(){
  ModalService.GetRemainingPermissions().then(response=>{ 
    this.IUser =JSON.parse(JSON.stringify(response.data))
    this.IUserLength=this.IUser.length-1;
    if(this.IUser.length==null){
    this.UserDataLength=0;
    }else{
      this.UserDataLength=1;
    }

    }).catch((e) => {
          console.log(e);
        });
},

  }, //Methods

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
/*-------------- */

.dropdown-menu {
    max-height: 280px;
    overflow-y: auto;
}
/*-------------- */

</style>
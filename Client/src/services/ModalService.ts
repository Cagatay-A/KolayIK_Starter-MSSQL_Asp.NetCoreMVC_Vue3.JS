import { environment } from "@/environments/environment";
import http from "@/http-common";
import IPermissionRequest from "@/models/PermissionRequest";
import User from "@/models/User";
import Permission from "@/models/Permission";
import Company from "@/models/Company";

class ModalService{
 
    getCurrentUser(): Promise<any> {
     return http.get<User[]>(environment.apiUrl+'User/userid?id='+environment.currentuserid); 
    }

    GetUserCompany(companyid:any): Promise<any> {
      return http.get<Company[]>(environment.apiUrl+'User/companyid?id='+companyid); 
    }
    
     GetMalePermision(): Promise<any> {
      return http.get<Permission[]>(environment.apiUrl+"User/getmalepermissions");
    }
    
    GetFemalePermision(): Promise<any> {
      return http.get<Permission[]>(environment.apiUrl+"User/getfemalepermissions");
    }

    CalcNetDay(datestart: any, datestop: any, userid:any,  timestart:any,timestop:any, ): Promise<any> {
    return http.get(environment.apiUrl+'User/calcnetday?userid='+userid+"&datestart="+datestart+"&datestop="+datestop+"&timestart="+timestart+"&timestop="+timestop); 
    }

    AddPermission(request:IPermissionRequest): Promise<any> {
          return http.post(environment.apiUrl+'User/add',request);
    }
    
    GetRemainingPermissions(): Promise<any> {
      return http.get(environment.apiUrl+'User/iuserremainingpermissions?userid='+environment.currentuserid); 
    }


  }
  export default new ModalService();
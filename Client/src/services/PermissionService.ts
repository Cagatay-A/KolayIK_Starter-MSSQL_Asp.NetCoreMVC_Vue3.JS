import { environment } from "@/environments/environment";
import http from "@/http-common";
import DataTable from "@/models/DataTable";
import User from "@/models/User";


class PermissionService{

getCurrentUser(): Promise<any> {
return http.get<User[]>(environment.apiUrl+'User/userid?id='+environment.currentuserid); 
}

getSearch(key:any): Promise<any> {
return http.get<any[]>(environment.apiUrl+'User/search?searchkey='+key); 
}

getDataTable(): Promise<any> {
return http.get<DataTable[]>(environment.apiUrl+'User/getdatatable');
}
    
putPermission(id: any, key: any): Promise<any> {
const adminid= environment.currentuserid; //Onaylama css i sadece admine açık olduğundan current user admin oluyor.
return http.put(environment.apiUrl+'User/requestid?requestid='+id+"&key="+key+"&adminid="+adminid); 
}

UpdateUserStatus(): Promise<any> {
return http.put<any[]>(environment.apiUrl+'User/updateuserstatus?userid='+environment.currentuserid); 
}

updateholidays(): Promise<any> {
return http.put<any[]>(environment.apiUrl+'User/updateholidays'); 
}

}

  export default new PermissionService();
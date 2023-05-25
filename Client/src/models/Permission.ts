export default interface Permission{
    permissionId:number;
    permissionGender:string;
    permissionName:string;
    permissionCycleType:string;
    permissionOnceLimit:number;
    permissionTotalLimit:number;
    permissionCreatedByUserId:number;
    permissionCreatedDate:Date; //DateTime in backend
    permissionUpdateByUserId?:number;
    permissionUpdateDate?:Date; //DateTime in backend
}
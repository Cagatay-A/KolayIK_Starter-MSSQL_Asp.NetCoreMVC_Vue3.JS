export default interface IUsersToPermission{
    iUsersToPermissionId:number;
    permissionId:number;
    approvedBalanceQuentity:number;//double in backend
    permissionBalanceQuentity:number;//double in backend
    createdByUserId:number;
    createdDate:Date;
    updateByUserId?:number;
    updateDate?:Date;
}
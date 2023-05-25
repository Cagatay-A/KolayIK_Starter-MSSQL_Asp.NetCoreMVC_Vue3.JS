export default interface PermissionRequest{
    permissionsRequestId:number;
    //requestPartnerUserId?:number; //deprecated
    requestAdminConfirm:string;
    requestStartDate:Date;
    requestStartTime:number;//TimeSpan in Backend
    requestStopDate:Date;
    requestStopTime:number;//TimeSpan in Backend
    permissionId:number;
    requestBrutDays:number;
    requestNetDays:number;//double in Backend
    requestComment?:string;
    //requestPartnerStopDate:Date;//deprecated
    //requestPartnerStopTime:number;//deprecated
    //requestPartnerConfirm?:string;//deprecated
    requestReturnStopDate:Date;
    requestReturnStopTime:number;//TimeSpan in Backend
    requestCreatedByUserId:number;
    requestCreatedDate:Date;
    requestCreatedTime:number;//TimeSpan in Backend
    requestUpdateByUserId?:number;
    requestUpdateDate?:Date;
}

export default interface IPermissionRequest{
    permissionsRequestId:number;
    //requestPartnerUserId?:number;//deprecated
    requestAdminConfirm:string;
    requestStartDate:Date;
    requestStartTime:number;//string in Backend
    requestStopDate:Date;
    requestStopTime:number;//string in Backend
    permissionId:number;
    requestBrutDays:number;
    requestNetDays:number;//double in Backend
    requestComment?:string;
    //requestPartnerStopDate:Date;//deprecated
    //requestPartnerStopTime:number;//deprecated
    //requestPartnerConfirm?:string;//deprecated
    requestReturnStopDate:Date;
    requestReturnStopTime:number;//string in Backend
    requestCreatedByUserId:number;
    requestCreatedDate:Date;
    requestUpdateByUserId?:number;
    requestUpdateDate?:Date;
}
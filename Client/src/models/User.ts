export default interface User{
    userId:number;
    userType:string;
    userRegistryDate:Date;
    userResignationDate?:Date;
    userName:string;
    userSurname:string;
    userPassword:number;//char in backend
    userCompanyId:number;
    userGender:string;
    userProfession:string;
    userProfessionType:string;
    userWorkingType?:string;
    userStatus:string;
    //userPartnerStatus:string; //deprecated
    userTotalBalanceDays:number;
    userUsedBalanceDays:number;//double in backend
    userBalanceDays:number;//double in backend
    userCreatedByUserId:number;
    userCreatedDate:Date;
    userUpdateByUserId?:number;
    userUpdateDate?:Date;
}
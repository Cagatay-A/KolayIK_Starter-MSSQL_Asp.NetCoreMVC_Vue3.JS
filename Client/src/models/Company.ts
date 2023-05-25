export default interface Company{
    CompanyId:number;
    CompanyName:string;
    CompanyStartWorkingTime:number;
    CompanyStopWorkingTime:number;
    CompanyStartLunchTime:number;
    CompanyStopLunchTime:number;
    CompanyCreatedByUserId:number;
    CompanyCreatedDate:Date;
    CompanyUpdateByUserId?:number;
    CompanyUpdateDate?:Date;
}
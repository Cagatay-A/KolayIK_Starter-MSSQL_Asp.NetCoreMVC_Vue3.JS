export default interface Holiday{
    holidayId:number;
    holidayName:string;
    holidayReferDate:Date;
    holidayStartDate:Date;
    holidayTailDays:number;
    holidayStopDate:Date;
    holidayNetDays:number;//dobule in backend
    holidayCategory:string;
}
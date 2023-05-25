using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolayIK.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Newtonsoft.Json;

namespace KolayIK.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("getdatatable")]
        public IEnumerable<DataTable> GetDataTable()
        {
            var request = _context.PermissionsRequests.ToList();
            User[] users = new User[request.Count];
            PermissionsRequest[] requests = new PermissionsRequest[request.Count];
            requests = _context.PermissionsRequests.ToList().ToArray();

            for (int i = 0; i < request.Count; i++)
            {
                int id = request[i].RequestCreatedByUserId;
                var user = _context.Users.FirstOrDefaultAsync(i => i.UserId == id);

                User data = new User
                {
                    UserBalanceDays = user.Result.UserBalanceDays,
                    UserCompanyId = user.Result.UserCompanyId,
                    UserCreatedByUserId = user.Result.UserCreatedByUserId,
                    UserGender = user.Result.UserGender,
                    UserId = user.Result.UserId,
                    UserName = user.Result.UserName,
                    UserPassword = user.Result.UserPassword,
                    UserProfession = user.Result.UserProfession,//
                    UserProfessionType = user.Result.UserProfessionType,
                    UserRegistryDate = user.Result.UserRegistryDate,
                    UserResignationDate = user.Result.UserResignationDate,
                    UserStatus = user.Result.UserStatus,
                    UserSurname = user.Result.UserSurname,
                    UserTotalBalanceDays = user.Result.UserTotalBalanceDays,
                    UserType = user.Result.UserType,
                    UserUpdateByUserId = user.Result.UserUpdateByUserId,
                    UserUpdateDate = user.Result.UserUpdateDate,
                    UserUsedBalanceDays = user.Result.UserUsedBalanceDays,
                    UserWorkingType = user.Result.UserWorkingType,
                };
                users[i] = data;
            }

            DataTable result = new DataTable
            {
                Users = users,
                PermissionsRequests = requests,
            };
            yield return result;
        }

        [HttpGet("userid")]
        public async Task<ActionResult<User>> GetProfile(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(i => i.UserId == id);

            return new User
            {
                UserBalanceDays = user.UserBalanceDays,
                UserCompanyId = user.UserCompanyId,
                UserCreatedByUserId = user.UserCreatedByUserId,
                UserCreatedDate = user.UserCreatedDate,
                UserGender = user.UserGender,
                UserId = user.UserId,
                UserName = user.UserName,
                UserPassword = user.UserPassword,
                UserProfession = user.UserProfession,
                UserProfessionType = user.UserProfessionType,
                UserRegistryDate = user.UserRegistryDate,
                UserResignationDate = user.UserResignationDate,
                UserStatus = user.UserStatus,
                UserSurname = user.UserSurname,
                UserTotalBalanceDays = user.UserTotalBalanceDays,
                UserType = user.UserType,
                UserUpdateByUserId = user.UserUpdateByUserId,
                UserUpdateDate = user.UserUpdateDate,
                UserUsedBalanceDays = user.UserUsedBalanceDays,
                UserWorkingType = user.UserWorkingType,
            };
        }

        [HttpGet("companyid")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(i => i.CompanyId == id);

            return new Company
            {
                CompanyCreatedByUserId = company.CompanyCreatedByUserId,
                CompanyCreatedDate = company.CompanyCreatedDate,
                CompanyId = company.CompanyId,
                CompanyName = company.CompanyName,
                CompanyStartLunchTime = company.CompanyStartLunchTime,
                CompanyStartWorkingTime = company.CompanyStartWorkingTime,
                CompanyStopLunchTime = company.CompanyStopLunchTime,
                CompanyStopWorkingTime = company.CompanyStopWorkingTime,
                CompanyUpdateByUserId = company.CompanyUpdateByUserId,
                CompanyUpdateDate = company.CompanyUpdateDate,
            };

        }

        public class ControlResponse //Metotların doğru çalışıp çalışmadığını görmek için kısa yol..
        {
            public string UserStatus { get; set; }
            public double UserUsedBalanceDays { get; set; }
            public double UserBalanceDays { get; set; }
            public double ApprovedBalanceQuentity { get; set; }
            public double PermissionBalanceQuentity { get; set; }
            public string RequestAdminConfirm { get; set; }
        }

        [HttpGet("Control")]
        public async Task<ActionResult<ControlResponse>> GetControlProfile(int Requestid)
        {//Userid=8, Permissionid=1, Requestid=19

            var User = _context.Users.Where(i => i.UserId == 8).ToList();
            var Iuser = _context.IUsersToPermissions.Where(i => i.CreatedByUserId == 8 && i.PermissionId == 1).ToList();
            var Request = _context.PermissionsRequests.Where(i => i.PermissionsRequestId == Requestid).ToList();

            return new ControlResponse
            {
                UserStatus = User[0].UserStatus,
                UserUsedBalanceDays = User[0].UserUsedBalanceDays,
                UserBalanceDays = User[0].UserBalanceDays,
                ApprovedBalanceQuentity = Iuser[0].ApprovedBalanceQuentity,
                PermissionBalanceQuentity = Iuser[0].PermissionBalanceQuentity,
                RequestAdminConfirm = Request[0].RequestAdminConfirm,
            };
        }

        [HttpGet("iuserremainingpermissions")]
        public async Task<ActionResult<IUsersToPermission[]>> GetRemainingPermissions(int userid)
        {
            var iuser = _context.IUsersToPermissions.Where(i => i.CreatedByUserId == userid).ToList();

            if (iuser == null)
            {
                return null;
            }
            else
            {
                IUsersToPermission[] iusers = iuser.ToArray();

                return iusers;
            }
        }

        [HttpPost("add")]
        public async Task<ActionResult<IPermissionsRequest>> Add(IPermissionsRequest request)
        {
            var UserData = _context.IUsersToPermissions.Where(i => i.CreatedByUserId == request.RequestCreatedByUserId && i.PermissionId == request.PermissionId).ToList();

            long startticks = (long)Convert.ToDouble(request.RequestStartTime);
            TimeSpan StartTimeSpan = new TimeSpan(startticks);

            long stopticks = (long)Convert.ToDouble(request.RequestStopTime);
            TimeSpan StopTimeSpan = new TimeSpan(stopticks);

            long pstopticks = (long)Convert.ToDouble(request.RequestReturnStopTime);
            TimeSpan ReturnStopTimeSpan = new TimeSpan(pstopticks);

            DateTime currentDateTime = DateTime.Now;
            TimeSpan currentTime = TimeSpan.Parse(currentDateTime.ToString("T"));

            PermissionsRequest RequestTable = new PermissionsRequest
            {
                PermissionsRequestId = request.PermissionsRequestId,
                RequestCreatedByUserId = request.RequestCreatedByUserId,
                RequestCreatedDate = currentDateTime,
                RequestCreatedTime = currentTime,
                //RequestPartnerUserId = request.RequestPartnerUserId,
                RequestAdminConfirm = request.RequestAdminConfirm,
                RequestStartDate = request.RequestStartDate,
                RequestStartTime = StartTimeSpan,
                RequestStopDate = request.RequestStopDate,
                RequestStopTime = StopTimeSpan,
                PermissionId = request.PermissionId,
                RequestBrutDays = request.RequestBrutDays,
                RequestNetDays = request.RequestNetDays,
                RequestComment = request.RequestComment,
                //RequestPartnerStopDate = request.RequestPartnerStopDate,
                //RequestPartnerStopTime = PStopTimeSpan,
                //RequestPartnerConfirm = request.RequestPartnerConfirm,
                RequestReturnStopDate = request.RequestReturnStopDate,
                RequestReturnStopTime = ReturnStopTimeSpan,
                RequestUpdateByUserId = request.RequestUpdateByUserId,
                RequestUpdateDate = request.RequestUpdateDate,
            };

            _context.PermissionsRequests.Add(RequestTable);
            _context.SaveChanges();

            return Ok(_context.PermissionsRequests.ToList());
        }

        [HttpPut("requestid")]
        public async Task<ActionResult<User>> AdminConfirm(int requestid, string key, int adminid)
        {

            if (key == "True")
            {

                var data = await _context.PermissionsRequests.FirstOrDefaultAsync(i => i.PermissionsRequestId == requestid);
                data.RequestAdminConfirm = key;
                _context.PermissionsRequests.Update(data);
                _context.SaveChanges();


                //-----AdminConfirmToIUserToPermissions-------
                AdminConfirmToIUserToPermissions(data, adminid);
                //-----AdminConfirmToIUserToPermissions-------


                //-----AdminConfirmToUser-------
                var user = await _context.Users.FirstOrDefaultAsync(i => i.UserId == data.RequestCreatedByUserId);
                var request = await _context.PermissionsRequests.FirstOrDefaultAsync(i => i.PermissionsRequestId == requestid);

                user.UserUsedBalanceDays = (user.UserUsedBalanceDays + request.RequestNetDays);
                double TotalDays = Convert.ToDouble(user.UserTotalBalanceDays);
                user.UserBalanceDays = (TotalDays - user.UserUsedBalanceDays);
                /*user.UserUsedBalanceDays = (user.UserUsedBalanceDays + request.RequestNetDays);
                user.UserBalanceDays = (user.UserTotalBalanceDays - request.RequestNetDays);*/
                user.UserStatus = "Holiday";

                _context.Users.Update(user);
                _context.SaveChanges();
                //-----AdminConfirmToUser-------
            }
            else
            {
                var data = await _context.PermissionsRequests.FirstOrDefaultAsync(i => i.PermissionsRequestId == requestid);
                data.RequestAdminConfirm = "False";
                _context.PermissionsRequests.Update(data);
                _context.SaveChanges();

                //-----AdminConfirmToIUserToPermissions-------
                AdminConfirmToIUserToPermissions(data, adminid);
                //-----AdminConfirmToIUserToPermissions-------

                //-----AdminConfirmToUser-------
                var user = await _context.Users.FirstOrDefaultAsync(i => i.UserId == data.RequestCreatedByUserId);
                var request = await _context.PermissionsRequests.FirstOrDefaultAsync(i => i.PermissionsRequestId == requestid);

                user.UserUsedBalanceDays = (user.UserUsedBalanceDays - request.RequestNetDays);
                double TotalDays = Convert.ToDouble(user.UserTotalBalanceDays);
                user.UserBalanceDays = (TotalDays - user.UserUsedBalanceDays);
                /*user.UserUsedBalanceDays = (user.UserUsedBalanceDays + request.RequestNetDays);
                user.UserBalanceDays = (user.UserTotalBalanceDays - request.RequestNetDays);*/
                user.UserStatus = "Working";

                _context.Users.Update(user);
                _context.SaveChanges();
                //-----AdminConfirmToUser-------
            }

            return Ok();

        }

        [HttpPost("confirmtoiusertopermissions")]
        public async Task<ActionResult<IUsersToPermission>> AdminConfirmToIUserToPermissions(PermissionsRequest perreqdata, int adminid)
        {
            if (perreqdata.RequestAdminConfirm == "True")
            {
                //---------
                var UserData = _context.IUsersToPermissions.Where(i => i.CreatedByUserId == perreqdata.RequestCreatedByUserId && i.PermissionId == perreqdata.PermissionId).ToList();
                var datalength = UserData.Count;
                var TotalLimit = _context.Permissions.Where(i => i.PermissionId == perreqdata.PermissionId).ToList();

                if (datalength == 0)
                {
                    IUsersToPermission addeddata1 = new IUsersToPermission
                    {
                        PermissionId = perreqdata.PermissionId,
                        ApprovedBalanceQuentity = perreqdata.RequestNetDays,
                        PermissionBalanceQuentity = Convert.ToDouble(TotalLimit[0].PermissionTotalLimit) - perreqdata.RequestNetDays,
                        CreatedByUserId = perreqdata.RequestCreatedByUserId,
                        CreatedDate = DateTime.Now.Date,
                        //UpdateByUserId = UserData[x].IUsersToPermissionId,
                        //UpdateDate = DateTime.Now.Date,
                    };
                    _context.IUsersToPermissions.Add(addeddata1);
                }
                else
                {
                    IUsersToPermission addeddata2 = new IUsersToPermission
                    {
                        IUsersToPermissionId = UserData[0].IUsersToPermissionId,
                        PermissionId = UserData[0].PermissionId,
                        ApprovedBalanceQuentity = UserData[0].ApprovedBalanceQuentity + perreqdata.RequestNetDays,
                        PermissionBalanceQuentity = Convert.ToDouble(TotalLimit[0].PermissionTotalLimit) - (UserData[0].ApprovedBalanceQuentity + perreqdata.RequestNetDays),
                        CreatedByUserId = UserData[0].CreatedByUserId,
                        CreatedDate = UserData[0].CreatedDate,
                        UpdateByUserId = adminid,
                        UpdateDate = DateTime.Now.Date,
                    };
                    _context.IUsersToPermissions.Update(addeddata2);
                }
                _context.SaveChanges();
                //---------
            }
            else
            {
                //---------
                var UserData = _context.IUsersToPermissions.Where(i => i.CreatedByUserId == perreqdata.RequestCreatedByUserId && i.PermissionId == perreqdata.PermissionId).ToList();
                var datalength = UserData.Count;
                var TotalLimit = _context.Permissions.Where(i => i.PermissionId == perreqdata.PermissionId).ToList();

                if (datalength == 0)
                {

                }
                else
                {
                    IUsersToPermission addeddata3 = new IUsersToPermission
                    {
                        IUsersToPermissionId = UserData[0].IUsersToPermissionId,
                        PermissionId = UserData[0].PermissionId,
                        ApprovedBalanceQuentity = UserData[0].ApprovedBalanceQuentity - perreqdata.RequestNetDays,
                        PermissionBalanceQuentity = Convert.ToDouble(TotalLimit[0].PermissionTotalLimit) - (UserData[0].ApprovedBalanceQuentity - perreqdata.RequestNetDays),
                        CreatedByUserId = UserData[0].CreatedByUserId,
                        CreatedDate = UserData[0].CreatedDate,
                        UpdateByUserId = adminid,
                        UpdateDate = DateTime.Now.Date,
                    };
                    _context.IUsersToPermissions.Update(addeddata3);
                }
                _context.SaveChanges();
                //---------
            }

            return Ok();
        }

        /*
        [HttpPut("confirmtousers")]
        public async Task<ActionResult<User>> AdminConfirmToUsers(int userid, int requestid)
        {

            var user = await _context.Users.FirstOrDefaultAsync(i => i.UserId == userid);
            var request = await _context.PermissionsRequests.FirstOrDefaultAsync(i => i.PermissionsRequestId == requestid);

            user.UserUsedBalanceDays = (user.UserUsedBalanceDays + request.RequestNetDays);
            user.UserBalanceDays = (Convert.ToDouble(user.UserTotalBalanceDays) - user.UserUsedBalanceDays);

            _context.Users.Update(user);
            _context.SaveChanges();

            return Ok();
        }
        */

        [HttpGet("getmalepermissions")]
        public IEnumerable<Permission> GetMalePermissions()
        {
            var Malepermission = _context.Permissions.Where(i => i.PermissionGender == "Male" || i.PermissionGender == "Both").ToList();
            return (Malepermission);
        }

        [HttpGet("getfemalepermissions")]
        public IEnumerable<Permission> GetFemalePermissions()
        {
            var Femalepermission = _context.Permissions.Where(i => i.PermissionGender == "Female" || i.PermissionGender == "Both").ToList();
            return (Femalepermission);
        }


        public TimeSpan resultreturntime;
        public DateTime resultreturndate;

        [HttpGet("calcnetday")]
        public async Task<ActionResult> CalcNetDay(int userid, DateTime datestart, DateTime datestop, string timestart, string timestop)
        {
            DateTime refdate = DateTime.Now;
            DateTime nowdate = DateTime.Parse(refdate.ToString("d"));
            TimeSpan nowtime = TimeSpan.Parse(refdate.ToString("T"));

            List<DateTime> minusdays = new List<DateTime>();
            List<DateTime> minustaildays = new List<DateTime>();

            //---------Tarih Farkı----------
            DateTime dtstart = DateTime.Parse(datestart.ToString("dd/M/yyyy"));
            DateTime dtstop = DateTime.Parse(datestop.ToString("dd/M/yyyy"));
            TimeSpan diffdate = dtstop - dtstart;
            int brutday = (int)diffdate.TotalDays;
            int netday = (int)diffdate.TotalDays;
            //---------Tarih Farkı----------

            //---------Hafta Sonları----------
            for (int i = 0; i <= netday; i++)
            {
                DateTime dateweeks = dtstart.AddDays(i);
                if (dateweeks.DayOfWeek == DayOfWeek.Saturday || dateweeks.DayOfWeek == DayOfWeek.Sunday)
                {
                    netday--;
                }
            }
            //---------Hafta Sonları----------

            //---------Tatiller----------
            var holidays = _context.Holidays.ToList();
            int holidayslength = holidays.Count - 1;

            for (int i = 0; i <= holidayslength - 1; i++)
            {
                TimeSpan holidaydiff = (holidays[i].HolidayStopDate - holidays[i].HolidayStartDate);
                int holidaylength = (((int)holidaydiff.TotalDays) + 1);

                for (int j = 0; j <= holidaylength - 1; j++)
                {
                    DateTime stepdate = holidays[i].HolidayStartDate.AddDays(j);

                    if (datestart <= stepdate && stepdate <= datestop)
                    {
                        if ((stepdate).DayOfWeek != DayOfWeek.Saturday || (stepdate).DayOfWeek != DayOfWeek.Sunday)
                        {
                            int tailexists = minustaildays.IndexOf(stepdate);
                            int checktail = holidays[i].HolidayTailDays;
                            if (j == 0 && checktail != 0 && tailexists == -1)
                            {
                                minustaildays.Add(stepdate);
                            }


                            int exists = minusdays.IndexOf(stepdate);
                            int tailexists2 = minustaildays.IndexOf(stepdate);
                            if (exists == -1 && tailexists2 == -1)
                            {
                                minusdays.Add(stepdate);
                            }
                        }
                    }

                }
            }

            double resultnetday = (netday - (((minustaildays.Count) * 0.5) + (minusdays.Count)));
            //---------Tatiller----------

            //---------ReturnDate+Time----------
            var user = await _context.Users.FirstOrDefaultAsync(i => i.UserId == userid);
            var company = await _context.Companies.FirstOrDefaultAsync(x => x.CompanyId == user.UserCompanyId);

            // company.CompanyStartWorkingTime = 0;

            DateTime StopDate = DateTime.Parse(datestop.ToString("dd/M/yyyy"));
            long stopticks = (long)Convert.ToDouble(timestop);
            TimeSpan StopTimeSpan = new TimeSpan(stopticks);


            //Hafta Sonu ise
            if (StopDate.DayOfWeek == DayOfWeek.Saturday || StopDate.DayOfWeek == DayOfWeek.Sunday)
            {

                //Cumartesi İse
                if (StopDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    resultreturndate = StopDate.AddDays(2);
                    resultreturntime = company.CompanyStartWorkingTime;

                }

                //Pazar İse
                if (StopDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    resultreturndate = StopDate.AddDays(1);
                    resultreturntime = company.CompanyStartWorkingTime;
                }

            }

            else
            {
                //Cuma ise
                if (StopDate.DayOfWeek == DayOfWeek.Friday)
                {
                    //5dk sonrası yemek saatine denk geliyor veya geçiyorsa.(ör11:55 - 12:00 veya 11:56- 12:01)
                    TimeSpan t1 = new TimeSpan(0, 0, 5, 0);
                    TimeSpan islunchtime = StopTimeSpan.Add(t1);
                    TimeSpan t2 = new TimeSpan(0, 0, 1, 0);
                    TimeSpan toworking = StopTimeSpan.Add(t1);

                    //Yemek Saatinden Önceyse ve Mesaideyse(ör: 08:00-12:00)
                    if (StopTimeSpan < company.CompanyStartLunchTime && (StopTimeSpan >= company.CompanyStartWorkingTime && StopTimeSpan < company.CompanyStopWorkingTime))
                    {
                        if (islunchtime >= company.CompanyStartLunchTime)
                        {
                            resultreturndate = StopDate;
                            resultreturntime = company.CompanyStopLunchTime;
                        }
                        else
                        {
                            resultreturndate = StopDate;
                            resultreturntime = toworking;
                        }
                    }
                    //Yemek Saatindeyse(ör: 12:00-13:00)
                    if ((StopTimeSpan >= company.CompanyStartLunchTime && StopTimeSpan <= company.CompanyStopLunchTime))
                    {
                        resultreturndate = StopDate;
                        resultreturntime = company.CompanyStopLunchTime;
                    }
                    //Yemek Saatinden Sonra ve Mesaideyse(ör: 13:00-18:00)
                    if (StopTimeSpan >= company.CompanyStopLunchTime && (StopTimeSpan >= company.CompanyStartWorkingTime && StopTimeSpan < company.CompanyStopWorkingTime))
                    {
                        resultreturndate = StopDate;
                        resultreturntime = toworking;
                    }
                    //Mesai Dışı(ör: 18:00-08:00)
                    if (StopTimeSpan <= company.CompanyStartWorkingTime && StopTimeSpan >= company.CompanyStopWorkingTime)
                    {
                        resultreturndate = StopDate.AddDays(1);
                        resultreturntime = company.CompanyStartWorkingTime;
                    }
                }
                else //Pazartesi, Salı Çarşamba Perşembe ise
                {

                    //5dk sonrası yemek saatine denk geliyor veya geçiyorsa.(ör11:55 - 12:00 veya 11:56- 12:01)
                    TimeSpan t1 = new TimeSpan(0, 0, 5, 0);
                    TimeSpan islunchtime = StopTimeSpan.Add(t1);
                    TimeSpan t2 = new TimeSpan(0, 0, 1, 0);
                    TimeSpan toworking = StopTimeSpan.Add(t1);


                    //Yemek Saatinden Önceyse ve Mesaideyse(ör: 08:00-12:00)
                    if (StopTimeSpan < company.CompanyStartLunchTime && (StopTimeSpan >= company.CompanyStartWorkingTime && StopTimeSpan < company.CompanyStopWorkingTime))
                    {
                        if (islunchtime >= company.CompanyStartLunchTime)
                        {
                            resultreturndate = StopDate;
                            resultreturntime = company.CompanyStopLunchTime;
                        }
                        else
                        {
                            resultreturndate = StopDate;
                            resultreturntime = toworking;
                        }
                    }
                    //Yemek Saatindeyse(ör: 12:00-13:00)
                    if ((StopTimeSpan >= company.CompanyStartLunchTime && StopTimeSpan <= company.CompanyStopLunchTime))
                    {
                        resultreturndate = StopDate;
                        resultreturntime = company.CompanyStopLunchTime;
                    }
                    //Yemek Saatinden Sonra ve Mesaideyse(ör: 13:00-18:00)
                    if (StopTimeSpan >= company.CompanyStopLunchTime && (StopTimeSpan >= company.CompanyStartWorkingTime && StopTimeSpan < company.CompanyStopWorkingTime))
                    {
                        resultreturndate = StopDate;
                        resultreturntime = toworking;
                    }
                    //Mesai Dışı(ör: 18:00-08:00)
                    if (StopTimeSpan <= company.CompanyStartWorkingTime && StopTimeSpan >= company.CompanyStopWorkingTime)
                    {
                        resultreturndate = StopDate.AddDays(1);
                        resultreturntime = company.CompanyStartWorkingTime;
                    }
                }


            }
            //---------ReturnDate+Time----------

            var result = brutday + "," + resultnetday + "," + resultreturndate.ToString("MM/dd/yyyy") + "," + resultreturntime;
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<ActionResult<DataTable>> Search(string searchkey)
        {
            string[] SpliteResult = searchkey.Split(' ');
            int Partslength = SpliteResult.Length - 1;
            string[] NameArray = new string[2];

            for (int i = 0; i <= Partslength; i++)
            {
                if (i == Partslength)
                {
                    NameArray[1] = SpliteResult[i].ToString().ToLower();
                }
                else
                {
                    if (NameArray[0] != null)
                    {
                        NameArray[0] = NameArray[0] + " " + SpliteResult[i].ToString().ToLower();
                    }
                    else
                    {
                        NameArray[0] = SpliteResult[i].ToString().ToLower();
                    }
                }
            }



            //string Name = NameArray[0].ToString();
            //string Surname = NameArray[1].ToString();
            var UserData = _context.Users.Where(x => x.UserName.ToLower() == NameArray[0] && x.UserSurname.ToLower() == NameArray[1]).ToList();
            //-----------------------
            int userid = UserData[0].UserId;

            var RequestsData = _context.PermissionsRequests.Where(x => x.RequestCreatedByUserId == userid).ToList();


            DataTable result = new DataTable
            {
                Users = UserData.ToArray(),
                PermissionsRequests = RequestsData.ToArray(),
            };

            return result;
        }

        [HttpPut("updateuserstatus")]
        public async Task<ActionResult<User>> UpdateUserStatus(int userid)
        {
            DateTime refdate = DateTime.Now;
            DateTime nowdate = DateTime.Parse(refdate.ToString("d"));
            TimeSpan nowtime = TimeSpan.Parse(refdate.ToString("T"));

            var PermissionData = _context.PermissionsRequests.Where(x => x.RequestCreatedByUserId == userid).ToList();
            var LastData = PermissionData[PermissionData.Count - 1];
            var LastHour = LastData.RequestStopTime;
            var LastDate = LastData.RequestStopDate;



            if (nowdate > LastDate && LastData.RequestAdminConfirm == "True") //Tarih Geçmişse..
            {
                var user = await _context.Users.FirstOrDefaultAsync(i => i.UserId == userid);
                user.UserStatus = "Working";
                _context.Users.Update(user);
                _context.SaveChanges();
            }
            else
            {
                if (nowdate == LastDate && nowtime >= LastHour && LastData.RequestAdminConfirm == "True") //Aynı Günde ise ve Saat Eşitse veya Geçmişse..
                {
                    var user = await _context.Users.FirstOrDefaultAsync(i => i.UserId == userid);
                    user.UserStatus = "Working";
                    _context.Users.Update(user);
                    _context.SaveChanges();
                }
                else
                {

                }

            }


            return Ok();

        }


        public int kurbanindis;
        public int ramazanindis;
        public int i = 0;

        [HttpPut("updateholidays")]
        public async Task<ActionResult<Holiday>> UpdateHolidays()
        {
            //-----------------Miladi-Hicri-------------------
            var currentdate = DateTime.Today;
            //DateTime Scnerio = new DateTime(2023, 04, 20); //20.04.2023(ramazan areffesi) //27.06.2023(kurban arefesi)
            CultureInfo HicriLib = CultureInfo.CreateSpecificCulture("ar-SA");
            string Hicricurrentdate = (currentdate).ToString("dd-MM-yyyy", HicriLib);
            string Hicricurrentyears = currentdate.ToString("yyyy", HicriLib);
            //-----------------Miladi-Hicri-------------------


            //-----------------Database-Query-------------------       
            var DynamicHolidays = _context.Holidays.Where(x => x.HolidayCategory == "Dynamic").ToList();
            //-----------------Database-Query-------------------   


            //-----------------DynamicHolidayIndis-------------------           
            foreach (var item in DynamicHolidays)
            {
                if (item.HolidayName == "Kurban Bayramı")
                {
                    kurbanindis = i;
                }
                else if (item.HolidayName == "Ramazan Bayramı")
                {
                    ramazanindis = i;
                }
                i++;
            }
            //-----------------DynamicHolidayIndis-------------------           


            //-----------------ParametersOfConditions-------------------
            string CurrentYear = DateTime.Now.Year.ToString();

            string KurbanDate = "09-" + "12-" + Hicricurrentyears;//09.12 Arefesi 1.Gün 10-12-yyyy
            string RamazanDate = "29-" + "09-" + Hicricurrentyears;//29.09Arefesi 1.Gün 01-10-yyyy

            string KurbanReferYear = DynamicHolidays[kurbanindis].HolidayReferDate.ToString("yyyy");
            string RamazanReferYear = DynamicHolidays[ramazanindis].HolidayReferDate.ToString("yyyy");
            //-----------------ParametersOfConditions-------------------



            if (CurrentYear != KurbanReferYear && Hicricurrentdate == KurbanDate) //referans yılı ile bulunduğu yıl aynı değilse ve Bayram Arefesi ise.
            {
                double KurbanStopDateUpdateValue = (DynamicHolidays[kurbanindis].HolidayNetDays);

                Holiday holiresult = new Holiday
                {
                    HolidayId = DynamicHolidays[kurbanindis].HolidayId,
                    HolidayName = DynamicHolidays[kurbanindis].HolidayName,
                    HolidayReferDate = currentdate,
                    HolidayStartDate = currentdate,
                    HolidayTailDays = DynamicHolidays[kurbanindis].HolidayTailDays,
                    HolidayStopDate = currentdate.AddDays(KurbanStopDateUpdateValue),
                    HolidayNetDays = DynamicHolidays[kurbanindis].HolidayNetDays,
                    HolidayCategory = DynamicHolidays[kurbanindis].HolidayCategory,
                };
                _context.Holidays.Update(holiresult);
                _context.SaveChanges();
            }

            else if (CurrentYear != RamazanReferYear && Hicricurrentdate == RamazanDate) //referans yılı ile bulunduğu yıl aynı değilse ve Bayram Arefesi ise.
            {
                double RamazanStopDateUpdateValue = (DynamicHolidays[ramazanindis].HolidayNetDays);

                Holiday holiresult = new Holiday
                {
                    HolidayId = DynamicHolidays[ramazanindis].HolidayId,
                    HolidayName = DynamicHolidays[ramazanindis].HolidayName,
                    HolidayReferDate = currentdate,
                    HolidayStartDate = currentdate,
                    HolidayTailDays = DynamicHolidays[ramazanindis].HolidayTailDays,
                    HolidayStopDate = currentdate.AddDays(RamazanStopDateUpdateValue),
                    HolidayNetDays = DynamicHolidays[ramazanindis].HolidayNetDays,
                    HolidayCategory = DynamicHolidays[ramazanindis].HolidayCategory,
                };
                _context.Holidays.Update(holiresult);
                _context.SaveChanges();
            }
            else
            {

            }



            return Ok(_context.Holidays.Where(x => x.HolidayCategory == "Dynamic").ToList());

        }


        /*
        [HttpDelete("delete")]
        // public async Task<ActionResult<ProductAdd>> Add(ProductAdd product)
        public async Task<ActionResult<Holiday>> Delete(int id, Holiday product)
        {

            product.HolidayId = id;

            _context.Holidays.Remove(product);
            _context.SaveChanges();

            return Ok();
          }
      */

    }
}

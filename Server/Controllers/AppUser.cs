using Microsoft.AspNetCore.Identity;
using System;

namespace KolayIK.Controllers
{
    public class AppUser : IdentityUser
    {
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserStatus { get; set; }
        public int? UserPermissionBalanceDays { get; set; }
        public int? UserUsedBalanceDay { get; set; }
    }
}
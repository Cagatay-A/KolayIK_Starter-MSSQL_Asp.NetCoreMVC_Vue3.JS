using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace KolayIK.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserType { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime UserRegistryDate { get; set; }//date in db

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime? UserResignationDate { get; set; }//date in db

        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public char UserPassword { get; set; }//nchar(32) 32 in db
        public int UserCompanyId { get; set; }
        public string UserGender { get; set; }
        public string UserProfession { get; set; }
        public string UserProfessionType { get; set; }
        public string? UserWorkingType { get; set; }
        public string UserStatus { get; set; }

        // public string UserPartnerStatus { get; set; } //deprecated
        public int UserTotalBalanceDays { get; set; }
        public double UserUsedBalanceDays { get; set; }//float in db
        public double UserBalanceDays { get; set; }//float in db
        public int UserCreatedByUserId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime UserCreatedDate { get; set; }//date in db

        public int? UserUpdateByUserId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime? UserUpdateDate { get; set; }//date in db
    }
}

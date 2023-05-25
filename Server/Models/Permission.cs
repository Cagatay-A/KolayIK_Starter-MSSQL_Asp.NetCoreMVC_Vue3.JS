using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KolayIK.Models
{
    public class Permission
    {
        public int PermissionId { get; set; }
        public string PermissionGender { get; set; }
        public string PermissionName { get; set; }
        public string PermissionCycleType { get; set; }
        public int PermissionOnceLimit { get; set; }
        public int PermissionTotalLimit { get; set; }
        public int PermissionCreatedByUserId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public System.DateTime PermissionCreatedDate { get; set; }//date in db

        public int? PermissionUpdateByUserId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public System.DateTime? PermissionUpdateDate { get; set; }//date in db
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KolayIK.Models
{
    public class IUsersToPermission
    {
        public int IUsersToPermissionId { get; set; }
        public int PermissionId { get; set; }
        public double ApprovedBalanceQuentity { get; set; }//float in db
        public double PermissionBalanceQuentity { get; set; }//float in db
        public int CreatedByUserId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public System.DateTime CreatedDate { get; set; }//date in db

        public int? UpdateByUserId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public System.DateTime? UpdateDate { get; set; }//date in db
    }
}

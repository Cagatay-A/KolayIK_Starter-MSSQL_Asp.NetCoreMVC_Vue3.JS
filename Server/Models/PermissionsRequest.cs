using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KolayIK.Models
{
    public class PermissionsRequest
    {
        public int PermissionsRequestId { get; set; }

        //public int? RequestPartnerUserId { get; set; } //deprecated
        public string RequestAdminConfirm { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime RequestStartDate { get; set; }//date in db


        [DisplayFormat(DataFormatString = "{HH:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public TimeSpan RequestStartTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime RequestStopDate { get; set; }//date in db

        [DisplayFormat(DataFormatString = "{HH:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public TimeSpan RequestStopTime { get; set; }

        public int PermissionId { get; set; }
        public int RequestBrutDays { get; set; }
        public double RequestNetDays { get; set; }//float in db
        public string? RequestComment { get; set; }//nvarchar(1000) in db

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        // public DateTime RequestPartnerStopDate { get; set; }//date in db - deprecated
        public DateTime RequestReturnStopDate { get; set; }//date in db

        [DisplayFormat(DataFormatString = "{HH:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        //public TimeSpan RequestPartnerStopTime { get; set; } //deprecated
        public TimeSpan RequestReturnStopTime { get; set; }

        //public string? RequestPartnerConfirm { get; set; } //deprecated 

        public int RequestCreatedByUserId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}")]
        public DateTime RequestCreatedDate { get; set; }//date in db

        [DisplayFormat(DataFormatString = "{HH:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public TimeSpan RequestCreatedTime { get; set; }

        public int? RequestUpdateByUserId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime? RequestUpdateDate { get; set; }//date in db
    }

    public class IPermissionsRequest
    {
        public int PermissionsRequestId { get; set; }

        //public int? RequestPartnerUserId { get; set; } //deprecated
        public string RequestAdminConfirm { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime RequestStartDate { get; set; }//date

        public string RequestStartTime { get; set; }        //time(7) in db

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime RequestStopDate { get; set; }//date

        public string RequestStopTime { get; set; }        //time(7) in db
        public int PermissionId { get; set; }
        public int RequestBrutDays { get; set; }
        public double RequestNetDays { get; set; }
        public string? RequestComment { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        //public DateTime RequestPartnerStopDate { get; set; }//date in db //deprecated
        //public string RequestPartnerStopTime { get; set; }  //time(7) in db //deprecated
        public DateTime RequestReturnStopDate { get; set; }     //date in db
        public string RequestReturnStopTime { get; set; }       //time(7) in db

        //public string? RequestPartnerConfirm { get; set; }    //deprecated

        public int RequestCreatedByUserId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}")]
        public DateTime RequestCreatedDate { get; set; }//date in db

        public int? RequestUpdateByUserId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime? RequestUpdateDate { get; set; }//date in db
    }
}

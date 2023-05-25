using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolayIK.Models;
using System.ComponentModel.DataAnnotations;

namespace KolayIK.Models
{
    public class Company
    {

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }


        [DisplayFormat(DataFormatString = "{HH:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public TimeSpan CompanyStartWorkingTime { get; set; }


        [DisplayFormat(DataFormatString = "{HH:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public TimeSpan CompanyStopWorkingTime { get; set; }


        [DisplayFormat(DataFormatString = "{HH:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public TimeSpan CompanyStartLunchTime { get; set; }


        [DisplayFormat(DataFormatString = "{HH:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public TimeSpan CompanyStopLunchTime { get; set; }


        public int CompanyCreatedByUserId { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime CompanyCreatedDate { get; set; }


        public int? CompanyUpdateByUserId { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime? CompanyUpdateDate { get; set; }
    }
}

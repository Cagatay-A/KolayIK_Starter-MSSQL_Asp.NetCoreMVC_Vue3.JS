using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KolayIK.Models
{
    public class Holiday
    {
        public int HolidayId { get; set; }
        public string HolidayName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime HolidayReferDate { get; set; }//date in db

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public System.DateTime HolidayStartDate { get; set; }//date in db

        public int HolidayTailDays { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public System.DateTime HolidayStopDate { get; set; }//date in db

        public double HolidayNetDays { get; set; }//float in db

        public string HolidayCategory { get; set; }
    }
}

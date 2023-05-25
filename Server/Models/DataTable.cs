using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolayIK.Models;

namespace KolayIK.Models
{
    public class DataTable
    {
        public User[] Users { get; set; }
        public PermissionsRequest[] PermissionsRequests { get; set; }
    }
}

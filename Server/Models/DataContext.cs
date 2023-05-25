using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace KolayIK.Models
{
    public class DataContext : DbContext
    {
        internal readonly object HttpContext;

        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionsRequest> PermissionsRequests { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<IUsersToPermission> IUsersToPermissions { get; set; }
        public DbSet<Company> Companies { get; set; }
        public object IUsersToPermission { get; internal set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }


    }
}

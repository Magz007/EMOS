using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EMOS.Models;

namespace EMOS.Models
{
    public class EMOSContext : DbContext
    {
        public EMOSContext (DbContextOptions<EMOSContext> options)
            : base(options)
        {
        }

        public DbSet<EMOS.Models.Employees> Employees { get; set; }

        public DbSet<EMOS.Models.Resident> Resident { get; set; }

        public DbSet<EMOS.Models.RCH> RCH { get; set; }

        public DbSet<EMOS.Models.Breakfastmeal> Breakfastmeal { get; set; }

        public DbSet<EMOS.Models.lunchmeal> lunchmeal { get; set; }

       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BL;

namespace MyApis.Data
{
    public class MyApisContext : DbContext
    {
        public MyApisContext (DbContextOptions<MyApisContext> options)
            : base(options)
        {
        }

        public DbSet<BL.Person> Person { get; set; }
        public DbSet<BL.Employee> Employee { get; set; }
    }
}

#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.EntityFrameworkCore; //DbContext
using WestWindSystem.Entities;
#endregion

namespace WestWindSystem.DAL
{
    //this class cannot be access from outside of the class library project
    //any reference within the class library project to this class will be honoured
    //this is a level of security
    internal class WestWindContext : DbContext
    {
        public WestWindContext()
        {

        }

        public WestWindContext(DbContextOptions<WestWindContext> options) : base(options)
        {

        }

        public DbSet<BuildVersion> BuildVersions { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Territory> Territories { get; set; }
    }
}

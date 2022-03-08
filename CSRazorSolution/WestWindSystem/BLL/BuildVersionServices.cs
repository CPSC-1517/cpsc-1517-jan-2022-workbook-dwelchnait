#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
#endregion

namespace WestWindSystem.BLL
{
    public class BuildVersionServices
    {
        #region setup of the context connection variable and class constructor
        
        //variable to hold an instance of context class
        private readonly WestWindContext _context;

        //constructor to create an instance of the registered context class
        internal BuildVersionServices(WestWindContext regcontext)
        {
            _context = regcontext;
        }
        #endregion

        #region Services: Query

        //create a method (services) that will retrieve the BuildVersion record
        //this will be called from the wep app (PageModel file), thus it needs to be public
        //this becomes part of the class library's (application library) public interface
        public BuildVersion GetBuildVersion()
        {
            //going to your context instance (class), use the property (DbSet) for
            //    BuildVersion data
            //using this property will retrieve your data from the database
            //the query will get the first record from the database collection (records)
            //   and return it
            //if no data was returned from sql for the query, the returned value will be null
            BuildVersion info = _context.BuildVersions.FirstOrDefault();
            return info;
        }
        #endregion
    }
}

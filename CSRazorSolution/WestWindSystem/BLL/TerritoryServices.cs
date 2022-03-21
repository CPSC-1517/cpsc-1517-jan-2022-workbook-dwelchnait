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
    public class TerritoryServices
    {
        #region setup of the context connection variable and class constructor

        //variable to hold an instance of context class
        private readonly WestWindContext _context;

        //constructor to create an instance of the registered context class
        internal TerritoryServices(WestWindContext regcontext)
        {
            _context = regcontext;
        }
        #endregion

        #region Queries
        
        //query by a string
        //this partial search query has been alter to allow for paging of its results
        //IF paging is NOT required the the query should have a single string parameter: partialdescription

        public List<Territory> GetByPartialDescription(string partialdescription,
                                                        int pagenumber,
                                                        int pagesize,
                                                        out int totalcount)
        {
            IEnumerable<Territory> info = _context.Territories
                            .Where(x => x.TerritoryDescription.Contains(partialdescription))
                            .OrderBy(x => x.TerritoryDescription);

            //using the paging parameters to obtain only the necessary rows that
            //  will be shown by the Paginator

            //determine the total collection size of our query
            totalcount = info.Count();
            //determine the number of rows to skip
            //this skipped count reflects the rows of the previous pages
            //remember the pagenumber is a natural number (1,2,3,...)
            //this needs to be treated as an index (natural number - 1)
            //the number of rows to skip is index * pagesize
            int skipRows = (pagenumber - 1) * pagesize;
            //return only the required number of rows.
            //this will be done using filters belonging to Linq
            //use the filter .Skip(n) to skip over n rows from the beginning of a collection
            //use the filter .Take(n) to take the next n rows from a collection
            return info.Skip(skipRows).Take(pagesize).ToList();

            //this is the return statement that would be used IF no paging is being implemented
            //return info.ToList();
        }
        //query by a number
        public List<Territory> GetByRegion(int regionid)
        {
            IEnumerable<Territory> info = _context.Territories
                            .Where(x => x.RegionID == regionid)
                            .OrderBy(x => x.TerritoryDescription);
            return info.ToList();
        }
        #endregion

    }
}

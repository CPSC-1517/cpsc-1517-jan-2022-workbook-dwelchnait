using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespaces
using WestWindSystem.BLL;       //this is where the services were coded
using WestWindSystem.Entities;  //this is where the entity definition is coded
#endregion


namespace WebApp.Pages.Samples
{
    public class RegionQueryOneModel : PageModel
    {
        #region Private service fields & class constructor
        private readonly ILogger<IndexModel> _logger;
        private readonly RegionServices _regionServices;

        public RegionQueryOneModel(ILogger<IndexModel> logger, RegionServices regionservices)
        {
            _logger = logger;
            _regionServices = regionservices;
        }
        #endregion

        [TempData]
        public string FeedbackMessage { get; set; }

        //this is bond to the input control via asp-for
        //this is a two way binding out and in
        //data is move out and in FOR YOU AUTOMATICALLY
        //SupportsGet = true will allow this property to be matched to
        //  a routing parameter of the same name.
        [BindProperty(SupportsGet = true)]
        public int regionid { get; set; }  

        public Region regionInfo { get; set; }

        public void OnGet()
        {
            if (regionid > 0)
            {
                regionInfo = _regionServices.Region_GetById(regionid);
                if (regionInfo == null)
                {
                    FeedbackMessage = "Region id is not valid. No such region on file";
                }
                else
                {
                    FeedbackMessage = $"ID: {regionInfo.RegionID} Description: {regionInfo.RegionDescription}";
                }
            }
        }

        // generic falling post handler
        public void OnPost()
        {
            FeedbackMessage = "WARNING!!! No OnPost page handler found. Execution default to the coded OnPost().";
        }

        // specific post method to use in conjunction with asp-page-handler="xxx"
        public IActionResult OnPostFetch()
        {
            if (regionid < 1)
            {
                FeedbackMessage = "Required: Region id is a non-zero positive whole number.";
            }
            //the receiving "regionid" is the routing parameter
            //the sending "regionid" is a BindProperty field
            return RedirectToPage(new {regionid = regionid });
        }

        // specific post method to use in conjunction with asp-page-handler="xxx"
        public IActionResult OnPostClear()
        {
            FeedbackMessage = "";
            //regionid = 0;
            ModelState.Clear();
            return RedirectToPage(new {regionid = (int?)null});
        }
    }
}

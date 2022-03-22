using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Samples
{
    public class ReceivingPageModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int? territoryid { get; set;}
        public void OnGet()
        {
        }
    }
}

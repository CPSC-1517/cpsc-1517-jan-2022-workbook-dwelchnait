using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string MyName { get; set; }
        public void OnGet()
        {
            Random random = new Random();
            int value = random.Next(0, 100);
            if (value % 2 == 0)
            {
                MyName = $"Don welcome you to the Razor World ({value})";
            }
            else
            {
                MyName = null;
            }
        }
    }
}
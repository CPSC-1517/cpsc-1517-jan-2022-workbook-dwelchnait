using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespaces
using WestWindSystem.BLL;       //this is where the services were coded
using WestWindSystem.Entities;  //this is where the entity definition is coded
using WebApp.Helpers;           //this is where the Paginator is coded
#endregion


namespace WebApp.Pages.Samples
{
    public class ProductCRUDModel : PageModel
    {
        #region Private service fields & class constructor
        private readonly ILogger<IndexModel> _logger;
        private readonly ProductServices _productServices;
        private readonly CategoryServices _categoryServices;
        private readonly SupplierServices _supplierServices;


        public ProductCRUDModel(ILogger<IndexModel> logger,
            ProductServices productservices,
            CategoryServices categoryservices,
            SupplierServices supplierservices)
        {
            _logger = logger;
            _productServices = productservices;
            _categoryServices = categoryservices;
            _supplierServices = supplierservices;

        }
        #endregion

        #region Feedback and Error Messages

        [TempData]
        public string Feedback { get; set; }

        public bool HasFeedback => !string.IsNullOrWhiteSpace(Feedback);

        public string ErrorMessage { get; set; }

        public bool HasError => !string.IsNullOrWhiteSpace(ErrorMessage);

        #endregion


        [BindProperty(SupportsGet = true)]
        public int? productid { get; set; }

        [BindProperty]
        public Product ProductInfo { get; set; }

        [BindProperty]
        public List<Category> CategoryList { get; set; } = new();

        [BindProperty]
        public List<Supplier> SupplierList { get; set; } = new();

        public void OnGet()
        {
            PopulateLists();

        }
        public void PopulateLists()
        {
            CategoryList = _categoryServices.Category_List();
            SupplierList = _supplierServices.Supplier_List();
        }

        public IActionResult OnPostClear()
        {
            Feedback = "";
            //searcharg = null;
            ModelState.Clear();
            return RedirectToPage(new { productid = (int?)null });
        }

        public IActionResult OnPostSearch()
        {
            return RedirectToPage("/Samples/CategoryProducts");
        }

    }
}

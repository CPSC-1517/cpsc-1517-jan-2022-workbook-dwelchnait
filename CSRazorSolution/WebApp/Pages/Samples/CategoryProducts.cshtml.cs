using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespaces
using WestWindSystem.BLL;       //this is where the services were coded
using WestWindSystem.Entities;  //this is where the entity definition is coded
using WebApp.Helpers;           //this is where the Paginator is coded
#endregion


namespace WebApp.Pages.Samples
{
    public class CategoryProductsModel : PageModel
    {
        #region Private service fields & class constructor
        private readonly ILogger<IndexModel> _logger;
        private readonly ProductServices _productServices;
        private readonly CategoryServices _categoryServices;
        private readonly SupplierServices _supplierServices;


        public CategoryProductsModel(ILogger<IndexModel> logger,
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

        [TempData]
        public string Feedback { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? searcharg { get; set; }

        public List<Product> ProductInfo { get; set; }

        [BindProperty]
        public List<Category> CategoryList { get; set; } = new();

        [BindProperty]
        public List<Supplier> SupplierList { get; set; } = new();

        public void OnGet()
        {
            PopulateLists();
            if(searcharg.HasValue && searcharg.Value > 0)
            {
                ProductInfo = _productServices.Product_CategoryProducts(searcharg.Value);
            }
        }

        public void PopulateLists()
        {
            CategoryList = _categoryServices.Category_List();
            SupplierList = _supplierServices.Supplier_List();
        }

        public IActionResult OnPostFetch()
        {
            if (searcharg.Value == 0)
            {
                Feedback = "Required: Search category not selected.";
            }

            return RedirectToPage(new { searcharg = searcharg });
        }

        public IActionResult OnPostClear()
        {
            Feedback = "";
            //searcharg = null;
            ModelState.Clear();
            return RedirectToPage(new { searcharg = (int?)null });
        }

        public IActionResult OnPostNew()
        {
            return RedirectToPage("/Samples/ProductCRUD");
        }

    }
}

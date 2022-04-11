using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Samples
{
    public class ControlsModel : PageModel
    {
        [TempData]
        public string Feedback { get; set; }

        [BindProperty]
        public string EmailText { get; set; }
        [BindProperty]
        public string PasswordText { get; set; }
        [BindProperty]
        public string DateTimeText { get; set; }

        [BindProperty]
        public string RadioMeal { get; set; }
        public string[] RadioMeals = new[] { "breakfast", "lunch", "dinner/supper", "snacks" };

        [BindProperty]
        public bool AcceptanceBox { get; set; } //remember value=true on input control

        [BindProperty]
        public string MessageBody { get; set; }

        [BindProperty]
        public int MyRide { get; set; }
        //pretend the collection is coming from the database
        //each row of the collection has two values: selection value; selection text
        //the class SelectionList will be use as the datatype for the collection
        public List<SelectionList> Rides { get; set; } 

        [BindProperty]
        public string VacationSpot { get; set; }
        public List<string> VacationSpotList { get; set; }

        [BindProperty]
        public int RangeValue { get; set; }
        
        public void OnGet()
        {
            PopulateLists();
        }

        public void PopulateLists()
        {
            //pretending that this data comes from the database
            Rides = new List<SelectionList>();
            Rides.Add(new SelectionList() { ValueId = 3, DisplayText="Bike" });
            Rides.Add(new SelectionList() { ValueId = 5, DisplayText="Board" });
            Rides.Add(new SelectionList() { ValueId = 2, DisplayText="Bus" });
            Rides.Add(new SelectionList() {ValueId = 1, DisplayText="Car" });
            Rides.Add(new SelectionList() { ValueId = 4, DisplayText="Motorcycle" });

            VacationSpotList = new List<string>();
            VacationSpotList.Add("California");
            VacationSpotList.Add("Caribbean");
            VacationSpotList.Add("Cruising");
            VacationSpotList.Add("Europe");
            VacationSpotList.Add("Florida");
            VacationSpotList.Add("Mexico");

        }
        public IActionResult OnPostText()
        {
            //this method is tied to the specific button on the form via
            //  the asp-page-handler attribute.
            //the form of the method name is OnPost then concatenate the
            //  value given to the handler attribute

            Feedback = $"Email {EmailText}; Password {PasswordText}; Date {DateTimeText}";
            PopulateLists();

            return Page();
        }

        public IActionResult OnPostRadioCheckArea()
        {
            Feedback = $"Meal {RadioMeal}; Acceptance {AcceptanceBox}; Message {MessageBody}";
            PopulateLists();

            return Page();
        }

        public IActionResult OnPostListSlider()
        {
            Feedback = $"Ride {MyRide}; Vacation {VacationSpot}; Review Satification {RangeValue}";
            PopulateLists();
            return Page();
        }

    }

    public class SelectionList
    {
        //common class used to hold 2 values for use in a select list scenario such
        //  as a drop down list
        public int ValueId { get; set; }
        public string DisplayText { get; set; }
    }

}

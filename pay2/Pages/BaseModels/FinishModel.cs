using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace pay2.Pages.BaseModels
{
    public class FinishModel : PageModel
    {
        [BindProperty] public int Id { get; set; }
        [BindProperty] public string Action { get; set; }
        public string Payment { get; set; }
    }
}

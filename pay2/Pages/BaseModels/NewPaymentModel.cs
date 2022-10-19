using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace pay2.Pages.BaseModels
{
    public class NewPaymentModel : PageModel
    {
        [BindProperty, Required] 
        public string ShopId { get; set; } = "948953";

        [BindProperty, Required]
        public string SecretKey { get; set; } = "test_HMPNO3hMiJA7H6eTz3uDDEczWaW4mBl-MA-O9pL_iQA";

        [BindProperty, Range(1, 2000), Required]
        public decimal Amount { get; set; } = 2000;

        [BindProperty]public string Payment { get; set; }
    }
}

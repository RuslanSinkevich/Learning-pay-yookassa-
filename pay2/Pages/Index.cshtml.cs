using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using pay2.Pages.BaseModels;
using Yandex.Checkout.V3;

namespace pay2.Pages
{
    public class IndexModel : NewPaymentModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnPost()
        {
            var client = new Client(ShopId, SecretKey);
            var id = PaymentStorage.GetNextId();

            var url = Request.GetUri();
            var redirect = $"{url.Scheme}://{url.Authority}/ConfirmSync?id={id}";

            var data = client.CreatePayment(
                new NewPayment
                {
                    Amount = new Amount
                    {
                        Value = Amount,
                    },
                    Confirmation = new Confirmation
                    {
                        Type = ConfirmationType.Redirect,
                        ReturnUrl = redirect
                    },
                    Description = "Order"
                });

            PaymentStorage.Payments[id] = new QueryData { Client = client, AsyncClient = client.MakeAsync(), Payment = data };

            return Redirect(data.Confirmation.ConfirmationUrl);
        }
    }
}

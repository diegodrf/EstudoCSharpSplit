using System;
using System.Collections.Generic;
using System.Text;
using Split.Entities;
using Split.Entities.Enums;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Split.Services
{
    class PaymentService
    {
        public string Response { get; private set; }
        public OrderId MerchantOrderId { get; set; }
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }

        public PaymentService(OrderId merchantOrderId, Customer customer, Payment payment)
        {
            MerchantOrderId = merchantOrderId;
            Customer = customer;
            Payment = payment;
        }

        public string BuildPayment()
        {
            Dictionary<string, object> json = new Dictionary<string, object>();
            json.Add("MerchantOrderId", MerchantOrderId.MerchantOrderId);
            json.Add("Customer", Customer);
            json.Add("Payment", Payment);

            return JsonConvert.SerializeObject(json);
        }

        public async Task SendPayment(string accessToken, bool withValidations)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://apisandbox.cieloecommerce.cielo.com.br");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            HttpContent content = new StringContent(BuildPayment(), Encoding.UTF8, MediaTypeHeaderValue.Parse("application/json").ToString());

            if (withValidations)
            {
                Validations();
            }

            HttpResponseMessage response = await client.PostAsync("/1/sales/", content);
            
            Response = await response.Content.ReadAsStringAsync();
        }

        private void Validations()
        {
            ValidationCheckAmount();
            ValidationDebitHasReturnUrl();
        }

        private void ValidationCheckAmount()
        {
            if (Payment.SplitPayments.Count > 0)
            {
                int SubordinatesAmount = 0;
                foreach (Participant participant in Payment.SplitPayments)
                {
                    SubordinatesAmount += participant.Amount;
                }
                if (Payment.Amount != SubordinatesAmount)
                {
                    throw new InvalidOperationException("The sum of amount of participants must be equal than Payment Amount");
                }
            }
        }
        private void ValidationDebitHasReturnUrl()
        {
            if (Payment.Type == PaymentTypes.DebitCard)
            {
                
                if (Payment.ReturnUrl is null || string.IsNullOrEmpty(Payment.ReturnUrl.ToString()))
                {
                    throw new InvalidOperationException("Debit operation must have a return Url");
                }
            }
        }
    }
}

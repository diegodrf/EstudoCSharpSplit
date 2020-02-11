using System;
using System.Threading.Tasks;
using Split.Services;
using Split.Entities;
using Split.Entities.Enums;
using Newtonsoft.Json;

namespace Split
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Credentials
            string clientId = Environment.GetEnvironmentVariable("ClientId", EnvironmentVariableTarget.User);
            string clientSecret = Environment.GetEnvironmentVariable("ClientSecret", EnvironmentVariableTarget.User);

            // Generate Oauth2 Token
            AuthenticationService auth = new AuthenticationService(clientId, clientSecret, true);
            await auth.Authenticate();

            // Input Payment Data
            OrderId orderId = new OrderId("1234");
            Address address = new Address("Rua Sem Nome", "100", null, "21888410", "Rio de Janeiro", "Centro", "RJ", "BR");
            Customer customer = new Customer("Diego Accept", "11033333799", DocumentTypes.CPF, "diego@gmail.com", "552198033999", null, null, address);

            CreditCard card = new CreditCard("4481530710186111", "Yamilet Taylor", "12/2020", "693", "Visa", false);
            Payment payment = new Payment(PaymentTypes.DebitCard, 50000, DiscountTypes.Commission, true, 1, "Lojinha", card, new Uri("https://www.google.com"));
            Participant Subordinado1 = new Participant(Environment.GetEnvironmentVariable("Subordinate1", EnvironmentVariableTarget.User), 50000, 10, 10);
            payment.AddParticipant(Subordinado1);


            // Build TransactionPayment JSON
            PaymentService ps = new PaymentService(orderId, customer, payment);
            string json = ps.BuildPayment();
            //Console.WriteLine(json);

            // Send Payment
            await ps.SendPayment(auth.Token.Access_Token, true);
            Console.WriteLine(ps.Response);
        }
    }
}

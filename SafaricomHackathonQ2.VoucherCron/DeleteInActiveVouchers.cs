using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace SafaricomHackathonQ2.VoucherCron
{
    public static class DeleteInActiveVouchers
    {
        [FunctionName("DeleteInActiveVouchers")]
        public static void Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var client = new RestClient("https://localhost:5001");

            var request = new RestRequest("api/Voucher/DeleteInActiveVouchers", Method.GET);

            var response = client.Execute(request);

            log.LogInformation(response.Content);
        }
    }
}

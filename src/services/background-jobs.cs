using RestSharp;

namespace JobsMicroservice.src.services
{
    public class BackgroundJobsService(IRestClient restClient)
    {
        private readonly IRestClient _restClient = restClient;
        public async Task DeactivateDriver(string token)
        {
            var request = new RestRequest("");
            request.AddHeader("Authorization", token);
            var response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                throw new Exception(response.Content);
            }
        }
        public async Task ChangeOrderStatus(string token)
        {
            var request = new RestRequest("https://localhost:5150/orders/check-assigned-orders");
            request.AddHeader("Authorization", token);
            var response = await _restClient.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                throw new Exception(response.Content);
            }
        }
    }
}

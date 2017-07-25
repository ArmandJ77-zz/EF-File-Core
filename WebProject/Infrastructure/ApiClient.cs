using RestSharp;
using System.Threading.Tasks;

namespace Infrastructure
{
    /// <summary>
    /// This is a waterd down version of an api client 
    /// I did not include the other request and DI principle
    /// as the main concern here is to just send a get request
    /// also this is not a reusable component nor was it intended to be, I just needed to make a rest request.
    /// There is a .net core ApiClient I am working on which leverages Restsharp.Core an 
    /// generics in the work which would replace this client in all my future projects
    /// </summary>
    public class ApiClient : IApiClient
    {
        public IRestResponse Get(string baseUrl,string urlParams)
        {
            var _client = new RestClient(baseUrl);
            //NO! bad armand, Y you hard code dis?
            var req = new RestRequest(urlParams, Method.GET);

            IRestResponse response = null;
            req.Method = Method.GET;
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(_client, req);
            }).Wait();
            return response;
        }

        private Task<IRestResponse> GetResponseContentAsync(RestClient client, RestRequest request)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            client.ExecuteAsync(request, response =>
            {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}

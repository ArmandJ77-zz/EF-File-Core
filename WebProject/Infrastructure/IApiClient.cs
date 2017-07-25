using RestSharp;

namespace Infrastructure
{
    public interface IApiClient
    {
        IRestResponse Get(string baseUrl, string urlParams);
    }
}

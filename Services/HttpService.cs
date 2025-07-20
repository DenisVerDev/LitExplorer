namespace LitExplorer.Services
{
    public abstract class HttpService
    {
        protected HttpClient HttpClient { get; private set; }

        protected string ApiUrl { get; private set; }

        public HttpService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            HttpClient = httpClientFactory.CreateClient();
            ApiUrl = configuration.GetConnectionString("LitExplorerAPI")!;
        }
    }
}

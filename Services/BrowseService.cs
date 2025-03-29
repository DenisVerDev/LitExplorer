using LitExplorer.LitExplorerDTO;
using System.Text.Json;
using System.Text;

namespace LitExplorer.Services
{
    public class BrowseService : HttpService
    {
        public BrowseService(IHttpClientFactory httpClientFactory, IConfiguration configuration) :
            base(httpClientFactory, configuration) 
        { }

        public async Task<List<BookDTO>?> BrowseBooksAsync(BrowseFilterDTO filter)
        {
            try
            {
                if (filter == null)
                    throw new Exception("Received filter was null!");

                string browseUrl = ApiUrl+"Browse";
                var jsonContent = new StringContent(JsonSerializer.Serialize(filter), Encoding.UTF8, "application/json");

                var response = await HttpClient.PostAsync(browseUrl, jsonContent);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<BookDTO>>
                        (
                            jsonResponse,
                            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                        ) ?? throw new Exception("Failed to deserialize received content!");
                }
                else throw new Exception("Failed to receive successful response!");
            }
            catch
            {
                return null;
            }
        }
    }
}

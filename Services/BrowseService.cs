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

        public async Task<BrowseBookResponse?> BrowseBooksAsync(BrowseFilterDTO filter, int page, int count, int userId)
        {
            try
            {
                if (filter == null)
                    throw new Exception("Received filter was null!");

                string browseUrl = $"{ApiUrl}Browse?page={page}&count={count}&userId={userId}";
                var jsonContent = new StringContent(JsonSerializer.Serialize(filter), Encoding.UTF8, "application/json");

                var response = await HttpClient.PostAsync(browseUrl, jsonContent);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<BrowseBookResponse>
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

        public async Task<int> GetPagesCountAsync(BrowseFilterDTO filter, int pageSize)
        {
            try
            {
                if (filter == null)
                    throw new Exception("Received filter was null!");

                string pagesUrl = $"{ApiUrl}Browse/pages?pageSize={pageSize}";
                var jsonContent = new StringContent(JsonSerializer.Serialize(filter), Encoding.UTF8, "application/json");

                var response = await HttpClient.PostAsync(pagesUrl, jsonContent);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<int>
                        (
                            jsonResponse,
                            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                        );
                }
                else throw new Exception("Failed to receive successful response!");
            }
            catch
            {
                return 0;
            }
        }
    }

    public class BrowseBookResponse
    {
        public List<BookDTO>? Books { get; set; } = null;
        public List<AuthorDTO>? Authors { get; set; } = null;
    }
}

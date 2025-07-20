
using LitExplorer.LitExplorerDTO;
using System.Text.Json;
using System.Text;

namespace LitExplorer.Services
{
    public class RecommendationService : HttpService
    {
        public RecommendationService(IHttpClientFactory httpClientFactory, IConfiguration configuration) 
            : base(httpClientFactory, configuration)
        {}

        public async Task<BrowseBookResponse?> RecommendBooksAsync(UserDTO? userDTO, RecommendationsOptions rOption, int count)
        {
            try
            {
                string browseUrl = $"{ApiUrl}Recommendations?rOptions={rOption}&count={count}";
                var jsonContent = new StringContent(JsonSerializer.Serialize(userDTO), Encoding.UTF8, "application/json");

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
    }
}

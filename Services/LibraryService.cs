
using LitExplorer.LitExplorerDTO;
using System.Text.Json;
using System.Text;

namespace LitExplorer.Services
{
    public class LibraryService : HttpService
    {
        public LibraryService(IHttpClientFactory httpClientFactory, IConfiguration configuration) 
            : base(httpClientFactory, configuration)
        {}

        public async Task<BrowseBookResponse?> InspectLibraryAsync(int userId, int page, int count)
        {
            try
            {
                string browseUrl = $"{ApiUrl}Library?userId={userId}&page={page}&count={count}";

                var response = await HttpClient.GetAsync(browseUrl);
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

        public async Task<bool> UpdateLibraryStatusAsync(UserDTO userDTO, int bookId, int? libraryStatus)
        {
            try
            {
                if (userDTO == null)
                    throw new Exception("Received user was null!");

                string browseUrl = $"{ApiUrl}Library/updateLibraryStatus?bookId={bookId}&libraryStatus={libraryStatus}";
                var jsonContent = new StringContent(JsonSerializer.Serialize(userDTO), Encoding.UTF8, "application/json");

                var response = await HttpClient.PostAsync(browseUrl, jsonContent);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateReadingHistoryAsync(UserDTO userDTO, int bookSourceId, int? lastReadChapter)
        {
            try
            {
                if (userDTO == null)
                    throw new Exception("Received user was null!");

                string browseUrl = $"{ApiUrl}Library/updateReadingHistory?bookSourceId={bookSourceId}&lastReadChapter={lastReadChapter}";
                var jsonContent = new StringContent(JsonSerializer.Serialize(userDTO), Encoding.UTF8, "application/json");

                var response = await HttpClient.PostAsync(browseUrl, jsonContent);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}

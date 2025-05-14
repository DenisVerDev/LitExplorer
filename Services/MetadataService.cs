
using LitExplorer.LitExplorerDTO;
using System.Text.Json;

namespace LitExplorer.Services
{
    public class MetadataService : HttpService
    {
        public MetadataService(IHttpClientFactory httpClientFactory, IConfiguration configuration) 
            : base(httpClientFactory, configuration)
        {}

        public async Task<List<TagDTO>?> GetTagsAsync()
        {
            try
            {
                string tagsUrl = ApiUrl + "Metadata/tags";

                var response = await HttpClient.GetAsync(tagsUrl);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<TagDTO>>
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

        public async Task<List<TagsCategoryDTO>?> GetTagsCategoriesAsync(bool tags)
        {
            try
            {
                string tagsCategoriesUrl = ApiUrl + $"Metadata/tagsCategories?tags={tags}";

                var response = await HttpClient.GetAsync(tagsCategoriesUrl);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<TagsCategoryDTO>>
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

        public async Task<List<SourceDTO>?> GetSourcesAsync()
        {
            try
            {
                string sourcesUrl = ApiUrl + $"Metadata/sources";

                var response = await HttpClient.GetAsync(sourcesUrl);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<SourceDTO>>
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

        public async Task<List<LibraryStatusDTO>?> GetLibraryStatusesAsync()
        {
            try
            {
                string libraryStatusesUrl = ApiUrl + $"Metadata/libraryStatuses";

                var response = await HttpClient.GetAsync(libraryStatusesUrl);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<LibraryStatusDTO>>
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

using LitExplorer.LitExplorerDTO;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace LitExplorer.Services
{
    public class UserService : HttpService
    {
        public const string userKey = "sessionUser";

        public UserDTO? SessionUser { get; set; } = null;

        private ProtectedLocalStorage pls = null!;

        public UserService(IHttpClientFactory httpClientFactory, IConfiguration configuration, ProtectedLocalStorage protectedLocalStorage) 
            : base(httpClientFactory, configuration)
        {
            pls = protectedLocalStorage;
        }

        public async Task<UserDTO?> SignUpAsync(string email, string password)
        {
            try
            {
                UserDTO user = new UserDTO() { Email = email, Password = password };

                string signUpUrl = $"{ApiUrl}User/signUp";
                var jsonContent = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");

                var response = await HttpClient.PostAsync(signUpUrl, jsonContent);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<UserDTO>
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

        public async Task<UserDTO?> SignInAsync(string email, string password)
        {
            try
            {
                UserDTO user = new UserDTO() { Email = email, Password = password };

                string signInUrl = $"{ApiUrl}User/signIn";
                var jsonContent = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");

                var response = await HttpClient.PostAsync(signInUrl, jsonContent);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<UserDTO>
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

        public async Task LoadSessionUserAsync()
        {
            var result = await pls.GetAsync<UserDTO>(userKey);
            SessionUser = result.Success ? result.Value : null;
        }

        public async Task SaveSessionUserAsync()
        {
            if (SessionUser != null) await pls.SetAsync(userKey, SessionUser);
            else await DeleteSessionUserAsync();
        }

        public async Task DeleteSessionUserAsync()
        {
            SessionUser = null;
            await pls.DeleteAsync(userKey);
        }
    }
}

using LitExplorer.LitExplorerDTO;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace LitExplorer.Services
{
    public class UserService : HttpService
    {
        public UserService(IHttpClientFactory httpClientFactory, IConfiguration configuration) 
            : base(httpClientFactory, configuration)
        {}

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
    }
}

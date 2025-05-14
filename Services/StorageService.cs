using LitExplorer.LitExplorerDTO;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace LitExplorer.Services
{
    public class StorageService
    {
        private ProtectedLocalStorage pls = null!;

        public StorageService(ProtectedLocalStorage protectedLocalStorage)
        {
            pls = protectedLocalStorage;
        }

        public async Task<object?> GetValueAsync<TValue>(string key)
        {
            var result = await pls.GetAsync<TValue>(key);
            return result.Success ? result.Value : null;
        }

        public async Task SaveValueAsync(string key, object value)
            => await pls.SetAsync(key, value);

        public async Task DeleteValueAsync(string key)
            => await pls.DeleteAsync(key);
    }
}

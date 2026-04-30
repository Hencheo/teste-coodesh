using Microsoft.JSInterop;

namespace MicroondasWeb
{
    public class AuthService
    {
        public bool IsAuthenticated { get; private set; }
        public string? Token { get; private set; }

        public event Action? OnChange;

        public async Task Login(string token, IJSRuntime js)
        {
            IsAuthenticated = true;
            Token = token;
            await js.InvokeVoidAsync("localStorage.setItem", "authToken", token);
            NotifyStateChanged();
        }

        public async Task Logout(IJSRuntime js)
        {
            IsAuthenticated = false;
            Token = null;
            await js.InvokeVoidAsync("localStorage.removeItem", "authToken");
            NotifyStateChanged();
        }

        public async Task CarregarSessao(IJSRuntime js)
        {
            var tokenSalvo = await js.InvokeAsync<string>("localStorage.getItem", "authToken");
            if (!string.IsNullOrEmpty(tokenSalvo))
            {
                IsAuthenticated = true;
                Token = tokenSalvo;
                NotifyStateChanged();
            }
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}

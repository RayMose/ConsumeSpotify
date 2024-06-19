
using ConsumeSpotify.Models;
using System.Text;
using System.Text.Json;

namespace ConsumeSpotify.Services
{
    public class SpotifyAccount : ISpotifyAccount
    {
        private readonly HttpClient _httpClient;

        public SpotifyAccount(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetToken(string clientId, string clientSecret)
        {
            //throw new NotImplementedException();

            var request = new HttpRequestMessage(HttpMethod.Post, "token");

            request.Headers.Authorization =  new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}")));

            request.Content = new FormUrlEncodedContent(new Dictionary<string, string> {
                {
                    "grant_type","client_credentials"
                } });

            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var authResult = await JsonSerializer.DeserializeAsync<AuthResult>(responseStream);

            return authResult.access_token;
        }
    }
}

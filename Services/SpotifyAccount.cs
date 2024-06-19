
namespace ConsumeSpotify.Services
{
    public class SpotifyAccount : ISpotifyAccount
    {
        private readonly HttpClient _httpClient;

        public SpotifyAccount(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<string> GetToken(string clientId, string clientSecret)
        {
            throw new NotImplementedException();
        }
    }
}

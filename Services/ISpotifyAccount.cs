namespace ConsumeSpotify.Services
{
    public interface ISpotifyAccount
    {
        Task<string> GetToken(string clientId, string clientSecret);
    }
}

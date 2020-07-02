namespace Proventos.Core.Dtos
{
    public sealed class Token
    {
        public Token(string id, string authToken, int expiresIn)
        {
            Id = id;
            AuthToken = authToken;
            ExpiresIn = expiresIn;
        }

        public string Id { get; }
        public string AuthToken { get; }
        public int ExpiresIn { get; }
    }
}

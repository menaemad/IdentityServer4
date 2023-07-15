using IdentityModel.Client;

namespace Movies.Client.HttpHandlers
{
    public class AuthenticationDelegationHandler : DelegatingHandler
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ClientCredentialsTokenRequest _clientCredentialsToken;

        public AuthenticationDelegationHandler(IHttpClientFactory httpClientFactory, ClientCredentialsTokenRequest clientCredentialsToken)
        {
            _httpClientFactory = httpClientFactory;
            _clientCredentialsToken = clientCredentialsToken;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var httpClient = _httpClientFactory.CreateClient("IDPClient");
            var tokentResponse = await httpClient.RequestClientCredentialsTokenAsync(_clientCredentialsToken);

            if (tokentResponse == null || tokentResponse.IsError)
                throw new HttpRequestException("Something went wrong to access token");
            request.SetBearerToken(tokentResponse.AccessToken);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}

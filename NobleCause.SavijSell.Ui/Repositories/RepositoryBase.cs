using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Http;

namespace NobleCause.SavijSell.Ui.Repositories
{
    public class RepositoryBase
    {
        protected readonly IFlurlClient _flurlClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RepositoryBase(IFlurlClientFactory flurlClientFactory,
                              IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            _flurlClient = flurlClientFactory.Get("https://localhost:44328");

            _flurlClient.BeforeCall(flurlCall => 
            {
                
                var token = _httpContextAccessor.HttpContext.Request
                                .Cookies[Constants.XAccessToken];
                if (!string.IsNullOrWhiteSpace(token))
                {
                    flurlCall.HttpRequestMessage.SetHeader("Authorization", $"bearer {token}");
                }
                else
                {
                    flurlCall.HttpRequestMessage.SetHeader("Authorization", string.Empty);
                }
            });
        }   
    }
}

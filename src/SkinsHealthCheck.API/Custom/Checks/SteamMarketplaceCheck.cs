using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace SkinsApiHealthChecks.Api.Custom.Checks
{
    public class SteamMarketplaceCheck : IHealthCheck
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<SteamMarketplaceCheck> _logger;

        public SteamMarketplaceCheck(
            IConfiguration configuration,
            ILogger<SteamMarketplaceCheck> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var httpClient = new HttpClient();

                var httpMessage = new HttpRequestMessage();
                httpMessage.Method = HttpMethod.Get;
                httpMessage.RequestUri = new Uri(_configuration["Urls:SteamMarketVerify"]);

                var response = await httpClient.SendAsync(httpMessage);

                if (response.IsSuccessStatusCode)
                    return HealthCheckResult.Healthy("Steam markeplace is online!");

                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return HealthCheckResult.Unhealthy("Steam markeplace is offline");
        }
    }
}

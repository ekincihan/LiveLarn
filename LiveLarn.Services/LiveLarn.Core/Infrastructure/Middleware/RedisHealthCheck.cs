using Microsoft.Extensions.Diagnostics.HealthChecks;
using StackExchange.Redis;
using System.Threading;
using System.Threading.Tasks;

namespace LiveLarn.Core.Infrastructure.Middleware
{
    public class RedisHealthCheck<THost> : IHealthCheck where THost : struct
    {
        private readonly string _host;
        public RedisHealthCheck(THost host)
        {
            _host = host.ToString();
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            using (ConnectionMultiplexer redis = await ConnectionMultiplexer.ConnectAsync(_host))
            {
                if (redis.IsConnected)
                    return HealthCheckResult.Healthy($"'{redis.ClientName}' connected.");
                else
                    return HealthCheckResult.Unhealthy($"'{redis.ClientName}' unable to connect!");
            }
        }
    }
}

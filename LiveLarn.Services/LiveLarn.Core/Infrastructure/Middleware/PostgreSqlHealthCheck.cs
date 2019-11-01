using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LiveLarn.Core.Infrastructure.Middleware
{
    public class PostgreSqlHealthCheck<TContext> : IHealthCheck where TContext : DbContext, new()
    {

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            using (TContext dbContext = new TContext())
            {
                bool canConnect = await dbContext.Database.CanConnectAsync();

                if (canConnect)
                    return HealthCheckResult.Healthy($"'{dbContext.Database.GetType().Name}' is connected");
                else
                    return HealthCheckResult.Unhealthy($"'{dbContext.Database.GetType().Name}' unable to connect!");
            }
        }    
    }
}

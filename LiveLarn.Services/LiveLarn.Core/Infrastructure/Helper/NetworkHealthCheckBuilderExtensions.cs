using LiveLarn.Core.Infrastructure.Middleware;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;

namespace LiveLarn.Core.Infrastructure.Helper
{
    public static class NetworkHealthCheckBuilderExtensions
    {
        const string PING_NAME = "ping";
        const string SFTP_NAME = "sftp";
        const string FTP_NAME = "ftp";
        const string DNS_NAME = "dns";
        const string IMAP_NAME = "imap";
        const string SMTP_NAME = "smtp";
        const string TCP_NAME = "tcp";

        public static IHealthChecksBuilder AddPingHealthCheck(this IHealthChecksBuilder builder, Action<PingHealthCheckOptions> setup, string name = default, HealthStatus? failureStatus = default, IEnumerable<string> tags = default, TimeSpan? timeout = default)
        {
            var options = new PingHealthCheckOptions();
            setup?.Invoke(options);

            return builder.Add(new HealthCheckRegistration(
               name ?? PING_NAME,
               sp => new PingHealthCheck(options),
               failureStatus,
               tags));
        }
    }
}
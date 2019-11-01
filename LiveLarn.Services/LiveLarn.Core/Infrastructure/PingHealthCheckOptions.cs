using System;
using System.Collections.Generic;
using System.Text;

namespace LiveLarn.Core.Infrastructure
{
    public class PingHealthCheckOptions
    {
        internal Dictionary<string, (string Host, int TimeOut)> ConfiguredHosts { get; } = new Dictionary<string, (string, int)>();

        public PingHealthCheckOptions AddHost(string host, int timeout)
        {
            ConfiguredHosts.Add(host, (host, timeout));
            return this;
        }
    }
}

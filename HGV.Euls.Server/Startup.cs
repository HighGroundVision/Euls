using HGV.Basilius.Client;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Caching;
using Polly.Caching.Memory;
using Polly.Registry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;

[assembly: FunctionsStartup(typeof(HGV.Euls.Server.Startup))]

namespace HGV.Euls.Server
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();
            builder.Services.AddMemoryCache();
            builder.Services.AddSingleton<IAsyncCacheProvider, MemoryCacheProvider>();

            builder.Services.AddSingleton<IReadOnlyPolicyRegistry<string>, PolicyRegistry>((serviceProvider) =>
            {
                var registry = new PolicyRegistry();
                registry.Add("Hyperstone",
                    Policy.CacheAsync<byte[]>(
                        serviceProvider.GetRequiredService<IAsyncCacheProvider>().AsyncFor<byte[]>(), TimeSpan.FromMinutes(60)
                    )
                );
                return registry;
            });

            builder.Services.AddSingleton<IMetaClient, MetaClient>();
        }
    }
}

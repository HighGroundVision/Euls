using HGV.Basilius.Client;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Polly.Caching;
using Polly.Caching.Memory;

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
            builder.Services.AddSingleton<IMetaClient, MetaClient>();
        }
    }
}

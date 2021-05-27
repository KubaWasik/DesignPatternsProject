using System;
using System.Net.Http;
using System.Threading.Tasks;

using Blazored.LocalStorage;

using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;

using Fluxor;
using Fluxor.Persist.Middleware;
using Fluxor.Persist.Storage;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Projekt.Client.Stores;

namespace Projekt.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddBlazoredLocalStorage(config => config.JsonSerializerOptions.WriteIndented = false);
            builder.Services.AddScoped<IStringStateStorage, LocalStateStorage>();
            builder.Services.AddScoped<IStoreHandler, JsonStoreHandler>();

            builder.Services.AddLogging(b => b.SetMinimumLevel(LogLevel.Debug));

            builder.Services
              .AddBlazorise(options =>
              {
                  options.ChangeTextOnKeyPress = true;
              })
              .AddBootstrapProviders()
              .AddFontAwesomeIcons();

            builder.Services.AddFluxor(options => options
                .ScanAssemblies(typeof(Program).Assembly)
                .UsePersist(o => o.UseInclusionApproach())
                .UseReduxDevTools()
            );

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
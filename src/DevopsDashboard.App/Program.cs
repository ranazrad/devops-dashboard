using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<DevopsDashboard.App.App>("#app");

await builder.Build().RunAsync();

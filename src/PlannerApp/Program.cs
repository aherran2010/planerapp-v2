using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using PlaneerApp.Client.Services;
//using PlaneerApp.Client.Services.Interfaces;
using PlannerApp;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//builder.Services.AddHttpClient("PlannerApp.Api", client =>
//{
//    client.BaseAddress = new Uri("https://plannerapp-api.azurewebsites.net");
//}).AddHttpMessageHandler<AuthorizationMessageHandler>();

builder.Services.AddHttpClient("PlannerApp.Api", client =>
{
    client.BaseAddress = new Uri("https://plannerapp-api.azurewebsites.net");
}).AddHttpMessageHandler<AuthorizationMessageHandler>();

builder.Services.AddTransient<AuthorizationMessageHandler>();

builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("PlannerApp.Api"));

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>();

builder.Services.AddHttpClientServices();

builder.Services.AddMudServices();
await builder.Build().RunAsync();

using MentalHealthApp.PWA;
using MentalHealthApp.PWA.Data.Context;
using MentalHealthApp.PWA.Data.Context.Interfaces;
using MentalHealthApp.PWA.Data.Context.Repositories;
using MentalHealthApp.PWA.Services;
using MentalHealthApp.PWA.Services.Interfaces;
using MentalHealthApp.PWA.Services.Singleton;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
/*
 * ~ hardcoded data repository
 * 
builder.Services.AddTransient<IVideoContentService, VideoContentService>();
*/
builder.Services.AddTransient<IVideoContentRepository, VideoContentRepository>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureDB"), b => b.MigrationsAssembly("MentalHealthApp.PWA"));
});

builder.Services.AddHttpClient<IApiService, ApiService>(client =>
{
    client.BaseAddress = new Uri("https://my4blocks.com/wp-json/external-login/v1/");
});
builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<ICookieAccess, CookieAccess>();

builder.Services.AddSingleton<TokenManager>();

// ~ test-suite
builder.Services.AddTransient<ITestSuiteDBFiller, TestSuiteDBFiller>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

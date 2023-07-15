using IdentityServer;
using IdentityServer4.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddIdentityServer()
    .AddInMemoryClients(Config.Clients)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryIdentityResources(Config.IdentityResources)
    //.AddInMemoryApiResources(Config.ApiResources)
    
    .AddTestUsers(Config.TestUsers)
    .AddDeveloperSigningCredential();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
//app.Use(async (context, next) =>
//{
//    context.Response.Headers.Add("Content-Security-Policy",
//        "default-src 'self'; connect-src 'self' wss://localhost:44392");

//    await next();
//});

app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
    {
        endpoints.MapDefaultControllerRoute();
    }
);
//

//app.MapRazorPages();

app.Run();

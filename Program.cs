using WebApplicationMVC;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services); // calling ConfigureServices method
builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddBlobServiceClient(builder.Configuration["pcdev01:blob"], preferMsi: true);
    clientBuilder.AddQueueServiceClient(builder.Configuration["pcdev01:queue"], preferMsi: true);
});
var app = builder.Build();
startup.Configure(app, builder.Environment); // calling Configure method

// Add services to the container.
//builder.Services.AddControllersWithViews();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

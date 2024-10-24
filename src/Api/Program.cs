using UserService.Application;
using UserService.Infrastructure;
using UserService.Api.Services.ConsulConfiguration;

var builder = WebApplication.CreateBuilder(args);

var options = new WebApplicationOptions();
var builder1 = WebApplication.CreateEmptyBuilder(options);
// builder.Configuration
//     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//     .AddEnvironmentVariables()
//     .AddCommandLine(args);
//
builder.Configuration.AddConsul();
// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices();


// Configure the HTTP request pipeline.
WebApplication app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUi(settings =>
    {
        settings.Path = "/api";
        settings.DocumentPath = "/api/specification.json";
    });
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapControllerRoute(
    "default",
    "{controller}/{action=Index}/{id?}");

app.UseExceptionHandler(options => { });

app.Map("/", () => Results.Redirect("/api"));

app.MapEndpoints();

app.Run();

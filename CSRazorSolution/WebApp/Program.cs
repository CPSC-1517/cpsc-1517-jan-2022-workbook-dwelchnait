#region Additional Namespaces
using Microsoft.EntityFrameworkCore;
using WestWindSystem;
#endregion

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//setup the connection string service for the application
//1) retreive the connection string information from your appsetting.json
var connectionString = builder.Configuration.GetConnectionString("WWDB");

//2) register any "services" you wish to use
//   in our solution our services will be created (coded) in the class library WestWindSystem
//   one of these services will be the setup of the database context connection
//   another services will be created as the application requires.

//this setup can be done here, locally
//this setup can also be done elsewhere and called from this location ****
builder.Services.WWBackendDependencies(options => options.UseSqlServer(connectionString));

//2 alternate if registering of services not self contained in class library
//will need to include appropriate namespace to access WestWindContext
//Context class must also be public
//reduces levels of security on your code.
//builder.Services.AddDbContext<WestWindContext>(context =>
//context.UseSqlServer(connectionString));

//builder.Services.AddTransient<WestWindServices>();


builder.Services.AddRazorPages();

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();

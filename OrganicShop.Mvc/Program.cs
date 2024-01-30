//using StructureMap.TypeRules;
using OrganicShop.Domain;
using OrganicShop.DAL;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using OrganicShop.Ioc;
using OrganicShop.BLL.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



#region config DbContex

builder.Services.AddDbContext<OrganicShopDbContext>(options =>
{
    options.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("OrganicShopConnectionString"),
    sqlServerOptions => sqlServerOptions.CommandTimeout(6000));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

#endregion



var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");



#region add Ioc

void RegisterServices(IServiceCollection services)
{
    builder.Host.UseServiceProviderFactory(new DryIocServiceProviderFactory(InversionOfControl.GetContainer()))
         .ConfigureContainer<Container>(builder =>{});
}


RegisterServices(builder.Services);

#endregion




app.Run();

using Asp.net_MVC_CRUD_with_D.D.D.Areas.Admin.Controllers;
using Asp.net_MVC_CRUD_with_D.D.D.Data;
using Autofac;
using Serilog;
using Autofac.Extensions.DependencyInjection;
using CRUD.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUD.Applicatiion;
using CRUD.Persistance;

using Serilog.Events;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Autofac configuration
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
var migrationassembly = Assembly.GetExecutingAssembly().FullName;
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Host.ConfigureContainer<ContainerBuilder>(ContainerBuilder =>
{  ContainerBuilder.RegisterModule(new WebModule());
    ContainerBuilder.RegisterModule(new ApplicationModule());
    ContainerBuilder.RegisterModule(new PersistanceModule(connectionString, migrationassembly));
}
);

//serilog configuration
builder.Host.UseSerilog((ctx, lc) => lc
.MinimumLevel.Debug()
.MinimumLevel.Override("Micosoft", LogEventLevel.Warning)
.Enrich.FromLogContext()
.ReadFrom.Configuration(builder.Configuration));




    // Add services to the container.

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString, (x) => x.MigrationsAssembly(migrationassembly)));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ApplicationDbContext>();
    builder.Services.AddControllersWithViews();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }
    else
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
        name: "areas",
        pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");


    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    app.MapRazorPages();

    app.Run();


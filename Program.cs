using HaritaWeb.Repositories;
using HaritaWeb.Repositories.Contracts;
using HaritaWeb.Services;
using HaritaWeb.Services.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlite(
        builder.Configuration.GetConnectionString("sqlconnection"),
        b => b.MigrationsAssembly("HaritaWeb.UI")
    );
});

builder.Services.Scan(scan => scan
.FromAssemblyOf<IRepositoryManager>()
.AddClasses(classes => classes.InNamespaces("HaritaWeb.Repositories"))
.AsImplementedInterfaces()
.WithScopedLifetime());

builder.Services.Scan(scan => scan
.FromAssemblyOf<IServiceManager>()
.AddClasses(classes => classes.InNamespaces("HaritaWeb.Services"))
.AsImplementedInterfaces()
.WithScopedLifetime());


builder.Services.AddAutoMapper(typeof(Program));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapAreaControllerRoute(
    name: "admin_area",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=604800"); // 7 gün cache
    }
});





app.Run();

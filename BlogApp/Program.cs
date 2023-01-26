using BlogApp.Configuration.LayerConfiguration;
using BlogApp.DataAccess.DbContexts;
using BlogApp.DataAccess.Interfaces;
using BlogApp.DataAccess.Repositories;
using BlogApp.Middlewares;
using BlogApp.Service.Interfaces;
using BlogApp.Service.Interfaces.Accounts;
using BlogApp.Service.Interfaces.Blogs;
using BlogApp.Service.Interfaces.Common;
using BlogApp.Service.Services;
using BlogApp.Service.Services.Accounts;
using BlogApp.Service.Services.Blogs;
using BlogApp.Service.Services.Common;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(option=>
{
	option.UseNpgsql(builder.Configuration.GetConnectionString("Database"));
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.ConfigureWeb(builder.Configuration);
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<IBlogService, BlogService>();


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
app.UseStatusCodePages(async context =>
{
    if (context.HttpContext.Response.StatusCode == 401)
    {
        context.HttpContext.Response.Redirect("accounts/login");
    }

});
app.UseMiddleware<TokenRedirectMiddleware>();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

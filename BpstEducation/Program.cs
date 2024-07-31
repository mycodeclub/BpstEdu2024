using BpstEducation.Data;
using Microsoft.EntityFrameworkCore;
using BpstEducation.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args); 

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConStr")));
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 3;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<AppDbContext>();


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
    pattern: "{controller=Account}/{action=autologin}/{id?}");

app.MapControllerRoute(
    name: "area",
    pattern: "{area=Admin}/{controller=Home}/{action=Index}/{id?}");

//app.MapAreaControllerRoute(
//    name: "default",
//    areaName: "Area",
//    pattern: "Area/{controller=Home}/{action=Index}"
//);


app.Run();

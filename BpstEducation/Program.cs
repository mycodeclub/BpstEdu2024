using BpstEducation.Data;
using Microsoft.EntityFrameworkCore;
using BpstEducation.Models;
using Microsoft.AspNetCore.Identity;
using BpstEducation.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddScoped<IUserServiceBAL, UserServiceBAL>();
builder.Services.AddScoped<IStudentServiceBAL, StudentServiceBAL>();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LiveConStr")));
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 3;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
// app.MapControllerRoute(name: "default", pattern: "{controller=Account}/{action=AutoLogin}/{id?}");
app.MapControllerRoute(name: "default", pattern: "{controller=Account}/{action=CreateMasterUser}/{id?}");
//app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();



using LogisticsWebsite_WebProgramingProject.Models;
using LogisticsWebsite_WebProgramingProject.Repositories;
using LogisticsWebsite_WebProgramingProject.Repositories.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<LogisticsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

/*builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<LogisticsContext>();
*/
/*builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<LogisticsContext>();*/

//Siu 3-4-24
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddDefaultTokenProviders()
        .AddDefaultUI()
        .AddEntityFrameworkStores<LogisticsContext>();

builder.Services.AddRazorPages();
//
builder.Services.AddControllersWithViews();
// Add services to the container.
builder.Services.AddScoped<IBookinginfomationRepository, EFbookinginfomationRepository>();
builder.Services.AddScoped<IBillofladingRepository, EFBillofladingRepository>();
builder.Services.AddScoped<IScheduleRepository, EFScheduleRepository>();
builder.Services.AddScoped<IPortRepository, EFPortRepository>();
builder.Services.AddScoped<IContainerRepository, EFContainerRepository>();
builder.Services.AddScoped<ITrackingRepository, EFTrackingRepository>();
builder.Services.AddScoped<IBookingWareHouseRepository, EFBokingWareHouseRepository>();

//Admin cua Siu cam cham
/*
builder.Services.AddScoped<UserManager<IdentityUser>>();*/
builder.Services.AddScoped<IBillOfLadingAdminRepository, EFBillOfLadingAdminRepository>();
builder.Services.AddScoped<IBookingWareHouseAdminRepository, EFBookingWareHouseAdminRepository>();
builder.Services.AddScoped<IContainerAdminRepository, EFContainerAdminRepository>();
builder.Services.AddScoped<ICostsIncurredAdminRepository, EFCostsIncurredAdminRepository>();
builder.Services.AddScoped<IInvoiceAdminRepository, EFInvoiceAdminRepository>();
builder.Services.AddScoped<IPortAdminRepository,EFPortAdminRepository>();
builder.Services.AddScoped<IScheduleAdminRepository, EFScheduleAdminRepository>();
builder.Services.AddScoped<IShipAdminRepository, EFShipAdminRepository>();
builder.Services.AddScoped<IWareHouseAdminRepository, EFWareHouseAdminRepository>();
builder.Services.AddScoped<ITrackingAdminRepository, EFTrackingAdminRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    //Siu-1/4/24
    //app.UseHsts();
}

//Siu-1/4/24
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//siu3-4-24
app.MapRazorPages();
//
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//
app.Run();

using AutoMapper;
using DemoMvc.Data;
using DemoMvc.Handler;
using DemoMvc.Repository;
using DemoMvc.Repository.HodRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("MVCDemo")));

builder.Services.AddDefaultIdentity<IdentityUser>().AddDefaultTokenProviders()
    .AddRoles<IdentityRole>() 
    .AddEntityFrameworkStores<DataContext>();

builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddTransient<HodRepository>();

var autoMapper = new MapperConfiguration(x => x.AddProfile(new AutoMappingHandler()));
IMapper mapper = autoMapper.CreateMapper();
builder.Services.AddSingleton(mapper);

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
app.UseAuthentication();;

app.UseAuthorization();

 //For Registration and Login (Both are Razor Pages)
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
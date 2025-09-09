using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrainingManager.BLL.Services;
using TrainingManager.BLL.Services.Interfaces;
using TrainingManager.Configurations;
using TrainingManager.DAL.Models;
using TrainingManager.DAL.Repositories;
using TrainingManager.DAL.Repositories.Interfaces;
using TrainingManager.Data;
using TrainingManager.Middlewares;

var builder = WebApplication.CreateBuilder(args); // sets up the application with default settings.

#region Services

// Add services to the container.
builder.Services.AddControllersWithViews(); // adds support for controllers and views in the application.

//builder.Services.AddTransient<CustomMiddleware>(); // registers the custom middleware to be used in the application pipeline.
//builder.Services.AddTransient<HelloMiddleware>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // configures the application to use Entity Framework Core with SQL Server, using a connection string from the configuration.

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IInstructorService, InstructorService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.Configure<CourseSettings>(builder.Configuration.GetSection(nameof(CourseSettings)));

builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(opt =>
{
    opt.Password.RequireNonAlphanumeric = true;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
})
    .AddEntityFrameworkStores<AppDbContext>() // make managers and stores to work with AppDbContext instead of default IdentityDbContext
    .AddDefaultTokenProviders();

var app = builder.Build(); // finalizes the configuration and prepares the application.

#endregion


#region Middlewares

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.Use(async (context, next) => {
//    await context.Response.WriteAsync("Hello from middleware! ");
//    await next(context); // Calls the next middleware in the pipeline.
//    await context.Response.WriteAsync("Goodbye from middleware! ");
//});

//app.UseMyCustomMiddleware(); // Uses the custom middleware defined in the TrainingManager.Middlewares namespace.
//app.UseCustomConventionalMiddleware(); // Uses the conventional middleware defined in the TrainingManager.Middlewares namespace.
app.UseMiddleware<HelloMiddleware>();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets(); 

app.Run(); // Runs the application and listens for incoming HTTP requests.

#endregion
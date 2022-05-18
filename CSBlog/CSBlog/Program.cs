using Microsoft.AspNetCore.Identity;
using CSBlog.Data;
using CSBlog.Data.Repository;
using CSBlog.Models.User;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// ============================================
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
  options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<BlogUser>(options => options.SignIn.RequireConfirmedAccount = true)
  .AddRoles<IdentityRole>()
  .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireClaim("Role", "Admin, Administrator"));
    options.AddPolicy("Moderator", policy => policy.RequireClaim("Role", "Admin, Moderator"));
    options.AddPolicy("User", policy => policy.RequireClaim("Role", "Admin, Moderator, User"));
});
builder.Services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
// builder.Services.AddScoped<IBlogRepository, BlogRepository>();
// builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddRazorPages()
  .AddRazorRuntimeCompilation();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
  name: "default",
  pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
// получение данных
// app.MapGet("/", (ApplicationContext db) => db.Users.ToList());
app.Run();
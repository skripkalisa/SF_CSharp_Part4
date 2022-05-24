using CSBlog.Core;
using CSBlog.Core.Repository;
using Microsoft.AspNetCore.Identity;
using CSBlog.Data;
using CSBlog.Data.Repository;
using CSBlog.Models.Blog;
using CSBlog.Models.User;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// ============================================
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var sqLiteConnectionString = builder.Configuration.GetConnectionString("SQliteConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
  options.UseSqlite(sqLiteConnectionString));
  // options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<BlogUser>(options => options.SignIn.RequireConfirmedAccount = true)
  .AddRoles<IdentityRole>()
  .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddControllersWithViews();
// builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//     .AddCookie();

#region Authorization

AddAuthorizationPolicies(builder.Services);

#endregion

AddScoped();

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
using (var scope = app.Services.CreateScope())
{
  var userManager = scope.ServiceProvider.GetRequiredService<UserManager<BlogUser>>();
  var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
  // var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

  SeedData.Seed(roleManager, userManager);
}

app.MapControllerRoute(
  "default",
  "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
// получение данных
// app.MapGet("/", (ApplicationContext db) => db.Users.ToList());
app.Run();

void AddAuthorizationPolicies(IServiceCollection services)
{
// builder.Services.AddAuthorization(options =>
// {
//   options.AddPolicy("Admin", policy => policy.RequireClaim("Role", "Admin, Administrator"));
//   options.AddPolicy("Moderator", policy => policy.RequireClaim("Role", "Admin, Moderator"));
//   options.AddPolicy("User", policy => policy.RequireClaim("Role", "Admin, Moderator, User"));
// });
  // services.AddAuthorization(options =>
  // {
  //   options.AddPolicy("Admin", policy => policy.RequireClaim("Admin"));
  //   // options.AddPolicy("Admin", policy => policy.RequireClaim("Role", "Admin, Administrator"));
  //   // options.AddPolicy("Moderator", policy => policy.RequireClaim("Role", "Admin, Moderator"));
  //   // options.AddPolicy("User", policy => policy.RequireClaim("Role", "Admin, Moderator, User"));
  // });
  {
    services.AddAuthorization(options =>
    {
      options.AddPolicy(Constants.Policies.RequireAdmin, policy => policy.RequireRole(Constants.Roles.Administrator));
      options.AddPolicy(Constants.Policies.RequireModerator, policy => policy.RequireRole(Constants.Roles.Moderator));
      // options.AddPolicy("RequireUser", policy => policy.RequireRole(Constants.Roles.User));
    });
  }
}

void AddScoped()
{
  builder.Services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
  builder.Services.AddScoped<IRepository<Tag>, TagRepository>();
  builder.Services.AddScoped<IRepository<Article>, ArticleRepository>();
  builder.Services.AddScoped<IRepository<Comment>, CommentRepository>();
  builder.Services.AddScoped<IUserRepository, UserRepository>();
  builder.Services.AddScoped<IRoleRepository, RoleRepository>();
  builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
}
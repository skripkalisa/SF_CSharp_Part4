using System.Reflection;
using API.Configuration;
using API.Validation;
using CSBlog.Core.Repository;
using CSBlog.Data;
using CSBlog.Data.Repository;
using CSBlog.Models.Blog;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
  // c =>
  // {
  //   c.ResolveConflictingActions(apiDescriptions =>
  //   {
  //     var descriptions = apiDescriptions as ApiDescription[] ?? apiDescriptions.ToArray();
  //     var first = descriptions.First(); // build relative to the 1st method
  //     var parameters = descriptions.SelectMany(d => d.ParameterDescriptions).ToList();
  //
  //     first.ParameterDescriptions.Clear();
  //     // add parameters and make them optional
  //     foreach (var parameter in parameters)
  //       if (first.ParameterDescriptions.All(x => x.Name != parameter.Name))
  //         first.ParameterDescriptions.Add(new ApiParameterDescription
  //         {
  //           ModelMetadata = parameter.ModelMetadata,
  //           Name = parameter.Name,
  //           ParameterDescriptor = parameter.ParameterDescriptor,
  //           Source = parameter.Source,
  //           IsRequired = false,
  //           DefaultValue = null
  //         });
  //     return first;
  //   });
  // }
);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
  options.UseSqlite(connectionString));

// Подключаем автомаппинг
var assembly = Assembly.GetAssembly(typeof(MappingProfile));
builder.Services.AddAutoMapper(assembly);


builder.Services.AddScoped<IRepository<Tag>, TagRepository>();
builder.Services.AddScoped<IRepository<Article>, ArticleRepository>();
builder.Services.AddScoped<IRepository<Comment>, CommentRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddTagRequestValidator>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
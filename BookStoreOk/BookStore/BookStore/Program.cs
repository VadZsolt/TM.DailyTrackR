using BookStore.Application;
using BookStore.Data.Abstractions;
using BookStore.Data.MongoDB;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyModel;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

internal class Program
{
  private static Assembly[] Assemblies;
  private static void Main(string[] args)
  {
    Assemblies = LoadApplicationDependecies();
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddFluentValidation(options =>
    {
      options.RegisterValidatorsFromAssemblies(Assemblies);
    });
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assemblies));
    // Add services to the container.

    var databaseSettings = new DatabaseConfiguration();
    builder.Configuration.Bind(nameof(DatabaseConfiguration), databaseSettings);
    builder.Services.AddSingleton<IDatabaseConfiguration>(databaseSettings);

    //builder.Services.AddSingleton<IDatabaseConfiguration>(builder.Configuration.Get<DatabaseConfiguration>());
    //builder.Services.AddSingleton<IDatabase, Database>();
    builder.Services.Scan(scan => scan.FromAssemblies(Assemblies)
  .AddClasses(type => type.AssignableTo(typeof(IRepository<>))).AsImplementedInterfaces().WithScopedLifetime()
    .AddClasses(type => type.AssignableTo(typeof(IDatabase))).AsImplementedInterfaces().WithSingletonLifetime()); //pt IDatabase

    // JWT Authentication
    var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);
    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
    });

    builder.Services.AddScoped<ITokenService, TokenService>();


    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookStore API", Version = "v1" });
    });




        var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
      app.UseSwagger();
      app.UseSwaggerUI();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore API V1");
        });
        }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
  }
  private static Assembly[] LoadApplicationDependecies()
  {
    var context = DependencyContext.Default;
    return context.RuntimeLibraries.SelectMany(library=>
    library.GetDefaultAssemblyNames(context))
      .Where
      (assembly=>assembly.FullName.Contains("BookStore"))
      .Select(Assembly.Load).ToArray();
  }
}
using BookStore.Data.Abstractions;
using BookStore.Data.MongoDB;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyModel;
using System.Reflection;

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

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

   
      

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
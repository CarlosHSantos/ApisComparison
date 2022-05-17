using ApiComGraphQL.Mutations;
using ApiComGraphQL.Queries;
using ApiComGraphQL.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedClasses.Context;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

var MyAllowSpecificOrigins = "GraphQL Cors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000/",
                                             "https://localhost:3000/")
                                             .AllowAnyHeader()
                                             .AllowAnyOrigin()
                                             .AllowAnyMethod();
                      });
});

builder.Services.AddGraphQLServer().AddMutationType<Mutation>().AddQueryType<Query>().AddProjections().AddFiltering().AddSorting();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddDbContext<DefaultDbContext>(option => option.UseSqlServer(connectionString));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.MapGraphQL();

app.Run();

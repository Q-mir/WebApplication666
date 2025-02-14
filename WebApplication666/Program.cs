using Data;
using Domain;
using Domain.Commands;
using Domain.DTO;
using Domain.Query;
using Microsoft.EntityFrameworkCore;
using Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

string? path = builder.Configuration.GetConnectionString("sql");
ArgumentNullException.ThrowIfNull(path);

builder.Services.AddDbContext<Connection>(row => row.UseSqlServer(path));
builder.Services.AddScoped<IRepository,RepositoryDB>();
builder.Services.AddScoped<ICommand<UserDTO>, RegistrationUserCommand>();
builder.Services.AddScoped<IQueryService<All,List<UserDTO>>, AllUsersService>();
builder.Services.AddScoped<IQueryService<SearchById,UserDTO>, GetUserByIdQuery>();

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.MapRazorPages();

app.Run();




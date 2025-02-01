using BusinessLayer.Interfaces;
using BusinessLayer.Services.PersonService;
using Core.Infrastruture.RepositoryPattern;
using DataLayer;
using DataLayer.Models.Clasess;
using Microsoft.EntityFrameworkCore;

// Navigate to the solution directory and set the resource path
var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
var solutionDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\..\"));
string dbPath = Path.Combine(solutionDirectory, "DataLayer", "Resources", "SQL");
  
var connectionString = "Data Source=" + dbPath + "\\Technical Task Data As SQL Server.db"; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

 

builder.Services.AddDbContext<PersonDetailsDBContext>(options => options.UseSqlite(connectionString));
builder.Services.AddScoped<IRepository<Person_Details>, Repository<Person_Details>>();
builder.Services.AddScoped<IRepository<CSVPersonDetails>, Repository<CSVPersonDetails>>();
builder.Services.AddScoped<IPersonDetailsService, PersonDetailsService>();
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
app.UseStaticFiles();
app.UseDefaultFiles(new DefaultFilesOptions
{
    DefaultFileNames = new List<string> { "html/persondetails.html" }
});
app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program { }
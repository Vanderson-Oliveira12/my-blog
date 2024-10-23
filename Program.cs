using Microsoft.EntityFrameworkCore;
using MyBlog.Context;
using MyBlog.MIddlewares;
using MyBlog.Repositories;
using MyBlog.Repositories.Interfaces;
using MyBlog.Services;
using MyBlog.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().ConfigureApiBehaviorOptions(opt =>
{
    opt.SuppressModelStateInvalidFilter = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string myConnectionDB = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(myConnectionDB, ServerVersion.AutoDetect(myConnectionDB)));


builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddLogging();

var app = builder.Build();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<HandleExceptionGlobalMiddleware>();

app.Run();

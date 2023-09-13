global using SuperHeroAPI.Models;
global using SuperHeroAPI.Data;
using SuperHeroAPI.Services.Kullan�c�Service;
using SuperHeroAPI.Services.SuperHeroService;
using Kullan�c�larAPI.Services.CategoryService;
using Kullan�c�larAPI.Services.BookmarkService;
using Kullan�c�larAPI.Services.userBookmarkService;
using Kullan�c�larAPI.Services.userLikeService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IKullan�c�Service, Kullan�c�Service>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IBookmarkService, BookmarkService>();
builder.Services.AddScoped<IuserBookmarkService, userBookmarkService>();
builder.Services.AddScoped<IuserLikeService, UserLikeService>();
builder.Services.AddDbContext<DataContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("*")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowSpecificOrigin");

app.MapGet("/", async context =>
{
    await context.Response.WriteAsync("Hello, World!");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
